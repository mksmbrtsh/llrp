// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.MSG_RO_ACCESS_REPORT
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class MSG_RO_ACCESS_REPORT : Message
  {
    public PARAM_TagReportData[] TagReportData;
    public PARAM_RFSurveyReportData[] RFSurveyReportData;
    public readonly CustomParameterArrayList Custom = new CustomParameterArrayList();

    public bool AddCustomParameter(ICustom_Parameter param)
    {
      if (param is IRO_ACCESS_REPORT_Custom_Param)
      {
        this.Custom.Add(param);
        return true;
      }
      if (param.GetType() != typeof (PARAM_Custom))
        return false;
      this.Custom.Add(param);
      return true;
    }

    public MSG_RO_ACCESS_REPORT()
    {
      this.msgType = (ushort) 61;
      this.MSG_ID = MessageID.getNewMessageID();
    }

    public override string ToString()
    {
      string str = "<RO_ACCESS_REPORT" + string.Format(" xmlns=\"{0}\"\n", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0") + string.Format(" xmlns:llrp=\"{0}\"\n", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0") + " xmlns:xsi= \"http://www.w3.org/2001/XMLSchema-instance\"\n" + string.Format(" xsi:schemaLocation=\"{0} {1}\"\n", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0/llrp.xsd") + " Version=\"" + this.version.ToString() + "\" MessageID=\"" + this.MSG_ID.ToString() + "\">\r\n";
      if (this.TagReportData != null)
      {
        int length = this.TagReportData.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.TagReportData[index].ToString());
      }
      if (this.RFSurveyReportData != null)
      {
        int length = this.RFSurveyReportData.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.RFSurveyReportData[index].ToString());
      }
      if (this.Custom != null)
      {
        int length = this.Custom.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.Custom[index].ToString());
      }
      return str + "</RO_ACCESS_REPORT>";
    }

    public static MSG_RO_ACCESS_REPORT FromString(string str)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(str);
      XmlNode documentElement = (XmlNode) xmlDocument.DocumentElement;
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(documentElement.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      MSG_RO_ACCESS_REPORT msgRoAccessReport = new MSG_RO_ACCESS_REPORT();
      try
      {
        msgRoAccessReport.MSG_ID = Convert.ToUInt32(XmlUtil.GetNodeAttrValue(documentElement, "MessageID"));
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(documentElement, "TagReportData", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
          {
            msgRoAccessReport.TagReportData = new PARAM_TagReportData[xmlNodes.Count];
            for (int i = 0; i < xmlNodes.Count; ++i)
              msgRoAccessReport.TagReportData[i] = PARAM_TagReportData.FromXmlNode(xmlNodes[i]);
          }
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(documentElement, "RFSurveyReportData", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
          {
            msgRoAccessReport.RFSurveyReportData = new PARAM_RFSurveyReportData[xmlNodes.Count];
            for (int i = 0; i < xmlNodes.Count; ++i)
              msgRoAccessReport.RFSurveyReportData[i] = PARAM_RFSurveyReportData.FromXmlNode(xmlNodes[i]);
          }
        }
      }
      catch
      {
      }
      try
      {
        ArrayList nodeCustomChildren = XmlUtil.GetXmlNodeCustomChildren(documentElement, nsmgr);
        if (nodeCustomChildren != null)
        {
          for (int index = 0; index < nodeCustomChildren.Count; ++index)
          {
            ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeXmlNodeToCustomParameter((XmlNode) nodeCustomChildren[index]);
            if (customParameter != null)
              msgRoAccessReport.AddCustomParameter(customParameter);
          }
        }
      }
      catch
      {
      }
      return msgRoAccessReport;
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
      if (this.TagReportData != null)
      {
        int length = this.TagReportData.Length;
        for (int index5 = 0; index5 < length; ++index5)
          this.TagReportData[index5].ToBitArray(ref bit_array, ref cursor);
      }
      if (this.RFSurveyReportData != null)
      {
        int length = this.RFSurveyReportData.Length;
        for (int index5 = 0; index5 < length; ++index5)
          this.RFSurveyReportData[index5].ToBitArray(ref bit_array, ref cursor);
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

    public static MSG_RO_ACCESS_REPORT FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor > length)
        return (MSG_RO_ACCESS_REPORT) null;
      ArrayList arrayList1 = new ArrayList();
      MSG_RO_ACCESS_REPORT msgRoAccessReport = new MSG_RO_ACCESS_REPORT();
      cursor += 6;
      if ((int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10) != (int) msgRoAccessReport.msgType)
      {
        cursor -= 16;
        return (MSG_RO_ACCESS_REPORT) null;
      }
      msgRoAccessReport.msgLen = (uint) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 32);
      msgRoAccessReport.msgID = (uint) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 32);
      ArrayList arrayList2 = new ArrayList();
      PARAM_TagReportData paramTagReportData;
      while ((paramTagReportData = PARAM_TagReportData.FromBitArray(ref bit_array, ref cursor, length)) != null)
        arrayList2.Add((object) paramTagReportData);
      if (arrayList2.Count > 0)
      {
        msgRoAccessReport.TagReportData = new PARAM_TagReportData[arrayList2.Count];
        for (int index = 0; index < arrayList2.Count; ++index)
          msgRoAccessReport.TagReportData[index] = (PARAM_TagReportData) arrayList2[index];
      }
      ArrayList arrayList3 = new ArrayList();
      PARAM_RFSurveyReportData surveyReportData;
      while ((surveyReportData = PARAM_RFSurveyReportData.FromBitArray(ref bit_array, ref cursor, length)) != null)
        arrayList3.Add((object) surveyReportData);
      if (arrayList3.Count > 0)
      {
        msgRoAccessReport.RFSurveyReportData = new PARAM_RFSurveyReportData[arrayList3.Count];
        for (int index = 0; index < arrayList3.Count; ++index)
          msgRoAccessReport.RFSurveyReportData[index] = (PARAM_RFSurveyReportData) arrayList3[index];
      }
      int num;
      bool flag;
      do
      {
        num = cursor;
        flag = false;
        ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeCustomParameter(ref bit_array, ref cursor, length);
        if (customParameter != null && msgRoAccessReport.AddCustomParameter(customParameter))
          flag = true;
      }
      while (flag);
      cursor = num;
      return msgRoAccessReport;
    }
  }
}
