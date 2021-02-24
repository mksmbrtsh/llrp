// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.MSG_GET_READER_CONFIG_RESPONSE
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class MSG_GET_READER_CONFIG_RESPONSE : Message
  {
    public PARAM_LLRPStatus LLRPStatus;
    public PARAM_Identification Identification;
    public PARAM_AntennaProperties[] AntennaProperties;
    public PARAM_AntennaConfiguration[] AntennaConfiguration;
    public PARAM_ReaderEventNotificationSpec ReaderEventNotificationSpec;
    public PARAM_ROReportSpec ROReportSpec;
    public PARAM_AccessReportSpec AccessReportSpec;
    public PARAM_LLRPConfigurationStateValue LLRPConfigurationStateValue;
    public PARAM_KeepaliveSpec KeepaliveSpec;
    public PARAM_GPIPortCurrentState[] GPIPortCurrentState;
    public PARAM_GPOWriteData[] GPOWriteData;
    public PARAM_EventsAndReports EventsAndReports;
    public readonly CustomParameterArrayList Custom = new CustomParameterArrayList();

    public bool AddCustomParameter(ICustom_Parameter param)
    {
      if (param is IGET_READER_CONFIG_RESPONSE_Custom_Param)
      {
        this.Custom.Add(param);
        return true;
      }
      if (param.GetType() != typeof (PARAM_Custom))
        return false;
      this.Custom.Add(param);
      return true;
    }

    public MSG_GET_READER_CONFIG_RESPONSE()
    {
      this.msgType = (ushort) 12;
      this.MSG_ID = MessageID.getNewMessageID();
    }

    public override string ToString()
    {
      string str = "<GET_READER_CONFIG_RESPONSE" + string.Format(" xmlns=\"{0}\"\n", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0") + string.Format(" xmlns:llrp=\"{0}\"\n", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0") + " xmlns:xsi= \"http://www.w3.org/2001/XMLSchema-instance\"\n" + string.Format(" xsi:schemaLocation=\"{0} {1}\"\n", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0", (object) "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0/llrp.xsd") + " Version=\"" + this.version.ToString() + "\" MessageID=\"" + this.MSG_ID.ToString() + "\">\r\n";
      if (this.LLRPStatus != null)
        str += Util.Indent(this.LLRPStatus.ToString());
      if (this.Identification != null)
        str += Util.Indent(this.Identification.ToString());
      if (this.AntennaProperties != null)
      {
        int length = this.AntennaProperties.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.AntennaProperties[index].ToString());
      }
      if (this.AntennaConfiguration != null)
      {
        int length = this.AntennaConfiguration.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.AntennaConfiguration[index].ToString());
      }
      if (this.ReaderEventNotificationSpec != null)
        str += Util.Indent(this.ReaderEventNotificationSpec.ToString());
      if (this.ROReportSpec != null)
        str += Util.Indent(this.ROReportSpec.ToString());
      if (this.AccessReportSpec != null)
        str += Util.Indent(this.AccessReportSpec.ToString());
      if (this.LLRPConfigurationStateValue != null)
        str += Util.Indent(this.LLRPConfigurationStateValue.ToString());
      if (this.KeepaliveSpec != null)
        str += Util.Indent(this.KeepaliveSpec.ToString());
      if (this.GPIPortCurrentState != null)
      {
        int length = this.GPIPortCurrentState.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.GPIPortCurrentState[index].ToString());
      }
      if (this.GPOWriteData != null)
      {
        int length = this.GPOWriteData.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.GPOWriteData[index].ToString());
      }
      if (this.EventsAndReports != null)
        str += Util.Indent(this.EventsAndReports.ToString());
      if (this.Custom != null)
      {
        int length = this.Custom.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.Custom[index].ToString());
      }
      return str + "</GET_READER_CONFIG_RESPONSE>";
    }

    public static MSG_GET_READER_CONFIG_RESPONSE FromString(string str)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(str);
      XmlNode documentElement = (XmlNode) xmlDocument.DocumentElement;
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(documentElement.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      MSG_GET_READER_CONFIG_RESPONSE readerConfigResponse = new MSG_GET_READER_CONFIG_RESPONSE();
      try
      {
        readerConfigResponse.MSG_ID = Convert.ToUInt32(XmlUtil.GetNodeAttrValue(documentElement, "MessageID"));
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(documentElement, "LLRPStatus", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            readerConfigResponse.LLRPStatus = PARAM_LLRPStatus.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(documentElement, "Identification", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            readerConfigResponse.Identification = PARAM_Identification.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(documentElement, "AntennaProperties", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
          {
            readerConfigResponse.AntennaProperties = new PARAM_AntennaProperties[xmlNodes.Count];
            for (int i = 0; i < xmlNodes.Count; ++i)
              readerConfigResponse.AntennaProperties[i] = PARAM_AntennaProperties.FromXmlNode(xmlNodes[i]);
          }
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(documentElement, "AntennaConfiguration", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
          {
            readerConfigResponse.AntennaConfiguration = new PARAM_AntennaConfiguration[xmlNodes.Count];
            for (int i = 0; i < xmlNodes.Count; ++i)
              readerConfigResponse.AntennaConfiguration[i] = PARAM_AntennaConfiguration.FromXmlNode(xmlNodes[i]);
          }
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(documentElement, "ReaderEventNotificationSpec", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            readerConfigResponse.ReaderEventNotificationSpec = PARAM_ReaderEventNotificationSpec.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(documentElement, "ROReportSpec", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            readerConfigResponse.ROReportSpec = PARAM_ROReportSpec.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(documentElement, "AccessReportSpec", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            readerConfigResponse.AccessReportSpec = PARAM_AccessReportSpec.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(documentElement, "LLRPConfigurationStateValue", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            readerConfigResponse.LLRPConfigurationStateValue = PARAM_LLRPConfigurationStateValue.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(documentElement, "KeepaliveSpec", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            readerConfigResponse.KeepaliveSpec = PARAM_KeepaliveSpec.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(documentElement, "GPIPortCurrentState", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
          {
            readerConfigResponse.GPIPortCurrentState = new PARAM_GPIPortCurrentState[xmlNodes.Count];
            for (int i = 0; i < xmlNodes.Count; ++i)
              readerConfigResponse.GPIPortCurrentState[i] = PARAM_GPIPortCurrentState.FromXmlNode(xmlNodes[i]);
          }
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(documentElement, "GPOWriteData", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
          {
            readerConfigResponse.GPOWriteData = new PARAM_GPOWriteData[xmlNodes.Count];
            for (int i = 0; i < xmlNodes.Count; ++i)
              readerConfigResponse.GPOWriteData[i] = PARAM_GPOWriteData.FromXmlNode(xmlNodes[i]);
          }
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(documentElement, "EventsAndReports", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            readerConfigResponse.EventsAndReports = PARAM_EventsAndReports.FromXmlNode(xmlNodes[0]);
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
              readerConfigResponse.AddCustomParameter(customParameter);
          }
        }
      }
      catch
      {
      }
      return readerConfigResponse;
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
      if (this.LLRPStatus != null)
        this.LLRPStatus.ToBitArray(ref bit_array, ref cursor);
      if (this.Identification != null)
        this.Identification.ToBitArray(ref bit_array, ref cursor);
      if (this.AntennaProperties != null)
      {
        int length = this.AntennaProperties.Length;
        for (int index5 = 0; index5 < length; ++index5)
          this.AntennaProperties[index5].ToBitArray(ref bit_array, ref cursor);
      }
      if (this.AntennaConfiguration != null)
      {
        int length = this.AntennaConfiguration.Length;
        for (int index5 = 0; index5 < length; ++index5)
          this.AntennaConfiguration[index5].ToBitArray(ref bit_array, ref cursor);
      }
      if (this.ReaderEventNotificationSpec != null)
        this.ReaderEventNotificationSpec.ToBitArray(ref bit_array, ref cursor);
      if (this.ROReportSpec != null)
        this.ROReportSpec.ToBitArray(ref bit_array, ref cursor);
      if (this.AccessReportSpec != null)
        this.AccessReportSpec.ToBitArray(ref bit_array, ref cursor);
      if (this.LLRPConfigurationStateValue != null)
        this.LLRPConfigurationStateValue.ToBitArray(ref bit_array, ref cursor);
      if (this.KeepaliveSpec != null)
        this.KeepaliveSpec.ToBitArray(ref bit_array, ref cursor);
      if (this.GPIPortCurrentState != null)
      {
        int length = this.GPIPortCurrentState.Length;
        for (int index5 = 0; index5 < length; ++index5)
          this.GPIPortCurrentState[index5].ToBitArray(ref bit_array, ref cursor);
      }
      if (this.GPOWriteData != null)
      {
        int length = this.GPOWriteData.Length;
        for (int index5 = 0; index5 < length; ++index5)
          this.GPOWriteData[index5].ToBitArray(ref bit_array, ref cursor);
      }
      if (this.EventsAndReports != null)
        this.EventsAndReports.ToBitArray(ref bit_array, ref cursor);
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

    public static MSG_GET_READER_CONFIG_RESPONSE FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor > length)
        return (MSG_GET_READER_CONFIG_RESPONSE) null;
      ArrayList arrayList1 = new ArrayList();
      MSG_GET_READER_CONFIG_RESPONSE readerConfigResponse = new MSG_GET_READER_CONFIG_RESPONSE();
      cursor += 6;
      if ((int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10) != (int) readerConfigResponse.msgType)
      {
        cursor -= 16;
        return (MSG_GET_READER_CONFIG_RESPONSE) null;
      }
      readerConfigResponse.msgLen = (uint) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 32);
      readerConfigResponse.msgID = (uint) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 32);
      readerConfigResponse.LLRPStatus = PARAM_LLRPStatus.FromBitArray(ref bit_array, ref cursor, length);
      readerConfigResponse.Identification = PARAM_Identification.FromBitArray(ref bit_array, ref cursor, length);
      ArrayList arrayList2 = new ArrayList();
      PARAM_AntennaProperties antennaProperties;
      while ((antennaProperties = PARAM_AntennaProperties.FromBitArray(ref bit_array, ref cursor, length)) != null)
        arrayList2.Add((object) antennaProperties);
      if (arrayList2.Count > 0)
      {
        readerConfigResponse.AntennaProperties = new PARAM_AntennaProperties[arrayList2.Count];
        for (int index = 0; index < arrayList2.Count; ++index)
          readerConfigResponse.AntennaProperties[index] = (PARAM_AntennaProperties) arrayList2[index];
      }
      ArrayList arrayList3 = new ArrayList();
      PARAM_AntennaConfiguration antennaConfiguration;
      while ((antennaConfiguration = PARAM_AntennaConfiguration.FromBitArray(ref bit_array, ref cursor, length)) != null)
        arrayList3.Add((object) antennaConfiguration);
      if (arrayList3.Count > 0)
      {
        readerConfigResponse.AntennaConfiguration = new PARAM_AntennaConfiguration[arrayList3.Count];
        for (int index = 0; index < arrayList3.Count; ++index)
          readerConfigResponse.AntennaConfiguration[index] = (PARAM_AntennaConfiguration) arrayList3[index];
      }
      readerConfigResponse.ReaderEventNotificationSpec = PARAM_ReaderEventNotificationSpec.FromBitArray(ref bit_array, ref cursor, length);
      readerConfigResponse.ROReportSpec = PARAM_ROReportSpec.FromBitArray(ref bit_array, ref cursor, length);
      readerConfigResponse.AccessReportSpec = PARAM_AccessReportSpec.FromBitArray(ref bit_array, ref cursor, length);
      readerConfigResponse.LLRPConfigurationStateValue = PARAM_LLRPConfigurationStateValue.FromBitArray(ref bit_array, ref cursor, length);
      readerConfigResponse.KeepaliveSpec = PARAM_KeepaliveSpec.FromBitArray(ref bit_array, ref cursor, length);
      ArrayList arrayList4 = new ArrayList();
      PARAM_GPIPortCurrentState portCurrentState;
      while ((portCurrentState = PARAM_GPIPortCurrentState.FromBitArray(ref bit_array, ref cursor, length)) != null)
        arrayList4.Add((object) portCurrentState);
      if (arrayList4.Count > 0)
      {
        readerConfigResponse.GPIPortCurrentState = new PARAM_GPIPortCurrentState[arrayList4.Count];
        for (int index = 0; index < arrayList4.Count; ++index)
          readerConfigResponse.GPIPortCurrentState[index] = (PARAM_GPIPortCurrentState) arrayList4[index];
      }
      ArrayList arrayList5 = new ArrayList();
      PARAM_GPOWriteData paramGpoWriteData;
      while ((paramGpoWriteData = PARAM_GPOWriteData.FromBitArray(ref bit_array, ref cursor, length)) != null)
        arrayList5.Add((object) paramGpoWriteData);
      if (arrayList5.Count > 0)
      {
        readerConfigResponse.GPOWriteData = new PARAM_GPOWriteData[arrayList5.Count];
        for (int index = 0; index < arrayList5.Count; ++index)
          readerConfigResponse.GPOWriteData[index] = (PARAM_GPOWriteData) arrayList5[index];
      }
      readerConfigResponse.EventsAndReports = PARAM_EventsAndReports.FromBitArray(ref bit_array, ref cursor, length);
      int num;
      bool flag;
      do
      {
        num = cursor;
        flag = false;
        ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeCustomParameter(ref bit_array, ref cursor, length);
        if (customParameter != null && readerConfigResponse.AddCustomParameter(customParameter))
          flag = true;
      }
      while (flag);
      cursor = num;
      return readerConfigResponse;
    }
  }
}
