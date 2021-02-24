// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_KeepaliveSpec
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_KeepaliveSpec : Parameter
  {
    public ENUM_KeepaliveTriggerType KeepaliveTriggerType;
    private short KeepaliveTriggerType_len = 8;
    public uint PeriodicTriggerValue;
    private short PeriodicTriggerValue_len;

    public PARAM_KeepaliveSpec() => this.typeID = (ushort) 220;

    public static PARAM_KeepaliveSpec FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_KeepaliveSpec) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_KeepaliveSpec paramKeepaliveSpec = new PARAM_KeepaliveSpec();
      paramKeepaliveSpec.tvCoding = bit_array[cursor];
      int val;
      if (paramKeepaliveSpec.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramKeepaliveSpec.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramKeepaliveSpec.length * 8;
      }
      if (val != (int) paramKeepaliveSpec.TypeID)
      {
        cursor = num1;
        return (PARAM_KeepaliveSpec) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 8;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len1);
      paramKeepaliveSpec.KeepaliveTriggerType = (ENUM_KeepaliveTriggerType) (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len2);
      paramKeepaliveSpec.PeriodicTriggerValue = (uint) obj;
      return paramKeepaliveSpec;
    }

    public override string ToString()
    {
      string str = "<KeepaliveSpec>" + "\r\n";
      try
      {
        str = str + "  <KeepaliveTriggerType>" + this.KeepaliveTriggerType.ToString() + "</KeepaliveTriggerType>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <PeriodicTriggerValue>" + Util.ConvertValueTypeToString((object) this.PeriodicTriggerValue, "u32", "") + "</PeriodicTriggerValue>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</KeepaliveSpec>" + "\r\n";
    }

    public static PARAM_KeepaliveSpec FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_KeepaliveSpec paramKeepaliveSpec = new PARAM_KeepaliveSpec();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "KeepaliveTriggerType");
      paramKeepaliveSpec.KeepaliveTriggerType = (ENUM_KeepaliveTriggerType) Enum.Parse(typeof (ENUM_KeepaliveTriggerType), nodeValue1);
      string nodeValue2 = XmlUtil.GetNodeValue(node, "PeriodicTriggerValue");
      paramKeepaliveSpec.PeriodicTriggerValue = (uint) Util.ParseValueTypeFromString(nodeValue2, "u32", "");
      return paramKeepaliveSpec;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.KeepaliveTriggerType, (int) this.KeepaliveTriggerType_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.PeriodicTriggerValue, (int) this.PeriodicTriggerValue_len);
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
