// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_ROSpecStopTrigger
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_ROSpecStopTrigger : Parameter
  {
    public ENUM_ROSpecStopTriggerType ROSpecStopTriggerType;
    private short ROSpecStopTriggerType_len = 8;
    public uint DurationTriggerValue;
    private short DurationTriggerValue_len;
    public PARAM_GPITriggerValue GPITriggerValue;

    public PARAM_ROSpecStopTrigger() => this.typeID = (ushort) 182;

    public static PARAM_ROSpecStopTrigger FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_ROSpecStopTrigger) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_ROSpecStopTrigger roSpecStopTrigger = new PARAM_ROSpecStopTrigger();
      roSpecStopTrigger.tvCoding = bit_array[cursor];
      int val;
      if (roSpecStopTrigger.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        roSpecStopTrigger.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) roSpecStopTrigger.length * 8;
      }
      if (val != (int) roSpecStopTrigger.TypeID)
      {
        cursor = num1;
        return (PARAM_ROSpecStopTrigger) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 8;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len1);
      roSpecStopTrigger.ROSpecStopTriggerType = (ENUM_ROSpecStopTriggerType) (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len2);
      roSpecStopTrigger.DurationTriggerValue = (uint) obj;
      roSpecStopTrigger.GPITriggerValue = PARAM_GPITriggerValue.FromBitArray(ref bit_array, ref cursor, length);
      return roSpecStopTrigger;
    }

    public override string ToString()
    {
      string str = "<ROSpecStopTrigger>" + "\r\n";
      try
      {
        str = str + "  <ROSpecStopTriggerType>" + this.ROSpecStopTriggerType.ToString() + "</ROSpecStopTriggerType>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <DurationTriggerValue>" + Util.ConvertValueTypeToString((object) this.DurationTriggerValue, "u32", "") + "</DurationTriggerValue>";
        str += "\r\n";
      }
      catch
      {
      }
      if (this.GPITriggerValue != null)
        str += Util.Indent(this.GPITriggerValue.ToString());
      return str + "</ROSpecStopTrigger>" + "\r\n";
    }

    public static PARAM_ROSpecStopTrigger FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_ROSpecStopTrigger roSpecStopTrigger = new PARAM_ROSpecStopTrigger();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "ROSpecStopTriggerType");
      roSpecStopTrigger.ROSpecStopTriggerType = (ENUM_ROSpecStopTriggerType) Enum.Parse(typeof (ENUM_ROSpecStopTriggerType), nodeValue1);
      string nodeValue2 = XmlUtil.GetNodeValue(node, "DurationTriggerValue");
      roSpecStopTrigger.DurationTriggerValue = (uint) Util.ParseValueTypeFromString(nodeValue2, "u32", "");
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "GPITriggerValue", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            roSpecStopTrigger.GPITriggerValue = PARAM_GPITriggerValue.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      return roSpecStopTrigger;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.ROSpecStopTriggerType, (int) this.ROSpecStopTriggerType_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.DurationTriggerValue, (int) this.DurationTriggerValue_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      if (this.GPITriggerValue != null)
        this.GPITriggerValue.ToBitArray(ref bit_array, ref cursor);
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
