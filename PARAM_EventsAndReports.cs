// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_EventsAndReports
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_EventsAndReports : Parameter
  {
    private const ushort param_reserved_len3 = 7;
    public bool HoldEventsAndReportsUponReconnect;
    private short HoldEventsAndReportsUponReconnect_len;

    public PARAM_EventsAndReports() => this.typeID = (ushort) 226;

    public static PARAM_EventsAndReports FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_EventsAndReports) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_EventsAndReports eventsAndReports = new PARAM_EventsAndReports();
      eventsAndReports.tvCoding = bit_array[cursor];
      int val;
      if (eventsAndReports.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        eventsAndReports.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) eventsAndReports.length * 8;
      }
      if (val != (int) eventsAndReports.TypeID)
      {
        cursor = num1;
        return (PARAM_EventsAndReports) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len = 1;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len);
      eventsAndReports.HoldEventsAndReportsUponReconnect = (bool) obj;
      cursor += 7;
      return eventsAndReports;
    }

    public override string ToString()
    {
      string str = "<EventsAndReports>" + "\r\n";
      try
      {
        str = str + "  <HoldEventsAndReportsUponReconnect>" + Util.ConvertValueTypeToString((object) this.HoldEventsAndReportsUponReconnect, "u1", "") + "</HoldEventsAndReportsUponReconnect>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</EventsAndReports>" + "\r\n";
    }

    public static PARAM_EventsAndReports FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_EventsAndReports eventsAndReports = new PARAM_EventsAndReports();
      string nodeValue = XmlUtil.GetNodeValue(node, "HoldEventsAndReportsUponReconnect");
      eventsAndReports.HoldEventsAndReportsUponReconnect = (bool) Util.ParseValueTypeFromString(nodeValue, "u1", "");
      return eventsAndReports;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.HoldEventsAndReportsUponReconnect, (int) this.HoldEventsAndReportsUponReconnect_len);
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
