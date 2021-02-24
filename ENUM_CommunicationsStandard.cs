// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.ENUM_CommunicationsStandard
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Xml.Serialization;

namespace Org.LLRP.LTK.LLRPV1
{
  [Serializable]
  public enum ENUM_CommunicationsStandard
  {
    [XmlEnum(Name = "Unspecified")] Unspecified,
    [XmlEnum(Name = "US_FCC_Part_15")] US_FCC_Part_15,
    [XmlEnum(Name = "ETSI_302_208")] ETSI_302_208,
    [XmlEnum(Name = "ETSI_300_220")] ETSI_300_220,
    [XmlEnum(Name = "Australia_LIPD_1W")] Australia_LIPD_1W,
    [XmlEnum(Name = "Australia_LIPD_4W")] Australia_LIPD_4W,
    [XmlEnum(Name = "Japan_ARIB_STD_T89")] Japan_ARIB_STD_T89,
    [XmlEnum(Name = "Hong_Kong_OFTA_1049")] Hong_Kong_OFTA_1049,
    [XmlEnum(Name = "Taiwan_DGT_LP0002")] Taiwan_DGT_LP0002,
    [XmlEnum(Name = "Korea_MIC_Article_5_2")] Korea_MIC_Article_5_2,
  }
}
