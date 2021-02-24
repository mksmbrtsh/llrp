// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_AISpecEvent
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_AISpecEvent : Parameter
  {
    public ENUM_AISpecEventType EventType;
    private short EventType_len = 8;
    public uint ROSpecID;
    private short ROSpecID_len;
    public ushort SpecIndex;
    private short SpecIndex_len;
    public UNION_AirProtocolSingulationDetails AirProtocolSingulationDetails = new UNION_AirProtocolSingulationDetails();

    public PARAM_AISpecEvent() => this.typeID = (ushort) 254;

    public static PARAM_AISpecEvent FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_AISpecEvent) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_AISpecEvent paramAiSpecEvent = new PARAM_AISpecEvent();
      paramAiSpecEvent.tvCoding = bit_array[cursor];
      int val;
      if (paramAiSpecEvent.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramAiSpecEvent.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramAiSpecEvent.length * 8;
      }
      if (val != (int) paramAiSpecEvent.TypeID)
      {
        cursor = num1;
        return (PARAM_AISpecEvent) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 8;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len1);
      paramAiSpecEvent.EventType = (ENUM_AISpecEventType) (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len2);
      paramAiSpecEvent.ROSpecID = (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len3 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len3);
      paramAiSpecEvent.SpecIndex = (ushort) obj;
      ushort num3 = 1;
      while (num3 != (ushort) 0)
      {
        num3 = (ushort) 0;
        PARAM_C1G2SingulationDetails singulationDetails = PARAM_C1G2SingulationDetails.FromBitArray(ref bit_array, ref cursor, length);
        if (singulationDetails != null)
        {
          ++num3;
          paramAiSpecEvent.AirProtocolSingulationDetails.Add((IParameter) singulationDetails);
        }
      }
      return paramAiSpecEvent;
    }

    public override string ToString()
    {
      string str = "<AISpecEvent>" + "\r\n";
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
        str = str + "  <SpecIndex>" + Util.ConvertValueTypeToString((object) this.SpecIndex, "u16", "") + "</SpecIndex>";
        str += "\r\n";
      }
      catch
      {
      }
      if (this.AirProtocolSingulationDetails != null)
      {
        int count = this.AirProtocolSingulationDetails.Count;
        for (int index = 0; index < count; ++index)
          str += Util.Indent(this.AirProtocolSingulationDetails[index].ToString());
      }
      return str + "</AISpecEvent>" + "\r\n";
    }

    public static PARAM_AISpecEvent FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_AISpecEvent paramAiSpecEvent = new PARAM_AISpecEvent();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "EventType");
      paramAiSpecEvent.EventType = (ENUM_AISpecEventType) Enum.Parse(typeof (ENUM_AISpecEventType), nodeValue1);
      string nodeValue2 = XmlUtil.GetNodeValue(node, "ROSpecID");
      paramAiSpecEvent.ROSpecID = (uint) Util.ParseValueTypeFromString(nodeValue2, "u32", "");
      string nodeValue3 = XmlUtil.GetNodeValue(node, "SpecIndex");
      paramAiSpecEvent.SpecIndex = (ushort) Util.ParseValueTypeFromString(nodeValue3, "u16", "");
      paramAiSpecEvent.AirProtocolSingulationDetails = new UNION_AirProtocolSingulationDetails();
      try
      {
        foreach (XmlNode childNode in node.ChildNodes)
        {
          switch (childNode.Name)
          {
            case "C1G2SingulationDetails":
              paramAiSpecEvent.AirProtocolSingulationDetails.Add((IParameter) PARAM_C1G2SingulationDetails.FromXmlNode(childNode));
              continue;
            default:
              continue;
          }
        }
      }
      catch
      {
      }
      return paramAiSpecEvent;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.SpecIndex, (int) this.SpecIndex_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      int count = this.AirProtocolSingulationDetails.Count;
      for (int index = 0; index < count; ++index)
        this.AirProtocolSingulationDetails[index].ToBitArray(ref bit_array, ref cursor);
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
