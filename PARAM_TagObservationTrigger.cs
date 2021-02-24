// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_TagObservationTrigger
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_TagObservationTrigger : Parameter
  {
    private const ushort param_reserved_len3 = 8;
    public ENUM_TagObservationTriggerType TriggerType;
    private short TriggerType_len = 8;
    public ushort NumberOfTags;
    private short NumberOfTags_len;
    public ushort NumberOfAttempts;
    private short NumberOfAttempts_len;
    public ushort T;
    private short T_len;
    public uint Timeout;
    private short Timeout_len;

    public PARAM_TagObservationTrigger() => this.typeID = (ushort) 185;

    public static PARAM_TagObservationTrigger FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_TagObservationTrigger) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_TagObservationTrigger observationTrigger = new PARAM_TagObservationTrigger();
      observationTrigger.tvCoding = bit_array[cursor];
      int val;
      if (observationTrigger.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        observationTrigger.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) observationTrigger.length * 8;
      }
      if (val != (int) observationTrigger.TypeID)
      {
        cursor = num1;
        return (PARAM_TagObservationTrigger) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 8;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len1);
      observationTrigger.TriggerType = (ENUM_TagObservationTriggerType) (uint) obj;
      cursor += 8;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len2);
      observationTrigger.NumberOfTags = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len3 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len3);
      observationTrigger.NumberOfAttempts = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len4 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len4);
      observationTrigger.T = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len5 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len5);
      observationTrigger.Timeout = (uint) obj;
      return observationTrigger;
    }

    public override string ToString()
    {
      string str = "<TagObservationTrigger>" + "\r\n";
      try
      {
        str = str + "  <TriggerType>" + this.TriggerType.ToString() + "</TriggerType>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <NumberOfTags>" + Util.ConvertValueTypeToString((object) this.NumberOfTags, "u16", "") + "</NumberOfTags>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <NumberOfAttempts>" + Util.ConvertValueTypeToString((object) this.NumberOfAttempts, "u16", "") + "</NumberOfAttempts>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <T>" + Util.ConvertValueTypeToString((object) this.T, "u16", "") + "</T>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <Timeout>" + Util.ConvertValueTypeToString((object) this.Timeout, "u32", "") + "</Timeout>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</TagObservationTrigger>" + "\r\n";
    }

    public static PARAM_TagObservationTrigger FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_TagObservationTrigger observationTrigger = new PARAM_TagObservationTrigger();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "TriggerType");
      observationTrigger.TriggerType = (ENUM_TagObservationTriggerType) Enum.Parse(typeof (ENUM_TagObservationTriggerType), nodeValue1);
      string nodeValue2 = XmlUtil.GetNodeValue(node, "NumberOfTags");
      observationTrigger.NumberOfTags = (ushort) Util.ParseValueTypeFromString(nodeValue2, "u16", "");
      string nodeValue3 = XmlUtil.GetNodeValue(node, "NumberOfAttempts");
      observationTrigger.NumberOfAttempts = (ushort) Util.ParseValueTypeFromString(nodeValue3, "u16", "");
      string nodeValue4 = XmlUtil.GetNodeValue(node, "T");
      observationTrigger.T = (ushort) Util.ParseValueTypeFromString(nodeValue4, "u16", "");
      string nodeValue5 = XmlUtil.GetNodeValue(node, "Timeout");
      observationTrigger.Timeout = (uint) Util.ParseValueTypeFromString(nodeValue5, "u32", "");
      return observationTrigger;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.TriggerType, (int) this.TriggerType_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      cursor += 8;
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.NumberOfTags, (int) this.NumberOfTags_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.NumberOfAttempts, (int) this.NumberOfAttempts_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.T, (int) this.T_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.Timeout, (int) this.Timeout_len);
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
