// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.DataType.Parameter
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System.Collections;

namespace Org.LLRP.LTK.LLRPV1.DataType
{
  public abstract class Parameter : IParameter
  {
    protected ushort typeID;
    protected ushort length;
    protected bool tvCoding;

    public virtual void ToBitArray(ref bool[] bit_array, ref int cursor)
    {
    }

    public virtual Parameter FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      return (Parameter) null;
    }

    public virtual Parameter FromString(string xml) => (Parameter) null;

    public ushort TypeID => this.typeID;

    public ushort Length => this.length;
  }
}
