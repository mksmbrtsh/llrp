// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_ConnectionCloseEvent
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_ConnectionCloseEvent : Parameter
  {
    public PARAM_ConnectionCloseEvent() => this.typeID = (ushort) 257;

    public static PARAM_ConnectionCloseEvent FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_ConnectionCloseEvent) null;
      int num = cursor;
      ArrayList arrayList = new ArrayList();
      PARAM_ConnectionCloseEvent connectionCloseEvent = new PARAM_ConnectionCloseEvent();
      connectionCloseEvent.tvCoding = bit_array[cursor];
      int val;
      if (connectionCloseEvent.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        connectionCloseEvent.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        int length1 = (int) connectionCloseEvent.length;
      }
      if (val == (int) connectionCloseEvent.TypeID)
        return connectionCloseEvent;
      cursor = num;
      return (PARAM_ConnectionCloseEvent) null;
    }

    public override string ToString() => "<ConnectionCloseEvent>" + "\r\n" + "</ConnectionCloseEvent>" + "\r\n";

    public static PARAM_ConnectionCloseEvent FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager namespaceManager = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      namespaceManager.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      namespaceManager.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      return new PARAM_ConnectionCloseEvent();
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
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
