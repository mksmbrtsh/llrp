// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_EventNotificationState
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_EventNotificationState : Parameter
  {
    private const ushort param_reserved_len4 = 7;
    public ENUM_NotificationEventType EventType;
    private short EventType_len = 16;
    public bool NotificationState;
    private short NotificationState_len;

    public PARAM_EventNotificationState() => this.typeID = (ushort) 245;

    public static PARAM_EventNotificationState FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_EventNotificationState) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_EventNotificationState notificationState = new PARAM_EventNotificationState();
      notificationState.tvCoding = bit_array[cursor];
      int val;
      if (notificationState.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        notificationState.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) notificationState.length * 8;
      }
      if (val != (int) notificationState.TypeID)
      {
        cursor = num1;
        return (PARAM_EventNotificationState) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len1);
      notificationState.EventType = (ENUM_NotificationEventType) (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len2);
      notificationState.NotificationState = (bool) obj;
      cursor += 7;
      return notificationState;
    }

    public override string ToString()
    {
      string str = "<EventNotificationState>" + "\r\n";
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
        str = str + "  <NotificationState>" + Util.ConvertValueTypeToString((object) this.NotificationState, "u1", "") + "</NotificationState>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</EventNotificationState>" + "\r\n";
    }

    public static PARAM_EventNotificationState FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_EventNotificationState notificationState = new PARAM_EventNotificationState();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "EventType");
      notificationState.EventType = (ENUM_NotificationEventType) Enum.Parse(typeof (ENUM_NotificationEventType), nodeValue1);
      string nodeValue2 = XmlUtil.GetNodeValue(node, "NotificationState");
      notificationState.NotificationState = (bool) Util.ParseValueTypeFromString(nodeValue2, "u1", "");
      return notificationState;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.NotificationState, (int) this.NotificationState_len);
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
