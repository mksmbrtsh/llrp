// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_HoppingEvent
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_HoppingEvent : Parameter
  {
    public ushort HopTableID;
    private short HopTableID_len;
    public ushort NextChannelIndex;
    private short NextChannelIndex_len;

    public PARAM_HoppingEvent() => this.typeID = (ushort) 247;

    public static PARAM_HoppingEvent FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_HoppingEvent) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_HoppingEvent paramHoppingEvent = new PARAM_HoppingEvent();
      paramHoppingEvent.tvCoding = bit_array[cursor];
      int val;
      if (paramHoppingEvent.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramHoppingEvent.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramHoppingEvent.length * 8;
      }
      if (val != (int) paramHoppingEvent.TypeID)
      {
        cursor = num1;
        return (PARAM_HoppingEvent) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len1);
      paramHoppingEvent.HopTableID = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len2);
      paramHoppingEvent.NextChannelIndex = (ushort) obj;
      return paramHoppingEvent;
    }

    public override string ToString()
    {
      string str = "<HoppingEvent>" + "\r\n";
      try
      {
        str = str + "  <HopTableID>" + Util.ConvertValueTypeToString((object) this.HopTableID, "u16", "") + "</HopTableID>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <NextChannelIndex>" + Util.ConvertValueTypeToString((object) this.NextChannelIndex, "u16", "") + "</NextChannelIndex>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</HoppingEvent>" + "\r\n";
    }

    public static PARAM_HoppingEvent FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_HoppingEvent paramHoppingEvent = new PARAM_HoppingEvent();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "HopTableID");
      paramHoppingEvent.HopTableID = (ushort) Util.ParseValueTypeFromString(nodeValue1, "u16", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "NextChannelIndex");
      paramHoppingEvent.NextChannelIndex = (ushort) Util.ParseValueTypeFromString(nodeValue2, "u16", "");
      return paramHoppingEvent;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.HopTableID, (int) this.HopTableID_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.NextChannelIndex, (int) this.NextChannelIndex_len);
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
