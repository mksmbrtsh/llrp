// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.DataType.Message
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System.Collections;

namespace Org.LLRP.LTK.LLRPV1.DataType
{
  public abstract class Message
  {
    protected ushort reserved;
    protected ushort version = 1;
    protected ushort msgType;
    protected uint msgLen;
    protected uint msgID;
    protected static uint sequence_num;

    public virtual bool[] ToBitArray() => (bool[]) null;

    public virtual Message FromBitArray(ref BitArray bit_array, ref int cursor, int length) => (Message) null;

    public virtual Message FromString(string xml) => (Message) null;

    public uint MSG_ID
    {
      get => this.msgID;
      set
      {
        Message.sequence_num = value;
        this.msgID = Message.sequence_num;
      }
    }

    public ushort VERSION
    {
      get => this.version;
      set => this.version = value;
    }

    public uint Length
    {
      get => this.msgLen;
      set => this.msgLen = value;
    }

    public ushort MSG_TYPE
    {
      get => this.msgType;
      set => this.msgType = value;
    }
  }
}
