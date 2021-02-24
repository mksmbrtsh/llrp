// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.DataType.IParameter
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

namespace Org.LLRP.LTK.LLRPV1.DataType
{
  public interface IParameter
  {
    void ToBitArray(ref bool[] bit_array, ref int cursor);
  }
}
