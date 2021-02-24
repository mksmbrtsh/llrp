// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.UNION_SpecParameter
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;

namespace Org.LLRP.LTK.LLRPV1
{
  public class UNION_SpecParameter : ParamArrayList
  {
    public bool AddCustomParameter(ICustom_Parameter param)
    {
      if (param is ISpecParameter_Custom_Param)
      {
        this.Add((IParameter) param);
        return true;
      }
      if (param.GetType() != typeof (PARAM_Custom))
        return false;
      this.Add((IParameter) param);
      return true;
    }
  }
}
