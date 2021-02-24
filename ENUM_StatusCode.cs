// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.ENUM_StatusCode
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Xml.Serialization;

namespace Org.LLRP.LTK.LLRPV1
{
  [Serializable]
  public enum ENUM_StatusCode
  {
    [XmlEnum(Name = "M_Success")] M_Success = 0,
    [XmlEnum(Name = "M_ParameterError")] M_ParameterError = 100, // 0x00000064
    [XmlEnum(Name = "M_FieldError")] M_FieldError = 101, // 0x00000065
    [XmlEnum(Name = "M_UnexpectedParameter")] M_UnexpectedParameter = 102, // 0x00000066
    [XmlEnum(Name = "M_MissingParameter")] M_MissingParameter = 103, // 0x00000067
    [XmlEnum(Name = "M_DuplicateParameter")] M_DuplicateParameter = 104, // 0x00000068
    [XmlEnum(Name = "M_OverflowParameter")] M_OverflowParameter = 105, // 0x00000069
    [XmlEnum(Name = "M_OverflowField")] M_OverflowField = 106, // 0x0000006A
    [XmlEnum(Name = "M_UnknownParameter")] M_UnknownParameter = 107, // 0x0000006B
    [XmlEnum(Name = "M_UnknownField")] M_UnknownField = 108, // 0x0000006C
    [XmlEnum(Name = "M_UnsupportedMessage")] M_UnsupportedMessage = 109, // 0x0000006D
    [XmlEnum(Name = "M_UnsupportedVersion")] M_UnsupportedVersion = 110, // 0x0000006E
    [XmlEnum(Name = "M_UnsupportedParameter")] M_UnsupportedParameter = 111, // 0x0000006F
    [XmlEnum(Name = "P_ParameterError")] P_ParameterError = 200, // 0x000000C8
    [XmlEnum(Name = "P_FieldError")] P_FieldError = 201, // 0x000000C9
    [XmlEnum(Name = "P_UnexpectedParameter")] P_UnexpectedParameter = 202, // 0x000000CA
    [XmlEnum(Name = "P_MissingParameter")] P_MissingParameter = 203, // 0x000000CB
    [XmlEnum(Name = "P_DuplicateParameter")] P_DuplicateParameter = 204, // 0x000000CC
    [XmlEnum(Name = "P_OverflowParameter")] P_OverflowParameter = 205, // 0x000000CD
    [XmlEnum(Name = "P_OverflowField")] P_OverflowField = 206, // 0x000000CE
    [XmlEnum(Name = "P_UnknownParameter")] P_UnknownParameter = 207, // 0x000000CF
    [XmlEnum(Name = "P_UnknownField")] P_UnknownField = 208, // 0x000000D0
    [XmlEnum(Name = "P_UnsupportedParameter")] P_UnsupportedParameter = 209, // 0x000000D1
    [XmlEnum(Name = "A_Invalid")] A_Invalid = 300, // 0x0000012C
    [XmlEnum(Name = "A_OutOfRange")] A_OutOfRange = 301, // 0x0000012D
    [XmlEnum(Name = "R_DeviceError")] R_DeviceError = 401, // 0x00000191
  }
}
