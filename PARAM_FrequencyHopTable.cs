// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_FrequencyHopTable
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_FrequencyHopTable : Parameter
  {
    private const ushort param_reserved_len3 = 8;
    public byte HopTableID;
    private short HopTableID_len;
    public UInt32Array Frequency = new UInt32Array();
    private short Frequency_len;

    public PARAM_FrequencyHopTable() => this.typeID = (ushort) 147;

    public static PARAM_FrequencyHopTable FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_FrequencyHopTable) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_FrequencyHopTable frequencyHopTable = new PARAM_FrequencyHopTable();
      frequencyHopTable.tvCoding = bit_array[cursor];
      int val;
      if (frequencyHopTable.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        frequencyHopTable.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) frequencyHopTable.length * 8;
      }
      if (val != (int) frequencyHopTable.TypeID)
      {
        cursor = num1;
        return (PARAM_FrequencyHopTable) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len = 8;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (byte), field_len);
      frequencyHopTable.HopTableID = (byte) obj;
      cursor += 8;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int fieldLength = Util.DetermineFieldLength(ref bit_array, ref cursor);
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (UInt32Array), fieldLength);
      frequencyHopTable.Frequency = (UInt32Array) obj;
      return frequencyHopTable;
    }

    public override string ToString()
    {
      string str = "<FrequencyHopTable>" + "\r\n";
      try
      {
        str = str + "  <HopTableID>" + Util.ConvertValueTypeToString((object) this.HopTableID, "u8", "") + "</HopTableID>";
        str += "\r\n";
      }
      catch
      {
      }
      if (this.Frequency != null)
      {
        try
        {
          str = str + "  <Frequency>" + Util.ConvertArrayTypeToString((object) this.Frequency, "u32v", "") + "</Frequency>";
          str += "\r\n";
        }
        catch
        {
        }
      }
      return str + "</FrequencyHopTable>" + "\r\n";
    }

    public static PARAM_FrequencyHopTable FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_FrequencyHopTable frequencyHopTable = new PARAM_FrequencyHopTable();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "HopTableID");
      frequencyHopTable.HopTableID = (byte) Util.ParseValueTypeFromString(nodeValue1, "u8", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "Frequency");
      frequencyHopTable.Frequency = (UInt32Array) Util.ParseArrayTypeFromString(nodeValue2, "u32v", "");
      return frequencyHopTable;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.HopTableID, (int) this.HopTableID_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      cursor += 8;
      if (this.Frequency != null)
      {
        try
        {
          Util.ConvertIntToBitArray((uint) this.Frequency.Count, 16).CopyTo((Array) bit_array, cursor);
          cursor += 16;
          BitArray bitArray = Util.ConvertObjToBitArray((object) this.Frequency, (int) this.Frequency_len);
          bitArray.CopyTo((Array) bit_array, cursor);
          cursor += bitArray.Length;
        }
        catch
        {
        }
      }
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
