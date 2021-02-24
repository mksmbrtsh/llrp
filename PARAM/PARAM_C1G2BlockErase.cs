// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2BlockErase
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2BlockErase : Parameter
  {
    private const ushort param_reserved_len5 = 6;
    public ushort OpSpecID;
    private short OpSpecID_len;
    public uint AccessPassword;
    private short AccessPassword_len;
    public TwoBits MB = new TwoBits((ushort) 0);
    private short MB_len;
    public ushort WordPointer;
    private short WordPointer_len;
    public ushort WordCount;
    private short WordCount_len;

    public PARAM_C1G2BlockErase() => this.typeID = (ushort) 346;

    public static PARAM_C1G2BlockErase FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2BlockErase) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_C1G2BlockErase paramC1G2BlockErase = new PARAM_C1G2BlockErase();
      paramC1G2BlockErase.tvCoding = bit_array[cursor];
      int val;
      if (paramC1G2BlockErase.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramC1G2BlockErase.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramC1G2BlockErase.length * 8;
      }
      if (val != (int) paramC1G2BlockErase.TypeID)
      {
        cursor = num1;
        return (PARAM_C1G2BlockErase) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len1);
      paramC1G2BlockErase.OpSpecID = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len2);
      paramC1G2BlockErase.AccessPassword = (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len3 = 2;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (TwoBits), field_len3);
      paramC1G2BlockErase.MB = (TwoBits) obj;
      cursor += 6;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len4 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len4);
      paramC1G2BlockErase.WordPointer = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len5 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len5);
      paramC1G2BlockErase.WordCount = (ushort) obj;
      return paramC1G2BlockErase;
    }

    public override string ToString()
    {
      string str = "<C1G2BlockErase>" + "\r\n";
      try
      {
        str = str + "  <OpSpecID>" + Util.ConvertValueTypeToString((object) this.OpSpecID, "u16", "") + "</OpSpecID>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <AccessPassword>" + Util.ConvertValueTypeToString((object) this.AccessPassword, "u32", "") + "</AccessPassword>";
        str += "\r\n";
      }
      catch
      {
      }
      if (this.MB != null)
      {
        try
        {
          str = str + "  <MB>" + this.MB.ToString() + "</MB>";
          str += "\r\n";
        }
        catch
        {
        }
      }
      try
      {
        str = str + "  <WordPointer>" + Util.ConvertValueTypeToString((object) this.WordPointer, "u16", "") + "</WordPointer>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <WordCount>" + Util.ConvertValueTypeToString((object) this.WordCount, "u16", "") + "</WordCount>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</C1G2BlockErase>" + "\r\n";
    }

    public static PARAM_C1G2BlockErase FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2BlockErase paramC1G2BlockErase = new PARAM_C1G2BlockErase();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "OpSpecID");
      paramC1G2BlockErase.OpSpecID = (ushort) Util.ParseValueTypeFromString(nodeValue1, "u16", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "AccessPassword");
      paramC1G2BlockErase.AccessPassword = (uint) Util.ParseValueTypeFromString(nodeValue2, "u32", "");
      string nodeValue3 = XmlUtil.GetNodeValue(node, "MB");
      paramC1G2BlockErase.MB = TwoBits.FromString(nodeValue3);
      string nodeValue4 = XmlUtil.GetNodeValue(node, "WordPointer");
      paramC1G2BlockErase.WordPointer = (ushort) Util.ParseValueTypeFromString(nodeValue4, "u16", "");
      string nodeValue5 = XmlUtil.GetNodeValue(node, "WordCount");
      paramC1G2BlockErase.WordCount = (ushort) Util.ParseValueTypeFromString(nodeValue5, "u16", "");
      return paramC1G2BlockErase;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.OpSpecID, (int) this.OpSpecID_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.AccessPassword, (int) this.AccessPassword_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      if (this.MB != null)
      {
        try
        {
          BitArray bitArray = Util.ConvertObjToBitArray((object) this.MB, (int) this.MB_len);
          bitArray.CopyTo((Array) bit_array, cursor);
          cursor += bitArray.Length;
        }
        catch
        {
        }
      }
      cursor += 6;
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.WordPointer, (int) this.WordPointer_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.WordCount, (int) this.WordCount_len);
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
