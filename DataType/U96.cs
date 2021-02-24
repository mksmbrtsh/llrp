// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.DataType.U96
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

namespace Org.LLRP.LTK.LLRPV1.DataType
{
  public class U96
  {
    private ushort[] data;

    public override string ToString() => string.Format("{0:4X}{1:4X}{2:4X}{3:4X}{4:4X}{5:4X}", (object) this.data[0], (object) this.data[1], (object) this.data[2], (object) this.data[3], (object) this.data[4], (object) this.data[5]);

    public U96() => this.data = new ushort[6];
  }
}
