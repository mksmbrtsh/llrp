// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_AccessSpec
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_AccessSpec : Parameter
  {
    private const ushort param_reserved_len6 = 7;
    public uint AccessSpecID;
    private short AccessSpecID_len;
    public ushort AntennaID;
    private short AntennaID_len;
    public ENUM_AirProtocols ProtocolID;
    private short ProtocolID_len = 8;
    public ENUM_AccessSpecState CurrentState;
    private short CurrentState_len = 1;
    public uint ROSpecID;
    private short ROSpecID_len;
    public PARAM_AccessSpecStopTrigger AccessSpecStopTrigger;
    public PARAM_AccessCommand AccessCommand;
    public PARAM_AccessReportSpec AccessReportSpec;
    public readonly CustomParameterArrayList Custom = new CustomParameterArrayList();

    public PARAM_AccessSpec() => this.typeID = (ushort) 207;

    public bool AddCustomParameter(ICustom_Parameter param)
    {
      if (param is IAccessSpec_Custom_Param)
      {
        this.Custom.Add(param);
        return true;
      }
      if (param.GetType() != typeof (PARAM_Custom))
        return false;
      this.Custom.Add(param);
      return true;
    }

    public static PARAM_AccessSpec FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_AccessSpec) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_AccessSpec paramAccessSpec = new PARAM_AccessSpec();
      paramAccessSpec.tvCoding = bit_array[cursor];
      int val;
      if (paramAccessSpec.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramAccessSpec.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramAccessSpec.length * 8;
      }
      if (val != (int) paramAccessSpec.TypeID)
      {
        cursor = num1;
        return (PARAM_AccessSpec) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 32;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len1);
      paramAccessSpec.AccessSpecID = (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len2);
      paramAccessSpec.AntennaID = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len3 = 8;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len3);
      paramAccessSpec.ProtocolID = (ENUM_AirProtocols) (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len4 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len4);
      paramAccessSpec.CurrentState = (ENUM_AccessSpecState) (uint) obj;
      cursor += 7;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len5 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len5);
      paramAccessSpec.ROSpecID = (uint) obj;
      paramAccessSpec.AccessSpecStopTrigger = PARAM_AccessSpecStopTrigger.FromBitArray(ref bit_array, ref cursor, length);
      paramAccessSpec.AccessCommand = PARAM_AccessCommand.FromBitArray(ref bit_array, ref cursor, length);
      paramAccessSpec.AccessReportSpec = PARAM_AccessReportSpec.FromBitArray(ref bit_array, ref cursor, length);
      int num3;
      bool flag;
      do
      {
        num3 = cursor;
        flag = false;
        ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeCustomParameter(ref bit_array, ref cursor, length);
        if (customParameter != null && cursor <= num2 && paramAccessSpec.AddCustomParameter(customParameter))
          flag = true;
      }
      while (flag);
      cursor = num3;
      return paramAccessSpec;
    }

    public override string ToString()
    {
      string str = "<AccessSpec>" + "\r\n";
      try
      {
        str = str + "  <AccessSpecID>" + Util.ConvertValueTypeToString((object) this.AccessSpecID, "u32", "") + "</AccessSpecID>";
        str += "\r\n";
      }
      catch
      {
      }
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
        str = str + "  <ProtocolID>" + this.ProtocolID.ToString() + "</ProtocolID>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <CurrentState>" + this.CurrentState.ToString() + "</CurrentState>";
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
      if (this.AccessSpecStopTrigger != null)
        str += Util.Indent(this.AccessSpecStopTrigger.ToString());
      if (this.AccessCommand != null)
        str += Util.Indent(this.AccessCommand.ToString());
      if (this.AccessReportSpec != null)
        str += Util.Indent(this.AccessReportSpec.ToString());
      if (this.Custom != null)
      {
        int length = this.Custom.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.Custom[index].ToString());
      }
      return str + "</AccessSpec>" + "\r\n";
    }

    public static PARAM_AccessSpec FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_AccessSpec paramAccessSpec = new PARAM_AccessSpec();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "AccessSpecID");
      paramAccessSpec.AccessSpecID = (uint) Util.ParseValueTypeFromString(nodeValue1, "u32", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "AntennaID");
      paramAccessSpec.AntennaID = (ushort) Util.ParseValueTypeFromString(nodeValue2, "u16", "");
      string nodeValue3 = XmlUtil.GetNodeValue(node, "ProtocolID");
      paramAccessSpec.ProtocolID = (ENUM_AirProtocols) Enum.Parse(typeof (ENUM_AirProtocols), nodeValue3);
      string nodeValue4 = XmlUtil.GetNodeValue(node, "CurrentState");
      paramAccessSpec.CurrentState = (ENUM_AccessSpecState) Enum.Parse(typeof (ENUM_AccessSpecState), nodeValue4);
      string nodeValue5 = XmlUtil.GetNodeValue(node, "ROSpecID");
      paramAccessSpec.ROSpecID = (uint) Util.ParseValueTypeFromString(nodeValue5, "u32", "");
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "AccessSpecStopTrigger", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramAccessSpec.AccessSpecStopTrigger = PARAM_AccessSpecStopTrigger.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "AccessCommand", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramAccessSpec.AccessCommand = PARAM_AccessCommand.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "AccessReportSpec", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramAccessSpec.AccessReportSpec = PARAM_AccessReportSpec.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        ArrayList nodeCustomChildren = XmlUtil.GetXmlNodeCustomChildren(node, nsmgr);
        if (nodeCustomChildren != null)
        {
          for (int index = 0; index < nodeCustomChildren.Count; ++index)
          {
            if (!arrayList.Contains(nodeCustomChildren[index]))
            {
              ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeXmlNodeToCustomParameter((XmlNode) nodeCustomChildren[index]);
              if (customParameter != null && paramAccessSpec.AddCustomParameter(customParameter))
                arrayList.Add(nodeCustomChildren[index]);
            }
          }
        }
      }
      catch
      {
      }
      return paramAccessSpec;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.AccessSpecID, (int) this.AccessSpecID_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.AntennaID, (int) this.AntennaID_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.ProtocolID, (int) this.ProtocolID_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.CurrentState, (int) this.CurrentState_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      cursor += 7;
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.ROSpecID, (int) this.ROSpecID_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      if (this.AccessSpecStopTrigger != null)
        this.AccessSpecStopTrigger.ToBitArray(ref bit_array, ref cursor);
      if (this.AccessCommand != null)
        this.AccessCommand.ToBitArray(ref bit_array, ref cursor);
      if (this.AccessReportSpec != null)
        this.AccessReportSpec.ToBitArray(ref bit_array, ref cursor);
      if (this.Custom != null)
      {
        int length = this.Custom.Length;
        for (int index = 0; index < length; ++index)
          this.Custom[index].ToBitArray(ref bit_array, ref cursor);
      }
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
