// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.ENUM_GetReaderCapabilitiesRequestedData
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Xml.Serialization;

namespace Org.LLRP.LTK.LLRPV1
{
  [Serializable]
  public enum ENUM_GetReaderCapabilitiesRequestedData
  {
    [XmlEnum(Name = "All")] All,
    [XmlEnum(Name = "General_Device_Capabilities")] General_Device_Capabilities,
    [XmlEnum(Name = "LLRP_Capabilities")] LLRP_Capabilities,
    [XmlEnum(Name = "Regulatory_Capabilities")] Regulatory_Capabilities,
    [XmlEnum(Name = "LLRP_Air_Protocol_Capabilities")] LLRP_Air_Protocol_Capabilities,
  }
}
