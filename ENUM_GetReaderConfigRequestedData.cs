// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.ENUM_GetReaderConfigRequestedData
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Xml.Serialization;

namespace Org.LLRP.LTK.LLRPV1
{
  [Serializable]
  public enum ENUM_GetReaderConfigRequestedData
  {
    [XmlEnum(Name = "All")] All,
    [XmlEnum(Name = "Identification")] Identification,
    [XmlEnum(Name = "AntennaProperties")] AntennaProperties,
    [XmlEnum(Name = "AntennaConfiguration")] AntennaConfiguration,
    [XmlEnum(Name = "ROReportSpec")] ROReportSpec,
    [XmlEnum(Name = "ReaderEventNotificationSpec")] ReaderEventNotificationSpec,
    [XmlEnum(Name = "AccessReportSpec")] AccessReportSpec,
    [XmlEnum(Name = "LLRPConfigurationStateValue")] LLRPConfigurationStateValue,
    [XmlEnum(Name = "KeepaliveSpec")] KeepaliveSpec,
    [XmlEnum(Name = "GPIPortCurrentState")] GPIPortCurrentState,
    [XmlEnum(Name = "GPOWriteData")] GPOWriteData,
    [XmlEnum(Name = "EventsAndReports")] EventsAndReports,
  }
}
