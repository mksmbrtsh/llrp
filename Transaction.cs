// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.Transaction
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Threading;

namespace Org.LLRP.LTK.LLRPV1
{
  internal class Transaction
  {
    private uint msg_id;
    private CommunicationInterface commIF;
    private ENUM_LLRP_MSG_TYPE msg_response_type;
    private byte[] rsp_data;
    private ManualResetEvent rsp_event;
    private ManualResetEvent err_event;

    public Transaction(
      CommunicationInterface ci,
      uint send_msg_id,
      ENUM_LLRP_MSG_TYPE response_type)
    {
      this.msg_id = send_msg_id;
      this.commIF = ci;
      this.msg_response_type = response_type;
      this.rsp_event = new ManualResetEvent(false);
      this.err_event = new ManualResetEvent(false);
    }

    private void ProcessFrame(short ver, short msg_type, int id, byte[] data)
    {
      if ((ENUM_LLRP_MSG_TYPE) msg_type == this.msg_response_type && (long) id == (long) this.msg_id)
      {
        this.rsp_data = new byte[data.Length];
        Array.Copy((Array) data, (Array) this.rsp_data, data.Length);
        this.rsp_event.Set();
      }
      if (msg_type != (short) 100)
        return;
      this.rsp_data = new byte[data.Length];
      Array.Copy((Array) data, (Array) this.rsp_data, data.Length);
      this.err_event.Set();
    }

    public static void Send(CommunicationInterface ci, byte[] data) => ci.Send(data);

    public static int Receive(CommunicationInterface ci, out byte[] buffer) => ci.Receive(out buffer);

    public void Send(Message msg) => this.commIF.Send(Util.ConvertBitArrayToByteArray(msg.ToBitArray()));

    public Message Transact(Message msg, out MSG_ERROR_MESSAGE msg_err, int time_out)
    {
      msg_err = (MSG_ERROR_MESSAGE) null;
      Message msg1 = (Message) null;
      this.commIF.OnFrameReceived += new delegateMessageReceived(this.ProcessFrame);
      this.Send(msg);
      switch (WaitHandle.WaitAny(new WaitHandle[2]
      {
        (WaitHandle) this.rsp_event,
        (WaitHandle) this.err_event
      }, time_out))
      {
        case 0:
          LLRPBinaryDecoder.Decode(ref this.rsp_data, out msg1);
          break;
        case 1:
          int cursor = 0;
          BitArray bitArray = Util.ConvertByteArrayToBitArray(this.rsp_data);
          int count = bitArray.Count;
          msg_err = MSG_ERROR_MESSAGE.FromBitArray(ref bitArray, ref cursor, count);
          break;
      }
      this.commIF.OnFrameReceived -= new delegateMessageReceived(this.ProcessFrame);
      return msg1;
    }
  }
}
