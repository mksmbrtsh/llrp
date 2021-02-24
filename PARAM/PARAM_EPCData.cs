// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_EPCData
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_EPCData : Parameter
  {
    public LLRPBitArray EPC = new LLRPBitArray();
    private short EPC_len;

    public PARAM_EPCData() => this.typeID = (ushort) 241;

    public static PARAM_EPCData FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_EPCData) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_EPCData paramEpcData = new PARAM_EPCData();
      paramEpcData.tvCoding = bit_array[cursor];
      int val;
      if (paramEpcData.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramEpcData.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramEpcData.length * 8;
      }
      if (val != (int) paramEpcData.TypeID)
      {
        cursor = num1;
        return (PARAM_EPCData) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int fieldLength = Util.DetermineFieldLength(ref bit_array, ref cursor);
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (LLRPBitArray), fieldLength);
      paramEpcData.EPC = (LLRPBitArray) obj;
      return paramEpcData;
    }

    public override string ToString()
    {
      string str = "<EPCData>" + "\r\n";
      if (this.EPC != null)
      {
        try
        {
          str = str + "  <EPC Count=\"" + (object) this.EPC.Count + "\">" + Util.ConvertArrayTypeToString((object) this.EPC, "u1v", "Hex") + "</EPC>";
          str += "\r\n";
        }
        catch
        {
        }
      }
      return str + "</EPCData>" + "\r\n";
    }

    public static PARAM_EPCData FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_EPCData paramEpcData = new PARAM_EPCData();
      string nodeValue = XmlUtil.GetNodeValue(node, "EPC");
      paramEpcData.EPC = (LLRPBitArray) Util.ParseArrayTypeFromString(nodeValue, "u1v", "Hex");
      string nodeAttribute = XmlUtil.GetNodeAttribute(node, "EPC", "Count");
      if (nodeAttribute != string.Empty)
        paramEpcData.EPC.Count = Convert.ToInt32(nodeAttribute);
      return paramEpcData;
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
      if (this.EPC != null)
      {
        try
        {
          Util.ConvertIntToBitArray((uint) this.EPC.Count, 16).CopyTo((Array) bit_array, cursor);
          cursor += 16;
          BitArray bitArray = Util.ConvertObjToBitArray((object) this.EPC, (int) this.EPC_len);
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
