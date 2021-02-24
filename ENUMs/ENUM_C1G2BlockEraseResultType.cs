// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.ENUM_C1G2BlockEraseResultType
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Xml.Serialization;

namespace Org.LLRP.LTK.LLRPV1
{
  [Serializable]
  public enum ENUM_C1G2BlockEraseResultType
  {
    [XmlEnum(Name = "Success")] Success,
    [XmlEnum(Name = "Tag_Memory_Overrun_Error")] Tag_Memory_Overrun_Error,
    [XmlEnum(Name = "Tag_Memory_Locked_Error")] Tag_Memory_Locked_Error,
    [XmlEnum(Name = "Insufficient_Power")] Insufficient_Power,
    [XmlEnum(Name = "Nonspecific_Tag_Error")] Nonspecific_Tag_Error,
    [XmlEnum(Name = "No_Response_From_Tag")] No_Response_From_Tag,
    [XmlEnum(Name = "Nonspecific_Reader_Error")] Nonspecific_Reader_Error,
  }
}
