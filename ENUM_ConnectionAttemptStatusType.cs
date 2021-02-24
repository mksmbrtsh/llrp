// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.ENUM_ConnectionAttemptStatusType
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Xml.Serialization;

namespace Org.LLRP.LTK.LLRPV1
{
  [Serializable]
  public enum ENUM_ConnectionAttemptStatusType
  {
    [XmlEnum(Name = "Success")] Success,
    [XmlEnum(Name = "Failed_A_Reader_Initiated_Connection_Already_Exists")] Failed_A_Reader_Initiated_Connection_Already_Exists,
    [XmlEnum(Name = "Failed_A_Client_Initiated_Connection_Already_Exists")] Failed_A_Client_Initiated_Connection_Already_Exists,
    [XmlEnum(Name = "Failed_Reason_Other_Than_A_Connection_Already_Exists")] Failed_Reason_Other_Than_A_Connection_Already_Exists,
    [XmlEnum(Name = "Another_Connection_Attempted")] Another_Connection_Attempted,
  }
}
