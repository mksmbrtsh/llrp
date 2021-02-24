// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.LLRPEndPoint
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Org.LLRP.LTK.LLRPV1
{
  public class LLRPEndPoint : IDisposable
  {
    private CommunicationInterface cI;
    private int LLRP1_TCP_PORT = 5084;
    private ManualResetEvent transactEvt;
    private short version;
    private short msg_type;
    private int msg_id;
    private byte[] data;
    private bool b_enqueue;
    private Queue<RAW_Message> raw_message_queue;

    public event delegateClientConnected OnClientConnected;

    public event delegateMessageReceived OnMessageReceived;

    public bool Create(string llrp_reader_name, bool server)
    {
      try
      {
        if (server)
        {
          this.cI = (CommunicationInterface) new TCPIPServer();
          this.cI.Open("", this.LLRP1_TCP_PORT);
        }
        else
        {
          this.cI = (CommunicationInterface) new TCPIPClient();
          this.cI.Open(llrp_reader_name, this.LLRP1_TCP_PORT);
        }
        this.cI.OnFrameReceived += new delegateMessageReceived(this.cI_OnMessageReceived);
        this.cI.OnClientConnected += new delegateClientConnected(this.cI_OnClientConnected);
      }
      catch
      {
        return false;
      }
      return true;
    }

    private void cI_OnClientConnected()
    {
      if (this.OnClientConnected == null)
        return;
      this.OnClientConnected();
    }

    private void triggerMessageReceived(short ver, short msg_type, int msg_id, byte[] msg_data)
    {
      if (this.OnMessageReceived == null)
        return;
      this.OnMessageReceived(ver, msg_type, msg_id, msg_data);
    }

    private void cI_OnMessageReceived(short ver, short msg_type, int msg_id, byte[] msg_data)
    {
      if (msg_type == (short) 100 || (int) msg_type == (int) this.msg_type && msg_id == this.msg_id)
      {
        Array.Copy((Array) msg_data, (Array) this.data, msg_data.Length);
        this.msg_type = msg_type;
        this.msg_id = msg_id;
        this.version = ver;
        this.transactEvt.Set();
      }
      if (this.OnMessageReceived != null)
        new delegateMessageReceived(this.triggerMessageReceived).BeginInvoke(ver, msg_type, msg_id, msg_data, (AsyncCallback) null, (object) null);
      lock (this)
      {
        if (!this.b_enqueue)
          return;
        this.raw_message_queue.Enqueue(new RAW_Message(ver, msg_type, msg_id, msg_data));
        this.b_enqueue = false;
      }
    }

    public void Close() => this.cI.Close();

    public void Dispose() => this.Close();

    public void SendMessage(Message msg)
    {
      byte[] byteArray = Util.ConvertBitArrayToByteArray(msg.ToBitArray());
      lock (this)
        this.b_enqueue = true;
      try
      {
        Transaction.Send(this.cI, byteArray);
      }
      catch
      {
        throw new Exception("Transaction Failed");
      }
    }

    public RAW_Message GetMessage()
    {
      lock (this)
        return this.raw_message_queue.Dequeue();
    }

    public Message TransactMessage(Message msg, int time_out)
    {
      byte[] byteArray = Util.ConvertBitArrayToByteArray(msg.ToBitArray());
      try
      {
        this.transactEvt = new ManualResetEvent(false);
        Transaction.Send(this.cI, byteArray);
        this.msg_id = (int) msg.MSG_ID;
        this.msg_type = msg.MSG_TYPE == (ushort) 1023 ? (short) msg.MSG_TYPE : (short) ((int) msg.MSG_TYPE + 10);
        if (!this.transactEvt.WaitOne(time_out, false))
          return (Message) null;
        int cursor = 0;
        switch ((ENUM_LLRP_MSG_TYPE) this.msg_type)
        {
          case ENUM_LLRP_MSG_TYPE.CLOSE_CONNECTION_RESPONSE:
            BitArray bitArray1 = Util.ConvertByteArrayToBitArray(byteArray);
            int count1 = bitArray1.Count;
            return (Message) MSG_CLOSE_CONNECTION_RESPONSE.FromBitArray(ref bitArray1, ref cursor, count1);
          case ENUM_LLRP_MSG_TYPE.GET_READER_CAPABILITIES_RESPONSE:
            BitArray bitArray2 = Util.ConvertByteArrayToBitArray(byteArray);
            int count2 = bitArray2.Count;
            return (Message) MSG_GET_READER_CAPABILITIES_RESPONSE.FromBitArray(ref bitArray2, ref cursor, count2);
          case ENUM_LLRP_MSG_TYPE.GET_READER_CONFIG_RESPONSE:
            BitArray bitArray3 = Util.ConvertByteArrayToBitArray(byteArray);
            int count3 = bitArray3.Count;
            return (Message) MSG_GET_READER_CONFIG_RESPONSE.FromBitArray(ref bitArray3, ref cursor, count3);
          case ENUM_LLRP_MSG_TYPE.SET_READER_CONFIG_RESPONSE:
            BitArray bitArray4 = Util.ConvertByteArrayToBitArray(byteArray);
            int count4 = bitArray4.Count;
            return (Message) MSG_SET_READER_CONFIG_RESPONSE.FromBitArray(ref bitArray4, ref cursor, count4);
          case ENUM_LLRP_MSG_TYPE.ADD_ROSPEC_RESPONSE:
            BitArray bitArray5 = Util.ConvertByteArrayToBitArray(byteArray);
            int count5 = bitArray5.Count;
            return (Message) MSG_ADD_ROSPEC_RESPONSE.FromBitArray(ref bitArray5, ref cursor, count5);
          case ENUM_LLRP_MSG_TYPE.DELETE_ROSPEC_RESPONSE:
            BitArray bitArray6 = Util.ConvertByteArrayToBitArray(byteArray);
            int count6 = bitArray6.Count;
            return (Message) MSG_DELETE_ROSPEC_RESPONSE.FromBitArray(ref bitArray6, ref cursor, count6);
          case ENUM_LLRP_MSG_TYPE.START_ROSPEC_RESPONSE:
            BitArray bitArray7 = Util.ConvertByteArrayToBitArray(byteArray);
            int count7 = bitArray7.Count;
            return (Message) MSG_START_ROSPEC_RESPONSE.FromBitArray(ref bitArray7, ref cursor, count7);
          case ENUM_LLRP_MSG_TYPE.STOP_ROSPEC_RESPONSE:
            BitArray bitArray8 = Util.ConvertByteArrayToBitArray(byteArray);
            int count8 = bitArray8.Count;
            return (Message) MSG_STOP_ROSPEC_RESPONSE.FromBitArray(ref bitArray8, ref cursor, count8);
          case ENUM_LLRP_MSG_TYPE.ENABLE_ROSPEC_RESPONSE:
            BitArray bitArray9 = Util.ConvertByteArrayToBitArray(byteArray);
            int count9 = bitArray9.Count;
            return (Message) MSG_ENABLE_ROSPEC_RESPONSE.FromBitArray(ref bitArray9, ref cursor, count9);
          case ENUM_LLRP_MSG_TYPE.DISABLE_ROSPEC_RESPONSE:
            BitArray bitArray10 = Util.ConvertByteArrayToBitArray(byteArray);
            int count10 = bitArray10.Count;
            return (Message) MSG_DISABLE_ROSPEC_RESPONSE.FromBitArray(ref bitArray10, ref cursor, count10);
          case ENUM_LLRP_MSG_TYPE.GET_ROSPECS_RESPONSE:
            BitArray bitArray11 = Util.ConvertByteArrayToBitArray(byteArray);
            int count11 = bitArray11.Count;
            return (Message) MSG_GET_ROSPECS_RESPONSE.FromBitArray(ref bitArray11, ref cursor, count11);
          case ENUM_LLRP_MSG_TYPE.ADD_ACCESSSPEC_RESPONSE:
            BitArray bitArray12 = Util.ConvertByteArrayToBitArray(byteArray);
            int count12 = bitArray12.Count;
            return (Message) MSG_ADD_ACCESSSPEC_RESPONSE.FromBitArray(ref bitArray12, ref cursor, count12);
          case ENUM_LLRP_MSG_TYPE.DELETE_ACCESSSPEC_RESPONSE:
            BitArray bitArray13 = Util.ConvertByteArrayToBitArray(byteArray);
            int count13 = bitArray13.Count;
            return (Message) MSG_DELETE_ACCESSSPEC_RESPONSE.FromBitArray(ref bitArray13, ref cursor, count13);
          case ENUM_LLRP_MSG_TYPE.ENABLE_ACCESSSPEC_RESPONSE:
            BitArray bitArray14 = Util.ConvertByteArrayToBitArray(byteArray);
            int count14 = bitArray14.Count;
            return (Message) MSG_ENABLE_ACCESSSPEC_RESPONSE.FromBitArray(ref bitArray14, ref cursor, count14);
          case ENUM_LLRP_MSG_TYPE.DISABLE_ACCESSSPEC_RESPONSE:
            BitArray bitArray15 = Util.ConvertByteArrayToBitArray(byteArray);
            int count15 = bitArray15.Count;
            return (Message) MSG_DISABLE_ACCESSSPEC_RESPONSE.FromBitArray(ref bitArray15, ref cursor, count15);
          case ENUM_LLRP_MSG_TYPE.GET_ACCESSSPECS_RESPONSE:
            BitArray bitArray16 = Util.ConvertByteArrayToBitArray(byteArray);
            int count16 = bitArray16.Count;
            return (Message) MSG_GET_ACCESSSPECS_RESPONSE.FromBitArray(ref bitArray16, ref cursor, count16);
          default:
            return (Message) null;
        }
      }
      catch
      {
        throw new Exception("Transaction Failed");
      }
    }
  }
}
