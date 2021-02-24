// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.PARAM_LLRPStatus
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class PARAM_LLRPStatus : Parameter
  {
    public ENUM_StatusCode StatusCode;
    private short StatusCode_len = 16;
    public string ErrorDescription = string.Empty;
    private short ErrorDescription_len;
    public PARAM_FieldError FieldError;
    public PARAM_ParameterError ParameterError;

    public PARAM_LLRPStatus() => this.typeID = (ushort) 287;

    public static PARAM_LLRPStatus FromBitArray(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (PARAM_LLRPStatus) null;
      int num1 = cursor;
      int num2 = length;
      ArrayList arrayList = new ArrayList();
      PARAM_LLRPStatus paramLlrpStatus = new PARAM_LLRPStatus();
      paramLlrpStatus.tvCoding = bit_array[cursor];
      int val;
      if (paramLlrpStatus.tvCoding)
      {
        ++cursor;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 7);
      }
      else
      {
        cursor += 6;
        val = (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 10);
        paramLlrpStatus.length = (ushort) Util.DetermineFieldLength(ref bit_array, ref cursor);
        num2 = num1 + (int) paramLlrpStatus.length * 8;
      }
      if (val != (int) paramLlrpStatus.TypeID)
      {
        cursor = num1;
        return (PARAM_LLRPStatus) null;
      }
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int field_len = 16;
      object obj;
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (uint), field_len);
      paramLlrpStatus.StatusCode = (ENUM_StatusCode) (uint) obj;
      if (cursor > length || cursor > num2)
        throw new Exception("Input data is not a complete LLRP message");
      int fieldLength = Util.DetermineFieldLength(ref bit_array, ref cursor);
      Util.ConvertBitArrayToObj(ref bit_array, ref cursor, out obj, typeof (string), fieldLength);
      paramLlrpStatus.ErrorDescription = (string) obj;
      paramLlrpStatus.FieldError = PARAM_FieldError.FromBitArray(ref bit_array, ref cursor, length);
      paramLlrpStatus.ParameterError = PARAM_ParameterError.FromBitArray(ref bit_array, ref cursor, length);
      return paramLlrpStatus;
    }

    public override string ToString()
    {
      string str = "<LLRPStatus>" + "\r\n";
      try
      {
        str = str + "  <StatusCode>" + this.StatusCode.ToString() + "</StatusCode>";
        str += "\r\n";
      }
      catch
      {
      }
      if (this.ErrorDescription != null)
      {
        try
        {
          str = str + "  <ErrorDescription>" + Util.ConvertArrayTypeToString((object) this.ErrorDescription, "utf8v", "UTF8") + "</ErrorDescription>";
          str += "\r\n";
        }
        catch
        {
        }
      }
      if (this.FieldError != null)
        str += Util.Indent(this.FieldError.ToString());
      if (this.ParameterError != null)
        str += Util.Indent(this.ParameterError.ToString());
      return str + "</LLRPStatus>" + "\r\n";
    }

    public static PARAM_LLRPStatus FromXmlNode(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      nsmgr.AddNamespace("", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      nsmgr.AddNamespace("llrp", "http://www.llrp.org/ltk/schema/core/encoding/xml/1.0");
      PARAM_LLRPStatus paramLlrpStatus = new PARAM_LLRPStatus();
      string nodeValue1 = XmlUtil.GetNodeValue(node, "StatusCode");
      paramLlrpStatus.StatusCode = (ENUM_StatusCode) Enum.Parse(typeof (ENUM_StatusCode), nodeValue1);
      string nodeValue2 = XmlUtil.GetNodeValue(node, "ErrorDescription");
      paramLlrpStatus.ErrorDescription = (string) Util.ParseArrayTypeFromString(nodeValue2, "utf8v", "UTF8");
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "FieldError", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramLlrpStatus.FieldError = PARAM_FieldError.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      try
      {
        XmlNodeList xmlNodes = XmlUtil.GetXmlNodes(node, "ParameterError", nsmgr);
        if (xmlNodes != null)
        {
          if (xmlNodes.Count != 0)
            paramLlrpStatus.ParameterError = PARAM_ParameterError.FromXmlNode(xmlNodes[0]);
        }
      }
      catch
      {
      }
      return paramLlrpStatus;
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
        BitArray bitArray = Util.ConvertObjToBitArray((object) this.StatusCode, (int) this.StatusCode_len);
        bitArray.CopyTo((Array) bit_array, cursor);
        cursor += bitArray.Length;
      }
      catch
      {
      }
      if (this.ErrorDescription != null)
      {
        try
        {
          Util.ConvertIntToBitArray((uint) this.ErrorDescription.Length, 16).CopyTo((Array) bit_array, cursor);
          cursor += 16;
          BitArray bitArray = Util.ConvertObjToBitArray((object) this.ErrorDescription, (int) this.ErrorDescription_len);
          bitArray.CopyTo((Array) bit_array, cursor);
          cursor += bitArray.Length;
        }
        catch
        {
        }
      }
      if (this.FieldError != null)
        this.FieldError.ToBitArray(ref bit_array, ref cursor);
      if (this.ParameterError != null)
        this.ParameterError.ToBitArray(ref bit_array, ref cursor);
      if (this.tvCoding)
        return;
      Util.ConvertIntToBitArray((uint) (cursor - num) / 8U, 16).CopyTo((Array) bit_array, num + 16);
    }
  }
}
