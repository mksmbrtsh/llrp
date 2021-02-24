// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.DataType.Int16Array
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Collections.Generic;

namespace Org.LLRP.LTK.LLRPV1.DataType
{
  [Serializable]
  public class Int16Array
  {
    public List<short> data = new List<short>();

    public void Add(short val) => this.data.Add(val);

    public short this[int index]
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
        ushort num1 = (ushort) ((uint) this.data[index] >> 8);
        ushort num2 = (ushort) ((uint) this.data[index] & (uint) byte.MaxValue);
        str = str + num1.ToString("X2") + num2.ToString("X2");
        if (index + 1 < this.data.Count)
          str += " ";
      }
      return str;
    }

    public string ToHexWordString()
    {
      string str = string.Empty;
      for (int index = 0; index < this.data.Count; ++index)
      {
        ushort num1 = (ushort) ((uint) this.data[index] >> 8);
        ushort num2 = (ushort) ((uint) this.data[index] & (uint) byte.MaxValue);
        str = str + num1.ToString("X2") + num2.ToString("X2");
        if (index + 1 < this.data.Count)
          str += " ";
      }
      return str;
    }

    public override string ToString()
    {
      try
      {
        short[] array = this.data.ToArray();
        string empty = string.Empty;
        for (int index = 0; index < array.Length; ++index)
        {
          empty += Convert.ToInt16(array[index]).ToString();
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

    public static Int16Array FromHexString(string str)
    {
      str = str.Trim();
      Int16Array int16Array = new Int16Array();
      if (str != string.Empty)
      {
        string[] strArray = Util.SplitString(str, new char[5]
        {
          ',',
          ' ',
          '\t',
          '\n',
          '\r'
        }, (ushort) 4);
        for (int index = 0; index < strArray.Length; ++index)
        {
          try
          {
            if (strArray[index] != string.Empty)
              int16Array.Add(Convert.ToInt16(strArray[index], 16));
          }
          catch
          {
          }
        }
      }
      return int16Array;
    }

    public static Int16Array FromString(string str)
    {
      str = str.Trim();
      Int16Array int16Array = new Int16Array();
      if (str != string.Empty)
      {
        string[] strArray = str.Split(new char[5]
        {
          ',',
          ' ',
          '\t',
          '\n',
          '\r'
        }, StringSplitOptions.RemoveEmptyEntries);
        for (int index = 0; index < strArray.Length; ++index)
        {
          try
          {
            if (strArray[index] != string.Empty)
              int16Array.Add(Convert.ToInt16(strArray[index], 10));
          }
          catch
          {
          }
        }
      }
      return int16Array;
    }
  }
}
