// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.DataType.MessageID
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

namespace Org.LLRP.LTK.LLRPV1.DataType
{
  public class MessageID
  {
    protected static object mutex = new object();
    protected static uint sequence_num = 0;

    public static uint getNewMessageID()
    {
      uint sequenceNum;
      lock (MessageID.mutex)
      {
        sequenceNum = MessageID.sequence_num;
        ++MessageID.sequence_num;
      }
      return sequenceNum;
    }
  }
}
