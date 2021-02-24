// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.RAW_Message
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;

namespace Org.LLRP.LTK.LLRPV1
{
  public class RAW_Message
  {
    public short version;
    public short msg_type;
    public int msg_id;
    public byte[] msg_body;

    public RAW_Message(short ver, short type, int id, byte[] data)
    {
      this.version = ver;
      this.msg_id = id;
      this.msg_type = type;
      this.msg_body = new byte[data.Length];
      Array.Copy((Array) data, (Array) this.msg_body, data.Length);
    }
  }
}
