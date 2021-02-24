// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2LockPayload
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2LockPayload : Parameter
  {
    public ENUM_C1G2LockPrivilege Privilege;
    private short Privilege_len = 8;
    public ENUM_C1G2LockDataField DataField;
    private short DataField_len = 8;

    public PARAM_C1G2LockPayload() => this.typeID = (ushort) 345;

    public static PARAM_C1G2LockPayload FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2LockPayload) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_C1G2LockPayload paramC1G2LockPayload = new PARAM_C1G2LockPayload();
      paramC1G2LockPayload.tvCoding = bit_array[cursor];
      int val;
      if (paramC1G2LockPayload.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramC1G2LockPayload.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramC1G2LockPayload.length * 8;
      }
      if (val != (int) paramC1G2LockPayload.TypeID)
      {
        cursor = num1;
        return (PARAM_C1G2LockPayload) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 8;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len1);
      paramC1G2LockPayload.Privilege = (ENUM_C1G2LockPrivilege) (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 8;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len2);
      paramC1G2LockPayload.DataField = (ENUM_C1G2LockDataField) (uint) obj;
      return paramC1G2LockPayload;
    }

    public override string ToString()
    {
      string str = "<C1G2LockPayload>" + "\r\n";
      try
      {
        str = str + "  <Privilege>" + this.Privilege.ToString() + "</Privilege>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <DataField>" + this.DataField.ToString() + "</DataField>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</C1G2LockPayload>" + "\r\n";
    }

    public static PARAM_C1G2LockPayload FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2LockPayload paramC1G2LockPayload = new PARAM_C1G2LockPayload();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "Privilege");
      paramC1G2LockPayload.Privilege = (ENUM_C1G2LockPrivilege) Enum.Parse(typeof (ENUM_C1G2LockPrivilege), nodeValue1);
      string nodeValue2 = XmlUtil.GetNodeValue(node, "DataField");
      paramC1G2LockPayload.DataField = (ENUM_C1G2LockDataField) Enum.Parse(typeof (ENUM_C1G2LockDataField), nodeValue2);
      return paramC1G2LockPayload;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.Privilege, (int) this.Privilege_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.DataField, (int) this.DataField_len);
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
