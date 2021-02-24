// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2TagInventoryStateUnawareFilterAction
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2TagInventoryStateUnawareFilterAction : Parameter
  {
    public ENUM_C1G2StateUnawareAction Action;
    private short Action_len = 8;

    public PARAM_C1G2TagInventoryStateUnawareFilterAction() => this.typeID = (ushort) 334;

    public static PARAM_C1G2TagInventoryStateUnawareFilterAction FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2TagInventoryStateUnawareFilterAction) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_C1G2TagInventoryStateUnawareFilterAction unawareFilterAction = new PARAM_C1G2TagInventoryStateUnawareFilterAction();
      unawareFilterAction.tvCoding = bit_array[cursor];
      int val;
      if (unawareFilterAction.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        unawareFilterAction.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) unawareFilterAction.length * 8;
      }
      if (val != (int) unawareFilterAction.TypeID)
      {
        cursor = num1;
        return (PARAM_C1G2TagInventoryStateUnawareFilterAction) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len = 8;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len);
      unawareFilterAction.Action = (ENUM_C1G2StateUnawareAction) (uint) obj;
      return unawareFilterAction;
    }

    public override string ToString()
    {
      string str = "<C1G2TagInventoryStateUnawareFilterAction>" + "\r\n";
      try
      {
        str = str + "  <Action>" + this.Action.ToString() + "</Action>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</C1G2TagInventoryStateUnawareFilterAction>" + "\r\n";
    }

    public static PARAM_C1G2TagInventoryStateUnawareFilterAction FromXmlNode(
      XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2TagInventoryStateUnawareFilterAction unawareFilterAction = new PARAM_C1G2TagInventoryStateUnawareFilterAction();
      string nodeValue = XmlUtil.GetNodeValue(node, "Action");
      unawareFilterAction.Action = (ENUM_C1G2StateUnawareAction) Enum.Parse(typeof (ENUM_C1G2StateUnawareAction), nodeValue);
      return unawareFilterAction;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.Action, (int) this.Action_len);
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
