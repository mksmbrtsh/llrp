// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_AccessCommand
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_AccessCommand : Parameter
  {
    public UNION_AirProtocolTagSpec AirProtocolTagSpec = new UNION_AirProtocolTagSpec();
    public UNION_AccessCommandOpSpec AccessCommandOpSpec = new UNION_AccessCommandOpSpec();
    public readonly CustomParameterArrayList Custom = new CustomParameterArrayList();

    public PARAM_AccessCommand() => this.typeID = (ushort) 209;

    public bool AddCustomParameter(ICustom_Parameter param)
    {
      if (param is IAccessCommand_Custom_Param)
      {
        this.Custom.Add(param);
        return true;
      }
      if (param.GetType() != typeof (PARAM_Custom))
        return false;
      this.Custom.Add(param);
      return true;
    }

    public static PARAM_AccessCommand FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_AccessCommand) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_AccessCommand paramAccessCommand = new PARAM_AccessCommand();
      paramAccessCommand.tvCoding = bit_array[cursor];
      int val;
      if (paramAccessCommand.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramAccessCommand.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramAccessCommand.length * 8;
      }
      if (val != (int) paramAccessCommand.TypeID)
      {
        cursor = num1;
        return (PARAM_AccessCommand) null;
      }
      ushort num3 = 1;
      while (num3 != (ushort) 0)
      {
        num3 = (ushort) 0;
        PARAM_C1G2TagSpec paramC1G2TagSpec = PARAM_C1G2TagSpec.FromBitArray(ref bit_array, ref cursor, length);
        if (paramC1G2TagSpec != null)
        {
          ++num3;
          paramAccessCommand.AirProtocolTagSpec.Add((IParameter) paramC1G2TagSpec);
        }
      }
      ushort num4 = 1;
      while (num4 != (ushort) 0)
      {
        num4 = (ushort) 0;
        PARAM_C1G2Read paramC1G2Read = PARAM_C1G2Read.FromBitArray(ref bit_array, ref cursor, length);
        if (paramC1G2Read != null)
        {
          ++num4;
          paramAccessCommand.AccessCommandOpSpec.Add((IParameter) paramC1G2Read);
        }
        PARAM_C1G2Write paramC1G2Write = PARAM_C1G2Write.FromBitArray(ref bit_array, ref cursor, length);
        if (paramC1G2Write != null)
        {
          ++num4;
          paramAccessCommand.AccessCommandOpSpec.Add((IParameter) paramC1G2Write);
        }
        PARAM_C1G2Kill paramC1G2Kill = PARAM_C1G2Kill.FromBitArray(ref bit_array, ref cursor, length);
        if (paramC1G2Kill != null)
        {
          ++num4;
          paramAccessCommand.AccessCommandOpSpec.Add((IParameter) paramC1G2Kill);
        }
        PARAM_C1G2Lock paramC1G2Lock = PARAM_C1G2Lock.FromBitArray(ref bit_array, ref cursor, length);
        if (paramC1G2Lock != null)
        {
          ++num4;
          paramAccessCommand.AccessCommandOpSpec.Add((IParameter) paramC1G2Lock);
        }
        PARAM_C1G2BlockErase paramC1G2BlockErase = PARAM_C1G2BlockErase.FromBitArray(ref bit_array, ref cursor, length);
        if (paramC1G2BlockErase != null)
        {
          ++num4;
          paramAccessCommand.AccessCommandOpSpec.Add((IParameter) paramC1G2BlockErase);
        }
        PARAM_C1G2BlockWrite paramC1G2BlockWrite = PARAM_C1G2BlockWrite.FromBitArray(ref bit_array, ref cursor, length);
        if (paramC1G2BlockWrite != null)
        {
          ++num4;
          paramAccessCommand.AccessCommandOpSpec.Add((IParameter) paramC1G2BlockWrite);
        }
        int num5 = cursor;
        ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeCustomParameter(ref bit_array, ref cursor, length);
        if (customParameter != null)
        {
          if (paramAccessCommand.AccessCommandOpSpec.AddCustomParameter(customParameter))
            ++num4;
          else
            cursor = num5;
        }
      }
      int num6;
      bool flag;
      do
      {
        num6 = cursor;
        flag = false;
        ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeCustomParameter(ref bit_array, ref cursor, length);
        if (customParameter != null && cursor <= num2 && paramAccessCommand.AddCustomParameter(customParameter))
          flag = true;
      }
      while (flag);
      cursor = num6;
      return paramAccessCommand;
    }

    public override string ToString()
    {
      string str = "<AccessCommand>" + "\r\n";
      if (this.AirProtocolTagSpec != null)
      {
        int count = this.AirProtocolTagSpec.Count;
        for (int index = 0; index < count; ++index)
          str += Util.Indent(this.AirProtocolTagSpec[index].ToString());
      }
      if (this.AccessCommandOpSpec != null)
      {
        int count = this.AccessCommandOpSpec.Count;
        for (int index = 0; index < count; ++index)
          str += Util.Indent(this.AccessCommandOpSpec[index].ToString());
      }
      if (this.Custom != null)
      {
        int length = this.Custom.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.Custom[index].ToString());
      }
      return str + "</AccessCommand>" + "\r\n";
    }

    public static PARAM_AccessCommand FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_AccessCommand paramAccessCommand = new PARAM_AccessCommand();
      paramAccessCommand.AirProtocolTagSpec = new UNION_AirProtocolTagSpec();
      try
      {
        foreach (XmlNode childNode in node.ChildNodes)
        {
          switch (childNode.Name)
          {
            case "C1G2TagSpec":
              paramAccessCommand.AirProtocolTagSpec.Add((IParameter) PARAM_C1G2TagSpec.FromXmlNode(childNode));
              continue;
            default:
              continue;
          }
        }
      }
      catch
      {
      }
      paramAccessCommand.AccessCommandOpSpec = new UNION_AccessCommandOpSpec();
      try
      {
        foreach (XmlNode childNode in node.ChildNodes)
        {
          switch (childNode.Name)
          {
            case "C1G2Read":
              paramAccessCommand.AccessCommandOpSpec.Add((IParameter) PARAM_C1G2Read.FromXmlNode(childNode));
              continue;
            case "C1G2Write":
              paramAccessCommand.AccessCommandOpSpec.Add((IParameter) PARAM_C1G2Write.FromXmlNode(childNode));
              continue;
            case "C1G2Kill":
              paramAccessCommand.AccessCommandOpSpec.Add((IParameter) PARAM_C1G2Kill.FromXmlNode(childNode));
              continue;
            case "C1G2Lock":
              paramAccessCommand.AccessCommandOpSpec.Add((IParameter) PARAM_C1G2Lock.FromXmlNode(childNode));
              continue;
            case "C1G2BlockErase":
              paramAccessCommand.AccessCommandOpSpec.Add((IParameter) PARAM_C1G2BlockErase.FromXmlNode(childNode));
              continue;
            case "C1G2BlockWrite":
              paramAccessCommand.AccessCommandOpSpec.Add((IParameter) PARAM_C1G2BlockWrite.FromXmlNode(childNode));
              continue;
            default:
              if (!arrayList.Contains((object) childNode))
              {
                ICustom_Parameter customParameter = CustomParamDecodeFactory.DecodeXmlNodeToCustomParameter(childNode);
                if (customParameter != null && paramAccessCommand.AccessCommandOpSpec.AddCustomParameter(customParameter))
                {
                  arrayList.Add((object) childNode);
                  continue;
                }
                continue;
              }
              continue;
          }
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
              if (customParameter != null && paramAccessCommand.AddCustomParameter(customParameter))
                arrayList.Add(nodeCustomChildren[index]);
            }
          }
        }
      }
      catch
      {
      }
      return paramAccessCommand;
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
      int count1 = this.AirProtocolTagSpec.Count;
      for (int index = 0; index < count1; ++index)
        this.AirProtocolTagSpec[index].ToBitArray(ref bit_array, ref cursor);
      int count2 = this.AccessCommandOpSpec.Count;
      for (int index = 0; index < count2; ++index)
        this.AccessCommandOpSpec[index].ToBitArray(ref bit_array, ref cursor);
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
