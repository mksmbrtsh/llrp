// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_GPIEvent
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_GPIEvent : Parameter
  {
    private const ushort param_reserved_len4 = 7;
    public ushort GPIPortNumber;
    private short GPIPortNumber_len;
    public bool GPIEvent;
    private short GPIEvent_len;

    public PARAM_GPIEvent() => this.typeID = (ushort) 248;

    public static PARAM_GPIEvent FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_GPIEvent) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_GPIEvent paramGpiEvent = new PARAM_GPIEvent();
      paramGpiEvent.tvCoding = bit_array[cursor];
      int val;
      if (paramGpiEvent.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramGpiEvent.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramGpiEvent.length * 8;
      }
      if (val != (int) paramGpiEvent.TypeID)
      {
        cursor = num1;
        return (PARAM_GPIEvent) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len1);
      paramGpiEvent.GPIPortNumber = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len2);
      paramGpiEvent.GPIEvent = (bool) obj;
      cursor += 7;
      return paramGpiEvent;
    }

    public override string ToString()
    {
      string str = "<GPIEvent>" + "\r\n";
      try
      {
        str = str + "  <GPIPortNumber>" + Util.ConvertValueTypeToString((object) this.GPIPortNumber, "u16", "") + "</GPIPortNumber>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <GPIEvent>" + Util.ConvertValueTypeToString((object) this.GPIEvent, "u1", "") + "</GPIEvent>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</GPIEvent>" + "\r\n";
    }

    public static PARAM_GPIEvent FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_GPIEvent paramGpiEvent = new PARAM_GPIEvent();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "GPIPortNumber");
      paramGpiEvent.GPIPortNumber = (ushort) Util.ParseValueTypeFromString(nodeValue1, "u16", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "GPIEvent");
      paramGpiEvent.GPIEvent = (bool) Util.ParseValueTypeFromString(nodeValue2, "u1", "");
      return paramGpiEvent;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.GPIPortNumber, (int) this.GPIPortNumber_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.GPIEvent, (int) this.GPIEvent_len);
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
