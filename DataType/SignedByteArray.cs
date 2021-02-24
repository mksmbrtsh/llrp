// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.DataType.SignedByteArray
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Org.LLRP.LTK.LLRPV1.DataType
{
  [Serializable]
  public class SignedByteArray
  {
    private List<sbyte> data = new List<sbyte>();

    public void Add(sbyte val) => this.data.Add(val);

    public sbyte this[int index]
    {
      get => this.data[index];
      set => this.data[index] = value;
    }

    public int Count => this.data.Count;

    public string ToHexWordString() => Util.ConvertSignedByteArrayToHexWordString(this.data.ToArray());

    public string ToHexString() => Util.ConvertSignedByteArrayToHexString(this.data.ToArray());

    public static SignedByteArray FromHexString(string str)
    {
      SignedByteArray signedByteArray = new SignedByteArray();
      str = str.Trim();
      string[] strArray = Util.SplitString(str, new char[5]
      {
        ',',
        ' ',
        '\t',
        '\n',
        '\r'
      }, (ushort) 2);
      int length = strArray.Length;
      for (int index = 0; index < strArray.Length; ++index)
      {
        try
        {
          signedByteArray.Add(sbyte.Parse(strArray[index], NumberStyles.HexNumber));
        }
        catch
        {
          signedByteArray.Add((sbyte) 0);
        }
      }
      return signedByteArray;
    }

    public static SignedByteArray FromString(string str)
    {
      SignedByteArray signedByteArray = new SignedByteArray();
      str = str.Trim();
      string[] strArray = str.Split(new char[5]
      {
        ',',
        ' ',
        '\t',
        '\n',
        '\r'
      }, StringSplitOptions.RemoveEmptyEntries);
      int length = strArray.Length;
      for (int index = 0; index < strArray.Length; ++index)
      {
        try
        {
          signedByteArray.Add(sbyte.Parse(strArray[index], NumberStyles.Integer));
        }
        catch
        {
          signedByteArray.Add((sbyte) 0);
        }
      }
      return signedByteArray;
    }

    public static SignedByteArray FromString(string str, Type t)
    {
      SignedByteArray signedByteArray = new SignedByteArray();
      str = str.Trim();
      string[] strArray = str.Split(new char[5]
      {
        ',',
        ' ',
        '\t',
        '\n',
        '\r'
      }, StringSplitOptions.RemoveEmptyEntries);
      int length = strArray.Length;
      for (int index = 0; index < strArray.Length; ++index)
      {
        try
        {
          signedByteArray.Add((sbyte) (int) Enum.Parse(t, strArray[index], true));
        }
        catch
        {
          signedByteArray.Add((sbyte) 0);
        }
      }
      return signedByteArray;
    }

    public override string ToString()
    {
      try
      {
        sbyte[] array = this.data.ToArray();
        string str = string.Empty;
        for (int index = 0; index < array.Length; ++index)
          str = str + Convert.ToInt16(array[index]).ToString() + " ";
        return str;
      }
      catch
      {
        return "code error!";
      }
    }

    public string ToString(Type t)
    {
      string str = string.Empty;
      foreach (int num in this.data)
        str = str + Enum.GetName(t, (object) 1) + " ";
      return str;
    }

    public sbyte[] ToArray() => this.data.ToArray();
  }
}
