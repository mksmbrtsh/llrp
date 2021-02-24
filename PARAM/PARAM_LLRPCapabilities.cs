// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_LLRPCapabilities
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_LLRPCapabilities : Parameter
  {
    private const ushort param_reserved_len7 = 3;
    public bool CanDoRFSurvey;
    private short CanDoRFSurvey_len;
    public bool CanReportBufferFillWarning;
    private short CanReportBufferFillWarning_len;
    public bool SupportsClientRequestOpSpec;
    private short SupportsClientRequestOpSpec_len;
    public bool CanDoTagInventoryStateAwareSingulation;
    private short CanDoTagInventoryStateAwareSingulation_len;
    public bool SupportsEventAndReportHolding;
    private short SupportsEventAndReportHolding_len;
    public byte MaxNumPriorityLevelsSupported;
    private short MaxNumPriorityLevelsSupported_len;
    public ushort ClientRequestOpSpecTimeout;
    private short ClientRequestOpSpecTimeout_len;
    public uint MaxNumROSpecs;
    private short MaxNumROSpecs_len;
    public uint MaxNumSpecsPerROSpec;
    private short MaxNumSpecsPerROSpec_len;
    public uint MaxNumInventoryParameterSpecsPerAISpec;
    private short MaxNumInventoryParameterSpecsPerAISpec_len;
    public uint MaxNumAccessSpecs;
    private short MaxNumAccessSpecs_len;
    public uint MaxNumOpSpecsPerAccessSpec;
    private short MaxNumOpSpecsPerAccessSpec_len;

    public PARAM_LLRPCapabilities() => this.typeID = (ushort) 142;

    public static PARAM_LLRPCapabilities FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_LLRPCapabilities) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_LLRPCapabilities llrpCapabilities = new PARAM_LLRPCapabilities();
      llrpCapabilities.tvCoding = bit_array[cursor];
      int val;
      if (llrpCapabilities.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        llrpCapabilities.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) llrpCapabilities.length * 8;
      }
      if (val != (int) llrpCapabilities.TypeID)
      {
        cursor = num1;
        return (PARAM_LLRPCapabilities) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 1;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len1);
      llrpCapabilities.CanDoRFSurvey = (bool) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len2);
      llrpCapabilities.CanReportBufferFillWarning = (bool) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len3 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len3);
      llrpCapabilities.SupportsClientRequestOpSpec = (bool) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len4 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len4);
      llrpCapabilities.CanDoTagInventoryStateAwareSingulation = (bool) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len5 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len5);
      llrpCapabilities.SupportsEventAndReportHolding = (bool) obj;
      cursor += 3;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len6 = 8;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (byte), field_len6);
      llrpCapabilities.MaxNumPriorityLevelsSupported = (byte) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len7 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len7);
      llrpCapabilities.ClientRequestOpSpecTimeout = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len8 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len8);
      llrpCapabilities.MaxNumROSpecs = (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len9 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len9);
      llrpCapabilities.MaxNumSpecsPerROSpec = (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len10 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len10);
      llrpCapabilities.MaxNumInventoryParameterSpecsPerAISpec = (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len11 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len11);
      llrpCapabilities.MaxNumAccessSpecs = (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len12 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len12);
      llrpCapabilities.MaxNumOpSpecsPerAccessSpec = (uint) obj;
      return llrpCapabilities;
    }

    public override string ToString()
    {
      string str = "<LLRPCapabilities>" + "\r\n";
      try
      {
        str = str + "  <CanDoRFSurvey>" + Util.ConvertValueTypeToString((object) this.CanDoRFSurvey, "u1", "") + "</CanDoRFSurvey>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <CanReportBufferFillWarning>" + Util.ConvertValueTypeToString((object) this.CanReportBufferFillWarning, "u1", "") + "</CanReportBufferFillWarning>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <SupportsClientRequestOpSpec>" + Util.ConvertValueTypeToString((object) this.SupportsClientRequestOpSpec, "u1", "") + "</SupportsClientRequestOpSpec>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <CanDoTagInventoryStateAwareSingulation>" + Util.ConvertValueTypeToString((object) this.CanDoTagInventoryStateAwareSingulation, "u1", "") + "</CanDoTagInventoryStateAwareSingulation>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <SupportsEventAndReportHolding>" + Util.ConvertValueTypeToString((object) this.SupportsEventAndReportHolding, "u1", "") + "</SupportsEventAndReportHolding>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <MaxNumPriorityLevelsSupported>" + Util.ConvertValueTypeToString((object) this.MaxNumPriorityLevelsSupported, "u8", "") + "</MaxNumPriorityLevelsSupported>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <ClientRequestOpSpecTimeout>" + Util.ConvertValueTypeToString((object) this.ClientRequestOpSpecTimeout, "u16", "") + "</ClientRequestOpSpecTimeout>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <MaxNumROSpecs>" + Util.ConvertValueTypeToString((object) this.MaxNumROSpecs, "u32", "") + "</MaxNumROSpecs>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <MaxNumSpecsPerROSpec>" + Util.ConvertValueTypeToString((object) this.MaxNumSpecsPerROSpec, "u32", "") + "</MaxNumSpecsPerROSpec>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <MaxNumInventoryParameterSpecsPerAISpec>" + Util.ConvertValueTypeToString((object) this.MaxNumInventoryParameterSpecsPerAISpec, "u32", "") + "</MaxNumInventoryParameterSpecsPerAISpec>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <MaxNumAccessSpecs>" + Util.ConvertValueTypeToString((object) this.MaxNumAccessSpecs, "u32", "") + "</MaxNumAccessSpecs>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <MaxNumOpSpecsPerAccessSpec>" + Util.ConvertValueTypeToString((object) this.MaxNumOpSpecsPerAccessSpec, "u32", "") + "</MaxNumOpSpecsPerAccessSpec>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</LLRPCapabilities>" + "\r\n";
    }

    public static PARAM_LLRPCapabilities FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_LLRPCapabilities llrpCapabilities = new PARAM_LLRPCapabilities();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "CanDoRFSurvey");
      llrpCapabilities.CanDoRFSurvey = (bool) Util.ParseValueTypeFromString(nodeValue1, "u1", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "CanReportBufferFillWarning");
      llrpCapabilities.CanReportBufferFillWarning = (bool) Util.ParseValueTypeFromString(nodeValue2, "u1", "");
      string nodeValue3 = XmlUtil.GetNodeValue(node, "SupportsClientRequestOpSpec");
      llrpCapabilities.SupportsClientRequestOpSpec = (bool) Util.ParseValueTypeFromString(nodeValue3, "u1", "");
      string nodeValue4 = XmlUtil.GetNodeValue(node, "CanDoTagInventoryStateAwareSingulation");
      llrpCapabilities.CanDoTagInventoryStateAwareSingulation = (bool) Util.ParseValueTypeFromString(nodeValue4, "u1", "");
      string nodeValue5 = XmlUtil.GetNodeValue(node, "SupportsEventAndReportHolding");
      llrpCapabilities.SupportsEventAndReportHolding = (bool) Util.ParseValueTypeFromString(nodeValue5, "u1", "");
      string nodeValue6 = XmlUtil.GetNodeValue(node, "MaxNumPriorityLevelsSupported");
      llrpCapabilities.MaxNumPriorityLevelsSupported = (byte) Util.ParseValueTypeFromString(nodeValue6, "u8", "");
      string nodeValue7 = XmlUtil.GetNodeValue(node, "ClientRequestOpSpecTimeout");
      llrpCapabilities.ClientRequestOpSpecTimeout = (ushort) Util.ParseValueTypeFromString(nodeValue7, "u16", "");
      string nodeValue8 = XmlUtil.GetNodeValue(node, "MaxNumROSpecs");
      llrpCapabilities.MaxNumROSpecs = (uint) Util.ParseValueTypeFromString(nodeValue8, "u32", "");
      string nodeValue9 = XmlUtil.GetNodeValue(node, "MaxNumSpecsPerROSpec");
      llrpCapabilities.MaxNumSpecsPerROSpec = (uint) Util.ParseValueTypeFromString(nodeValue9, "u32", "");
      string nodeValue10 = XmlUtil.GetNodeValue(node, "MaxNumInventoryParameterSpecsPerAISpec");
      llrpCapabilities.MaxNumInventoryParameterSpecsPerAISpec = (uint) Util.ParseValueTypeFromString(nodeValue10, "u32", "");
      string nodeValue11 = XmlUtil.GetNodeValue(node, "MaxNumAccessSpecs");
      llrpCapabilities.MaxNumAccessSpecs = (uint) Util.ParseValueTypeFromString(nodeValue11, "u32", "");
      string nodeValue12 = XmlUtil.GetNodeValue(node, "MaxNumOpSpecsPerAccessSpec");
      llrpCapabilities.MaxNumOpSpecsPerAccessSpec = (uint) Util.ParseValueTypeFromString(nodeValue12, "u32", "");
      return llrpCapabilities;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.CanDoRFSurvey, (int) this.CanDoRFSurvey_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.CanReportBufferFillWarning, (int) this.CanReportBufferFillWarning_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.SupportsClientRequestOpSpec, (int) this.SupportsClientRequestOpSpec_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.CanDoTagInventoryStateAwareSingulation, (int) this.CanDoTagInventoryStateAwareSingulation_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.SupportsEventAndReportHolding, (int) this.SupportsEventAndReportHolding_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      cursor += 3;
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.MaxNumPriorityLevelsSupported, (int) this.MaxNumPriorityLevelsSupported_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.ClientRequestOpSpecTimeout, (int) this.ClientRequestOpSpecTimeout_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.MaxNumROSpecs, (int) this.MaxNumROSpecs_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.MaxNumSpecsPerROSpec, (int) this.MaxNumSpecsPerROSpec_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.MaxNumInventoryParameterSpecsPerAISpec, (int) this.MaxNumInventoryParameterSpecsPerAISpec_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.MaxNumAccessSpecs, (int) this.MaxNumAccessSpecs_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.MaxNumOpSpecsPerAccessSpec, (int) this.MaxNumOpSpecsPerAccessSpec_len);
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
