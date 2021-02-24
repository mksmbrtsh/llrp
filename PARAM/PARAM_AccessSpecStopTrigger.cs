// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_AccessSpecStopTrigger
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_AccessSpecStopTrigger : Parameter
  {
    public ENUM_AccessSpecStopTriggerType AccessSpecStopTrigger;
    private short AccessSpecStopTrigger_len = 8;
    public ushort OperationCountValue;
    private short OperationCountValue_len;

    public PARAM_AccessSpecStopTrigger() => this.typeID = (ushort) 208;

    public static PARAM_AccessSpecStopTrigger FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_AccessSpecStopTrigger) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_AccessSpecStopTrigger accessSpecStopTrigger = new PARAM_AccessSpecStopTrigger();
      accessSpecStopTrigger.tvCoding = bit_array[cursor];
      int val;
      if (accessSpecStopTrigger.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        accessSpecStopTrigger.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) accessSpecStopTrigger.length * 8;
      }
      if (val != (int) accessSpecStopTrigger.TypeID)
      {
        cursor = num1;
        return (PARAM_AccessSpecStopTrigger) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 8;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len1);
      accessSpecStopTrigger.AccessSpecStopTrigger = (ENUM_AccessSpecStopTriggerType) (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len2);
      accessSpecStopTrigger.OperationCountValue = (ushort) obj;
      return accessSpecStopTrigger;
    }

    public override string ToString()
    {
      string str = "<AccessSpecStopTrigger>" + "\r\n";
      try
      {
        str = str + "  <AccessSpecStopTrigger>" + this.AccessSpecStopTrigger.ToString() + "</AccessSpecStopTrigger>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <OperationCountValue>" + Util.ConvertValueTypeToString((object) this.OperationCountValue, "u16", "") + "</OperationCountValue>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</AccessSpecStopTrigger>" + "\r\n";
    }

    public static PARAM_AccessSpecStopTrigger FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_AccessSpecStopTrigger accessSpecStopTrigger = new PARAM_AccessSpecStopTrigger();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "AccessSpecStopTrigger");
      accessSpecStopTrigger.AccessSpecStopTrigger = (ENUM_AccessSpecStopTriggerType) Enum.Parse(typeof (ENUM_AccessSpecStopTriggerType), nodeValue1);
      string nodeValue2 = XmlUtil.GetNodeValue(node, "OperationCountValue");
      accessSpecStopTrigger.OperationCountValue = (ushort) Util.ParseValueTypeFromString(nodeValue2, "u16", "");
      return accessSpecStopTrigger;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.AccessSpecStopTrigger, (int) this.AccessSpecStopTrigger_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.OperationCountValue, (int) this.OperationCountValue_len);
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
