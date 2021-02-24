// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.TCPIPClient
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Net.Sockets;
using System.Threading;

namespace Org.LLRP.LTK.LLRPV1
{
  internal class TCPIPClient : CommunicationInterface
  {
    private const int LLRP_HEADER_SIZE = 10;
    private const int BUFFER_SIZE = 2048;
    private TcpClient tcp_client;
    private NetworkStream ns;
    private TCPIPClient.EMessageProcessingState message_state;
    private uint msg_cursor;
    private byte[] msg_header_storage = new byte[10];
    private byte[] msg_data;
    private int buffer_cursor;
    private int buffer_bytes_available;
    private byte[] buffer;
    private short msg_ver;
    private short msg_type;
    private int msg_len;
    private int msg_id;
    private bool trying_to_close;
    private object syn_msg = new object();
    private ManualResetEvent non_block_tcp_connection_evt;

    public override bool Open(string device_name, int port)
    {
      this.trying_to_close = false;
      this.tcp_client = new TcpClient(device_name, port);
      if (this.tcp_client == null)
        throw new LLRPNetworkException("Unable to connect to specified reader in specified time period.");
      try
      {
        this.ns = this.tcp_client.GetStream();
        this.InitializeMessageProcessing();
        this.StartNewBufferReceive();
      }
      catch (Exception ex)
      {
        this.Close();
        throw ex;
      }
      return true;
    }

    public override bool Open(string device_name, int port, int timeout)
    {
      this.trying_to_close = false;
      this.tcp_client = new TcpClient(AddressFamily.InterNetwork);
      this.non_block_tcp_connection_evt = new ManualResetEvent(false);
      this.tcp_client.BeginConnect(device_name, port, new AsyncCallback(this.NonBlockTCPConnectionCallback), (object) this.tcp_client);
      this.ns = (NetworkStream) null;
      if (this.non_block_tcp_connection_evt.WaitOne(timeout, false))
      {
        this.ns = this.tcp_client.GetStream();
        try
        {
          this.InitializeMessageProcessing();
          this.StartNewBufferReceive();
        }
        catch (Exception ex)
        {
          this.Close();
          throw ex;
        }
        return true;
      }
      this.Close();
      throw new LLRPNetworkException("Unable to connect to specified reader in specified time period.");
    }

    private void NonBlockTCPConnectionCallback(IAsyncResult ar)
    {
      try
      {
        if (!(ar.AsyncState is TcpClient asyncState) || !asyncState.Connected)
          return;
        this.non_block_tcp_connection_evt.Set();
      }
      catch
      {
      }
    }

    private void InitializeMessageProcessing()
    {
      lock (this.syn_msg)
      {
        this.ReInitializeMessageProcessing();
        this.message_state = TCPIPClient.EMessageProcessingState.MESSAGE_HEADER;
      }
    }

    private void ReInitializeMessageProcessing()
    {
      Array.Clear((Array) this.msg_header_storage, 0, 10);
      this.msg_cursor = 0U;
      this.msg_data = (byte[]) null;
      this.msg_ver = (short) 0;
      this.msg_type = (short) 0;
      this.msg_len = 0;
      this.msg_id = 0;
    }

    private void StartNewBufferReceive()
    {
      lock (this.syn_msg)
      {
        this.buffer_cursor = 0;
        this.buffer_bytes_available = 0;
        this.buffer = new byte[2048];
        if (this.ns != null)
        {
          this.ns.Flush();
          this.ns.BeginRead(this.buffer, this.buffer_cursor, 2048 - this.buffer_cursor, new AsyncCallback(this.OnDataRead), (object) this.message_state);
          return;
        }
      }
      throw new LLRPNetworkException("Unale to obtain NetStream for read/write");
    }

    private void importAndQualifyHeader()
    {
      int num = ((int) this.msg_header_storage[0] << 8) + (int) this.msg_header_storage[1];
      this.msg_type = (short) (num & 1023);
      this.msg_ver = (short) (num >> 10 & 7);
      this.msg_len = ((int) this.msg_header_storage[2] << 24) + ((int) this.msg_header_storage[3] << 16) + ((int) this.msg_header_storage[4] << 8) + (int) this.msg_header_storage[5];
      this.msg_id = ((int) this.msg_header_storage[6] << 24) + ((int) this.msg_header_storage[7] << 16) + ((int) this.msg_header_storage[8] << 8) + (int) this.msg_header_storage[9];
    }

    private void OnDataRead(IAsyncResult ar)
    {
      int asyncState = (int) ar.AsyncState;
      try
      {
        this.buffer_bytes_available += this.ns.EndRead(ar);
        if (this.buffer_bytes_available == 0)
          return;
      }
      catch (Exception ex)
      {
      }
      lock (this.syn_msg)
      {
        while (this.buffer_bytes_available > 0)
        {
          switch (this.message_state)
          {
            case TCPIPClient.EMessageProcessingState.MESSAGE_HEADER:
              int num1 = (int) Math.Min((long) (10U - this.msg_cursor), (long) this.buffer_bytes_available);
              Array.Copy((Array) this.buffer, (long) this.buffer_cursor, (Array) this.msg_header_storage, (long) this.msg_cursor, (long) num1);
              this.msg_cursor += (uint) num1;
              this.buffer_cursor += num1;
              this.buffer_bytes_available -= num1;
              if (this.msg_cursor == 10U)
              {
                this.importAndQualifyHeader();
                this.msg_data = new byte[this.msg_len];
                Array.Copy((Array) this.msg_header_storage, (Array) this.msg_data, 10);
                if ((long) this.msg_cursor == (long) this.msg_len)
                {
                  this.TriggerMessageEvent(this.msg_ver, this.msg_type, this.msg_id, this.msg_data);
                  this.ReInitializeMessageProcessing();
                  this.message_state = TCPIPClient.EMessageProcessingState.MESSAGE_HEADER;
                  continue;
                }
                this.message_state = TCPIPClient.EMessageProcessingState.MESSAGE_BODY;
                continue;
              }
              continue;
            case TCPIPClient.EMessageProcessingState.MESSAGE_BODY:
              int num2 = (int) Math.Min((long) this.msg_len - (long) this.msg_cursor, (long) this.buffer_bytes_available);
              Array.Copy((Array) this.buffer, (long) this.buffer_cursor, (Array) this.msg_data, (long) this.msg_cursor, (long) num2);
              this.msg_cursor += (uint) num2;
              this.buffer_cursor += num2;
              this.buffer_bytes_available -= num2;
              if ((long) this.msg_cursor == (long) this.msg_len)
              {
                this.TriggerMessageEvent(this.msg_ver, this.msg_type, this.msg_id, this.msg_data);
                this.ReInitializeMessageProcessing();
                this.message_state = TCPIPClient.EMessageProcessingState.MESSAGE_HEADER;
                continue;
              }
              continue;
            default:
              continue;
          }
        }
      }
      try
      {
        this.StartNewBufferReceive();
      }
      catch
      {
      }
    }

    public override void Close()
    {
      this.trying_to_close = true;
      new ManualResetEvent(false).WaitOne(100, false);
      if (this.ns != null)
        this.ns.Close();
      if (this.tcp_client == null)
        return;
      this.tcp_client.Close();
    }

    public override int Send(byte[] data)
    {
      if (this.ns == null)
        return 0;
      try
      {
        lock (this.ns)
        {
          this.ns.Flush();
          this.ns.Write(data, 0, data.Length);
        }
        return data.Length;
      }
      catch
      {
        return -1;
      }
    }

    public override int Receive(out byte[] buffer)
    {
      try
      {
        this.ns.ReadTimeout = 200;
        byte[] buffer1 = new byte[8096];
        int length = this.ns.Read(buffer1, 0, 8096);
        buffer = new byte[length];
        Array.Copy((Array) buffer1, 0, (Array) buffer, 0, length);
        return length;
      }
      catch
      {
        buffer = (byte[]) null;
        return -1;
      }
    }

    public override void Dispose() => this.Close();

    private enum EMessageProcessingState
    {
      MESSAGE_UNKNOWN,
      MESSAGE_HEADER,
      MESSAGE_BODY,
    }
  }
}
