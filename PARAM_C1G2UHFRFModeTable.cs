// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_C1G2UHFRFModeTable
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_C1G2UHFRFModeTable : Parameter
  {
    public PARAM_C1G2UHFRFModeTableEntry[] C1G2UHFRFModeTableEntry;

    public PARAM_C1G2UHFRFModeTable() => this.typeID = (ushort) 328;

    public static PARAM_C1G2UHFRFModeTable FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_C1G2UHFRFModeTable) null;
      int num = cursor;
      ArrayList arrayList1 = new ArrayList();
      PARAM_C1G2UHFRFModeTable g2UhfrfModeTable = new PARAM_C1G2UHFRFModeTable();
      g2UhfrfModeTable.tvCoding = bit_array[cursor];
      int val;
      if (g2UhfrfModeTable.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        g2UhfrfModeTable.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        int length1 = (int) g2UhfrfModeTable.length;
      }
      if (val != (int) g2UhfrfModeTable.TypeID)
      {
        cursor = num;
        return (PARAM_C1G2UHFRFModeTable) null;
      }
      ArrayList arrayList2 = new ArrayList();
      PARAM_C1G2UHFRFModeTableEntry uhfrfModeTableEntry;
      while ((uhfrfModeTableEntry = PARAM_C1G2UHFRFModeTableEntry.FromBitArray(ref bit_array, ref cursor, length)) != null)
        arrayList2.Add((object) uhfrfModeTableEntry);
      if (arrayList2.Count > 0)
      {
        g2UhfrfModeTable.C1G2UHFRFModeTableEntry = new PARAM_C1G2UHFRFModeTableEntry[arrayList2.Count];
        for (int index = 0; index < arrayList2.Count; ++index)
          g2UhfrfModeTable.C1G2UHFRFModeTableEntry[index] = (PARAM_C1G2UHFRFModeTableEntry) arrayList2[index];
      }
      return g2UhfrfModeTable;
    }

    public override string ToString()
    {
      string str = "<C1G2UHFRFModeTable>" + "\r\n";
      if (this.C1G2UHFRFModeTableEntry != null)
      {
        int length = this.C1G2UHFRFModeTableEntry.Length;
        for (int index = 0; index < length; ++index)
          str += Util.Indent(this.C1G2UHFRFModeTableEntry[index].ToString());
      }
      return str + "</C1G2UHFRFModeTable>" + "\r\n";
    }

    public static PARAM_C1G2UHFRFModeTable FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_C1G2UHFRFModeTable g2UhfrfModeTable = new PARAM_C1G2UHFRFModeTable();
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "C1G2UHFRFModeTableEntry", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
          {
            g2UhfrfModeTable.C1G2UHFRFModeTableEntry = new PARAM_C1G2UHFRFModeTableEntry[xmlNodes.Count];
            for (int i = 0; i < xmlNodes.Count; ++i)
              g2UhfrfModeTable.C1G2UHFRFModeTableEntry[i] = PARAM_C1G2UHFRFModeTableEntry.FromXmlNode(xmlNodes[i]);
          }
        }
      }
      catch
      {
      }
      return g2UhfrfModeTable;
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
      if (this.C1G2UHFRFModeTableEntry != null)
      {
        int length = this.C1G2UHFRFModeTableEntry.Length;
        for (int index = 0; index < length; ++index)
          this.C1G2UHFRFModeTableEntry[index].ToBitArray(ref bit_array, ref cursor);
      }
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
