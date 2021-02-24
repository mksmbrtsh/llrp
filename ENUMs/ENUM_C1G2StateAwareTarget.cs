// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.ENUM_C1G2StateAwareTarget
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Xml.Serialization;

namespace Org.LLRP.LTK.LLRPV1
{
  [Serializable]
  public enum ENUM_C1G2StateAwareTarget
  {
    [XmlEnum(Name = "SL")] SL,
    [XmlEnum(Name = "Inventoried_State_For_Session_S0")] Inventoried_State_For_Session_S0,
    [XmlEnum(Name = "Inventoried_State_For_Session_S1")] Inventoried_State_For_Session_S1,
    [XmlEnum(Name = "Inventoried_State_For_Session_S2")] Inventoried_State_For_Session_S2,
    [XmlEnum(Name = "Inventoried_State_For_Session_S3")] Inventoried_State_For_Session_S3,
  }
}
