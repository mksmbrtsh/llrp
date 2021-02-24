// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_FrequencyRSSILevelEntry
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_FrequencyRSSILevelEntry : Parameter
  {
    public uint Frequency;
    private short Frequency_len;
    public uint Bandwidth;
    private short Bandwidth_len;
    public sbyte AverageRSSI;
    private short AverageRSSI_len;
    public sbyte PeakRSSI;
    private short PeakRSSI_len;
    public UNION_Timestamp Timestamp = new UNION_Timestamp();

    public PARAM_FrequencyRSSILevelEntry() => this.typeID = (ushort) 243;

    public static PARAM_FrequencyRSSILevelEntry FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_FrequencyRSSILevelEntry) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_FrequencyRSSILevelEntry frequencyRssiLevelEntry = new PARAM_FrequencyRSSILevelEntry();
      frequencyRssiLevelEntry.tvCoding = bit_array[cursor];
      int val;
      if (frequencyRssiLevelEntry.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        frequencyRssiLevelEntry.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) frequencyRssiLevelEntry.length * 8;
      }
      if (val != (int) frequencyRssiLevelEntry.TypeID)
      {
        cursor = num1;
        return (PARAM_FrequencyRSSILevelEntry) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 32;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len1);
      frequencyRssiLevelEntry.Frequency = (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len2);
      frequencyRssiLevelEntry.Bandwidth = (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len3 = 8;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (sbyte), field_len3);
      frequencyRssiLevelEntry.AverageRSSI = (sbyte) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len4 = 8;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (sbyte), field_len4);
      frequencyRssiLevelEntry.PeakRSSI = (sbyte) obj;
      ushort num3 = 1;
      while (num3 != (ushort) 0)
      {
        num3 = (ushort) 0;
        PARAM_UTCTimestamp paramUtcTimestamp = PARAM_UTCTimestamp.FromBitArray(ref bit_array, ref cursor, length);
        if (paramUtcTimestamp != null)
        {
          ++num3;
          frequencyRssiLevelEntry.Timestamp.Add((IParameter) paramUtcTimestamp);
        }
        PARAM_Uptime paramUptime = PARAM_Uptime.FromBitArray(ref bit_array, ref cursor, length);
        if (paramUptime != null)
        {
          ++num3;
          frequencyRssiLevelEntry.Timestamp.Add((IParameter) paramUptime);
        }
      }
      return frequencyRssiLevelEntry;
    }

    public override string ToString()
    {
      string str = "<FrequencyRSSILevelEntry>" + "\r\n";
      try
      {
        str = str + "  <Frequency>" + Util.ConvertValueTypeToString((object) this.Frequency, "u32", "") + "</Frequency>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <Bandwidth>" + Util.ConvertValueTypeToString((object) this.Bandwidth, "u32", "") + "</Bandwidth>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <AverageRSSI>" + Util.ConvertValueTypeToString((object) this.AverageRSSI, "s8", "") + "</AverageRSSI>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <PeakRSSI>" + Util.ConvertValueTypeToString((object) this.PeakRSSI, "s8", "") + "</PeakRSSI>";
        str += "\r\n";
      }
      catch
      {
      }
      if (this.Timestamp != null)
      {
        int count = this.Timestamp.Count;
        for (int index = 0; index < count; ++index)
          str += Util.Indent(this.Timestamp[index].ToString());
      }
      return str + "</FrequencyRSSILevelEntry>" + "\r\n";
    }

    public static PARAM_FrequencyRSSILevelEntry FromXmlNode(
      XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_FrequencyRSSILevelEntry frequencyRssiLevelEntry = new PARAM_FrequencyRSSILevelEntry();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "Frequency");
      frequencyRssiLevelEntry.Frequency = (uint) Util.ParseValueTypeFromString(nodeValue1, "u32", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "Bandwidth");
      frequencyRssiLevelEntry.Bandwidth = (uint) Util.ParseValueTypeFromString(nodeValue2, "u32", "");
      string nodeValue3 = XmlUtil.GetNodeValue(node, "AverageRSSI");
      frequencyRssiLevelEntry.AverageRSSI = (sbyte) Util.ParseValueTypeFromString(nodeValue3, "s8", "");
      string nodeValue4 = XmlUtil.GetNodeValue(node, "PeakRSSI");
      frequencyRssiLevelEntry.PeakRSSI = (sbyte) Util.ParseValueTypeFromString(nodeValue4, "s8", "");
      frequencyRssiLevelEntry.Timestamp = new UNION_Timestamp();
      try
      {
        foreach (XmlNode childNode in node.ChildNodes)
        {
          switch (childNode.Name)
          {
            case "UTCTimestamp":
              frequencyRssiLevelEntry.Timestamp.Add((IParameter) PARAM_UTCTimestamp.FromXmlNode(childNode));
              continue;
            case "Uptime":
              frequencyRssiLevelEntry.Timestamp.Add((IParameter) PARAM_Uptime.FromXmlNode(childNode));
              continue;
            default:
              continue;
          }
        }
      }
      catch
      {
      }
      return frequencyRssiLevelEntry;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.Frequency, (int) this.Frequency_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.Bandwidth, (int) this.Bandwidth_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.AverageRSSI, (int) this.AverageRSSI_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.PeakRSSI, (int) this.PeakRSSI_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      int count = this.Timestamp.Count;
      for (int index = 0; index < count; ++index)
        this.Timestamp[index].ToBitArray(ref bit_array, ref cursor);
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
