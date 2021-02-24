// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_ROSpecEvent
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_ROSpecEvent : Parameter
  {
    public ENUM_ROSpecEventType EventType;
    private short EventType_len = 8;
    public uint ROSpecID;
    private short ROSpecID_len;
    public uint PreemptingROSpecID;
    private short PreemptingROSpecID_len;

    public PARAM_ROSpecEvent() => this.typeID = (ushort) 249;

    public static PARAM_ROSpecEvent FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_ROSpecEvent) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_ROSpecEvent paramRoSpecEvent = new PARAM_ROSpecEvent();
      paramRoSpecEvent.tvCoding = bit_array[cursor];
      int val;
      if (paramRoSpecEvent.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramRoSpecEvent.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramRoSpecEvent.length * 8;
      }
      if (val != (int) paramRoSpecEvent.TypeID)
      {
        cursor = num1;
        return (PARAM_ROSpecEvent) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 8;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len1);
      paramRoSpecEvent.EventType = (ENUM_ROSpecEventType) (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len2);
      paramRoSpecEvent.ROSpecID = (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len3 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len3);
      paramRoSpecEvent.PreemptingROSpecID = (uint) obj;
      return paramRoSpecEvent;
    }

    public override string ToString()
    {
      string str = "<ROSpecEvent>" + "\r\n";
      try
      {
        str = str + "  <EventType>" + this.EventType.ToString() + "</EventType>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <ROSpecID>" + Util.ConvertValueTypeToString((object) this.ROSpecID, "u32", "") + "</ROSpecID>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <PreemptingROSpecID>" + Util.ConvertValueTypeToString((object) this.PreemptingROSpecID, "u32", "") + "</PreemptingROSpecID>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</ROSpecEvent>" + "\r\n";
    }

    public static PARAM_ROSpecEvent FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_ROSpecEvent paramRoSpecEvent = new PARAM_ROSpecEvent();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "EventType");
      paramRoSpecEvent.EventType = (ENUM_ROSpecEventType) Enum.Parse(typeof (ENUM_ROSpecEventType), nodeValue1);
      string nodeValue2 = XmlUtil.GetNodeValue(node, "ROSpecID");
      paramRoSpecEvent.ROSpecID = (uint) Util.ParseValueTypeFromString(nodeValue2, "u32", "");
      string nodeValue3 = XmlUtil.GetNodeValue(node, "PreemptingROSpecID");
      paramRoSpecEvent.PreemptingROSpecID = (uint) Util.ParseValueTypeFromString(nodeValue3, "u32", "");
      return paramRoSpecEvent;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.EventType, (int) this.EventType_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.ROSpecID, (int) this.ROSpecID_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.PreemptingROSpecID, (int) this.PreemptingROSpecID_len);
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
