// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_FrequencyInformation
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_FrequencyInformation : Parameter
  {
    private const ushort param_reserved_len3 = 7;
    public bool Hopping;
    private short Hopping_len;
    public PARAM_FrequencyHopTable[] FrequencyHopTable;
    public PARAM_FixedFrequencyTable FixedFrequencyTable;

    public PARAM_FrequencyInformation() => this.typeID = (ushort) 146;

    public static PARAM_FrequencyInformation FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_FrequencyInformation) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList1 = new ArrayList();
      PARAM_FrequencyInformation frequencyInformation = new PARAM_FrequencyInformation();
      frequencyInformation.tvCoding = bit_array[cursor];
      int val;
      if (frequencyInformation.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        frequencyInformation.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) frequencyInformation.length * 8;
      }
      if (val != (int) frequencyInformation.TypeID)
      {
        cursor = num1;
        return (PARAM_FrequencyInformation) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len = 1;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len);
      frequencyInformation.Hopping = (bool) obj;
      cursor += 7;
      ArrayList arrayList2 = new ArrayList();
      PARAM_FrequencyHopTable frequencyHopTable;
      while ((frequencyHopTable = PARAM_FrequencyHopTable.FromBitArray(ref bit_array, ref cursor, length)) != null)
        arrayList2.Add((object) frequencyHopTable);
      if (arrayList2.Count > 0)
      {
        frequencyInformation.FrequencyHopTable = new PARAM_FrequencyHopTable[arrayList2.Count];
        for (int index = 0; index < arrayList2.Count; ++index)
          frequencyInformation.FrequencyHopTable[index] = (PARAM_FrequencyHopTable) arrayList2[index];
      }
      frequencyInformation.FixedFrequencyTable = PARAM_FixedFrequencyTable.FromBitArray(ref bit_array, ref cursor, length);
      return frequencyInformation;
    }

    public override string ToString()
    {
      string str = "<FrequencyInformation>" + "\r\n";
      try
      {
        str = str + "  <Hopping>" + Util.ConvertValueTypeToString((object) this.Hopping, "u1", "") + "</Hopping>";
        str += "\r\n";
      }
      catch
      {
      }
      if (this.FrequencyHopTable != null)
      {
        int length = this.FrequencyHopTable.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.FrequencyHopTable[index].ToString());
      }
      if (this.FixedFrequencyTable != null)
        str += Util.Indent(this.FixedFrequencyTable.ToString());
      return str + "</FrequencyInformation>" + "\r\n";
    }

    public static PARAM_FrequencyInformation FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_FrequencyInformation frequencyInformation = new PARAM_FrequencyInformation();
      string nodeValue = XmlUtil.GetNodeValue(node, "Hopping");
      frequencyInformation.Hopping = (bool) Util.ParseValueTypeFromString(nodeValue, "u1", "");
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "FrequencyHopTable", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
          {
            frequencyInformation.FrequencyHopTable = new PARAM_FrequencyHopTable[xmlNodes.Count];
            for (int i = 0; i < xmlNodes.Count; ++i)
              frequencyInformation.FrequencyHopTable[i] = PARAM_FrequencyHopTable.FromXmlNode(xmlNodes[i]);
          }
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "FixedFrequencyTable", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            frequencyInformation.FixedFrequencyTable = PARAM_FixedFrequencyTable.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      return frequencyInformation;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.Hopping, (int) this.Hopping_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      cursor += 7;
      if (this.FrequencyHopTable != null)
      {
        int length = this.FrequencyHopTable.Length;
        for (int index = 0; index < length; ++index)
          this.FrequencyHopTable[index].ToBitArray(ref bit_array, ref cursor);
      }
      if (this.FixedFrequencyTable != null)
        this.FixedFrequencyTable.ToBitArray(ref bit_array, ref cursor);
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
