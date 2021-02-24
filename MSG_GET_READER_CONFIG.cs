// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.MSG_GET_READER_CONFIG
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class MSG_GET_READER_CONFIG : Message
  {
    public ushort AntennaID;
    private short AntennaID_len;
    public ENUM_GetReaderConfigRequestedData RequestedData;
    private short RequestedData_len = 8;
    public ushort GPIPortNum;
    private short GPIPortNum_len;
    public ushort GPOPortNum;
    private short GPOPortNum_len;
    public readonly CustomParameterArrayList Custom = new CustomParameterArrayList();

    public bool AddCustomParameter(ICustom_Parameter param)
    {
      if (param is IGET_READER_CONFIG_Custom_Param)
      {
        this.Custom.Add(param);
        return true;
      }
      if (param.GetType() != typeof (PARAM_Custom))
        return false;
      this.Custom.Add(param);
      return true;
    }

    public MSG_GET_READER_CONFIG()
    {
      this.msgType = (ushort) 2;
      this.MSG_ID = MessageID.getNewMessageID();
    }

    public override string ToString()
    {
      string str = "<GET_READER_CONFIG" + string.Format(" xmlns=\"{0}\"\n", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0") + string.Format(" xmlns:llrp=\"{0}\"\n", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0") + " xmlns:xsi= \"http://www.w3.org/2001/XMLSchema-instance\"\n" + string.Format(" xsi:schemaLocation=\"{0} {1}\"\n", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0/llrp.xsd") + " Version=\"" + this.version.ToString() + "\" MessageID=\"" + this.MSG_ID.ToString() + "\">\r\n";
      try
      {
        str = str + "  <AntennaID>" + Util.ConvertValueTypeToString((object) this.AntennaID, "u16", "") + "</AntennaID>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <RequestedData>" + this.RequestedData.ToString() + "</RequestedData>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <GPIPortNum>" + Util.ConvertValueTypeToString((object) this.GPIPortNum, "u16", "") + "</GPIPortNum>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <GPOPortNum>" + Util.ConvertValueTypeToString((object) this.GPOPortNum, "u16", "") + "</GPOPortNum>";
        str += "\r\n";
      }
      catch
      {
      }
      if (this.Custom != null)
      {
        int length = this.Custom.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.Custom[index].ToString());
      }
      return str + "</GET_READER_CONFIG>";
    }

    public static MSG_GET_READER_CONFIG FromString(string str)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(str);
      XmlNode documentElement = (XmlNode) xmlDocument.DocumentElement;
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(documentElement.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      MSG_GET_READER_CONFIG msgGetReaderConfig = new MSG_GET_READER_CONFIG();
      try
      {
        msgGetReaderConfig.MSG_ID = Convert.ToUInt32(XmlUtil.GetNodeAttrValue(documentElement, "MessageID"));
      }
      catch
      {
      }
      string nodeValue1 = XmlUtil.GetNodeValue(documentElement, "AntennaID");
      msgGetReaderConfig.AntennaID = (ushort) Util.ParseValueTypeFromString(nodeValue1, "u16", "");
      string nodeValue2 = XmlUtil.GetNodeValue(documentElement, "RequestedData");
      msgGetReaderConfig.RequestedData = (ENUM_GetReaderConfigRequestedData) Enum.Parse(typeof (ENUM_GetReaderConfigRequestedData), nodeValue2);
      string nodeValue3 = XmlUtil.GetNodeValue(documentElement, "GPIPortNum");
      msgGetReaderConfig.GPIPortNum = (ushort) Util.ParseValueTypeFromString(nodeValue3, "u16", "");
      string nodeValue4 = XmlUtil.GetNodeValue(documentElement, "GPOPortNum");
      msgGetReaderConfig.GPOPortNum = (ushort) Util.ParseValueTypeFromString(nodeValue4, "u16", "");
      try
      {
        ArrayList nodeCustomChildren = XmlUtil.GetXmlNodeCustomChildren(documentElement, nsmgr);
        if (nodeCustomChildren != null)
        {
          for (int index = 0; index < nodeCustomChildren.Count; ++index)
          {
            ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeXmlNodeToCustomParameter((XmlNode) nodeCustomChildren[index]);
            if (customParameter != null)
              msgGetReaderConfig.AddCustomParameter(customParameter);
          }
        }
      }
      catch
      {
      }
      return msgGetReaderConfig;
    }

    public override bool[] ToBitArray()
    {
      int num = 0;
      bool[] bit_array = new bool[33554432];
      BitArray bitArray1 = Util.ConvertIntToBitArray((uint) this.version, 3);
      int index1 = num + 3;
      bitArray1.CopyTo((Array) bit_array, index1);
      int index2 = index1 + 3;
      Util.ConvertIntToBitArray((uint) this.msgType, 10).CopyTo((Array) bit_array, index2);
      int index3 = index2 + 10;
      Util.ConvertIntToBitArray(this.msgLen, 32).CopyTo((Array) bit_array, index3);
      int index4 = index3 + 32;
      Util.ConvertIntToBitArray(this.msgID, 32).CopyTo((Array) bit_array, index4);
      int cursor = index4 + 32;
      try
      {
        BitArray bitArray2 = Util.ConvertObjToBitArray((object) this.AntennaID, (int) this.AntennaID_len);
        bitArray2.CopyTo((Array) bit_array, cursor);
        cursor += bitArray2.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray2 = Util.ConvertObjToBitArray((object) this.RequestedData, (int) this.RequestedData_len);
        bitArray2.CopyTo((Array) bit_array, cursor);
        cursor += bitArray2.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray2 = Util.ConvertObjToBitArray((object) this.GPIPortNum, (int) this.GPIPortNum_len);
        bitArray2.CopyTo((Array) bit_array, cursor);
        cursor += bitArray2.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray2 = Util.ConvertObjToBitArray((object) this.GPOPortNum, (int) this.GPOPortNum_len);
        bitArray2.CopyTo((Array) bit_array, cursor);
        cursor += bitArray2.Length;
      }
      catch
      {
      }
      if (this.Custom != null)
      {
        int length = this.Custom.Length;
        for (int index5 = 0; index5 < length; ++index5)
          this.Custom[index5].ToBitArray(ref bit_array, ref cursor);
      }
      Util.ConvertIntToBitArray((uint) cursor / 8U, 32).CopyTo((Array) bit_array, 16);
      bool[] flagArray = new bool[cursor];
      Array.Copy((Array) bit_array, 0, (Array) flagArray, 0, cursor);
      return flagArray;
    }

    public static MSG_GET_READER_CONFIG FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor > length)
        return (MSG_GET_READER_CONFIG) null;
      ArrayList arrayList = new ArrayList();
      MSG_GET_READER_CONFIG msgGetReaderConfig = new MSG_GET_READER_CONFIG();
      cursor += 6;
      if ((int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10) != (int) msgGetReaderConfig.msgType)
      {
        cursor -= 16;
        return (MSG_GET_READER_CONFIG) null;
      }
      msgGetReaderConfig.msgLen = (uint) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 32);
      msgGetReaderConfig.msgID = (uint) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 32);
      if (cursor > length)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len1);
      msgGetReaderConfig.AntennaID = (ushort) obj;
      if (cursor > length)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 8;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len2);
      msgGetReaderConfig.RequestedData = (ENUM_GetReaderConfigRequestedData) (uint) obj;
      if (cursor > length)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len3 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len3);
      msgGetReaderConfig.GPIPortNum = (ushort) obj;
      if (cursor > length)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len4 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len4);
      msgGetReaderConfig.GPOPortNum = (ushort) obj;
      int num;
      bool flag;
      do
      {
        num = cursor;
        flag = false;
        ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeCustomParameter(ref bit_array, ref cursor, length);
        if (customParameter != null && msgGetReaderConfig.AddCustomParameter(customParameter))
          flag = true;
      }
      while (flag);
      cursor = num;
      return msgGetReaderConfig;
    }
  }
}
