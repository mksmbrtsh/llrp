// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_GPOWriteData
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_GPOWriteData : Parameter
  {
    private const ushort param_reserved_len4 = 7;
    public ushort GPOPortNumber;
    private short GPOPortNumber_len;
    public bool GPOData;
    private short GPOData_len;

    public PARAM_GPOWriteData() => this.typeID = (ushort) 219;

    public static PARAM_GPOWriteData FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_GPOWriteData) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_GPOWriteData paramGpoWriteData = new PARAM_GPOWriteData();
      paramGpoWriteData.tvCoding = bit_array[cursor];
      int val;
      if (paramGpoWriteData.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramGpoWriteData.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramGpoWriteData.length * 8;
      }
      if (val != (int) paramGpoWriteData.TypeID)
      {
        cursor = num1;
        return (PARAM_GPOWriteData) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len1);
      paramGpoWriteData.GPOPortNumber = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len2);
      paramGpoWriteData.GPOData = (bool) obj;
      cursor += 7;
      return paramGpoWriteData;
    }

    public override string ToString()
    {
      string str = "<GPOWriteData>" + "\r\n";
      try
      {
        str = str + "  <GPOPortNumber>" + Util.ConvertValueTypeToString((object) this.GPOPortNumber, "u16", "") + "</GPOPortNumber>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <GPOData>" + Util.ConvertValueTypeToString((object) this.GPOData, "u1", "") + "</GPOData>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</GPOWriteData>" + "\r\n";
    }

    public static PARAM_GPOWriteData FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_GPOWriteData paramGpoWriteData = new PARAM_GPOWriteData();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "GPOPortNumber");
      paramGpoWriteData.GPOPortNumber = (ushort) Util.ParseValueTypeFromString(nodeValue1, "u16", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "GPOData");
      paramGpoWriteData.GPOData = (bool) Util.ParseValueTypeFromString(nodeValue2, "u1", "");
      return paramGpoWriteData;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.GPOPortNumber, (int) this.GPOPortNumber_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.GPOData, (int) this.GPOData_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      cursor += 7;
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
