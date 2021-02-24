// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_EPC_96
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_EPC_96 : Parameter
  {
    public LLRPBitArray EPC = new LLRPBitArray();
    private short EPC_len;

    public PARAM_EPC_96()
    {
      this.typeID = (ushort) 13;
      this.tvCoding = true;
    }

    public static PARAM_EPC_96 FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_EPC_96) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_EPC_96 paramEpc96 = new PARAM_EPC_96();
      paramEpc96.tvCoding = bit_array[cursor];
      int val;
      if (paramEpc96.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramEpc96.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramEpc96.length * 8;
      }
      if (val != (int) paramEpc96.TypeID)
      {
        cursor = num1;
        return (PARAM_EPC_96) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len = 96;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (LLRPBitArray), field_len);
      paramEpc96.EPC = (LLRPBitArray) obj;
      return paramEpc96;
    }

    public override string ToString()
    {
      string str = "<EPC_96>" + "\r\n";
      if (this.EPC != null)
      {
        try
        {
          str = str + "  <EPC>" + Util.ConvertArrayTypeToString((object) this.EPC, "u96", "Hex") + "</EPC>";
          str += "\r\n";
        }
        catch
        {
        }
      }
      return str + "</EPC_96>" + "\r\n";
    }

    public static PARAM_EPC_96 FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_EPC_96 paramEpc96 = new PARAM_EPC_96();
      string nodeValue = XmlUtil.GetNodeValue(node, "EPC");
      paramEpc96.EPC = (LLRPBitArray) Util.ParseArrayTypeFromString(nodeValue, "u96", "Hex");
      return paramEpc96;
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
