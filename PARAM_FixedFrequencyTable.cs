// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_FixedFrequencyTable
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_FixedFrequencyTable : Parameter
  {
    public UInt32Array Frequency = new UInt32Array();
    private short Frequency_len;

    public PARAM_FixedFrequencyTable() => this.typeID = (ushort) 148;

    public static PARAM_FixedFrequencyTable FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_FixedFrequencyTable) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_FixedFrequencyTable fixedFrequencyTable = new PARAM_FixedFrequencyTable();
      fixedFrequencyTable.tvCoding = bit_array[cursor];
      int val;
      if (fixedFrequencyTable.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        fixedFrequencyTable.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) fixedFrequencyTable.length * 8;
      }
      if (val != (int) fixedFrequencyTable.TypeID)
      {
        cursor = num1;
        return (PARAM_FixedFrequencyTable) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int fieldLength = Util.DetermineFieldLength(ref bit_array, ref cursor);
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (UInt32Array), fieldLength);
      fixedFrequencyTable.Frequency = (UInt32Array) obj;
      return fixedFrequencyTable;
    }

    public override string ToString()
    {
      string str = "<FixedFrequencyTable>" + "\r\n";
      if (this.Frequency != null)
      {
        try
        {
          str = str + "  <Frequency>" + Util.ConvertArrayTypeToString((object) this.Frequency, "u32v", "") + "</Frequency>";
          str += "\r\n";
        }
        catch
        {
        }
      }
      return str + "</FixedFrequencyTable>" + "\r\n";
    }

    public static PARAM_FixedFrequencyTable FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_FixedFrequencyTable fixedFrequencyTable = new PARAM_FixedFrequencyTable();
      string nodeValue = XmlUtil.GetNodeValue(node, "Frequency");
      fixedFrequencyTable.Frequency = (UInt32Array) Util.ParseArrayTypeFromString(nodeValue, "u32v", "");
      return fixedFrequencyTable;
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
      if (this.Frequency != null)
      {
        try
        {
          Util.ConvertIntToBitArray((uint) this.Frequency.Count, 16).CopyTo((Array) bit_array, cursor);
          cursor += 16;
          BitArray bitArray = Util.ConvertObjToBitArray((object) this.Frequency, (int) this.Frequency_len);
          bitArray.CopyTo((Array) bit_array, cursor);
          cursor += bitArray.Length;
        }
        catch
        {
        }
      }
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
