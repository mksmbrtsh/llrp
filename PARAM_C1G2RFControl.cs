// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2RFControl
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2RFControl : Parameter
  {
    public ushort ModeIndex;
    private short ModeIndex_len;
    public ushort Tari;
    private short Tari_len;

    public PARAM_C1G2RFControl() => this.typeID = (ushort) 335;

    public static PARAM_C1G2RFControl FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2RFControl) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_C1G2RFControl paramC1G2RfControl = new PARAM_C1G2RFControl();
      paramC1G2RfControl.tvCoding = bit_array[cursor];
      int val;
      if (paramC1G2RfControl.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramC1G2RfControl.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramC1G2RfControl.length * 8;
      }
      if (val != (int) paramC1G2RfControl.TypeID)
      {
        cursor = num1;
        return (PARAM_C1G2RFControl) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len1);
      paramC1G2RfControl.ModeIndex = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len2);
      paramC1G2RfControl.Tari = (ushort) obj;
      return paramC1G2RfControl;
    }

    public override string ToString()
    {
      string str = "<C1G2RFControl>" + "\r\n";
      try
      {
        str = str + "  <ModeIndex>" + Util.ConvertValueTypeToString((object) this.ModeIndex, "u16", "") + "</ModeIndex>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <Tari>" + Util.ConvertValueTypeToString((object) this.Tari, "u16", "") + "</Tari>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</C1G2RFControl>" + "\r\n";
    }

    public static PARAM_C1G2RFControl FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2RFControl paramC1G2RfControl = new PARAM_C1G2RFControl();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "ModeIndex");
      paramC1G2RfControl.ModeIndex = (ushort) Util.ParseValueTypeFromString(nodeValue1, "u16", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "Tari");
      paramC1G2RfControl.Tari = (ushort) Util.ParseValueTypeFromString(nodeValue2, "u16", "");
      return paramC1G2RfControl;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.ModeIndex, (int) this.ModeIndex_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.Tari, (int) this.Tari_len);
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
