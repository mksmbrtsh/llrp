// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.DataType.Int32Array
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Collections.Generic;

namespace Org.LLRP.LTK.LLRPV1.DataType
{
  [Serializable]
  public class Int32Array
  {
    public List<int> data = new List<int>();

    public void Add(int val) => this.data.Add(val);

    public int this[int index]
    {
      get => this.data[index];
      set => this.data[index] = value;
    }

    public int Count => this.data.Count;

    public string ToHexString()
    {
      string str = string.Empty;
      for (int index = 0; index < this.data.Count; ++index)
      {
        ushort num1 = (ushort) (this.data[index] >> 16);
        ushort num2 = (ushort) (this.data[index] & (int) ushort.MaxValue);
        ushort num3 = (ushort) ((uint) num1 >> 8);
        ushort num4 = (ushort) ((uint) num1 & (uint) byte.MaxValue);
        ushort num5 = (ushort) ((uint) num2 >> 8);
        ushort num6 = (ushort) ((uint) num2 & (uint) byte.MaxValue);
        str = str + num3.ToString("X2") + num4.ToString("X2") + num5.ToString("X2") + num6.ToString("X2");
      }
      return str;
    }

    public override string ToString()
    {
      try
      {
        int[] array = this.data.ToArray();
        string empty = string.Empty;
        for (int index = 0; index < array.Length; ++index)
        {
          empty += Convert.ToInt32(array[index]).ToString();
          if (index + 1 < array.Length)
            empty += " ";
        }
        return empty;
      }
      catch
      {
        return "code error!";
      }
    }

    public static Int32Array FromHexString(string str)
    {
      str = str.Trim();
      Int32Array int32Array = new Int32Array();
      string str1 = str;
      char[] seperator = new char[2]{ ',', ' ' };
      foreach (string str2 in Util.SplitString(str1, seperator, (ushort) 8))
      {
        try
        {
          int32Array.Add(Convert.ToInt32(str2, 16));
        }
        catch
        {
        }
      }
      return int32Array;
    }

    public static Int32Array FromString(string str)
    {
      str = str.Trim();
      Int32Array int32Array = new Int32Array();
      string str1 = str;
      char[] separator = new char[5]
      {
        ',',
        ' ',
        '\t',
        '\n',
        '\r'
      };
      foreach (string str2 in str1.Split(separator, StringSplitOptions.RemoveEmptyEntries))
      {
        try
        {
          int32Array.Add(Convert.ToInt32(str2, 10));
        }
        catch
        {
        }
      }
      return int32Array;
    }
  }
}
