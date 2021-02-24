// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_GPIOCapabilities
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_GPIOCapabilities : Parameter
  {
    public ushort NumGPIs;
    private short NumGPIs_len;
    public ushort NumGPOs;
    private short NumGPOs_len;

    public PARAM_GPIOCapabilities() => this.typeID = (ushort) 141;

    public static PARAM_GPIOCapabilities FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_GPIOCapabilities) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_GPIOCapabilities gpioCapabilities = new PARAM_GPIOCapabilities();
      gpioCapabilities.tvCoding = bit_array[cursor];
      int val;
      if (gpioCapabilities.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        gpioCapabilities.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) gpioCapabilities.length * 8;
      }
      if (val != (int) gpioCapabilities.TypeID)
      {
        cursor = num1;
        return (PARAM_GPIOCapabilities) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len1);
      gpioCapabilities.NumGPIs = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len2);
      gpioCapabilities.NumGPOs = (ushort) obj;
      return gpioCapabilities;
    }

    public override string ToString()
    {
      string str = "<GPIOCapabilities>" + "\r\n";
      try
      {
        str = str + "  <NumGPIs>" + Util.ConvertValueTypeToString((object) this.NumGPIs, "u16", "") + "</NumGPIs>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <NumGPOs>" + Util.ConvertValueTypeToString((object) this.NumGPOs, "u16", "") + "</NumGPOs>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</GPIOCapabilities>" + "\r\n";
    }

    public static PARAM_GPIOCapabilities FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_GPIOCapabilities gpioCapabilities = new PARAM_GPIOCapabilities();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "NumGPIs");
      gpioCapabilities.NumGPIs = (ushort) Util.ParseValueTypeFromString(nodeValue1, "u16", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "NumGPOs");
      gpioCapabilities.NumGPOs = (ushort) Util.ParseValueTypeFromString(nodeValue2, "u16", "");
      return gpioCapabilities;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.NumGPIs, (int) this.NumGPIs_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.NumGPOs, (int) this.NumGPOs_len);
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
