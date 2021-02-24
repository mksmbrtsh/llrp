// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.ENUM_ROReportTriggerType
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Xml.Serialization;

namespace Org.LLRP.LTK.LLRPV1
{
  [Serializable]
  public enum ENUM_ROReportTriggerType
  {
    [XmlEnum(Name = "None")] None,
    [XmlEnum(Name = "Upon_N_Tags_Or_End_Of_AISpec")] Upon_N_Tags_Or_End_Of_AISpec,
    [XmlEnum(Name = "Upon_N_Tags_Or_End_Of_ROSpec")] Upon_N_Tags_Or_End_Of_ROSpec,
  }
}
