// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_UHFBandCapabilities
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_UHFBandCapabilities : Parameter
  {
    public PARAM_TransmitPowerLevelTableEntry[] TransmitPowerLevelTableEntry;
    public PARAM_FrequencyInformation FrequencyInformation;
    public UNION_AirProtocolUHFRFModeTable AirProtocolUHFRFModeTable = new UNION_AirProtocolUHFRFModeTable();

    public PARAM_UHFBandCapabilities() => this.typeID = (ushort) 144;

    public static PARAM_UHFBandCapabilities FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_UHFBandCapabilities) null;
      int num1 = cursor;
      ArrayList arrayList1 = new ArrayList();
      PARAM_UHFBandCapabilities bandCapabilities = new PARAM_UHFBandCapabilities();
      bandCapabilities.tvCoding = bit_array[cursor];
      int val;
      if (bandCapabilities.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        bandCapabilities.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        int length1 = (int) bandCapabilities.length;
      }
      if (val != (int) bandCapabilities.TypeID)
      {
        cursor = num1;
        return (PARAM_UHFBandCapabilities) null;
      }
      ArrayList arrayList2 = new ArrayList();
      PARAM_TransmitPowerLevelTableEntry powerLevelTableEntry;
      while ((powerLevelTableEntry = PARAM_TransmitPowerLevelTableEntry.FromBitArray(ref bit_array, ref cursor, length)) != null)
        arrayList2.Add((object) powerLevelTableEntry);
      if (arrayList2.Count > 0)
      {
        bandCapabilities.TransmitPowerLevelTableEntry = new PARAM_TransmitPowerLevelTableEntry[arrayList2.Count];
        for (int index = 0; index < arrayList2.Count; ++index)
          bandCapabilities.TransmitPowerLevelTableEntry[index] = (PARAM_TransmitPowerLevelTableEntry) arrayList2[index];
      }
      bandCapabilities.FrequencyInformation = PARAM_FrequencyInformation.FromBitArray(ref bit_array, ref cursor, length);
      ushort num2 = 1;
      while (num2 != (ushort) 0)
      {
        num2 = (ushort) 0;
        PARAM_C1G2UHFRFModeTable g2UhfrfModeTable = PARAM_C1G2UHFRFModeTable.FromBitArray(ref bit_array, ref cursor, length);
        if (g2UhfrfModeTable != null)
        {
          ++num2;
          bandCapabilities.AirProtocolUHFRFModeTable.Add((IParameter) g2UhfrfModeTable);
        }
      }
      return bandCapabilities;
    }

    public override string ToString()
    {
      string str = "<UHFBandCapabilities>" + "\r\n";
      if (this.TransmitPowerLevelTableEntry != null)
      {
        int length = this.TransmitPowerLevelTableEntry.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.TransmitPowerLevelTableEntry[index].ToString());
      }
      if (this.FrequencyInformation != null)
        str += Util.Indent(this.FrequencyInformation.ToString());
      if (this.AirProtocolUHFRFModeTable != null)
      {
        int count = this.AirProtocolUHFRFModeTable.Count;
        for (int index = 0; index < count; ++index)
          str += Util.Indent(this.AirProtocolUHFRFModeTable[index].ToString());
      }
      return str + "</UHFBandCapabilities>" + "\r\n";
    }

    public static PARAM_UHFBandCapabilities FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_UHFBandCapabilities bandCapabilities = new PARAM_UHFBandCapabilities();
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "TransmitPowerLevelTableEntry", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
          {
            bandCapabilities.TransmitPowerLevelTableEntry = new PARAM_TransmitPowerLevelTableEntry[xmlNodes.Count];
            for (int i = 0; i < xmlNodes.Count; ++i)
              bandCapabilities.TransmitPowerLevelTableEntry[i] = PARAM_TransmitPowerLevelTableEntry.FromXmlNode(xmlNodes[i]);
          }
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "FrequencyInformation", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            bandCapabilities.FrequencyInformation = PARAM_FrequencyInformation.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      bandCapabilities.AirProtocolUHFRFModeTable = new UNION_AirProtocolUHFRFModeTable();
      try
      {
        foreach (XmlNode childNode in node.ChildNodes)
        {
          switch (childNode.Name)
          {
            case "C1G2UHFRFModeTable":
              bandCapabilities.AirProtocolUHFRFModeTable.Add((IParameter) PARAM_C1G2UHFRFModeTable.FromXmlNode(childNode));
              continue;
            default:
              continue;
          }
        }
      }
      catch
      {
      }
      return bandCapabilities;
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
      if (this.TransmitPowerLevelTableEntry != null)
      {
        int length = this.TransmitPowerLevelTableEntry.Length;
        for (int index = 0; index < length; ++index)
          this.TransmitPowerLevelTableEntry[index].ToBitArray(ref bit_array, ref cursor);
      }
      if (this.FrequencyInformation != null)
        this.FrequencyInformation.ToBitArray(ref bit_array, ref cursor);
      int count = this.AirProtocolUHFRFModeTable.Count;
      for (int index = 0; index < count; ++index)
        this.AirProtocolUHFRFModeTable[index].ToBitArray(ref bit_array, ref cursor);
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
