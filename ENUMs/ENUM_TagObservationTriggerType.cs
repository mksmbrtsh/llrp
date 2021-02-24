// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.ENUM_TagObservationTriggerType
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Xml.Serialization;

namespace Org.LLRP.LTK.LLRPV1
{
  [Serializable]
  public enum ENUM_TagObservationTriggerType
  {
    [XmlEnum(Name = "Upon_Seeing_N_Tags_Or_Timeout")] Upon_Seeing_N_Tags_Or_Timeout,
    [XmlEnum(Name = "Upon_Seeing_No_More_New_Tags_For_Tms_Or_Timeout")] Upon_Seeing_No_More_New_Tags_For_Tms_Or_Timeout,
    [XmlEnum(Name = "N_Attempts_To_See_All_Tags_In_FOV_Or_Timeout")] N_Attempts_To_See_All_Tags_In_FOV_Or_Timeout,
  }
}
