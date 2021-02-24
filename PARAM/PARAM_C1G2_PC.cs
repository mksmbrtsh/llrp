// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2_PC
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2_PC : Parameter
  {
    public ushort PC_Bits;
    private short PC_Bits_len;

    public PARAM_C1G2_PC()
    {
      this.typeID = (ushort) 12;
      this.tvCoding = true;
    }

    public static PARAM_C1G2_PC FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2_PC) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_C1G2_PC paramC1G2Pc = new PARAM_C1G2_PC();
      paramC1G2Pc.tvCoding = bit_array[cursor];
      int val;
      if (paramC1G2Pc.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramC1G2Pc.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramC1G2Pc.length * 8;
      }
      if (val != (int) paramC1G2Pc.TypeID)
      {
        cursor = num1;
        return (PARAM_C1G2_PC) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len);
      paramC1G2Pc.PC_Bits = (ushort) obj;
      return paramC1G2Pc;
    }

    public override string ToString()
    {
      string str = "<C1G2_PC>" + "\r\n";
      try
      {
        str = str + "  <PC_Bits>" + Util.ConvertValueTypeToString((object) this.PC_Bits, "u16", "") + "</PC_Bits>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</C1G2_PC>" + "\r\n";
    }

    public static PARAM_C1G2_PC FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2_PC paramC1G2Pc = new PARAM_C1G2_PC();
      string nodeValue = XmlUtil.GetNodeValue(node, "PC_Bits");
      paramC1G2Pc.PC_Bits = (ushort) Util.ParseValueTypeFromString(nodeValue, "u16", "");
      return paramC1G2Pc;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.PC_Bits, (int) this.PC_Bits_len);
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
