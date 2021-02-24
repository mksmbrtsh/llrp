// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2TagSpec
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2TagSpec : Parameter
  {
    public PARAM_C1G2TargetTag[] C1G2TargetTag;

    public PARAM_C1G2TagSpec() => this.typeID = (ushort) 338;

    public static PARAM_C1G2TagSpec FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2TagSpec) null;
      int num = cursor;
      ArrayList arrayList1 = new ArrayList();
      PARAM_C1G2TagSpec paramC1G2TagSpec = new PARAM_C1G2TagSpec();
      paramC1G2TagSpec.tvCoding = bit_array[cursor];
      int val;
      if (paramC1G2TagSpec.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramC1G2TagSpec.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        int length1 = (int) paramC1G2TagSpec.length;
      }
      if (val != (int) paramC1G2TagSpec.TypeID)
      {
        cursor = num;
        return (PARAM_C1G2TagSpec) null;
      }
      ArrayList arrayList2 = new ArrayList();
      PARAM_C1G2TargetTag paramC1G2TargetTag;
      while ((paramC1G2TargetTag = PARAM_C1G2TargetTag.FromBitArray(ref bit_array, ref cursor, length)) != null)
        arrayList2.Add((object) paramC1G2TargetTag);
      if (arrayList2.Count > 0)
      {
        paramC1G2TagSpec.C1G2TargetTag = new PARAM_C1G2TargetTag[arrayList2.Count];
        for (int index = 0; index < arrayList2.Count; ++index)
          paramC1G2TagSpec.C1G2TargetTag[index] = (PARAM_C1G2TargetTag) arrayList2[index];
      }
      return paramC1G2TagSpec;
    }

    public override string ToString()
    {
      string str = "<C1G2TagSpec>" + "\r\n";
      if (this.C1G2TargetTag != null)
      {
        int length = this.C1G2TargetTag.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.C1G2TargetTag[index].ToString());
      }
      return str + "</C1G2TagSpec>" + "\r\n";
    }

    public static PARAM_C1G2TagSpec FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2TagSpec paramC1G2TagSpec = new PARAM_C1G2TagSpec();
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "C1G2TargetTag", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
          {
            paramC1G2TagSpec.C1G2TargetTag = new PARAM_C1G2TargetTag[xmlNodes.Count];
            for (int i = 0; i < xmlNodes.Count; ++i)
              paramC1G2TagSpec.C1G2TargetTag[i] = PARAM_C1G2TargetTag.FromXmlNode(xmlNodes[i]);
          }
        }
      }
      catch
      {
      }
      return paramC1G2TagSpec;
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
      if (this.C1G2TargetTag != null)
      {
        int length = this.C1G2TargetTag.Length;
        for (int index = 0; index < length; ++index)
          this.C1G2TargetTag[index].ToBitArray(ref bit_array, ref cursor);
      }
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
