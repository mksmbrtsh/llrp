// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_InventoryParameterSpecID
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_InventoryParameterSpecID : Parameter
  {
    public ushort InventoryParameterSpecID;
    private short InventoryParameterSpecID_len;

    public PARAM_InventoryParameterSpecID()
    {
      this.typeID = (ushort) 10;
      this.tvCoding = true;
    }

    public static PARAM_InventoryParameterSpecID FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_InventoryParameterSpecID) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_InventoryParameterSpecID inventoryParameterSpecId = new PARAM_InventoryParameterSpecID();
      inventoryParameterSpecId.tvCoding = bit_array[cursor];
      int val;
      if (inventoryParameterSpecId.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        inventoryParameterSpecId.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) inventoryParameterSpecId.length * 8;
      }
      if (val != (int) inventoryParameterSpecId.TypeID)
      {
        cursor = num1;
        return (PARAM_InventoryParameterSpecID) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len);
      inventoryParameterSpecId.InventoryParameterSpecID = (ushort) obj;
      return inventoryParameterSpecId;
    }

    public override string ToString()
    {
      string str = "<InventoryParameterSpecID>" + "\r\n";
      try
      {
        str = str + "  <InventoryParameterSpecID>" + Util.ConvertValueTypeToString((object) this.InventoryParameterSpecID, "u16", "") + "</InventoryParameterSpecID>";
        str += "\r\n";
      }
      catch
      {
      }
      return str + "</InventoryParameterSpecID>" + "\r\n";
    }

    public static PARAM_InventoryParameterSpecID FromXmlNode(
      XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_InventoryParameterSpecID inventoryParameterSpecId = new PARAM_InventoryParameterSpecID();
      string nodeValue = XmlUtil.GetNodeValue(node, "InventoryParameterSpecID");
      inventoryParameterSpecId.InventoryParameterSpecID = (ushort) Util.ParseValueTypeFromString(nodeValue, "u16", "");
      return inventoryParameterSpecId;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.InventoryParameterSpecID, (int) this.InventoryParameterSpecID_len);
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
