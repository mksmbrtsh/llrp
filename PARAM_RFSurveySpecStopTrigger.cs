// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_RFSurveySpecStopTrigger
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_RFSurveySpecStopTrigger : Parameter
  {
    public ENUM_RFSurveySpecStopTriggerType StopTriggerType;
    private short StopTriggerType_len = 8;
    public uint DurationPeriod;
    private short DurationPeriod_len;
    public uint N;
    private short N_len;

    public PARAM_RFSurveySpecStopTrigger() => this.typeID = (ushort) 188;

    public static PARAM_RFSurveySpecStopTrigger FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_RFSurveySpecStopTrigger) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_RFSurveySpecStopTrigger surveySpecStopTrigger = new PARAM_RFSurveySpecStopTrigger();
      surveySpecStopTrigger.tvCoding = bit_array[cursor];
      int val;
      if (surveySpecStopTrigger.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        surveySpecStopTrigger.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) surveySpecStopTrigger.length * 8;
      }
      if (val != (int) surveySpecStopTrigger.TypeID)
      {
        cursor = num1;
        return (PARAM_RFSurveySpecStopTrigger) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 8;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len1);
      surveySpecStopTrigger.StopTriggerType = (ENUM_RFSurveySpecStopTriggerType) (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len2);
      surveySpecStopTrigger.DurationPeriod = (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len3 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len3);
      surveySpecStopTrigger.N = (uint) obj;
      return surveySpecStopTrigger;
    }

    public override string ToString()
    {
      string str = "<RFSurveySpecStopTrigger>" + "\r\n";
      try
      {
        str = str + "  <StopTriggerType>" + this.StopTriggerType.ToString() + "</StopTriggerType>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <DurationPeriod>" + Util.ConvertValueTypeToString((object) this.DurationPeriod, "u32", "") + "</DurationPeriod>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <N>" + Util.ConvertValueTypeToString((object) this.N, "u32", "") + "</N>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</RFSurveySpecStopTrigger>" + "\r\n";
    }

    public static PARAM_RFSurveySpecStopTrigger FromXmlNode(
      XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_RFSurveySpecStopTrigger surveySpecStopTrigger = new PARAM_RFSurveySpecStopTrigger();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "StopTriggerType");
      surveySpecStopTrigger.StopTriggerType = (ENUM_RFSurveySpecStopTriggerType) Enum.Parse(typeof (ENUM_RFSurveySpecStopTriggerType), nodeValue1);
      string nodeValue2 = XmlUtil.GetNodeValue(node, "DurationPeriod");
      surveySpecStopTrigger.DurationPeriod = (uint) Util.ParseValueTypeFromString(nodeValue2, "u32", "");
      string nodeValue3 = XmlUtil.GetNodeValue(node, "N");
      surveySpecStopTrigger.N = (uint) Util.ParseValueTypeFromString(nodeValue3, "u32", "");
      return surveySpecStopTrigger;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.StopTriggerType, (int) this.StopTriggerType_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.DurationPeriod, (int) this.DurationPeriod_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.N, (int) this.N_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
