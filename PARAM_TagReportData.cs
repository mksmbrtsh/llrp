// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_TagReportData
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_TagReportData : Parameter
  {
    public UNION_EPCParameter EPCParameter = new UNION_EPCParameter();
    public PARAM_ROSpecID ROSpecID;
    public PARAM_SpecIndex SpecIndex;
    public PARAM_InventoryParameterSpecID InventoryParameterSpecID;
    public PARAM_AntennaID AntennaID;
    public PARAM_PeakRSSI PeakRSSI;
    public PARAM_ChannelIndex ChannelIndex;
    public PARAM_FirstSeenTimestampUTC FirstSeenTimestampUTC;
    public PARAM_FirstSeenTimestampUptime FirstSeenTimestampUptime;
    public PARAM_LastSeenTimestampUTC LastSeenTimestampUTC;
    public PARAM_LastSeenTimestampUptime LastSeenTimestampUptime;
    public PARAM_TagSeenCount TagSeenCount;
    public UNION_AirProtocolTagData AirProtocolTagData = new UNION_AirProtocolTagData();
    public PARAM_AccessSpecID AccessSpecID;
    public UNION_AccessCommandOpSpecResult AccessCommandOpSpecResult = new UNION_AccessCommandOpSpecResult();
    public readonly CustomParameterArrayList Custom = new CustomParameterArrayList();

    public PARAM_TagReportData() => this.typeID = (ushort) 240;

    public bool AddCustomParameter(ICustom_Parameter param)
    {
      if (param is ITagReportData_Custom_Param)
      {
        this.Custom.Add(param);
        return true;
      }
      if (param.GetType() != typeof (PARAM_Custom))
        return false;
      this.Custom.Add(param);
      return true;
    }

    public static PARAM_TagReportData FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_TagReportData) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_TagReportData paramTagReportData = new PARAM_TagReportData();
      paramTagReportData.tvCoding = bit_array[cursor];
      int val;
      if (paramTagReportData.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramTagReportData.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramTagReportData.length * 8;
      }
      if (val != (int) paramTagReportData.TypeID)
      {
        cursor = num1;
        return (PARAM_TagReportData) null;
      }
      ushort num3 = 1;
      while (num3 != (ushort) 0)
      {
        num3 = (ushort) 0;
        PARAM_EPCData paramEpcData = PARAM_EPCData.FromBitArray(ref bit_array, ref cursor, length);
        if (paramEpcData != null)
        {
          ++num3;
          paramTagReportData.EPCParameter.Add((IParameter) paramEpcData);
        }
        PARAM_EPC_96 paramEpc96 = PARAM_EPC_96.FromBitArray(ref bit_array, ref cursor, length);
        if (paramEpc96 != null)
        {
          ++num3;
          paramTagReportData.EPCParameter.Add((IParameter) paramEpc96);
        }
      }
      paramTagReportData.ROSpecID = PARAM_ROSpecID.FromBitArray(ref bit_array, ref cursor, length);
      paramTagReportData.SpecIndex = PARAM_SpecIndex.FromBitArray(ref bit_array, ref cursor, length);
      paramTagReportData.InventoryParameterSpecID = PARAM_InventoryParameterSpecID.FromBitArray(ref bit_array, ref cursor, length);
      paramTagReportData.AntennaID = PARAM_AntennaID.FromBitArray(ref bit_array, ref cursor, length);
      paramTagReportData.PeakRSSI = PARAM_PeakRSSI.FromBitArray(ref bit_array, ref cursor, length);
      paramTagReportData.ChannelIndex = PARAM_ChannelIndex.FromBitArray(ref bit_array, ref cursor, length);
      paramTagReportData.FirstSeenTimestampUTC = PARAM_FirstSeenTimestampUTC.FromBitArray(ref bit_array, ref cursor, length);
      paramTagReportData.FirstSeenTimestampUptime = PARAM_FirstSeenTimestampUptime.FromBitArray(ref bit_array, ref cursor, length);
      paramTagReportData.LastSeenTimestampUTC = PARAM_LastSeenTimestampUTC.FromBitArray(ref bit_array, ref cursor, length);
      paramTagReportData.LastSeenTimestampUptime = PARAM_LastSeenTimestampUptime.FromBitArray(ref bit_array, ref cursor, length);
      paramTagReportData.TagSeenCount = PARAM_TagSeenCount.FromBitArray(ref bit_array, ref cursor, length);
      ushort num4 = 1;
      while (num4 != (ushort) 0)
      {
        num4 = (ushort) 0;
        PARAM_C1G2_PC paramC1G2Pc = PARAM_C1G2_PC.FromBitArray(ref bit_array, ref cursor, length);
        if (paramC1G2Pc != null)
        {
          ++num4;
          paramTagReportData.AirProtocolTagData.Add((IParameter) paramC1G2Pc);
        }
        PARAM_C1G2_CRC paramC1G2Crc = PARAM_C1G2_CRC.FromBitArray(ref bit_array, ref cursor, length);
        if (paramC1G2Crc != null)
        {
          ++num4;
          paramTagReportData.AirProtocolTagData.Add((IParameter) paramC1G2Crc);
        }
      }
      paramTagReportData.AccessSpecID = PARAM_AccessSpecID.FromBitArray(ref bit_array, ref cursor, length);
      ushort num5 = 1;
      while (num5 != (ushort) 0)
      {
        num5 = (ushort) 0;
        PARAM_C1G2ReadOpSpecResult readOpSpecResult = PARAM_C1G2ReadOpSpecResult.FromBitArray(ref bit_array, ref cursor, length);
        if (readOpSpecResult != null)
        {
          ++num5;
          paramTagReportData.AccessCommandOpSpecResult.Add((IParameter) readOpSpecResult);
        }
        PARAM_C1G2WriteOpSpecResult writeOpSpecResult1 = PARAM_C1G2WriteOpSpecResult.FromBitArray(ref bit_array, ref cursor, length);
        if (writeOpSpecResult1 != null)
        {
          ++num5;
          paramTagReportData.AccessCommandOpSpecResult.Add((IParameter) writeOpSpecResult1);
        }
        PARAM_C1G2KillOpSpecResult killOpSpecResult = PARAM_C1G2KillOpSpecResult.FromBitArray(ref bit_array, ref cursor, length);
        if (killOpSpecResult != null)
        {
          ++num5;
          paramTagReportData.AccessCommandOpSpecResult.Add((IParameter) killOpSpecResult);
        }
        PARAM_C1G2LockOpSpecResult lockOpSpecResult = PARAM_C1G2LockOpSpecResult.FromBitArray(ref bit_array, ref cursor, length);
        if (lockOpSpecResult != null)
        {
          ++num5;
          paramTagReportData.AccessCommandOpSpecResult.Add((IParameter) lockOpSpecResult);
        }
        PARAM_C1G2BlockEraseOpSpecResult eraseOpSpecResult = PARAM_C1G2BlockEraseOpSpecResult.FromBitArray(ref bit_array, ref cursor, length);
        if (eraseOpSpecResult != null)
        {
          ++num5;
          paramTagReportData.AccessCommandOpSpecResult.Add((IParameter) eraseOpSpecResult);
        }
        PARAM_C1G2BlockWriteOpSpecResult writeOpSpecResult2 = PARAM_C1G2BlockWriteOpSpecResult.FromBitArray(ref bit_array, ref cursor, length);
        if (writeOpSpecResult2 != null)
        {
          ++num5;
          paramTagReportData.AccessCommandOpSpecResult.Add((IParameter) writeOpSpecResult2);
        }
        int num6 = cursor;
        ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeCustomParameter(ref bit_array, ref cursor, length);
        if (customParameter != null)
        {
          if (paramTagReportData.AccessCommandOpSpecResult.AddCustomParameter(customParameter))
            ++num5;
          else
            cursor = num6;
        }
      }
      int num7;
      bool flag;
      do
      {
        num7 = cursor;
        flag = false;
        ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeCustomParameter(ref bit_array, ref cursor, length);
        if (customParameter != null && cursor <= num2 && paramTagReportData.AddCustomParameter(customParameter))
          flag = true;
      }
      while (flag);
      cursor = num7;
      return paramTagReportData;
    }

    public override string ToString()
    {
      string str = "<TagReportData>" + "\r\n";
      if (this.EPCParameter != null)
      {
        int count = this.EPCParameter.Count;
        for (int index = 0; index < count; ++index)
          str += Util.Indent(this.EPCParameter[index].ToString());
      }
      if (this.ROSpecID != null)
        str += Util.Indent(this.ROSpecID.ToString());
      if (this.SpecIndex != null)
        str += Util.Indent(this.SpecIndex.ToString());
      if (this.InventoryParameterSpecID != null)
        str += Util.Indent(this.InventoryParameterSpecID.ToString());
      if (this.AntennaID != null)
        str += Util.Indent(this.AntennaID.ToString());
      if (this.PeakRSSI != null)
        str += Util.Indent(this.PeakRSSI.ToString());
      if (this.ChannelIndex != null)
        str += Util.Indent(this.ChannelIndex.ToString());
      if (this.FirstSeenTimestampUTC != null)
        str += Util.Indent(this.FirstSeenTimestampUTC.ToString());
      if (this.FirstSeenTimestampUptime != null)
        str += Util.Indent(this.FirstSeenTimestampUptime.ToString());
      if (this.LastSeenTimestampUTC != null)
        str += Util.Indent(this.LastSeenTimestampUTC.ToString());
      if (this.LastSeenTimestampUptime != null)
        str += Util.Indent(this.LastSeenTimestampUptime.ToString());
      if (this.TagSeenCount != null)
        str += Util.Indent(this.TagSeenCount.ToString());
      if (this.AirProtocolTagData != null)
      {
        int count = this.AirProtocolTagData.Count;
        for (int index = 0; index < count; ++index)
          str += Util.Indent(this.AirProtocolTagData[index].ToString());
      }
      if (this.AccessSpecID != null)
        str += Util.Indent(this.AccessSpecID.ToString());
      if (this.AccessCommandOpSpecResult != null)
      {
        int count = this.AccessCommandOpSpecResult.Count;
        for (int index = 0; index < count; ++index)
          str += Util.Indent(this.AccessCommandOpSpecResult[index].ToString());
      }
      if (this.Custom != null)
      {
        int length = this.Custom.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.Custom[index].ToString());
      }
      return str + "</TagReportData>" + "\r\n";
    }

    public static PARAM_TagReportData FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_TagReportData paramTagReportData = new PARAM_TagReportData();
      paramTagReportData.EPCParameter = new UNION_EPCParameter();
      try
      {
        foreach (XmlNode childNode in node.ChildNodes)
        {
          switch (childNode.Name)
          {
            case "EPCData":
              paramTagReportData.EPCParameter.Add((IParameter) PARAM_EPCData.FromXmlNode(childNode));
              continue;
            case "EPC_96":
              paramTagReportData.EPCParameter.Add((IParameter) PARAM_EPC_96.FromXmlNode(childNode));
              continue;
            default:
              continue;
          }
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "ROSpecID", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramTagReportData.ROSpecID = PARAM_ROSpecID.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "SpecIndex", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramTagReportData.SpecIndex = PARAM_SpecIndex.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "InventoryParameterSpecID", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramTagReportData.InventoryParameterSpecID = PARAM_InventoryParameterSpecID.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "AntennaID", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramTagReportData.AntennaID = PARAM_AntennaID.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "PeakRSSI", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramTagReportData.PeakRSSI = PARAM_PeakRSSI.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "ChannelIndex", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramTagReportData.ChannelIndex = PARAM_ChannelIndex.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "FirstSeenTimestampUTC", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramTagReportData.FirstSeenTimestampUTC = PARAM_FirstSeenTimestampUTC.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "FirstSeenTimestampUptime", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramTagReportData.FirstSeenTimestampUptime = PARAM_FirstSeenTimestampUptime.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "LastSeenTimestampUTC", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramTagReportData.LastSeenTimestampUTC = PARAM_LastSeenTimestampUTC.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "LastSeenTimestampUptime", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramTagReportData.LastSeenTimestampUptime = PARAM_LastSeenTimestampUptime.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "TagSeenCount", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramTagReportData.TagSeenCount = PARAM_TagSeenCount.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      paramTagReportData.AirProtocolTagData = new UNION_AirProtocolTagData();
      try
      {
        foreach (XmlNode childNode in node.ChildNodes)
        {
          switch (childNode.Name)
          {
            case "C1G2_PC":
              paramTagReportData.AirProtocolTagData.Add((IParameter) PARAM_C1G2_PC.FromXmlNode(childNode));
              continue;
            case "C1G2_CRC":
              paramTagReportData.AirProtocolTagData.Add((IParameter) PARAM_C1G2_CRC.FromXmlNode(childNode));
              continue;
            default:
              continue;
          }
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "AccessSpecID", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramTagReportData.AccessSpecID = PARAM_AccessSpecID.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      paramTagReportData.AccessCommandOpSpecResult = new UNION_AccessCommandOpSpecResult();
      try
      {
        foreach (XmlNode childNode in node.ChildNodes)
        {
          switch (childNode.Name)
          {
            case "C1G2ReadOpSpecResult":
              paramTagReportData.AccessCommandOpSpecResult.Add((IParameter) PARAM_C1G2ReadOpSpecResult.FromXmlNode(childNode));
              continue;
            case "C1G2WriteOpSpecResult":
              paramTagReportData.AccessCommandOpSpecResult.Add((IParameter) PARAM_C1G2WriteOpSpecResult.FromXmlNode(childNode));
              continue;
            case "C1G2KillOpSpecResult":
              paramTagReportData.AccessCommandOpSpecResult.Add((IParameter) PARAM_C1G2KillOpSpecResult.FromXmlNode(childNode));
              continue;
            case "C1G2LockOpSpecResult":
              paramTagReportData.AccessCommandOpSpecResult.Add((IParameter) PARAM_C1G2LockOpSpecResult.FromXmlNode(childNode));
              continue;
            case "C1G2BlockEraseOpSpecResult":
              paramTagReportData.AccessCommandOpSpecResult.Add((IParameter) PARAM_C1G2BlockEraseOpSpecResult.FromXmlNode(childNode));
              continue;
            case "C1G2BlockWriteOpSpecResult":
              paramTagReportData.AccessCommandOpSpecResult.Add((IParameter) PARAM_C1G2BlockWriteOpSpecResult.FromXmlNode(childNode));
              continue;
            default:
              if (!arrayList.Contains((object) childNode))
              {
                ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeXmlNodeToCustomParameter(childNode);
                if (customParameter != null && paramTagReportData.AccessCommandOpSpecResult.AddCustomParameter(customParameter))
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
        ArrayList nodeCustomChildren = XmlUtil.GetXmlNodeCustomChildren(node, nsmgr);
        if (nodeCustomChildren != null)
        {
          for (int index = 0; index < nodeCustomChildren.Count; ++index)
          {
            if (!arrayList.Contains(nodeCustomChildren[index]))
            {
              ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeXmlNodeToCustomParameter((XmlNode) nodeCustomChildren[index]);
              if (customParameter != null && paramTagReportData.AddCustomParameter(customParameter))
                arrayList.Add(nodeCustomChildren[index]);
            }
          }
        }
      }
      catch
      {
      }
      return paramTagReportData;
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
      int count1 = this.EPCParameter.Count;
      for (int index = 0; index < count1; ++index)
        this.EPCParameter[index].ToBitArray(ref bit_array, ref cursor);
      if (this.ROSpecID != null)
        this.ROSpecID.ToBitArray(ref bit_array, ref cursor);
      if (this.SpecIndex != null)
        this.SpecIndex.ToBitArray(ref bit_array, ref cursor);
      if (this.InventoryParameterSpecID != null)
        this.InventoryParameterSpecID.ToBitArray(ref bit_array, ref cursor);
      if (this.AntennaID != null)
        this.AntennaID.ToBitArray(ref bit_array, ref cursor);
      if (this.PeakRSSI != null)
        this.PeakRSSI.ToBitArray(ref bit_array, ref cursor);
      if (this.ChannelIndex != null)
        this.ChannelIndex.ToBitArray(ref bit_array, ref cursor);
      if (this.FirstSeenTimestampUTC != null)
        this.FirstSeenTimestampUTC.ToBitArray(ref bit_array, ref cursor);
      if (this.FirstSeenTimestampUptime != null)
        this.FirstSeenTimestampUptime.ToBitArray(ref bit_array, ref cursor);
      if (this.LastSeenTimestampUTC != null)
        this.LastSeenTimestampUTC.ToBitArray(ref bit_array, ref cursor);
      if (this.LastSeenTimestampUptime != null)
        this.LastSeenTimestampUptime.ToBitArray(ref bit_array, ref cursor);
      if (this.TagSeenCount != null)
        this.TagSeenCount.ToBitArray(ref bit_array, ref cursor);
      int count2 = this.AirProtocolTagData.Count;
      for (int index = 0; index < count2; ++index)
        this.AirProtocolTagData[index].ToBitArray(ref bit_array, ref cursor);
      if (this.AccessSpecID != null)
        this.AccessSpecID.ToBitArray(ref bit_array, ref cursor);
      int count3 = this.AccessCommandOpSpecResult.Count;
      for (int index = 0; index < count3; ++index)
        this.AccessCommandOpSpecResult[index].ToBitArray(ref bit_array, ref cursor);
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
