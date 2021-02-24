// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_AntennaProperties
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_AntennaProperties : Parameter
  {
    private const ushort param_reserved_len3 = 7;
    public bool AntennaConnected;
    private short AntennaConnected_len;
    public ushort AntennaID;
    private short AntennaID_len;
    public short AntennaGain;
    private short AntennaGain_len;

    public PARAM_AntennaProperties() => this.typeID = (ushort) 221;

    public static PARAM_AntennaProperties FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_AntennaProperties) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_AntennaProperties antennaProperties = new PARAM_AntennaProperties();
      antennaProperties.tvCoding = bit_array[cursor];
      int val;
      if (antennaProperties.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        antennaProperties.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) antennaProperties.length * 8;
      }
      if (val != (int) antennaProperties.TypeID)
      {
        cursor = num1;
        return (PARAM_AntennaProperties) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 1;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len1);
      antennaProperties.AntennaConnected = (bool) obj;
      cursor += 7;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len2);
      antennaProperties.AntennaID = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len3 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (short), field_len3);
      antennaProperties.AntennaGain = (short) obj;
      return antennaProperties;
    }

    public override string ToString()
    {
      string str = "<AntennaProperties>" + "\r\n";
      try
      {
        str = str + "  <AntennaConnected>" + Util.ConvertValueTypeToString((object) this.AntennaConnected, "u1", "") + "</AntennaConnected>";
        str += "\r\n";
      }
      catch
      {
      }
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
        str = str + "  <AntennaGain>" + Util.ConvertValueTypeToString((object) this.AntennaGain, "s16", "") + "</AntennaGain>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</AntennaProperties>" + "\r\n";
    }

    public static PARAM_AntennaProperties FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_AntennaProperties antennaProperties = new PARAM_AntennaProperties();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "AntennaConnected");
      antennaProperties.AntennaConnected = (bool) Util.ParseValueTypeFromString(nodeValue1, "u1", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "AntennaID");
      antennaProperties.AntennaID = (ushort) Util.ParseValueTypeFromString(nodeValue2, "u16", "");
      string nodeValue3 = XmlUtil.GetNodeValue(node, "AntennaGain");
      antennaProperties.AntennaGain = (short) Util.ParseValueTypeFromString(nodeValue3, "s16", "");
      return antennaProperties;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.AntennaConnected, (int) this.AntennaConnected_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      cursor += 7;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.AntennaGain, (int) this.AntennaGain_len);
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
