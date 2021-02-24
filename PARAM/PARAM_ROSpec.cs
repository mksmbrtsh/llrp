// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_ROSpec
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_ROSpec : Parameter
  {
    public uint ROSpecID;
    private short ROSpecID_len;
    public byte Priority;
    private short Priority_len;
    public ENUM_ROSpecState CurrentState;
    private short CurrentState_len = 8;
    public PARAM_ROBoundarySpec ROBoundarySpec;
    public UNION_SpecParameter SpecParameter = new UNION_SpecParameter();
    public PARAM_ROReportSpec ROReportSpec;

    public PARAM_ROSpec() => this.typeID = (ushort) 177;

    public static PARAM_ROSpec FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_ROSpec) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_ROSpec paramRoSpec = new PARAM_ROSpec();
      paramRoSpec.tvCoding = bit_array[cursor];
      int val;
      if (paramRoSpec.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramRoSpec.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramRoSpec.length * 8;
      }
      if (val != (int) paramRoSpec.TypeID)
      {
        cursor = num1;
        return (PARAM_ROSpec) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 32;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len1);
      paramRoSpec.ROSpecID = (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 8;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (byte), field_len2);
      paramRoSpec.Priority = (byte) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len3 = 8;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len3);
      paramRoSpec.CurrentState = (ENUM_ROSpecState) (uint) obj;
      paramRoSpec.ROBoundarySpec = PARAM_ROBoundarySpec.FromBitArray(ref bit_array, ref cursor, length);
      ushort num3 = 1;
      while (num3 != (ushort) 0)
      {
        num3 = (ushort) 0;
        PARAM_AISpec paramAiSpec = PARAM_AISpec.FromBitArray(ref bit_array, ref cursor, length);
        if (paramAiSpec != null)
        {
          ++num3;
          paramRoSpec.SpecParameter.Add((IParameter) paramAiSpec);
        }
        PARAM_RFSurveySpec paramRfSurveySpec = PARAM_RFSurveySpec.FromBitArray(ref bit_array, ref cursor, length);
        if (paramRfSurveySpec != null)
        {
          ++num3;
          paramRoSpec.SpecParameter.Add((IParameter) paramRfSurveySpec);
        }
        int num4 = cursor;
        ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeCustomParameter(ref bit_array, ref cursor, length);
        if (customParameter != null)
        {
          if (paramRoSpec.SpecParameter.AddCustomParameter(customParameter))
            ++num3;
          else
            cursor = num4;
        }
      }
      paramRoSpec.ROReportSpec = PARAM_ROReportSpec.FromBitArray(ref bit_array, ref cursor, length);
      return paramRoSpec;
    }

    public override string ToString()
    {
      string str = "<ROSpec>" + "\r\n";
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
        str = str + "  <Priority>" + Util.ConvertValueTypeToString((object) this.Priority, "u8", "") + "</Priority>";
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
      if (this.ROBoundarySpec != null)
        str += Util.Indent(this.ROBoundarySpec.ToString());
      if (this.SpecParameter != null)
      {
        int count = this.SpecParameter.Count;
        for (int index = 0; index < count; ++index)
          str += Util.Indent(this.SpecParameter[index].ToString());
      }
      if (this.ROReportSpec != null)
        str += Util.Indent(this.ROReportSpec.ToString());
      return str + "</ROSpec>" + "\r\n";
    }

    public static PARAM_ROSpec FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_ROSpec paramRoSpec = new PARAM_ROSpec();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "ROSpecID");
      paramRoSpec.ROSpecID = (uint) Util.ParseValueTypeFromString(nodeValue1, "u32", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "Priority");
      paramRoSpec.Priority = (byte) Util.ParseValueTypeFromString(nodeValue2, "u8", "");
      string nodeValue3 = XmlUtil.GetNodeValue(node, "CurrentState");
      paramRoSpec.CurrentState = (ENUM_ROSpecState) Enum.Parse(typeof (ENUM_ROSpecState), nodeValue3);
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "ROBoundarySpec", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramRoSpec.ROBoundarySpec = PARAM_ROBoundarySpec.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      paramRoSpec.SpecParameter = new UNION_SpecParameter();
      try
      {
        foreach (XmlNode childNode in node.ChildNodes)
        {
          switch (childNode.Name)
          {
            case "AISpec":
              paramRoSpec.SpecParameter.Add((IParameter) PARAM_AISpec.FromXmlNode(childNode));
              continue;
            case "RFSurveySpec":
              paramRoSpec.SpecParameter.Add((IParameter) PARAM_RFSurveySpec.FromXmlNode(childNode));
              continue;
            default:
              if (!arrayList.Contains((object) childNode))
              {
                ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeXmlNodeToCustomParameter(childNode);
                if (customParameter != null && paramRoSpec.SpecParameter.AddCustomParameter(customParameter))
                {
                  arrayList.Add((object) childNode);
                  continue;
                }
                continue;
              }
              continue;
          }
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "ROReportSpec", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramRoSpec.ROReportSpec = PARAM_ROReportSpec.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      return paramRoSpec;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.ROSpecID, (int) this.ROSpecID_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.Priority, (int) this.Priority_len);
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
      if (this.ROBoundarySpec != null)
        this.ROBoundarySpec.ToBitArray(ref bit_array, ref cursor);
      int count = this.SpecParameter.Count;
      for (int index = 0; index < count; ++index)
        this.SpecParameter[index].ToBitArray(ref bit_array, ref cursor);
      if (this.ROReportSpec != null)
        this.ROReportSpec.ToBitArray(ref bit_array, ref cursor);
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
