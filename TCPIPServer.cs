// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.TCPIPServer
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Net;
using System.Net.Sockets;

namespace Org.LLRP.LTK.LLRPV1
{
  internal class TCPIPServer : CommunicationInterface
  {
    private const int BUFFER_SIZE = 1024;
    private TcpListener server;
    private NetworkStream ns;
    private bool new_message = true;
    private short msg_ver;
    private short msg_type;
    private int msg_len;
    private int msg_id;
    private byte[] msg_data;
    private int msg_cursor;
    private bool trying_to_close;
    private object syn_msg = new object();

    public TCPIPServer() => this.state = new AsynReadState(1024);

    private void DoAcceptTCPClientCallBack(IAsyncResult ar)
    {
      try
      {
        this.ns = ((TcpListener) ar.AsyncState).EndAcceptTcpClient(ar).GetStream();
        new delegateClientConnected(((CommunicationInterface) this).TriggerOnClientConnect).BeginInvoke((AsyncCallback) null, (object) null);
        this.ns.EndRead(this.ns.BeginRead(this.state.data, 0, 1024, new AsyncCallback(this.OnDataRead), (object) this.state));
      }
      catch
      {
      }
    }

    public override void Close()
    {
      if (this.ns != null)
        this.ns.Close();
      if (this.server == null)
        return;
      this.server.Stop();
    }

    public override bool Open(string device_name, int port)
    {
      try
      {
        this.server = new TcpListener(new IPAddress(new byte[4]
        {
          (byte) 127,
          (byte) 0,
          (byte) 0,
          (byte) 1
        }), port);
        this.server.Start();
        this.server.BeginAcceptTcpClient(new AsyncCallback(this.DoAcceptTCPClientCallBack), (object) this.server);
      }
      catch
      {
        return false;
      }
      return true;
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

    public override int Send(byte[] data)
    {
      try
      {
        lock (this.ns)
          this.ns.Write(data, 0, data.Length);
        return data.Length;
      }
      catch
      {
        return -1;
      }
    }

    private void OnDataRead(IAsyncResult ar)
    {
      int sourceIndex = 0;
      AsynReadState asyncState = (AsynReadState) ar.AsyncState;
      int length = this.ns.EndRead(ar);
      if (asyncState.data[0] == (byte) 0)
      {
        this.server.BeginAcceptTcpClient(new AsyncCallback(this.DoAcceptTCPClientCallBack), (object) this.server);
      }
      else
      {
        lock (this.syn_msg)
        {
          try
          {
            int num1;
            while (true)
            {
              for (; !this.new_message; this.new_message = true)
              {
                if (length >= this.msg_len - this.msg_cursor)
                {
                  Array.Copy((Array) asyncState.data, 0, (Array) this.msg_data, this.msg_cursor, this.msg_len - this.msg_cursor);
                  this.TriggerMessageEvent(this.msg_ver, this.msg_type, this.msg_id, this.msg_data);
                  sourceIndex += this.msg_len - this.msg_cursor;
                }
                else
                {
                  this.new_message = false;
                  Array.Copy((Array) asyncState.data, 0, (Array) this.msg_data, this.msg_cursor, length);
                  this.msg_cursor += length;
                  goto label_21;
                }
              }
              this.msg_cursor = 0;
              num1 = length - sourceIndex;
              if (num1 > 10)
              {
                int num2 = ((int) asyncState.data[sourceIndex] << 8) + (int) asyncState.data[sourceIndex + 1];
                try
                {
                  this.msg_type = (short) (num2 & 1023);
                  this.msg_ver = (short) (num2 >> 10 & 7);
                  this.msg_len = ((int) asyncState.data[sourceIndex + 2] << 24) + ((int) asyncState.data[sourceIndex + 3] << 16) + ((int) asyncState.data[sourceIndex + 4] << 8) + (int) asyncState.data[sourceIndex + 5];
                  this.msg_id = ((int) asyncState.data[sourceIndex + 6] << 24) + ((int) asyncState.data[sourceIndex + 7] << 16) + ((int) asyncState.data[sourceIndex + 8] << 8) + (int) asyncState.data[sourceIndex + 9];
                }
                catch
                {
                  this.msg_len = 0;
                }
                if (this.msg_len > 0 && this.msg_ver == (short) 1)
                {
                  this.msg_data = new byte[this.msg_len];
                  if (length >= sourceIndex + this.msg_len)
                  {
                    Array.Copy((Array) asyncState.data, sourceIndex, (Array) this.msg_data, 0, this.msg_len);
                    this.TriggerMessageEvent(this.msg_ver, this.msg_type, this.msg_id, this.msg_data);
                    sourceIndex += this.msg_len;
                    this.new_message = true;
                  }
                  else
                    break;
                }
                else
                  goto label_21;
              }
              else
                goto label_12;
            }
            this.new_message = false;
            Array.Copy((Array) asyncState.data, sourceIndex, (Array) this.msg_data, 0, length - sourceIndex);
            this.msg_cursor = length - sourceIndex;
            goto label_21;
label_12:
            this.new_message = true;
            if (this.ns == null)
              return;
            if (!this.ns.CanRead)
              return;
            try
            {
              this.ns.Flush();
              this.state = new AsynReadState(1024);
              Array.Copy((Array) asyncState.data, sourceIndex, (Array) this.state.data, 0, num1);
              if (this.trying_to_close)
                return;
              this.ns.BeginRead(this.state.data, num1, 1024 - num1, new AsyncCallback(this.OnDataRead), (object) this.state);
              return;
            }
            catch
            {
              return;
            }
label_21:
            if (this.ns == null)
              return;
            if (!this.ns.CanRead)
              return;
            try
            {
              this.ns.Flush();
              this.state = new AsynReadState(1024);
              if (this.trying_to_close)
                return;
              this.ns.BeginRead(this.state.data, 0, 1024, new AsyncCallback(this.OnDataRead), (object) this.state);
            }
            catch
            {
            }
          }
          catch
          {
          }
        }
      }
    }
  }
}
