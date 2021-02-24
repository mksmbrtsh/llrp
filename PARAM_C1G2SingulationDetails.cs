﻿// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2SingulationDetails
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2SingulationDetails : Parameter
  {
    public ushort NumCollisionSlots;
    private short NumCollisionSlots_len;
    public ushort NumEmptySlots;
    private short NumEmptySlots_len;

    public PARAM_C1G2SingulationDetails()
    {
      this.typeID = (ushort) 18;
      this.tvCoding = true;
    }

    public static PARAM_C1G2SingulationDetails FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2SingulationDetails) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_C1G2SingulationDetails singulationDetails = new PARAM_C1G2SingulationDetails();
      singulationDetails.tvCoding = bit_array[cursor];
      int val;
      if (singulationDetails.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        singulationDetails.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) singulationDetails.length * 8;
      }
      if (val != (int) singulationDetails.TypeID)
      {
        cursor = num1;
        return (PARAM_C1G2SingulationDetails) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len1);
      singulationDetails.NumCollisionSlots = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len2);
      singulationDetails.NumEmptySlots = (ushort) obj;
      return singulationDetails;
    }

    public override string ToString()
    {
      string str = "<C1G2SingulationDetails>" + "\r\n";
      try
      {
        str = str + "  <NumCollisionSlots>" + Util.ConvertValueTypeToString((object) this.NumCollisionSlots, "u16", "") + "</NumCollisionSlots>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <NumEmptySlots>" + Util.ConvertValueTypeToString((object) this.NumEmptySlots, "u16", "") + "</NumEmptySlots>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</C1G2SingulationDetails>" + "\r\n";
    }

    public static PARAM_C1G2SingulationDetails FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2SingulationDetails singulationDetails = new PARAM_C1G2SingulationDetails();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "NumCollisionSlots");
      singulationDetails.NumCollisionSlots = (ushort) Util.ParseValueTypeFromString(nodeValue1, "u16", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "NumEmptySlots");
      singulationDetails.NumEmptySlots = (ushort) Util.ParseValueTypeFromString(nodeValue2, "u16", "");
      return singulationDetails;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.NumCollisionSlots, (int) this.NumCollisionSlots_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.NumEmptySlots, (int) this.NumEmptySlots_len);
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
