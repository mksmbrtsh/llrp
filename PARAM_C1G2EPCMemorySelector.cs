// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2EPCMemorySelector
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2EPCMemorySelector : Parameter
  {
    private const ushort param_reserved_len4 = 6;
    public bool EnableCRC;
    private short EnableCRC_len;
    public bool EnablePCBits;
    private short EnablePCBits_len;

    public PARAM_C1G2EPCMemorySelector() => this.typeID = (ushort) 348;

    public static PARAM_C1G2EPCMemorySelector FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2EPCMemorySelector) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_C1G2EPCMemorySelector epcMemorySelector = new PARAM_C1G2EPCMemorySelector();
      epcMemorySelector.tvCoding = bit_array[cursor];
      int val;
      if (epcMemorySelector.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        epcMemorySelector.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) epcMemorySelector.length * 8;
      }
      if (val != (int) epcMemorySelector.TypeID)
      {
        cursor = num1;
        return (PARAM_C1G2EPCMemorySelector) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 1;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len1);
      epcMemorySelector.EnableCRC = (bool) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len2);
      epcMemorySelector.EnablePCBits = (bool) obj;
      cursor += 6;
      return epcMemorySelector;
    }

    public override string ToString()
    {
      string str = "<C1G2EPCMemorySelector>" + "\r\n";
      try
      {
        str = str + "  <EnableCRC>" + Util.ConvertValueTypeToString((object) this.EnableCRC, "u1", "") + "</EnableCRC>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <EnablePCBits>" + Util.ConvertValueTypeToString((object) this.EnablePCBits, "u1", "") + "</EnablePCBits>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</C1G2EPCMemorySelector>" + "\r\n";
    }

    public static PARAM_C1G2EPCMemorySelector FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2EPCMemorySelector epcMemorySelector = new PARAM_C1G2EPCMemorySelector();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "EnableCRC");
      epcMemorySelector.EnableCRC = (bool) Util.ParseValueTypeFromString(nodeValue1, "u1", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "EnablePCBits");
      epcMemorySelector.EnablePCBits = (bool) Util.ParseValueTypeFromString(nodeValue2, "u1", "");
      return epcMemorySelector;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.EnableCRC, (int) this.EnableCRC_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.EnablePCBits, (int) this.EnablePCBits_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      cursor += 6;
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
