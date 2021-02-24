// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2_CRC
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2_CRC : Parameter
  {
    public ushort CRC;
    private short CRC_len;

    public PARAM_C1G2_CRC()
    {
      this.typeID = (ushort) 11;
      this.tvCoding = true;
    }

    public static PARAM_C1G2_CRC FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2_CRC) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_C1G2_CRC paramC1G2Crc = new PARAM_C1G2_CRC();
      paramC1G2Crc.tvCoding = bit_array[cursor];
      int val;
      if (paramC1G2Crc.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramC1G2Crc.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramC1G2Crc.length * 8;
      }
      if (val != (int) paramC1G2Crc.TypeID)
      {
        cursor = num1;
        return (PARAM_C1G2_CRC) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len);
      paramC1G2Crc.CRC = (ushort) obj;
      return paramC1G2Crc;
    }

    public override string ToString()
    {
      string str = "<C1G2_CRC>" + "\r\n";
      try
      {
        str = str + "  <CRC>" + Util.ConvertValueTypeToString((object) this.CRC, "u16", "") + "</CRC>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</C1G2_CRC>" + "\r\n";
    }

    public static PARAM_C1G2_CRC FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2_CRC paramC1G2Crc = new PARAM_C1G2_CRC();
      string nodeValue = XmlUtil.GetNodeValue(node, "CRC");
      paramC1G2Crc.CRC = (ushort) Util.ParseValueTypeFromString(nodeValue, "u16", "");
      return paramC1G2Crc;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.CRC, (int) this.CRC_len);
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
