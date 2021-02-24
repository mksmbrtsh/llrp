// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.CommunicationInterface
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;

namespace Org.LLRP.LTK.LLRPV1
{
  [Serializable]
  internal abstract class CommunicationInterface : IDisposable
  {
    protected AsynReadState state;

    public event delegateMessageReceived OnFrameReceived;

    public event delegateClientConnected OnClientConnected;

    protected void TriggerMessageEvent(short ver, short msg_type, int msg_id, byte[] data)
    {
        if (this.OnFrameReceived == null)
          return;
        this.OnFrameReceived(ver, msg_type, msg_id, data);
    }

    public void TriggerOnClientConnect()
    {
        if (this.OnClientConnected == null)
          return;
        this.OnClientConnected();
    }

    public virtual bool Open(string device_name, int port) => false;

    public virtual bool Open(string device_name, int port, int timeout) => false;

    public virtual void Close()
    {
    }

    public virtual int Send(byte[] data) => 0;

    public virtual int Receive(out byte[] buffer)
    {
      buffer = (byte[]) null;
      return 0;
    }

    public virtual bool SetBufferSize(int size) => false;

    public virtual void Dispose()
    {
    }
  }
}
