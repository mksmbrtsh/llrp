// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2UHFRFModeTableEntry
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2UHFRFModeTableEntry : Parameter
  {
    private const ushort param_reserved_len5 = 6;
    public uint ModeIdentifier;
    private short ModeIdentifier_len;
    public ENUM_C1G2DRValue DRValue;
    private short DRValue_len = 1;
    public bool EPCHAGTCConformance;
    private short EPCHAGTCConformance_len;
    public ENUM_C1G2MValue MValue;
    private short MValue_len = 8;
    public ENUM_C1G2ForwardLinkModulation ForwardLinkModulation;
    private short ForwardLinkModulation_len = 8;
    public ENUM_C1G2SpectralMaskIndicator SpectralMaskIndicator;
    private short SpectralMaskIndicator_len = 8;
    public uint BDRValue;
    private short BDRValue_len;
    public uint PIEValue;
    private short PIEValue_len;
    public uint MinTariValue;
    private short MinTariValue_len;
    public uint MaxTariValue;
    private short MaxTariValue_len;
    public uint StepTariValue;
    private short StepTariValue_len;

    public PARAM_C1G2UHFRFModeTableEntry() => this.typeID = (ushort) 329;

    public static PARAM_C1G2UHFRFModeTableEntry FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2UHFRFModeTableEntry) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_C1G2UHFRFModeTableEntry uhfrfModeTableEntry = new PARAM_C1G2UHFRFModeTableEntry();
      uhfrfModeTableEntry.tvCoding = bit_array[cursor];
      int val;
      if (uhfrfModeTableEntry.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        uhfrfModeTableEntry.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) uhfrfModeTableEntry.length * 8;
      }
      if (val != (int) uhfrfModeTableEntry.TypeID)
      {
        cursor = num1;
        return (PARAM_C1G2UHFRFModeTableEntry) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 32;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len1);
      uhfrfModeTableEntry.ModeIdentifier = (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len2);
      uhfrfModeTableEntry.DRValue = (ENUM_C1G2DRValue) (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len3 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len3);
      uhfrfModeTableEntry.EPCHAGTCConformance = (bool) obj;
      cursor += 6;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len4 = 8;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len4);
      uhfrfModeTableEntry.MValue = (ENUM_C1G2MValue) (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len5 = 8;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len5);
      uhfrfModeTableEntry.ForwardLinkModulation = (ENUM_C1G2ForwardLinkModulation) (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len6 = 8;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len6);
      uhfrfModeTableEntry.SpectralMaskIndicator = (ENUM_C1G2SpectralMaskIndicator) (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len7 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len7);
      uhfrfModeTableEntry.BDRValue = (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len8 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len8);
      uhfrfModeTableEntry.PIEValue = (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len9 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len9);
      uhfrfModeTableEntry.MinTariValue = (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len10 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len10);
      uhfrfModeTableEntry.MaxTariValue = (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len11 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len11);
      uhfrfModeTableEntry.StepTariValue = (uint) obj;
      return uhfrfModeTableEntry;
    }

    public override string ToString()
    {
      string str = "<C1G2UHFRFModeTableEntry>" + "\r\n";
      try
      {
        str = str + "  <ModeIdentifier>" + Util.ConvertValueTypeToString((object) this.ModeIdentifier, "u32", "") + "</ModeIdentifier>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <DRValue>" + this.DRValue.ToString() + "</DRValue>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <EPCHAGTCConformance>" + Util.ConvertValueTypeToString((object) this.EPCHAGTCConformance, "u1", "") + "</EPCHAGTCConformance>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <MValue>" + this.MValue.ToString() + "</MValue>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <ForwardLinkModulation>" + this.ForwardLinkModulation.ToString() + "</ForwardLinkModulation>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <SpectralMaskIndicator>" + this.SpectralMaskIndicator.ToString() + "</SpectralMaskIndicator>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <BDRValue>" + Util.ConvertValueTypeToString((object) this.BDRValue, "u32", "") + "</BDRValue>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <PIEValue>" + Util.ConvertValueTypeToString((object) this.PIEValue, "u32", "") + "</PIEValue>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <MinTariValue>" + Util.ConvertValueTypeToString((object) this.MinTariValue, "u32", "") + "</MinTariValue>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <MaxTariValue>" + Util.ConvertValueTypeToString((object) this.MaxTariValue, "u32", "") + "</MaxTariValue>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <StepTariValue>" + Util.ConvertValueTypeToString((object) this.StepTariValue, "u32", "") + "</StepTariValue>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</C1G2UHFRFModeTableEntry>" + "\r\n";
    }

    public static PARAM_C1G2UHFRFModeTableEntry FromXmlNode(
      XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2UHFRFModeTableEntry uhfrfModeTableEntry = new PARAM_C1G2UHFRFModeTableEntry();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "ModeIdentifier");
      uhfrfModeTableEntry.ModeIdentifier = (uint) Util.ParseValueTypeFromString(nodeValue1, "u32", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "DRValue");
      uhfrfModeTableEntry.DRValue = (ENUM_C1G2DRValue) Enum.Parse(typeof (ENUM_C1G2DRValue), nodeValue2);
      string nodeValue3 = XmlUtil.GetNodeValue(node, "EPCHAGTCConformance");
      uhfrfModeTableEntry.EPCHAGTCConformance = (bool) Util.ParseValueTypeFromString(nodeValue3, "u1", "");
      string nodeValue4 = XmlUtil.GetNodeValue(node, "MValue");
      uhfrfModeTableEntry.MValue = (ENUM_C1G2MValue) Enum.Parse(typeof (ENUM_C1G2MValue), nodeValue4);
      string nodeValue5 = XmlUtil.GetNodeValue(node, "ForwardLinkModulation");
      uhfrfModeTableEntry.ForwardLinkModulation = (ENUM_C1G2ForwardLinkModulation) Enum.Parse(typeof (ENUM_C1G2ForwardLinkModulation), nodeValue5);
      string nodeValue6 = XmlUtil.GetNodeValue(node, "SpectralMaskIndicator");
      uhfrfModeTableEntry.SpectralMaskIndicator = (ENUM_C1G2SpectralMaskIndicator) Enum.Parse(typeof (ENUM_C1G2SpectralMaskIndicator), nodeValue6);
      string nodeValue7 = XmlUtil.GetNodeValue(node, "BDRValue");
      uhfrfModeTableEntry.BDRValue = (uint) Util.ParseValueTypeFromString(nodeValue7, "u32", "");
      string nodeValue8 = XmlUtil.GetNodeValue(node, "PIEValue");
      uhfrfModeTableEntry.PIEValue = (uint) Util.ParseValueTypeFromString(nodeValue8, "u32", "");
      string nodeValue9 = XmlUtil.GetNodeValue(node, "MinTariValue");
      uhfrfModeTableEntry.MinTariValue = (uint) Util.ParseValueTypeFromString(nodeValue9, "u32", "");
      string nodeValue10 = XmlUtil.GetNodeValue(node, "MaxTariValue");
      uhfrfModeTableEntry.MaxTariValue = (uint) Util.ParseValueTypeFromString(nodeValue10, "u32", "");
      string nodeValue11 = XmlUtil.GetNodeValue(node, "StepTariValue");
      uhfrfModeTableEntry.StepTariValue = (uint) Util.ParseValueTypeFromString(nodeValue11, "u32", "");
      return uhfrfModeTableEntry;
    }

    public override void ToBitArray(ref bool[] bit_array, ref int cursor)
    {
      int num = cursor;
      if (this.tvCoding)
      {
        bit_array[cursor] = true;
        ++cursor;
        Util.ConvertIntToBitArray((uint) this.typeID, 7).CopyTo((Array) bit_array, cursor);
        cursor += 7;
      }
      else
      {
        cursor += 6;
        Util.ConvertIntToBitArray((uint) this.typeID, 10).CopyTo((Array) bit_array, cursor);
        cursor += 10;
        cursor += 16;
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.ModeIdentifier, (int) this.ModeIdentifier_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.DRValue, (int) this.DRValue_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.EPCHAGTCConformance, (int) this.EPCHAGTCConformance_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      cursor += 6;
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.MValue, (int) this.MValue_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.ForwardLinkModulation, (int) this.ForwardLinkModulation_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.SpectralMaskIndicator, (int) this.SpectralMaskIndicator_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.BDRValue, (int) this.BDRValue_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.PIEValue, (int) this.PIEValue_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.MinTariValue, (int) this.MinTariValue_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.MaxTariValue, (int) this.MaxTariValue_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.StepTariValue, (int) this.StepTariValue_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
