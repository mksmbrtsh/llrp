// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.LLRPClient
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Threading;

namespace Org.LLRP.LTK.LLRPV1
{
  [Serializable]
  public class LLRPClient : IDisposable
  {
    private CommunicationInterface cI;
    private int LLRP_TCP_PORT = 5084;
    private int MSG_TIME_OUT = 10000;
    private Thread notificationThread;
    private BlockingQueue notificationQueue;
    private ManualResetEvent conn_evt;
    private ENUM_ConnectionAttemptStatusType conn_status_type;
    private string reader_name;
    private bool connected;

    public event delegateReaderEventNotification OnReaderEventNotification;

    public event delegateRoAccessReport OnRoAccessReportReceived;

    public event delegateKeepAlive OnKeepAlive;

    public event delegateEncapReaderEventNotification OnEncapedReaderEventNotification;

    public event delegateEncapRoAccessReport OnEncapedRoAccessReportReceived;

    public event delegateEncapKeepAlive OnEncapedKeepAlive;

    protected void TriggerReaderEventNotification(MSG_READER_EVENT_NOTIFICATION msg)
    {
      try
      {
        if (this.OnReaderEventNotification != null)
          this.OnReaderEventNotification(msg);
        if (this.OnEncapedReaderEventNotification == null)
          return;
        ENCAPED_READER_EVENT_NOTIFICATION eventNotification = new ENCAPED_READER_EVENT_NOTIFICATION();
        eventNotification.reader = this.reader_name;
        eventNotification.ntf = msg;
      }
      catch
      {
      }
    }

    protected void TriggerRoAccessReport(MSG_RO_ACCESS_REPORT msg)
    {
      try
      {
        if (this.OnRoAccessReportReceived != null)
          this.OnRoAccessReportReceived(msg);
        if (this.OnEncapedRoAccessReportReceived == null)
          return;
        this.OnEncapedRoAccessReportReceived(new ENCAPED_RO_ACCESS_REPORT()
        {
          reader = this.reader_name,
          report = msg
        });
      }
      catch
      {
      }
    }

    protected void TriggerKeepAlive(MSG_KEEPALIVE msg)
    {
      try
      {
        if (this.OnKeepAlive != null)
          this.OnKeepAlive(msg);
        if (this.OnEncapedKeepAlive == null)
          return;
        this.OnEncapedKeepAlive(new ENCAPED_KEEP_ALIVE()
        {
          reader = this.reader_name,
          keep_alive = msg
        });
      }
      catch
      {
      }
    }

    public string ReaderName => this.reader_name;

    public bool IsConnected => this.connected;

    public void SetMessageTimeOut(int time_out) => this.MSG_TIME_OUT = time_out;

    public int GetMessageTimeOut() => this.MSG_TIME_OUT;

    public LLRPClient()
    {
      this.cI = (CommunicationInterface) new TCPIPClient();
      this.notificationQueue = new BlockingQueue();
      this.notificationThread = new Thread(new ThreadStart(this.ProcessNotificationQueue));
      this.notificationThread.IsBackground = true;
      this.notificationThread.Start();
    }

    public LLRPClient(int port)
    {
      this.LLRP_TCP_PORT = port;
      this.cI = (CommunicationInterface) new TCPIPClient();
    }

    private void ProcessNotificationQueue()
    {
      if (this.notificationQueue == null)
        return;
      while (true)
      {
        Message message = (Message) this.notificationQueue.Dequeue();
        switch ((int) message.MSG_TYPE - 61)
        {
          case 0:
            this.TriggerRoAccessReport((MSG_RO_ACCESS_REPORT) message);
            continue;
          case 1:
            this.TriggerKeepAlive((MSG_KEEPALIVE) message);
            continue;
          case 2:
            this.TriggerReaderEventNotification((MSG_READER_EVENT_NOTIFICATION) message);
            continue;
          default:
            continue;
        }
      }
    }

    public bool Open(
      string llrp_reader_name,
      int timeout,
      out ENUM_ConnectionAttemptStatusType status)
    {
      this.reader_name = llrp_reader_name;
      status = ~ENUM_ConnectionAttemptStatusType.Success;
      this.cI.OnFrameReceived += new delegateMessageReceived(this.ProcessFrame);
      try
      {
        this.cI.Open(llrp_reader_name, this.LLRP_TCP_PORT, timeout);
      }
      catch (Exception ex)
      {
        this.cI.OnFrameReceived -= new delegateMessageReceived(this.ProcessFrame);
        throw ex;
      }
      this.conn_evt = new ManualResetEvent(false);
      if (this.conn_evt.WaitOne(timeout, false))
      {
        status = this.conn_status_type;
        if (status == ENUM_ConnectionAttemptStatusType.Success)
        {
          this.connected = true;
          return this.connected;
        }
      }
      this.reader_name = llrp_reader_name;
      try
      {
        this.cI.Close();
        this.cI.OnFrameReceived -= new delegateMessageReceived(this.ProcessFrame);
      }
      catch
      {
      }
      this.connected = false;
      return this.connected;
    }

    public bool Close()
    {
      try
      {
        MSG_CLOSE_CONNECTION_RESPONSE connectionResponse = this.CLOSE_CONNECTION(new MSG_CLOSE_CONNECTION(), out MSG_ERROR_MESSAGE _, this.MSG_TIME_OUT);
        bool flag = true;
        if (connectionResponse != null)
        {
          if (connectionResponse.LLRPStatus.StatusCode == ENUM_StatusCode.M_Success)
            goto label_3;
        }
        flag = false;
label_3:
        try
        {
          this.cI.Close();
        }
        catch
        {
        }
        this.cI.OnFrameReceived -= new delegateMessageReceived(this.ProcessFrame);
        this.connected = false;
        return flag;
      }
      catch
      {
        return false;
      }
    }

    public void Dispose() => this.Close();

    private void ProcessFrame(short ver, short msg_type, int msg_id, byte[] data)
    {
      int cursor = 0;
      switch (msg_type)
      {
        case 61:
          try
          {
            BitArray bitArray = Util.ConvertByteArrayToBitArray(data);
            int count = bitArray.Count;
            this.notificationQueue.Enqueue((object) MSG_RO_ACCESS_REPORT.FromBitArray(ref bitArray, ref cursor, count));
            break;
          }
          catch
          {
            break;
          }
        case 62:
          try
          {
            BitArray bitArray = Util.ConvertByteArrayToBitArray(data);
            int count = bitArray.Count;
            this.notificationQueue.Enqueue((object) MSG_KEEPALIVE.FromBitArray(ref bitArray, ref cursor, count));
            break;
          }
          catch
          {
            break;
          }
        case 63:
          try
          {
            BitArray bitArray = Util.ConvertByteArrayToBitArray(data);
            int count = bitArray.Count;
            MSG_READER_EVENT_NOTIFICATION eventNotification = MSG_READER_EVENT_NOTIFICATION.FromBitArray(ref bitArray, ref cursor, count);
            if (this.conn_evt != null && eventNotification.ReaderEventNotificationData.ConnectionAttemptEvent != null)
            {
              this.conn_status_type = eventNotification.ReaderEventNotificationData.ConnectionAttemptEvent.Status;
              this.conn_evt.Set();
              break;
            }
            this.notificationQueue.Enqueue((object) eventNotification);
            break;
          }
          catch
          {
            break;
          }
      }
    }

    public MSG_CUSTOM_MESSAGE CUSTOM_MESSAGE(
      MSG_CUSTOM_MESSAGE msg,
      out MSG_ERROR_MESSAGE msg_err,
      int time_out)
    {
      return (MSG_CUSTOM_MESSAGE) new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.CUSTOM_MESSAGE).Transact((Message) msg, out msg_err, time_out);
    }

    public MSG_GET_READER_CAPABILITIES_RESPONSE GET_READER_CAPABILITIES(
      MSG_GET_READER_CAPABILITIES msg,
      out MSG_ERROR_MESSAGE msg_err,
      int time_out)
    {
      return (MSG_GET_READER_CAPABILITIES_RESPONSE) new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.GET_READER_CAPABILITIES_RESPONSE).Transact((Message) msg, out msg_err, time_out);
    }

    public MSG_ADD_ROSPEC_RESPONSE ADD_ROSPEC(
      MSG_ADD_ROSPEC msg,
      out MSG_ERROR_MESSAGE msg_err,
      int time_out)
    {
      return (MSG_ADD_ROSPEC_RESPONSE) new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.ADD_ROSPEC_RESPONSE).Transact((Message) msg, out msg_err, time_out);
    }

    public MSG_DELETE_ROSPEC_RESPONSE DELETE_ROSPEC(
      MSG_DELETE_ROSPEC msg,
      out MSG_ERROR_MESSAGE msg_err,
      int time_out)
    {
      return (MSG_DELETE_ROSPEC_RESPONSE) new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.DELETE_ROSPEC_RESPONSE).Transact((Message) msg, out msg_err, time_out);
    }

    public MSG_START_ROSPEC_RESPONSE START_ROSPEC(
      MSG_START_ROSPEC msg,
      out MSG_ERROR_MESSAGE msg_err,
      int time_out)
    {
      return (MSG_START_ROSPEC_RESPONSE) new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.START_ROSPEC_RESPONSE).Transact((Message) msg, out msg_err, time_out);
    }

    public MSG_STOP_ROSPEC_RESPONSE STOP_ROSPEC(
      MSG_STOP_ROSPEC msg,
      out MSG_ERROR_MESSAGE msg_err,
      int time_out)
    {
      return (MSG_STOP_ROSPEC_RESPONSE) new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.STOP_ROSPEC_RESPONSE).Transact((Message) msg, out msg_err, time_out);
    }

    public MSG_ENABLE_ROSPEC_RESPONSE ENABLE_ROSPEC(
      MSG_ENABLE_ROSPEC msg,
      out MSG_ERROR_MESSAGE msg_err,
      int time_out)
    {
      return (MSG_ENABLE_ROSPEC_RESPONSE) new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.ENABLE_ROSPEC_RESPONSE).Transact((Message) msg, out msg_err, time_out);
    }

    public MSG_DISABLE_ROSPEC_RESPONSE DISABLE_ROSPEC(
      MSG_DISABLE_ROSPEC msg,
      out MSG_ERROR_MESSAGE msg_err,
      int time_out)
    {
      return (MSG_DISABLE_ROSPEC_RESPONSE) new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.DISABLE_ROSPEC_RESPONSE).Transact((Message) msg, out msg_err, time_out);
    }

    public MSG_GET_ROSPECS_RESPONSE GET_ROSPECS(
      MSG_GET_ROSPECS msg,
      out MSG_ERROR_MESSAGE msg_err,
      int time_out)
    {
      return (MSG_GET_ROSPECS_RESPONSE) new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.GET_ROSPECS_RESPONSE).Transact((Message) msg, out msg_err, time_out);
    }

    public MSG_ADD_ACCESSSPEC_RESPONSE ADD_ACCESSSPEC(
      MSG_ADD_ACCESSSPEC msg,
      out MSG_ERROR_MESSAGE msg_err,
      int time_out)
    {
      return (MSG_ADD_ACCESSSPEC_RESPONSE) new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.ADD_ACCESSSPEC_RESPONSE).Transact((Message) msg, out msg_err, time_out);
    }

    public MSG_DELETE_ACCESSSPEC_RESPONSE DELETE_ACCESSSPEC(
      MSG_DELETE_ACCESSSPEC msg,
      out MSG_ERROR_MESSAGE msg_err,
      int time_out)
    {
      return (MSG_DELETE_ACCESSSPEC_RESPONSE) new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.DELETE_ACCESSSPEC_RESPONSE).Transact((Message) msg, out msg_err, time_out);
    }

    public MSG_ENABLE_ACCESSSPEC_RESPONSE ENABLE_ACCESSSPEC(
      MSG_ENABLE_ACCESSSPEC msg,
      out MSG_ERROR_MESSAGE msg_err,
      int time_out)
    {
      return (MSG_ENABLE_ACCESSSPEC_RESPONSE) new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.ENABLE_ACCESSSPEC_RESPONSE).Transact((Message) msg, out msg_err, time_out);
    }

    public MSG_DISABLE_ACCESSSPEC_RESPONSE DISABLE_ACCESSSPEC(
      MSG_DISABLE_ACCESSSPEC msg,
      out MSG_ERROR_MESSAGE msg_err,
      int time_out)
    {
      return (MSG_DISABLE_ACCESSSPEC_RESPONSE) new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.DISABLE_ACCESSSPEC_RESPONSE).Transact((Message) msg, out msg_err, time_out);
    }

    public MSG_GET_ACCESSSPECS_RESPONSE GET_ACCESSSPECS(
      MSG_GET_ACCESSSPECS msg,
      out MSG_ERROR_MESSAGE msg_err,
      int time_out)
    {
      return (MSG_GET_ACCESSSPECS_RESPONSE) new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.GET_ACCESSSPECS_RESPONSE).Transact((Message) msg, out msg_err, time_out);
    }

    public MSG_GET_READER_CONFIG_RESPONSE GET_READER_CONFIG(
      MSG_GET_READER_CONFIG msg,
      out MSG_ERROR_MESSAGE msg_err,
      int time_out)
    {
      return (MSG_GET_READER_CONFIG_RESPONSE) new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.GET_READER_CONFIG_RESPONSE).Transact((Message) msg, out msg_err, time_out);
    }

    public MSG_SET_READER_CONFIG_RESPONSE SET_READER_CONFIG(
      MSG_SET_READER_CONFIG msg,
      out MSG_ERROR_MESSAGE msg_err,
      int time_out)
    {
      return (MSG_SET_READER_CONFIG_RESPONSE) new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.SET_READER_CONFIG_RESPONSE).Transact((Message) msg, out msg_err, time_out);
    }

    public MSG_CLOSE_CONNECTION_RESPONSE CLOSE_CONNECTION(
      MSG_CLOSE_CONNECTION msg,
      out MSG_ERROR_MESSAGE msg_err,
      int time_out)
    {
      return (MSG_CLOSE_CONNECTION_RESPONSE) new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.CLOSE_CONNECTION_RESPONSE).Transact((Message) msg, out msg_err, time_out);
    }

    public void GET_REPORT(MSG_GET_REPORT msg, out MSG_ERROR_MESSAGE msg_err, int time_out)
    {
      msg_err = (MSG_ERROR_MESSAGE) null;
      new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.GET_REPORT).Send((Message) msg);
    }

    public void KEEPALIVE_ACK(MSG_KEEPALIVE_ACK msg, out MSG_ERROR_MESSAGE msg_err, int time_out)
    {
      msg_err = (MSG_ERROR_MESSAGE) null;
      new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.KEEPALIVE_ACK).Send((Message) msg);
    }

    public void ENABLE_EVENTS_AND_REPORTS(
      MSG_ENABLE_EVENTS_AND_REPORTS msg,
      out MSG_ERROR_MESSAGE msg_err,
      int time_out)
    {
      msg_err = (MSG_ERROR_MESSAGE) null;
      new Transaction(this.cI, msg.MSG_ID, ENUM_LLRP_MSG_TYPE.ENABLE_EVENTS_AND_REPORTS).Send((Message) msg);
    }
  }
}
