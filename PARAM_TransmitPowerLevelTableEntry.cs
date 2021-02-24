// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_TransmitPowerLevelTableEntry
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_TransmitPowerLevelTableEntry : Parameter
  {
    public ushort Index;
    private short Index_len;
    public short TransmitPowerValue;
    private short TransmitPowerValue_len;

    public PARAM_TransmitPowerLevelTableEntry() => this.typeID = (ushort) 145;

    public static PARAM_TransmitPowerLevelTableEntry FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_TransmitPowerLevelTableEntry) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_TransmitPowerLevelTableEntry powerLevelTableEntry = new PARAM_TransmitPowerLevelTableEntry();
      powerLevelTableEntry.tvCoding = bit_array[cursor];
      int val;
      if (powerLevelTableEntry.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        powerLevelTableEntry.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) powerLevelTableEntry.length * 8;
      }
      if (val != (int) powerLevelTableEntry.TypeID)
      {
        cursor = num1;
        return (PARAM_TransmitPowerLevelTableEntry) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len1);
      powerLevelTableEntry.Index = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (short), field_len2);
      powerLevelTableEntry.TransmitPowerValue = (short) obj;
      return powerLevelTableEntry;
    }

    public override string ToString()
    {
      string str = "<TransmitPowerLevelTableEntry>" + "\r\n";
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
        str = str + "  <TransmitPowerValue>" + Util.ConvertValueTypeToString((object) this.TransmitPowerValue, "s16", "") + "</TransmitPowerValue>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</TransmitPowerLevelTableEntry>" + "\r\n";
    }

    public static PARAM_TransmitPowerLevelTableEntry FromXmlNode(
      XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_TransmitPowerLevelTableEntry powerLevelTableEntry = new PARAM_TransmitPowerLevelTableEntry();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "Index");
      powerLevelTableEntry.Index = (ushort) Util.ParseValueTypeFromString(nodeValue1, "u16", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "TransmitPowerValue");
      powerLevelTableEntry.TransmitPowerValue = (short) Util.ParseValueTypeFromString(nodeValue2, "s16", "");
      return powerLevelTableEntry;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.TransmitPowerValue, (int) this.TransmitPowerValue_len);
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
