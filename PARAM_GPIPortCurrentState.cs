// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_GPIPortCurrentState
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_GPIPortCurrentState : Parameter
  {
    private const ushort param_reserved_len4 = 7;
    public ushort GPIPortNum;
    private short GPIPortNum_len;
    public bool Config;
    private short Config_len;
    public ENUM_GPIPortState State;
    private short State_len = 8;

    public PARAM_GPIPortCurrentState() => this.typeID = (ushort) 225;

    public static PARAM_GPIPortCurrentState FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_GPIPortCurrentState) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_GPIPortCurrentState portCurrentState = new PARAM_GPIPortCurrentState();
      portCurrentState.tvCoding = bit_array[cursor];
      int val;
      if (portCurrentState.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        portCurrentState.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) portCurrentState.length * 8;
      }
      if (val != (int) portCurrentState.TypeID)
      {
        cursor = num1;
        return (PARAM_GPIPortCurrentState) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len1);
      portCurrentState.GPIPortNum = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 1;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len2);
      portCurrentState.Config = (bool) obj;
      cursor += 7;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len3 = 8;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len3);
      portCurrentState.State = (ENUM_GPIPortState) (uint) obj;
      return portCurrentState;
    }

    public override string ToString()
    {
      string str = "<GPIPortCurrentState>" + "\r\n";
      try
      {
        str = str + "  <GPIPortNum>" + Util.ConvertValueTypeToString((object) this.GPIPortNum, "u16", "") + "</GPIPortNum>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <Config>" + Util.ConvertValueTypeToString((object) this.Config, "u1", "") + "</Config>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <State>" + this.State.ToString() + "</State>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</GPIPortCurrentState>" + "\r\n";
    }

    public static PARAM_GPIPortCurrentState FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_GPIPortCurrentState portCurrentState = new PARAM_GPIPortCurrentState();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "GPIPortNum");
      portCurrentState.GPIPortNum = (ushort) Util.ParseValueTypeFromString(nodeValue1, "u16", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "Config");
      portCurrentState.Config = (bool) Util.ParseValueTypeFromString(nodeValue2, "u1", "");
      string nodeValue3 = XmlUtil.GetNodeValue(node, "State");
      portCurrentState.State = (ENUM_GPIPortState) Enum.Parse(typeof (ENUM_GPIPortState), nodeValue3);
      return portCurrentState;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.GPIPortNum, (int) this.GPIPortNum_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.Config, (int) this.Config_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      cursor += 7;
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.State, (int) this.State_len);
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
