// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.MSG_CUSTOM_MESSAGE
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class MSG_CUSTOM_MESSAGE : Message
  {
    protected uint VendorIdentifier;
    protected byte MessageSubtype;
    protected ByteArray Data;
    private short VendorIdentifier_len;
    private short MessageSubtype_len;
    private short Data_len;

    public MSG_CUSTOM_MESSAGE()
    {
      this.msgType = (ushort) 1023;
      this.MSG_ID = MessageID.getNewMessageID();
    }

    public uint VendorID
    {
      get => this.VendorIdentifier;
      set => this.VendorIdentifier = value;
    }

    public byte SubType
    {
      get => this.MessageSubtype;
      set => this.MessageSubtype = value;
    }

    public override string ToString()
    {
      string str = "<CUSTOM_MESSAGE" + string.Format(" xmlns=\"{0}\"\n", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0") + string.Format(" xmlns:llrp=\"{0}\"\n", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0") + " xmlns:xsi= \"http://www.w3.org/2001/XMLSchema-instance\"\n" + string.Format(" xsi:schemaLocation=\"{0} {1}\"\n", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0/llrp.xsd") + " Version=\"" + this.version.ToString() + "\" MessageID=\"" + this.MSG_ID.ToString() + "\">\r\n";
      try
      {
        str += "  <VendorIdentifier>";
        str += Util.ConvertValueTypeToString((object) this.VendorIdentifier, "u32", "");
        str += "</VendorIdentifier>\r\n";
      }
      catch
      {
      }
      try
      {
        str += "  <MessageSubtype>";
        str += Util.ConvertValueTypeToString((object) this.MessageSubtype, "u8", "");
        str += "</MessageSubtype>\r\n";
      }
      catch
      {
      }
      if (this.Data != null)
      {
        try
        {
          str += "  <Data>";
          str += Util.ConvertArrayTypeToString((object) this.Data, "bytesToEnd", "Hex");
          str += "</Data>\r\n";
        }
        catch
        {
        }
      }
      return str + "</CUSTOM_MESSAGE>";
    }

    public static MSG_CUSTOM_MESSAGE FromString(string str)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(str);
      XmlNode documentElement = (XmlNode) xmlDocument.DocumentElement;
      MSG_CUSTOM_MESSAGE msgCustomMessage = new MSG_CUSTOM_MESSAGE();
      try
      {
        msgCustomMessage.MSG_ID = Convert.ToUInt32(XmlUtil.GetNodeAttrValue(documentElement, "MessageID"));
      }
      catch
      {
      }
      string nodeValue1 = XmlUtil.GetNodeValue(documentElement, "VendorIdentifier");
      msgCustomMessage.VendorIdentifier = (uint) Util.ParseValueTypeFromString(nodeValue1, "u32", "");
      string nodeValue2 = XmlUtil.GetNodeValue(documentElement, "MessageSubtype");
      msgCustomMessage.MessageSubtype = (byte) Util.ParseValueTypeFromString(nodeValue2, "u8", "");
      string nodeValue3 = XmlUtil.GetNodeValue(documentElement, "Data");
      msgCustomMessage.Data = (ByteArray) Util.ParseArrayTypeFromString(nodeValue3, "bytesToEnd", "Hex");
      return msgCustomMessage;
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
        BitArray bitArray2 = Util.ConvertObjToBitArray((object) this.VendorIdentifier, (int) this.VendorIdentifier_len);
        bitArray2.CopyTo((Array) flagArray1, length);
        length += bitArray2.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray2 = Util.ConvertObjToBitArray((object) this.MessageSubtype, (int) this.MessageSubtype_len);
        bitArray2.CopyTo((Array) flagArray1, length);
        length += bitArray2.Length;
      }
      catch
      {
      }
      if (this.Data != null)
      {
        try
        {
          BitArray bitArray2 = Util.ConvertObjToBitArray((object) this.Data, (int) this.Data_len);
          bitArray2.CopyTo((Array) flagArray1, length);
          length += bitArray2.Length;
        }
        catch
        {
        }
      }
      Util.ConvertIntToBitArray((uint) length / 8U, 32).CopyTo((Array) flagArray1, 16);
      bool[] flagArray2 = new bool[length];
      Array.Copy((Array) flagArray1, 0, (Array) flagArray2, 0, length);
      return flagArray2;
    }

    public static MSG_CUSTOM_MESSAGE FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor > length)
        return (MSG_CUSTOM_MESSAGE) null;
      ArrayList arrayList = new ArrayList();
      MSG_CUSTOM_MESSAGE msgCustomMessage = new MSG_CUSTOM_MESSAGE();
      cursor += 6;
      if ((int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10) != (int) msgCustomMessage.msgType)
      {
        cursor -= 16;
        return (MSG_CUSTOM_MESSAGE) null;
      }
      msgCustomMessage.msgLen = (uint) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 32);
      msgCustomMessage.msgID = (uint) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 32);
      if (cursor > length)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 32;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len1);
      msgCustomMessage.VendorIdentifier = (uint) obj;
      if (cursor > length)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 8;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (byte), field_len2);
      msgCustomMessage.MessageSubtype = (byte) obj;
      if (cursor > length)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len3 = (bit_array.Length - cursor) / 8;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ByteArray), field_len3);
      msgCustomMessage.Data = (ByteArray) obj;
      return msgCustomMessage;
    }
  }
}
