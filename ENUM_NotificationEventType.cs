// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.ENUM_NotificationEventType
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Xml.Serialization;

namespace Org.LLRP.LTK.LLRPV1
{
  [Serializable]
  public enum ENUM_NotificationEventType
  {
    [XmlEnum(Name = "Upon_Hopping_To_Next_Channel")] Upon_Hopping_To_Next_Channel,
    [XmlEnum(Name = "GPI_Event")] GPI_Event,
    [XmlEnum(Name = "ROSpec_Event")] ROSpec_Event,
    [XmlEnum(Name = "Report_Buffer_Fill_Warning")] Report_Buffer_Fill_Warning,
    [XmlEnum(Name = "Reader_Exception_Event")] Reader_Exception_Event,
    [XmlEnum(Name = "RFSurvey_Event")] RFSurvey_Event,
    [XmlEnum(Name = "AISpec_Event")] AISpec_Event,
    [XmlEnum(Name = "AISpec_Event_With_Details")] AISpec_Event_With_Details,
    [XmlEnum(Name = "Antenna_Event")] Antenna_Event,
  }
}
