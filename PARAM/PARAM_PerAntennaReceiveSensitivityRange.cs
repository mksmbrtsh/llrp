// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_PerAntennaReceiveSensitivityRange
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_PerAntennaReceiveSensitivityRange : Parameter
  {
    public ushort AntennaID;
    private short AntennaID_len;
    public ushort ReceiveSensitivityIndexMin;
    private short ReceiveSensitivityIndexMin_len;
    public ushort ReceiveSensitivityIndexMax;
    private short ReceiveSensitivityIndexMax_len;

    public PARAM_PerAntennaReceiveSensitivityRange() => this.typeID = (ushort) 149;

    public static PARAM_PerAntennaReceiveSensitivityRange FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_PerAntennaReceiveSensitivityRange) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_PerAntennaReceiveSensitivityRange sensitivityRange = new PARAM_PerAntennaReceiveSensitivityRange();
      sensitivityRange.tvCoding = bit_array[cursor];
      int val;
      if (sensitivityRange.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        sensitivityRange.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) sensitivityRange.length * 8;
      }
      if (val != (int) sensitivityRange.TypeID)
      {
        cursor = num1;
        return (PARAM_PerAntennaReceiveSensitivityRange) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len1);
      sensitivityRange.AntennaID = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len2);
      sensitivityRange.ReceiveSensitivityIndexMin = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len3 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len3);
      sensitivityRange.ReceiveSensitivityIndexMax = (ushort) obj;
      return sensitivityRange;
    }

    public override string ToString()
    {
      string str = "<PerAntennaReceiveSensitivityRange>" + "\r\n";
      try
      {
        str = str + "  <AntennaID>" + Util.ConvertValueTypeToString((object) this.AntennaID, "u16", "") + "</AntennaID>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <ReceiveSensitivityIndexMin>" + Util.ConvertValueTypeToString((object) this.ReceiveSensitivityIndexMin, "u16", "") + "</ReceiveSensitivityIndexMin>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <ReceiveSensitivityIndexMax>" + Util.ConvertValueTypeToString((object) this.ReceiveSensitivityIndexMax, "u16", "") + "</ReceiveSensitivityIndexMax>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</PerAntennaReceiveSensitivityRange>" + "\r\n";
    }

    public static PARAM_PerAntennaReceiveSensitivityRange FromXmlNode(
      XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_PerAntennaReceiveSensitivityRange sensitivityRange = new PARAM_PerAntennaReceiveSensitivityRange();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "AntennaID");
      sensitivityRange.AntennaID = (ushort) Util.ParseValueTypeFromString(nodeValue1, "u16", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "ReceiveSensitivityIndexMin");
      sensitivityRange.ReceiveSensitivityIndexMin = (ushort) Util.ParseValueTypeFromString(nodeValue2, "u16", "");
      string nodeValue3 = XmlUtil.GetNodeValue(node, "ReceiveSensitivityIndexMax");
      sensitivityRange.ReceiveSensitivityIndexMax = (ushort) Util.ParseValueTypeFromString(nodeValue3, "u16", "");
      return sensitivityRange;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.AntennaID, (int) this.AntennaID_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.ReceiveSensitivityIndexMin, (int) this.ReceiveSensitivityIndexMin_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.ReceiveSensitivityIndexMax, (int) this.ReceiveSensitivityIndexMax_len);
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
