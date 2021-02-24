// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2Filter
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2Filter : Parameter
  {
    private const ushort param_reserved_len3 = 6;
    public ENUM_C1G2TruncateAction T;
    private short T_len = 2;
    public PARAM_C1G2TagInventoryMask C1G2TagInventoryMask;
    public PARAM_C1G2TagInventoryStateAwareFilterAction C1G2TagInventoryStateAwareFilterAction;
    public PARAM_C1G2TagInventoryStateUnawareFilterAction C1G2TagInventoryStateUnawareFilterAction;

    public PARAM_C1G2Filter() => this.typeID = (ushort) 331;

    public static PARAM_C1G2Filter FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2Filter) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_C1G2Filter paramC1G2Filter = new PARAM_C1G2Filter();
      paramC1G2Filter.tvCoding = bit_array[cursor];
      int val;
      if (paramC1G2Filter.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramC1G2Filter.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramC1G2Filter.length * 8;
      }
      if (val != (int) paramC1G2Filter.TypeID)
      {
        cursor = num1;
        return (PARAM_C1G2Filter) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len = 2;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len);
      paramC1G2Filter.T = (ENUM_C1G2TruncateAction) (uint) obj;
      cursor += 6;
      paramC1G2Filter.C1G2TagInventoryMask = PARAM_C1G2TagInventoryMask.FromBitArray(ref bit_array, ref cursor, length);
      paramC1G2Filter.C1G2TagInventoryStateAwareFilterAction = PARAM_C1G2TagInventoryStateAwareFilterAction.FromBitArray(ref bit_array, ref cursor, length);
      paramC1G2Filter.C1G2TagInventoryStateUnawareFilterAction = PARAM_C1G2TagInventoryStateUnawareFilterAction.FromBitArray(ref bit_array, ref cursor, length);
      return paramC1G2Filter;
    }

    public override string ToString()
    {
      string str = "<C1G2Filter>" + "\r\n";
      try
      {
        str = str + "  <T>" + this.T.ToString() + "</T>";
        str += "\r\n";
      }
      catch
      {
      }
      if (this.C1G2TagInventoryMask != null)
        str += Util.Indent(this.C1G2TagInventoryMask.ToString());
      if (this.C1G2TagInventoryStateAwareFilterAction != null)
        str += Util.Indent(this.C1G2TagInventoryStateAwareFilterAction.ToString());
      if (this.C1G2TagInventoryStateUnawareFilterAction != null)
        str += Util.Indent(this.C1G2TagInventoryStateUnawareFilterAction.ToString());
      return str + "</C1G2Filter>" + "\r\n";
    }

    public static PARAM_C1G2Filter FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2Filter paramC1G2Filter = new PARAM_C1G2Filter();
      string nodeValue = XmlUtil.GetNodeValue(node, "T");
      paramC1G2Filter.T = (ENUM_C1G2TruncateAction) Enum.Parse(typeof (ENUM_C1G2TruncateAction), nodeValue);
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "C1G2TagInventoryMask", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramC1G2Filter.C1G2TagInventoryMask = PARAM_C1G2TagInventoryMask.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "C1G2TagInventoryStateAwareFilterAction", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramC1G2Filter.C1G2TagInventoryStateAwareFilterAction = PARAM_C1G2TagInventoryStateAwareFilterAction.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "C1G2TagInventoryStateUnawareFilterAction", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramC1G2Filter.C1G2TagInventoryStateUnawareFilterAction = PARAM_C1G2TagInventoryStateUnawareFilterAction.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      return paramC1G2Filter;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.T, (int) this.T_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      cursor += 6;
      if (this.C1G2TagInventoryMask != null)
        this.C1G2TagInventoryMask.ToBitArray(ref bit_array, ref cursor);
      if (this.C1G2TagInventoryStateAwareFilterAction != null)
        this.C1G2TagInventoryStateAwareFilterAction.ToBitArray(ref bit_array, ref cursor);
      if (this.C1G2TagInventoryStateUnawareFilterAction != null)
        this.C1G2TagInventoryStateUnawareFilterAction.ToBitArray(ref bit_array, ref cursor);
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
