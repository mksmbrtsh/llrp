// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2ReadOpSpecResult
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2ReadOpSpecResult : Parameter
  {
    public ENUM_C1G2ReadResultType Result;
    private short Result_len = 8;
    public ushort OpSpecID;
    private short OpSpecID_len;
    public UInt16Array ReadData = new UInt16Array();
    private short ReadData_len;

    public PARAM_C1G2ReadOpSpecResult() => this.typeID = (ushort) 349;

    public static PARAM_C1G2ReadOpSpecResult FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2ReadOpSpecResult) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_C1G2ReadOpSpecResult readOpSpecResult = new PARAM_C1G2ReadOpSpecResult();
      readOpSpecResult.tvCoding = bit_array[cursor];
      int val;
      if (readOpSpecResult.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        readOpSpecResult.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) readOpSpecResult.length * 8;
      }
      if (val != (int) readOpSpecResult.TypeID)
      {
        cursor = num1;
        return (PARAM_C1G2ReadOpSpecResult) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 8;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len1);
      readOpSpecResult.Result = (ENUM_C1G2ReadResultType) (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len2);
      readOpSpecResult.OpSpecID = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int fieldLength = Util.DetermineFieldLength(ref bit_array, ref cursor);
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (UInt16Array), fieldLength);
      readOpSpecResult.ReadData = (UInt16Array) obj;
      return readOpSpecResult;
    }

    public override string ToString()
    {
      string str = "<C1G2ReadOpSpecResult>" + "\r\n";
      try
      {
        str = str + "  <Result>" + this.Result.ToString() + "</Result>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <OpSpecID>" + Util.ConvertValueTypeToString((object) this.OpSpecID, "u16", "") + "</OpSpecID>";
        str += "\r\n";
      }
      catch
      {
      }
      if (this.ReadData != null)
      {
        try
        {
          str = str + "  <ReadData>" + Util.ConvertArrayTypeToString((object) this.ReadData, "u16v", "Hex") + "</ReadData>";
          str += "\r\n";
        }
        catch
        {
        }
      }
      return str + "</C1G2ReadOpSpecResult>" + "\r\n";
    }

    public static PARAM_C1G2ReadOpSpecResult FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2ReadOpSpecResult readOpSpecResult = new PARAM_C1G2ReadOpSpecResult();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "Result");
      readOpSpecResult.Result = (ENUM_C1G2ReadResultType) Enum.Parse(typeof (ENUM_C1G2ReadResultType), nodeValue1);
      string nodeValue2 = XmlUtil.GetNodeValue(node, "OpSpecID");
      readOpSpecResult.OpSpecID = (ushort) Util.ParseValueTypeFromString(nodeValue2, "u16", "");
      string nodeValue3 = XmlUtil.GetNodeValue(node, "ReadData");
      readOpSpecResult.ReadData = (UInt16Array) Util.ParseArrayTypeFromString(nodeValue3, "u16v", "Hex");
      return readOpSpecResult;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.Result, (int) this.Result_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
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
      if (this.ReadData != null)
      {
        try
        {
          Util.ConvertIntToBitArray((uint) this.ReadData.Count, 16).CopyTo((Array) bit_array, cursor);
          cursor += 16;
          BitArray bitArray = Util.ConvertObjToBitArray((object) this.ReadData, (int) this.ReadData_len);
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
