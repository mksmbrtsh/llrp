﻿// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.ENUM_C1G2SpectralMaskIndicator
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Xml.Serialization;

namespace Org.LLRP.LTK.LLRPV1
{
  [Serializable]
  public enum ENUM_C1G2SpectralMaskIndicator
  {
    [XmlEnum(Name = "Unknown")] Unknown,
    [XmlEnum(Name = "SI")] SI,
    [XmlEnum(Name = "MI")] MI,
    [XmlEnum(Name = "DI")] DI,
  }
}
