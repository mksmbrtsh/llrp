// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.DataType.ParamArrayList
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System.Collections.Generic;

namespace Org.LLRP.LTK.LLRPV1.DataType
{
  public class ParamArrayList
  {
    private List<IParameter> data;

    public ParamArrayList() => this.data = new List<IParameter>();

    public void Add(IParameter val) => this.data.Add(val);

    public IParameter this[int index]
    {
      get => this.data[index];
      set => this.data[index] = value;
    }

    public int Count => this.data.Count;

    public int Length => this.data.Count;
  }
}
