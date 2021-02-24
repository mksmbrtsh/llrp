// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.ENUM_RFSurveySpecStopTriggerType
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Xml.Serialization;

namespace Org.LLRP.LTK.LLRPV1
{
  [Serializable]
  public enum ENUM_RFSurveySpecStopTriggerType
  {
    [XmlEnum(Name = "Null")] Null,
    [XmlEnum(Name = "Duration")] Duration,
    [XmlEnum(Name = "N_Iterations_Through_Frequency_Range")] N_Iterations_Through_Frequency_Range,
  }
}
