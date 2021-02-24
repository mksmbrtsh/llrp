// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.MSG_DISABLE_ROSPEC
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class MSG_DISABLE_ROSPEC : Message
  {
    public uint ROSpecID;
    private short ROSpecID_len;

    public MSG_DISABLE_ROSPEC()
    {
      this.msgType = (ushort) 25;
      this.MSG_ID = MessageID.getNewMessageID();
    }

    public override string ToString()
    {
      string str = "<DISABLE_ROSPEC" + string.Format(" xmlns=\"{0}\"\n", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0") + string.Format(" xmlns:llrp=\"{0}\"\n", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0") + " xmlns:xsi= \"http://www.w3.org/2001/XMLSchema-instance\"\n" + string.Format(" xsi:schemaLocation=\"{0} {1}\"\n", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0/llrp.xsd") + " Version=\"" + this.version.ToString() + "\" MessageID=\"" + this.MSG_ID.ToString() + "\">\r\n";
      try
      {
        str = str + "  <ROSpecID>" + Util.ConvertValueTypeToString((object) this.ROSpecID, "u32", "") + "</ROSpecID>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</DISABLE_ROSPEC>";
    }

    public static MSG_DISABLE_ROSPEC FromString(string str)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(str);
      XmlNode documentElement = (XmlNode) xmlDocument.DocumentElement;
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(documentElement.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      MSG_DISABLE_ROSPEC msgDisableRospec = new MSG_DISABLE_ROSPEC();
      try
      {
        msgDisableRospec.MSG_ID = Convert.ToUInt32(XmlUtil.GetNodeAttrValue(documentElement, "MessageID"));
      }
      catch
      {
      }
      string nodeValue = XmlUtil.GetNodeValue(documentElement, "ROSpecID");
      msgDisableRospec.ROSpecID = (uint) Util.ParseValueTypeFromString(nodeValue, "u32", "");
      return msgDisableRospec;
    }

    public override bool[] ToBitArray()
    {
      int num = 0;
      bool[] flagArray1 = new bool[33554432];
      BitArray bitArray1 = Util.ConvertIntToBitArray((uint) this.version, 3);
      int index1 = num + 3;
      bitArray1.CopyTo((Array) flagArray1, index1);
      int index2 = index1 + 3;
      Util.ConvertIntToBitArray((uint) this.msgType, 10).CopyTo((Array) flagArray1, index2);
      int index3 = index2 + 10;
      Util.ConvertIntToBitArray(this.msgLen, 32).CopyTo((Array) flagArray1, index3);
      int index4 = index3 + 32;
      Util.ConvertIntToBitArray(this.msgID, 32).CopyTo((Array) flagArray1, index4);
      int length = index4 + 32;
      try
      {
        BitArray bitArray2 = Util.ConvertObjToBitArray((object) this.ROSpecID, (int) this.ROSpecID_len);
        bitArray2.CopyTo((Array) flagArray1, length);
        length += bitArray2.Length;
      }
      catch
      {
      }
      Util.ConvertIntToBitArray((uint) length / 8U, 32).CopyTo((Array) flagArray1, 16);
      bool[] flagArray2 = new bool[length];
      Array.Copy((Array) flagArray1, 0, (Array) flagArray2, 0, length);
      return flagArray2;
    }

    public static MSG_DISABLE_ROSPEC FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor > length)
        return (MSG_DISABLE_ROSPEC) null;
      ArrayList arrayList = new ArrayList();
      MSG_DISABLE_ROSPEC msgDisableRospec = new MSG_DISABLE_ROSPEC();
      cursor += 6;
      if ((int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10) != (int) msgDisableRospec.msgType)
      {
        cursor -= 16;
        return (MSG_DISABLE_ROSPEC) null;
      }
      msgDisableRospec.msgLen = (uint) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 32);
      msgDisableRospec.msgID = (uint) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 32);
      if (cursor > length)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len = 32;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len);
      msgDisableRospec.ROSpecID = (uint) obj;
      return msgDisableRospec;
    }
  }
}
