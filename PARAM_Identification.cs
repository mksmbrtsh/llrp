// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_Identification
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_Identification : Parameter
  {
    public ENUM_IdentificationType IDType;
    private short IDType_len = 8;
    public ByteArray ReaderID = new ByteArray();
    private short ReaderID_len;

    public PARAM_Identification() => this.typeID = (ushort) 218;

    public static PARAM_Identification FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_Identification) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_Identification paramIdentification = new PARAM_Identification();
      paramIdentification.tvCoding = bit_array[cursor];
      int val;
      if (paramIdentification.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramIdentification.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramIdentification.length * 8;
      }
      if (val != (int) paramIdentification.TypeID)
      {
        cursor = num1;
        return (PARAM_Identification) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len = 8;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len);
      paramIdentification.IDType = (ENUM_IdentificationType) (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int fieldLength = Util.DetermineFieldLength(ref bit_array, ref cursor);
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ByteArray), fieldLength);
      paramIdentification.ReaderID = (ByteArray) obj;
      return paramIdentification;
    }

    public override string ToString()
    {
      string str = "<Identification>" + "\r\n";
      try
      {
        str = str + "  <IDType>" + this.IDType.ToString() + "</IDType>";
        str += "\r\n";
      }
      catch
      {
      }
      if (this.ReaderID != null)
      {
        try
        {
          str = str + "  <ReaderID>" + Util.ConvertArrayTypeToString((object) this.ReaderID, "u8v", "Hex") + "</ReaderID>";
          str += "\r\n";
        }
        catch
        {
        }
      }
      return str + "</Identification>" + "\r\n";
    }

    public static PARAM_Identification FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_Identification paramIdentification = new PARAM_Identification();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "IDType");
      paramIdentification.IDType = (ENUM_IdentificationType) Enum.Parse(typeof (ENUM_IdentificationType), nodeValue1);
      string nodeValue2 = XmlUtil.GetNodeValue(node, "ReaderID");
      paramIdentification.ReaderID = (ByteArray) Util.ParseArrayTypeFromString(nodeValue2, "u8v", "Hex");
      return paramIdentification;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.IDType, (int) this.IDType_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      if (this.ReaderID != null)
      {
        try
        {
          Util.ConvertIntToBitArray((uint) this.ReaderID.Count, 16).CopyTo((Array) bit_array, cursor);
          cursor += 16;
          BitArray bitArray = Util.ConvertObjToBitArray((object) this.ReaderID, (int) this.ReaderID_len);
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
