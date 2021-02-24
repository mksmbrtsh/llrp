// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_ROReportSpec
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_ROReportSpec : Parameter
  {
    public ENUM_ROReportTriggerType ROReportTrigger;
    private short ROReportTrigger_len = 8;
    public ushort N;
    private short N_len;
    public PARAM_TagReportContentSelector TagReportContentSelector;
    public readonly CustomParameterArrayList Custom = new CustomParameterArrayList();

    public PARAM_ROReportSpec() => this.typeID = (ushort) 237;

    public bool AddCustomParameter(ICustom_Parameter param)
    {
      if (param is IROReportSpec_Custom_Param)
      {
        this.Custom.Add(param);
        return true;
      }
      if (param.GetType() != typeof (PARAM_Custom))
        return false;
      this.Custom.Add(param);
      return true;
    }

    public static PARAM_ROReportSpec FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_ROReportSpec) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_ROReportSpec paramRoReportSpec = new PARAM_ROReportSpec();
      paramRoReportSpec.tvCoding = bit_array[cursor];
      int val;
      if (paramRoReportSpec.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramRoReportSpec.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramRoReportSpec.length * 8;
      }
      if (val != (int) paramRoReportSpec.TypeID)
      {
        cursor = num1;
        return (PARAM_ROReportSpec) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len1 = 8;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len1);
      paramRoReportSpec.ROReportTrigger = (ENUM_ROReportTriggerType) (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len2 = 16;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (ushort), field_len2);
      paramRoReportSpec.N = (ushort) obj;
      paramRoReportSpec.TagReportContentSelector = PARAM_TagReportContentSelector.FromBitArray(ref bit_array, ref cursor, length);
      int num3;
      bool flag;
      do
      {
        num3 = cursor;
        flag = false;
        ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeCustomParameter(ref bit_array, ref cursor, length);
        if (customParameter != null && cursor <= num2 && paramRoReportSpec.AddCustomParameter(customParameter))
          flag = true;
      }
      while (flag);
      cursor = num3;
      return paramRoReportSpec;
    }

    public override string ToString()
    {
      string str = "<ROReportSpec>" + "\r\n";
      try
      {
        str = str + "  <ROReportTrigger>" + this.ROReportTrigger.ToString() + "</ROReportTrigger>";
        str += "\r\n";
      }
      catch
      {
      }
      try
      {
        str = str + "  <N>" + Util.ConvertValueTypeToString((object) this.N, "u16", "") + "</N>";
        str += "\r\n";
      }
      catch
      {
      }
      if (this.TagReportContentSelector != null)
        str += Util.Indent(this.TagReportContentSelector.ToString());
      if (this.Custom != null)
      {
        int length = this.Custom.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.Custom[index].ToString());
      }
      return str + "</ROReportSpec>" + "\r\n";
    }

    public static PARAM_ROReportSpec FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_ROReportSpec paramRoReportSpec = new PARAM_ROReportSpec();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "ROReportTrigger");
      paramRoReportSpec.ROReportTrigger = (ENUM_ROReportTriggerType) Enum.Parse(typeof (ENUM_ROReportTriggerType), nodeValue1);
      string nodeValue2 = XmlUtil.GetNodeValue(node, "N");
      paramRoReportSpec.N = (ushort) Util.ParseValueTypeFromString(nodeValue2, "u16", "");
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "TagReportContentSelector", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramRoReportSpec.TagReportContentSelector = PARAM_TagReportContentSelector.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        ArrayList nodeCustomChildren = XmlUtil.GetXmlNodeCustomChildren(node, nsmgr);
        if (nodeCustomChildren != null)
        {
          for (int index = 0; index < nodeCustomChildren.Count; ++index)
          {
            if (!arrayList.Contains(nodeCustomChildren[index]))
            {
              ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeXmlNodeToCustomParameter((XmlNode) nodeCustomChildren[index]);
              if (customParameter != null && paramRoReportSpec.AddCustomParameter(customParameter))
                arrayList.Add(nodeCustomChildren[index]);
            }
          }
        }
      }
      catch
      {
      }
      return paramRoReportSpec;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.ROReportTrigger, (int) this.ROReportTrigger_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      try
      {
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.N, (int) this.N_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      if (this.TagReportContentSelector != null)
        this.TagReportContentSelector.ToBitArray(ref bit_array, ref cursor);
      if (this.Custom != null)
      {
        int length = this.Custom.Length;
        for (int index = 0; index < length; ++index)
          this.Custom[index].ToBitArray(ref bit_array, ref cursor);
      }
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
