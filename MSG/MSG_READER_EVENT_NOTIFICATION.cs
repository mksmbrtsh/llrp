// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.MSG_READER_EVENT_NOTIFICATION
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class MSG_READER_EVENT_NOTIFICATION : Message
  {
    public PARAM_ReaderEventNotificationData ReaderEventNotificationData;

    public MSG_READER_EVENT_NOTIFICATION()
    {
      this.msgType = (ushort) 63;
      this.MSG_ID = MessageID.getNewMessageID();
    }

    public override string ToString()
    {
      string str = "<READER_EVENT_NOTIFICATION" + string.Format(" xmlns=\"{0}\"\n", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0") + string.Format(" xmlns:llrp=\"{0}\"\n", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0") + " xmlns:xsi= \"http://www.w3.org/2001/XMLSchema-instance\"\n" + string.Format(" xsi:schemaLocation=\"{0} {1}\"\n", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0/llrp.xsd") + " Version=\"" + this.version.ToString() + "\" MessageID=\"" + this.MSG_ID.ToString() + "\">\r\n";
      if (this.ReaderEventNotificationData != null)
        str += Util.Indent(this.ReaderEventNotificationData.ToString());
      return str + "</READER_EVENT_NOTIFICATION>";
    }

    public static MSG_READER_EVENT_NOTIFICATION FromString(string str)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(str);
      XmlNode documentElement = (XmlNode) xmlDocument.DocumentElement;
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(documentElement.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      MSG_READER_EVENT_NOTIFICATION eventNotification = new MSG_READER_EVENT_NOTIFICATION();
      try
      {
        eventNotification.MSG_ID = Convert.ToUInt32(XmlUtil.GetNodeAttrValue(documentElement, "MessageID"));
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(documentElement, "ReaderEventNotificationData", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            eventNotification.ReaderEventNotificationData = PARAM_ReaderEventNotificationData.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      return eventNotification;
    }

    public override bool[] ToBitArray()
    {
      int num = 0;
      bool[] bit_array = new bool[33554432];
      BitArray bitArray = Util.ConvertIntToBitArray((uint) this.version, 3);
      int index1 = num + 3;
      bitArray.CopyTo((Array) bit_array, index1);
      int index2 = index1 + 3;
      Util.ConvertIntToBitArray((uint) this.msgType, 10).CopyTo((Array) bit_array, index2);
      int index3 = index2 + 10;
      Util.ConvertIntToBitArray(this.msgLen, 32).CopyTo((Array) bit_array, index3);
      int index4 = index3 + 32;
      Util.ConvertIntToBitArray(this.msgID, 32).CopyTo((Array) bit_array, index4);
      int cursor = index4 + 32;
      if (this.ReaderEventNotificationData != null)
        this.ReaderEventNotificationData.ToBitArray(ref bit_array, ref cursor);
      Util.ConvertIntToBitArray((uint) cursor / 8U, 32).CopyTo((Array) bit_array, 16);
      bool[] flagArray = new bool[cursor];
      Array.Copy((Array) bit_array, 0, (Array) flagArray, 0, cursor);
      return flagArray;
    }

    public static MSG_READER_EVENT_NOTIFICATION FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor > length)
        return (MSG_READER_EVENT_NOTIFICATION) null;
      ArrayList arrayList = new ArrayList();
      MSG_READER_EVENT_NOTIFICATION eventNotification = new MSG_READER_EVENT_NOTIFICATION();
      cursor += 6;
      if ((int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10) != (int) eventNotification.msgType)
      {
        cursor -= 16;
        return (MSG_READER_EVENT_NOTIFICATION) null;
      }
      eventNotification.msgLen = (uint) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 32);
      eventNotification.msgID = (uint) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 32);
      eventNotification.ReaderEventNotificationData = PARAM_ReaderEventNotificationData.FromBitArray(ref bit_array, ref cursor, length);
      return eventNotification;
    }
  }
}
