// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_PerAntennaAirProtocol
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_PerAntennaAirProtocol : Parameter
  {
    public ushort AntennaID;
    private short AntennaID_len;
    public ByteArray ProtocolID = new ByteArray();
    private short ProtocolID_len;

    public PARAM_PerAntennaAirProtocol() => this.typeID = (ushort) 140;

    public static PARAM_PerAntennaAirProtocol FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_PerAntennaAirProtocol) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_PerAntennaAirProtocol antennaAirProtocol = new PARAM_PerAntennaAirProtocol();
      antennaAirProtocol.tvCoding = bit_array[cursor];
      int val;
      if (antennaAirProtocol.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        antennaAirProtocol.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) antennaAirProtocol.length * 8;
      }
      if (val != (int) antennaAirProtocol.TypeID)
      {
        cursor = num1;
        return (PARAM_PerAntennaAirProtocol) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len);
      antennaAirProtocol.AntennaID = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int fieldLength = Util.DetermineFieldLength(ref bit_array, ref cursor);
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ByteArray), fieldLength);
      antennaAirProtocol.ProtocolID = (ByteArray) obj;
      return antennaAirProtocol;
    }

    public override string ToString()
    {
      string str = "<PerAntennaAirProtocol>" + "\r\n";
      try
      {
        str = str + "  <AntennaID>" + Util.ConvertValueTypeToString((object) this.AntennaID, "u16", "") + "</AntennaID>";
        str += "\r\n";
      }
      catch
      {
      }
      if (this.ProtocolID != null)
      {
        try
        {
          str = str + "  <ProtocolID>" + this.ProtocolID.ToString(typeof (ENUM_AirProtocols)) + "</ProtocolID>";
          str += "\r\n";
        }
        catch
        {
        }
      }
      return str + "</PerAntennaAirProtocol>" + "\r\n";
    }

    public static PARAM_PerAntennaAirProtocol FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_PerAntennaAirProtocol antennaAirProtocol = new PARAM_PerAntennaAirProtocol();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "AntennaID");
      antennaAirProtocol.AntennaID = (ushort) Util.ParseValueTypeFromString(nodeValue1, "u16", "");
      string nodeValue2 = XmlUtil.GetNodeValue(node, "ProtocolID");
      antennaAirProtocol.ProtocolID = ByteArray.FromString(nodeValue2, typeof (ENUM_AirProtocols));
      return antennaAirProtocol;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.AntennaID, (int) this.AntennaID_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      if (this.ProtocolID != null)
      {
        try
        {
          Util.ConvertIntToBitArray((uint) this.ProtocolID.Count, 16).CopyTo((Array) bit_array, cursor);
          cursor += 16;
          BitArray bitArray = Util.ConvertObjToBitArray((object) this.ProtocolID, (int) this.ProtocolID_len);
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
