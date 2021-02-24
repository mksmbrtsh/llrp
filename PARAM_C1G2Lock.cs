// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2Lock
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2Lock : Parameter
  {
    public ushort OpSpecID;
    private short OpSpecID_len;
    public uint AccessPassword;
    private short AccessPassword_len;
    public PARAM_C1G2LockPayload[] C1G2LockPayload;

    public PARAM_C1G2Lock() => this.typeID = (ushort) 344;

    public static PARAM_C1G2Lock FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2Lock) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList1 = new ArrayList();
      PARAM_C1G2Lock paramC1G2Lock = new PARAM_C1G2Lock();
      paramC1G2Lock.tvCoding = bit_array[cursor];
      int val;
      if (paramC1G2Lock.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramC1G2Lock.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramC1G2Lock.length * 8;
      }
      if (val != (int) paramC1G2Lock.TypeID)
      {
        cursor = num1;
        return (PARAM_C1G2Lock) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len1);
      paramC1G2Lock.OpSpecID = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len2);
      paramC1G2Lock.AccessPassword = (uint) obj;
      ArrayList arrayList2 = new ArrayList();
      PARAM_C1G2LockPayload paramC1G2LockPayload;
      while ((paramC1G2LockPayload = PARAM_C1G2LockPayload.FromBitArray(ref bit_array, ref cursor, length)) != null)
        arrayList2.Add((object) paramC1G2LockPayload);
      if (arrayList2.Count > 0)
      {
        paramC1G2Lock.C1G2LockPayload = new PARAM_C1G2LockPayload[arrayList2.Count];
        for (int index = 0; index < arrayList2.Count; ++index)
          paramC1G2Lock.C1G2LockPayload[index] = (PARAM_C1G2LockPayload) arrayList2[index];
      }
      return paramC1G2Lock;
    }

    public override string ToString()
    {
      string str = "<C1G2Lock>" + "\r\n";
      try
      {
        str = str + "  <OpSpecID>" + Util.ConvertValueTypeToString((object) this.OpSpecID, "u16", "") + "</OpSpecID>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <AccessPassword>" + Util.ConvertValueTypeToString((object) this.AccessPassword, "u32", "") + "</AccessPassword>";
        str += "\r\n";
      }
      catch
      {
      }
      if (this.C1G2LockPayload != null)
      {
        int length = this.C1G2LockPayload.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.C1G2LockPayload[index].ToString());
      }
      return str + "</C1G2Lock>" + "\r\n";
    }

    public static PARAM_C1G2Lock FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2Lock paramC1G2Lock = new PARAM_C1G2Lock();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "OpSpecID");
      paramC1G2Lock.OpSpecID = (ushort) Util.ParseValueTypeFromString(nodeValue1, "u16", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "AccessPassword");
      paramC1G2Lock.AccessPassword = (uint) Util.ParseValueTypeFromString(nodeValue2, "u32", "");
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "C1G2LockPayload", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
          {
            paramC1G2Lock.C1G2LockPayload = new PARAM_C1G2LockPayload[xmlNodes.Count];
            for (int i = 0; i < xmlNodes.Count; ++i)
              paramC1G2Lock.C1G2LockPayload[i] = PARAM_C1G2LockPayload.FromXmlNode(xmlNodes[i]);
          }
        }
      }
      catch
      {
      }
      return paramC1G2Lock;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.OpSpecID, (int) this.OpSpecID_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.AccessPassword, (int) this.AccessPassword_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      if (this.C1G2LockPayload != null)
      {
        int length = this.C1G2LockPayload.Length;
        for (int index = 0; index < length; ++index)
          this.C1G2LockPayload[index].ToBitArray(ref bit_array, ref cursor);
      }
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
