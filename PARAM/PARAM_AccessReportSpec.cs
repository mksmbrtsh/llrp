// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_AccessReportSpec
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_AccessReportSpec : Parameter
  {
    public ENUM_AccessReportTriggerType AccessReportTrigger;
    private short AccessReportTrigger_len = 8;

    public PARAM_AccessReportSpec() => this.typeID = (ushort) 239;

    public static PARAM_AccessReportSpec FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_AccessReportSpec) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_AccessReportSpec accessReportSpec = new PARAM_AccessReportSpec();
      accessReportSpec.tvCoding = bit_array[cursor];
      int val;
      if (accessReportSpec.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        accessReportSpec.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) accessReportSpec.length * 8;
      }
      if (val != (int) accessReportSpec.TypeID)
      {
        cursor = num1;
        return (PARAM_AccessReportSpec) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len = 8;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len);
      accessReportSpec.AccessReportTrigger = (ENUM_AccessReportTriggerType) (uint) obj;
      return accessReportSpec;
    }

    public override string ToString()
    {
      string str = "<AccessReportSpec>" + "\r\n";
      try
      {
        str = str + "  <AccessReportTrigger>" + this.AccessReportTrigger.ToString() + "</AccessReportTrigger>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</AccessReportSpec>" + "\r\n";
    }

    public static PARAM_AccessReportSpec FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_AccessReportSpec accessReportSpec = new PARAM_AccessReportSpec();
      string nodeValue = XmlUtil.GetNodeValue(node, "AccessReportTrigger");
      accessReportSpec.AccessReportTrigger = (ENUM_AccessReportTriggerType) Enum.Parse(typeof (ENUM_AccessReportTriggerType), nodeValue);
      return accessReportSpec;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.AccessReportTrigger, (int) this.AccessReportTrigger_len);
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
