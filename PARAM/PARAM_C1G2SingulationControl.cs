// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2SingulationControl
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2SingulationControl : Parameter
  {
    private const ushort param_reserved_len3 = 6;
    public TwoBits Session = new TwoBits((ushort) 0);
    private short Session_len;
    public ushort TagPopulation;
    private short TagPopulation_len;
    public uint TagTransitTime;
    private short TagTransitTime_len;
    public PARAM_C1G2TagInventoryStateAwareSingulationAction C1G2TagInventoryStateAwareSingulationAction;

    public PARAM_C1G2SingulationControl() => this.typeID = (ushort) 336;

    public static PARAM_C1G2SingulationControl FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2SingulationControl) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_C1G2SingulationControl singulationControl = new PARAM_C1G2SingulationControl();
      singulationControl.tvCoding = bit_array[cursor];
      int val;
      if (singulationControl.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        singulationControl.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) singulationControl.length * 8;
      }
      if (val != (int) singulationControl.TypeID)
      {
        cursor = num1;
        return (PARAM_C1G2SingulationControl) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 2;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (TwoBits), field_len1);
      singulationControl.Session = (TwoBits) obj;
      cursor += 6;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len2);
      singulationControl.TagPopulation = (ushort) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len3 = 32;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len3);
      singulationControl.TagTransitTime = (uint) obj;
      singulationControl.C1G2TagInventoryStateAwareSingulationAction = PARAM_C1G2TagInventoryStateAwareSingulationAction.FromBitArray(ref bit_array, ref cursor, length);
      return singulationControl;
    }

    public override string ToString()
    {
      string str = "<C1G2SingulationControl>" + "\r\n";
      if (this.Session != null)
      {
        try
        {
          str = str + "  <Session>" + this.Session.ToString() + "</Session>";
          str += "\r\n";
        }
        catch
        {
        }
      }
      try
      {
        str = str + "  <TagPopulation>" + Util.ConvertValueTypeToString((object) this.TagPopulation, "u16", "") + "</TagPopulation>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <TagTransitTime>" + Util.ConvertValueTypeToString((object) this.TagTransitTime, "u32", "") + "</TagTransitTime>";
        str += "\r\n";
      }
      catch
      {
      }
      if (this.C1G2TagInventoryStateAwareSingulationAction != null)
        str += Util.Indent(this.C1G2TagInventoryStateAwareSingulationAction.ToString());
      return str + "</C1G2SingulationControl>" + "\r\n";
    }

    public static PARAM_C1G2SingulationControl FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2SingulationControl singulationControl = new PARAM_C1G2SingulationControl();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "Session");
      singulationControl.Session = TwoBits.FromString(nodeValue1);
      string nodeValue2 = XmlUtil.GetNodeValue(node, "TagPopulation");
      singulationControl.TagPopulation = (ushort) Util.ParseValueTypeFromString(nodeValue2, "u16", "");
      string nodeValue3 = XmlUtil.GetNodeValue(node, "TagTransitTime");
      singulationControl.TagTransitTime = (uint) Util.ParseValueTypeFromString(nodeValue3, "u32", "");
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "C1G2TagInventoryStateAwareSingulationAction", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            singulationControl.C1G2TagInventoryStateAwareSingulationAction = PARAM_C1G2TagInventoryStateAwareSingulationAction.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      return singulationControl;
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
      if (this.Session != null)
      {
        try
        {
          BitArray bitArray = Util.ConvertObjToBitArray((object) this.Session, (int) this.Session_len);
          bitArray.CopyTo((Array) bit_array, cursor);
          cursor += bitArray.Length;
        }
        catch
        {
        }
      }
      cursor += 6;
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.TagPopulation, (int) this.TagPopulation_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.TagTransitTime, (int) this.TagTransitTime_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      if (this.C1G2TagInventoryStateAwareSingulationAction != null)
        this.C1G2TagInventoryStateAwareSingulationAction.ToBitArray(ref bit_array, ref cursor);
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
