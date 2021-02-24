// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.DataType.TwoBits
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;

namespace Org.LLRP.LTK.LLRPV1.DataType
{
  public class TwoBits
  {
    private bool[] bits = new bool[2];

    public TwoBits() => this.bits = new bool[2];

    public TwoBits(bool bit1, bool bit2)
    {
      this.bits = new bool[2];
      this.bits[0] = bit1;
      this.bits[1] = bit2;
    }

    public TwoBits(ushort data)
    {
      this.bits[0] = ((int) data & 2) == 2;
      this.bits[1] = ((int) data & 1) == 1;
    }

    public ushort ToInt() => (ushort) ((this.bits[0] ? 2 : 0) + (this.bits[1] ? 1 : 0));

    public bool this[int index]
    {
      get => index <= 1 ? this.bits[index] : throw new Exception("Index is out of range!");
      set
      {
        if (index > 1)
          throw new Exception("Index is out of range!");
        this.bits[index] = value;
      }
    }

    public static TwoBits FromString(string str)
    {
      try
      {
        return new TwoBits(Convert.ToUInt16(str));
      }
      catch
      {
        return (TwoBits) null;
      }
    }

    public override string ToString() => ((ushort) ((this.bits[0] ? 2 : 0) + (this.bits[1] ? 1 : 0))).ToString();
  }
}
