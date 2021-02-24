// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_TagReportContentSelector
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_TagReportContentSelector : Parameter
  {
    private const ushort param_reserved_len12 = 6;
    public bool EnableROSpecID;
    private short EnableROSpecID_len;
    public bool EnableSpecIndex;
    private short EnableSpecIndex_len;
    public bool EnableInventoryParameterSpecID;
    private short EnableInventoryParameterSpecID_len;
    public bool EnableAntennaID;
    private short EnableAntennaID_len;
    public bool EnableChannelIndex;
    private short EnableChannelIndex_len;
    public bool EnablePeakRSSI;
    private short EnablePeakRSSI_len;
    public bool EnableFirstSeenTimestamp;
    private short EnableFirstSeenTimestamp_len;
    public bool EnableLastSeenTimestamp;
    private short EnableLastSeenTimestamp_len;
    public bool EnableTagSeenCount;
    private short EnableTagSeenCount_len;
    public bool EnableAccessSpecID;
    private short EnableAccessSpecID_len;
    public UNION_AirProtocolEPCMemorySelector AirProtocolEPCMemorySelector = new UNION_AirProtocolEPCMemorySelector();

    public PARAM_TagReportContentSelector() => this.typeID = (ushort) 238;

    public static PARAM_TagReportContentSelector FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_TagReportContentSelector) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_TagReportContentSelector reportContentSelector = new PARAM_TagReportContentSelector();
      reportContentSelector.tvCoding = bit_array[cursor];
      int val;
      if (reportContentSelector.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        reportContentSelector.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) reportContentSelector.length * 8;
      }
      if (val != (int) reportContentSelector.TypeID)
      {
        cursor = num1;
        return (PARAM_TagReportContentSelector) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 1;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len1);
      reportContentSelector.EnableROSpecID = (bool) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len2);
      reportContentSelector.EnableSpecIndex = (bool) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len3 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len3);
      reportContentSelector.EnableInventoryParameterSpecID = (bool) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len4 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len4);
      reportContentSelector.EnableAntennaID = (bool) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len5 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len5);
      reportContentSelector.EnableChannelIndex = (bool) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len6 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len6);
      reportContentSelector.EnablePeakRSSI = (bool) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len7 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len7);
      reportContentSelector.EnableFirstSeenTimestamp = (bool) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len8 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len8);
      reportContentSelector.EnableLastSeenTimestamp = (bool) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len9 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len9);
      reportContentSelector.EnableTagSeenCount = (bool) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len10 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len10);
      reportContentSelector.EnableAccessSpecID = (bool) obj;
      cursor += 6;
      ushort num3 = 1;
      while (num3 != (ushort) 0)
      {
        num3 = (ushort) 0;
        PARAM_C1G2EPCMemorySelector epcMemorySelector = PARAM_C1G2EPCMemorySelector.FromBitArray(ref bit_array, ref cursor, length);
        if (epcMemorySelector != null)
        {
          ++num3;
          reportContentSelector.AirProtocolEPCMemorySelector.Add((IParameter) epcMemorySelector);
        }
      }
      return reportContentSelector;
    }

    public override string ToString()
    {
      string str = "<TagReportContentSelector>" + "\r\n";
      try
      {
        str = str + "  <EnableROSpecID>" + Util.ConvertValueTypeToString((object) this.EnableROSpecID, "u1", "") + "</EnableROSpecID>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <EnableSpecIndex>" + Util.ConvertValueTypeToString((object) this.EnableSpecIndex, "u1", "") + "</EnableSpecIndex>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <EnableInventoryParameterSpecID>" + Util.ConvertValueTypeToString((object) this.EnableInventoryParameterSpecID, "u1", "") + "</EnableInventoryParameterSpecID>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <EnableAntennaID>" + Util.ConvertValueTypeToString((object) this.EnableAntennaID, "u1", "") + "</EnableAntennaID>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <EnableChannelIndex>" + Util.ConvertValueTypeToString((object) this.EnableChannelIndex, "u1", "") + "</EnableChannelIndex>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <EnablePeakRSSI>" + Util.ConvertValueTypeToString((object) this.EnablePeakRSSI, "u1", "") + "</EnablePeakRSSI>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <EnableFirstSeenTimestamp>" + Util.ConvertValueTypeToString((object) this.EnableFirstSeenTimestamp, "u1", "") + "</EnableFirstSeenTimestamp>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <EnableLastSeenTimestamp>" + Util.ConvertValueTypeToString((object) this.EnableLastSeenTimestamp, "u1", "") + "</EnableLastSeenTimestamp>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <EnableTagSeenCount>" + Util.ConvertValueTypeToString((object) this.EnableTagSeenCount, "u1", "") + "</EnableTagSeenCount>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <EnableAccessSpecID>" + Util.ConvertValueTypeToString((object) this.EnableAccessSpecID, "u1", "") + "</EnableAccessSpecID>";
        str += "\r\n";
      }
      catch
      {
      }
      if (this.AirProtocolEPCMemorySelector != null)
      {
        int count = this.AirProtocolEPCMemorySelector.Count;
        for (int index = 0; index < count; ++index)
          str += Util.Indent(this.AirProtocolEPCMemorySelector[index].ToString());
      }
      return str + "</TagReportContentSelector>" + "\r\n";
    }

    public static PARAM_TagReportContentSelector FromXmlNode(
      XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_TagReportContentSelector reportContentSelector = new PARAM_TagReportContentSelector();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "EnableROSpecID");
      reportContentSelector.EnableROSpecID = (bool) Util.ParseValueTypeFromString(nodeValue1, "u1", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "EnableSpecIndex");
      reportContentSelector.EnableSpecIndex = (bool) Util.ParseValueTypeFromString(nodeValue2, "u1", "");
      string nodeValue3 = XmlUtil.GetNodeValue(node, "EnableInventoryParameterSpecID");
      reportContentSelector.EnableInventoryParameterSpecID = (bool) Util.ParseValueTypeFromString(nodeValue3, "u1", "");
      string nodeValue4 = XmlUtil.GetNodeValue(node, "EnableAntennaID");
      reportContentSelector.EnableAntennaID = (bool) Util.ParseValueTypeFromString(nodeValue4, "u1", "");
      string nodeValue5 = XmlUtil.GetNodeValue(node, "EnableChannelIndex");
      reportContentSelector.EnableChannelIndex = (bool) Util.ParseValueTypeFromString(nodeValue5, "u1", "");
      string nodeValue6 = XmlUtil.GetNodeValue(node, "EnablePeakRSSI");
      reportContentSelector.EnablePeakRSSI = (bool) Util.ParseValueTypeFromString(nodeValue6, "u1", "");
      string nodeValue7 = XmlUtil.GetNodeValue(node, "EnableFirstSeenTimestamp");
      reportContentSelector.EnableFirstSeenTimestamp = (bool) Util.ParseValueTypeFromString(nodeValue7, "u1", "");
      string nodeValue8 = XmlUtil.GetNodeValue(node, "EnableLastSeenTimestamp");
      reportContentSelector.EnableLastSeenTimestamp = (bool) Util.ParseValueTypeFromString(nodeValue8, "u1", "");
      string nodeValue9 = XmlUtil.GetNodeValue(node, "EnableTagSeenCount");
      reportContentSelector.EnableTagSeenCount = (bool) Util.ParseValueTypeFromString(nodeValue9, "u1", "");
      string nodeValue10 = XmlUtil.GetNodeValue(node, "EnableAccessSpecID");
      reportContentSelector.EnableAccessSpecID = (bool) Util.ParseValueTypeFromString(nodeValue10, "u1", "");
      reportContentSelector.AirProtocolEPCMemorySelector = new UNION_AirProtocolEPCMemorySelector();
      try
      {
        foreach (XmlNode childNode in node.ChildNodes)
        {
          switch (childNode.Name)
          {
            case "C1G2EPCMemorySelector":
              reportContentSelector.AirProtocolEPCMemorySelector.Add((IParameter) PARAM_C1G2EPCMemorySelector.FromXmlNode(childNode));
              continue;
            default:
              continue;
          }
        }
      }
      catch
      {
      }
      return reportContentSelector;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.EnableROSpecID, (int) this.EnableROSpecID_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.EnableSpecIndex, (int) this.EnableSpecIndex_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.EnableInventoryParameterSpecID, (int) this.EnableInventoryParameterSpecID_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.EnableAntennaID, (int) this.EnableAntennaID_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.EnableChannelIndex, (int) this.EnableChannelIndex_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.EnablePeakRSSI, (int) this.EnablePeakRSSI_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.EnableFirstSeenTimestamp, (int) this.EnableFirstSeenTimestamp_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.EnableLastSeenTimestamp, (int) this.EnableLastSeenTimestamp_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.EnableTagSeenCount, (int) this.EnableTagSeenCount_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.EnableAccessSpecID, (int) this.EnableAccessSpecID_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      cursor += 6;
      int count = this.AirProtocolEPCMemorySelector.Count;
      for (int index = 0; index < count; ++index)
        this.AirProtocolEPCMemorySelector[index].ToBitArray(ref bit_array, ref cursor);
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
