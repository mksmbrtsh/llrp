// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2BlockEraseOpSpecResult
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2BlockEraseOpSpecResult : Parameter
  {
    public ENUM_C1G2BlockEraseResultType Result;
    private short Result_len = 8;
    public ushort OpSpecID;
    private short OpSpecID_len;

    public PARAM_C1G2BlockEraseOpSpecResult() => this.typeID = (ushort) 353;

    public static PARAM_C1G2BlockEraseOpSpecResult FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2BlockEraseOpSpecResult) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_C1G2BlockEraseOpSpecResult eraseOpSpecResult = new PARAM_C1G2BlockEraseOpSpecResult();
      eraseOpSpecResult.tvCoding = bit_array[cursor];
      int val;
      if (eraseOpSpecResult.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        eraseOpSpecResult.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) eraseOpSpecResult.length * 8;
      }
      if (val != (int) eraseOpSpecResult.TypeID)
      {
        cursor = num1;
        return (PARAM_C1G2BlockEraseOpSpecResult) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 8;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len1);
      eraseOpSpecResult.Result = (ENUM_C1G2BlockEraseResultType) (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len2);
      eraseOpSpecResult.OpSpecID = (ushort) obj;
      return eraseOpSpecResult;
    }

    public override string ToString()
    {
      string str = "<C1G2BlockEraseOpSpecResult>" + "\r\n";
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
      return str + "</C1G2BlockEraseOpSpecResult>" + "\r\n";
    }

    public static PARAM_C1G2BlockEraseOpSpecResult FromXmlNode(
      XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2BlockEraseOpSpecResult eraseOpSpecResult = new PARAM_C1G2BlockEraseOpSpecResult();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "Result");
      eraseOpSpecResult.Result = (ENUM_C1G2BlockEraseResultType) Enum.Parse(typeof (ENUM_C1G2BlockEraseResultType), nodeValue1);
      string nodeValue2 = XmlUtil.GetNodeValue(node, "OpSpecID");
      eraseOpSpecResult.OpSpecID = (ushort) Util.ParseValueTypeFromString(nodeValue2, "u16", "");
      return eraseOpSpecResult;
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
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
