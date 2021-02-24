// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.DataType.CustomParameterArrayList
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System.Collections.Generic;

namespace Org.LLRP.LTK.LLRPV1.DataType
{
  public class CustomParameterArrayList
  {
    private List<ICustom_Parameter> list;

    public CustomParameterArrayList() => this.list = new List<ICustom_Parameter>();

    public int Length => this.list.Count;

    public int Count => this.list.Count;

    public int Add(ICustom_Parameter value)
    {
      this.list.Add(value);
      return this.list.Count;
    }

    public ICustom_Parameter this[int index]
    {
      get => this.list[index];
      set => this.list[index] = value;
    }
  }
}
