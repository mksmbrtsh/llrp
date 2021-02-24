// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2InventoryCommand
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2InventoryCommand : Parameter
  {
    private const ushort param_reserved_len3 = 7;
    public bool TagInventoryStateAware;
    private short TagInventoryStateAware_len;
    public PARAM_C1G2Filter[] C1G2Filter;
    public PARAM_C1G2RFControl C1G2RFControl;
    public PARAM_C1G2SingulationControl C1G2SingulationControl;
    public readonly CustomParameterArrayList Custom = new CustomParameterArrayList();

    public PARAM_C1G2InventoryCommand() => this.typeID = (ushort) 330;

    public bool AddCustomParameter(ICustom_Parameter param)
    {
      if (param is IC1G2InventoryCommand_Custom_Param)
      {
        this.Custom.Add(param);
        return true;
      }
      if (param.GetType() != typeof (PARAM_Custom))
        return false;
      this.Custom.Add(param);
      return true;
    }

    public static PARAM_C1G2InventoryCommand FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2InventoryCommand) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList1 = new ArrayList();
      PARAM_C1G2InventoryCommand inventoryCommand = new PARAM_C1G2InventoryCommand();
      inventoryCommand.tvCoding = bit_array[cursor];
      int val;
      if (inventoryCommand.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        inventoryCommand.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) inventoryCommand.length * 8;
      }
      if (val != (int) inventoryCommand.TypeID)
      {
        cursor = num1;
        return (PARAM_C1G2InventoryCommand) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len = 1;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (bool), field_len);
      inventoryCommand.TagInventoryStateAware = (bool) obj;
      cursor += 7;
      ArrayList arrayList2 = new ArrayList();
      PARAM_C1G2Filter paramC1G2Filter;
      while ((paramC1G2Filter = PARAM_C1G2Filter.FromBitArray(ref bit_array, ref cursor, length)) != null)
        arrayList2.Add((object) paramC1G2Filter);
      if (arrayList2.Count > 0)
      {
        inventoryCommand.C1G2Filter = new PARAM_C1G2Filter[arrayList2.Count];
        for (int index = 0; index < arrayList2.Count; ++index)
          inventoryCommand.C1G2Filter[index] = (PARAM_C1G2Filter) arrayList2[index];
      }
      inventoryCommand.C1G2RFControl = PARAM_C1G2RFControl.FromBitArray(ref bit_array, ref cursor, length);
      inventoryCommand.C1G2SingulationControl = PARAM_C1G2SingulationControl.FromBitArray(ref bit_array, ref cursor, length);
      int num3;
      bool flag;
      do
      {
        num3 = cursor;
        flag = false;
        ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeCustomParameter(ref bit_array, ref cursor, length);
        if (customParameter != null && cursor <= num2 && inventoryCommand.AddCustomParameter(customParameter))
          flag = true;
      }
      while (flag);
      cursor = num3;
      return inventoryCommand;
    }

    public override string ToString()
    {
      string str = "<C1G2InventoryCommand>" + "\r\n";
      try
      {
        str = str + "  <TagInventoryStateAware>" + Util.ConvertValueTypeToString((object) this.TagInventoryStateAware, "u1", "") + "</TagInventoryStateAware>";
        str += "\r\n";
      }
      catch
      {
      }
      if (this.C1G2Filter != null)
      {
        int length = this.C1G2Filter.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.C1G2Filter[index].ToString());
      }
      if (this.C1G2RFControl != null)
        str += Util.Indent(this.C1G2RFControl.ToString());
      if (this.C1G2SingulationControl != null)
        str += Util.Indent(this.C1G2SingulationControl.ToString());
      if (this.Custom != null)
      {
        int length = this.Custom.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.Custom[index].ToString());
      }
      return str + "</C1G2InventoryCommand>" + "\r\n";
    }

    public static PARAM_C1G2InventoryCommand FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2InventoryCommand inventoryCommand = new PARAM_C1G2InventoryCommand();
      string nodeValue = XmlUtil.GetNodeValue(node, "TagInventoryStateAware");
      inventoryCommand.TagInventoryStateAware = (bool) Util.ParseValueTypeFromString(nodeValue, "u1", "");
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "C1G2Filter", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
          {
            inventoryCommand.C1G2Filter = new PARAM_C1G2Filter[xmlNodes.Count];
            for (int i = 0; i < xmlNodes.Count; ++i)
              inventoryCommand.C1G2Filter[i] = PARAM_C1G2Filter.FromXmlNode(xmlNodes[i]);
          }
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "C1G2RFControl", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            inventoryCommand.C1G2RFControl = PARAM_C1G2RFControl.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "C1G2SingulationControl", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            inventoryCommand.C1G2SingulationControl = PARAM_C1G2SingulationControl.FromXmlNode(xmlNodes[0]);
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
              if (customParameter != null && inventoryCommand.AddCustomParameter(customParameter))
                arrayList.Add(nodeCustomChildren[index]);
            }
          }
        }
      }
      catch
      {
      }
      return inventoryCommand;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.TagInventoryStateAware, (int) this.TagInventoryStateAware_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      cursor += 7;
      if (this.C1G2Filter != null)
      {
        int length = this.C1G2Filter.Length;
        for (int index = 0; index < length; ++index)
          this.C1G2Filter[index].ToBitArray(ref bit_array, ref cursor);
      }
      if (this.C1G2RFControl != null)
        this.C1G2RFControl.ToBitArray(ref bit_array, ref cursor);
      if (this.C1G2SingulationControl != null)
        this.C1G2SingulationControl.ToBitArray(ref bit_array, ref cursor);
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
