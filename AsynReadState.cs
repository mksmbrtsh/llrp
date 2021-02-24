// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.AsynReadState
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;

namespace Org.LLRP.LTK.LLRPV1
{
  [Serializable]
  internal class AsynReadState
  {
    public byte[] data;

    public AsynReadState(int buffer_size) => this.data = new byte[buffer_size];
  }
}
