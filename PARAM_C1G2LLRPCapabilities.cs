// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2LLRPCapabilities
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2LLRPCapabilities : Parameter
  {
    private const ushort param_reserved_len4 = 6;
    public bool CanSupportBlockErase;
    private short CanSupportBlockErase_len;
    public bool CanSupportBlockWrite;
    private short CanSupportBlockWrite_len;
    public ushort MaxNumSelectFiltersPerQuery;
    private short MaxNumSelectFiltersPerQuery_len;

    public PARAM_C1G2LLRPCapabilities() => this.typeID = (ushort) 327;

    public static PARAM_C1G2LLRPCapabilities FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2LLRPCapabilities) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_C1G2LLRPCapabilities llrpCapabilities = new PARAM_C1G2LLRPCapabilities();
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
        return (PARAM_C1G2LLRPCapabilities) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 1;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len1);
      llrpCapabilities.CanSupportBlockErase = (bool) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len2);
      llrpCapabilities.CanSupportBlockWrite = (bool) obj;
      cursor += 6;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len3 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len3);
      llrpCapabilities.MaxNumSelectFiltersPerQuery = (ushort) obj;
      return llrpCapabilities;
    }

    public override string ToString()
    {
      string str = "<C1G2LLRPCapabilities>" + "\r\n";
      try
      {
        str = str + "  <CanSupportBlockErase>" + Util.ConvertValueTypeToString((object) this.CanSupportBlockErase, "u1", "") + "</CanSupportBlockErase>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <CanSupportBlockWrite>" + Util.ConvertValueTypeToString((object) this.CanSupportBlockWrite, "u1", "") + "</CanSupportBlockWrite>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <MaxNumSelectFiltersPerQuery>" + Util.ConvertValueTypeToString((object) this.MaxNumSelectFiltersPerQuery, "u16", "") + "</MaxNumSelectFiltersPerQuery>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</C1G2LLRPCapabilities>" + "\r\n";
    }

    public static PARAM_C1G2LLRPCapabilities FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2LLRPCapabilities llrpCapabilities = new PARAM_C1G2LLRPCapabilities();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "CanSupportBlockErase");
      llrpCapabilities.CanSupportBlockErase = (bool) Util.ParseValueTypeFromString(nodeValue1, "u1", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "CanSupportBlockWrite");
      llrpCapabilities.CanSupportBlockWrite = (bool) Util.ParseValueTypeFromString(nodeValue2, "u1", "");
      string nodeValue3 = XmlUtil.GetNodeValue(node, "MaxNumSelectFiltersPerQuery");
      llrpCapabilities.MaxNumSelectFiltersPerQuery = (ushort) Util.ParseValueTypeFromString(nodeValue3, "u16", "");
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.CanSupportBlockErase, (int) this.CanSupportBlockErase_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.CanSupportBlockWrite, (int) this.CanSupportBlockWrite_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      cursor += 6;
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.MaxNumSelectFiltersPerQuery, (int) this.MaxNumSelectFiltersPerQuery_len);
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
