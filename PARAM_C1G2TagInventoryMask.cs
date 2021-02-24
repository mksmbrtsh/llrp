// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2TagInventoryMask
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2TagInventoryMask : Parameter
  {
    private const ushort param_reserved_len3 = 6;
    public TwoBits MB = new TwoBits((ushort) 0);
    private short MB_len;
    public ushort Pointer;
    private short Pointer_len;
    public LLRPBitArray TagMask = new LLRPBitArray();
    private short TagMask_len;

    public PARAM_C1G2TagInventoryMask() => this.typeID = (ushort) 332;

    public static PARAM_C1G2TagInventoryMask FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2TagInventoryMask) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_C1G2TagInventoryMask tagInventoryMask = new PARAM_C1G2TagInventoryMask();
      tagInventoryMask.tvCoding = bit_array[cursor];
      int val;
      if (tagInventoryMask.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        tagInventoryMask.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) tagInventoryMask.length * 8;
      }
      if (val != (int) tagInventoryMask.TypeID)
      {
        cursor = num1;
        return (PARAM_C1G2TagInventoryMask) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 2;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (TwoBits), field_len1);
      tagInventoryMask.MB = (TwoBits) obj;
      cursor += 6;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len2);
      tagInventoryMask.Pointer = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int fieldLength = Util.DetermineFieldLength(ref bit_array, ref cursor);
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (LLRPBitArray), fieldLength);
      tagInventoryMask.TagMask = (LLRPBitArray) obj;
      return tagInventoryMask;
    }

    public override string ToString()
    {
      string str = "<C1G2TagInventoryMask>" + "\r\n";
      if (this.MB != null)
      {
        try
        {
          str = str + "  <MB>" + this.MB.ToString() + "</MB>";
          str += "\r\n";
        }
        catch
        {
        }
      }
      try
      {
        str = str + "  <Pointer>" + Util.ConvertValueTypeToString((object) this.Pointer, "u16", "") + "</Pointer>";
        str += "\r\n";
      }
      catch
      {
      }
      if (this.TagMask != null)
      {
        try
        {
          str = str + "  <TagMask Count=\"" + (object) this.TagMask.Count + "\">" + Util.ConvertArrayTypeToString((object) this.TagMask, "u1v", "Hex") + "</TagMask>";
          str += "\r\n";
        }
        catch
        {
        }
      }
      return str + "</C1G2TagInventoryMask>" + "\r\n";
    }

    public static PARAM_C1G2TagInventoryMask FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2TagInventoryMask tagInventoryMask = new PARAM_C1G2TagInventoryMask();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "MB");
      tagInventoryMask.MB = TwoBits.FromString(nodeValue1);
      string nodeValue2 = XmlUtil.GetNodeValue(node, "Pointer");
      tagInventoryMask.Pointer = (ushort) Util.ParseValueTypeFromString(nodeValue2, "u16", "");
      string nodeValue3 = XmlUtil.GetNodeValue(node, "TagMask");
      tagInventoryMask.TagMask = (LLRPBitArray) Util.ParseArrayTypeFromString(nodeValue3, "u1v", "Hex");
      string nodeAttribute = XmlUtil.GetNodeAttribute(node, "TagMask", "Count");
      if (nodeAttribute != string.Empty)
        tagInventoryMask.TagMask.Count = Convert.ToInt32(nodeAttribute);
      return tagInventoryMask;
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
      if (this.MB != null)
      {
        try
        {
          BitArray bitArray = Util.ConvertObjToBitArray((object) this.MB, (int) this.MB_len);
          bitArray.CopyTo((Array) bit_array, cursor);
          cursor += bitArray.Length;
        }
        catch
        {
        }
      }
      cursor += 6;
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.Pointer, (int) this.Pointer_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      if (this.TagMask != null)
      {
        try
        {
          Util.ConvertIntToBitArray((uint) this.TagMask.Count, 16).CopyTo((Array) bit_array, cursor);
          cursor += 16;
          BitArray bitArray = Util.ConvertObjToBitArray((object) this.TagMask, (int) this.TagMask_len);
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
