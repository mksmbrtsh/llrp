// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_ReceiveSensitivityTableEntry
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_ReceiveSensitivityTableEntry : Parameter
  {
    public ushort Index;
    private short Index_len;
    public short ReceiveSensitivityValue;
    private short ReceiveSensitivityValue_len;

    public PARAM_ReceiveSensitivityTableEntry() => this.typeID = (ushort) 139;

    public static PARAM_ReceiveSensitivityTableEntry FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_ReceiveSensitivityTableEntry) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_ReceiveSensitivityTableEntry sensitivityTableEntry = new PARAM_ReceiveSensitivityTableEntry();
      sensitivityTableEntry.tvCoding = bit_array[cursor];
      int val;
      if (sensitivityTableEntry.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        sensitivityTableEntry.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) sensitivityTableEntry.length * 8;
      }
      if (val != (int) sensitivityTableEntry.TypeID)
      {
        cursor = num1;
        return (PARAM_ReceiveSensitivityTableEntry) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len1);
      sensitivityTableEntry.Index = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (short), field_len2);
      sensitivityTableEntry.ReceiveSensitivityValue = (short) obj;
      return sensitivityTableEntry;
    }

    public override string ToString()
    {
      string str = "<ReceiveSensitivityTableEntry>" + "\r\n";
      try
      {
        str = str + "  <Index>" + Util.ConvertValueTypeToString((object) this.Index, "u16", "") + "</Index>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <ReceiveSensitivityValue>" + Util.ConvertValueTypeToString((object) this.ReceiveSensitivityValue, "s16", "") + "</ReceiveSensitivityValue>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</ReceiveSensitivityTableEntry>" + "\r\n";
    }

    public static PARAM_ReceiveSensitivityTableEntry FromXmlNode(
      XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_ReceiveSensitivityTableEntry sensitivityTableEntry = new PARAM_ReceiveSensitivityTableEntry();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "Index");
      sensitivityTableEntry.Index = (ushort) Util.ParseValueTypeFromString(nodeValue1, "u16", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "ReceiveSensitivityValue");
      sensitivityTableEntry.ReceiveSensitivityValue = (short) Util.ParseValueTypeFromString(nodeValue2, "s16", "");
      return sensitivityTableEntry;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.Index, (int) this.Index_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.ReceiveSensitivityValue, (int) this.ReceiveSensitivityValue_len);
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
