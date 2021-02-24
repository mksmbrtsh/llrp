// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.ENUM_C1G2StateAwareAction
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Xml.Serialization;

namespace Org.LLRP.LTK.LLRPV1
{
  [Serializable]
  public enum ENUM_C1G2StateAwareAction
  {
    [XmlEnum(Name = "AssertSLOrA_DeassertSLOrB")] AssertSLOrA_DeassertSLOrB,
    [XmlEnum(Name = "AssertSLOrA_Noop")] AssertSLOrA_Noop,
    [XmlEnum(Name = "Noop_DeassertSLOrB")] Noop_DeassertSLOrB,
    [XmlEnum(Name = "NegateSLOrABBA_Noop")] NegateSLOrABBA_Noop,
    [XmlEnum(Name = "DeassertSLOrB_AssertSLOrA")] DeassertSLOrB_AssertSLOrA,
    [XmlEnum(Name = "DeassertSLOrB_Noop")] DeassertSLOrB_Noop,
    [XmlEnum(Name = "Noop_AssertSLOrA")] Noop_AssertSLOrA,
    [XmlEnum(Name = "Noop_NegateSLOrABBA")] Noop_NegateSLOrABBA,
  }
}
