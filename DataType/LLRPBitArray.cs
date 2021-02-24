// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.DataType.LLRPBitArray
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Collections.Generic;

namespace Org.LLRP.LTK.LLRPV1.DataType
{
  [Serializable]
  public class LLRPBitArray
  {
    private List<bool> data = new List<bool>();

    public void Add(bool val) => this.data.Add(val);

    public bool this[int index]
    {
      get => this.data[index];
      set => this.data[index] = value;
    }

    public int Count
    {
      get => this.data.Count;
      set
      {
        if (this.data.Count <= value)
          return;
        this.data.RemoveRange(value, this.data.Count - value);
      }
    }

    public string ToHexString()
    {
      try
      {
        return Util.ConvertByteArrayToHexString(Util.ConvertBitArrayToByteArray(this.data.ToArray()));
      }
      catch
      {
        return "code error!";
      }
    }

    public string ToHexWordString()
    {
      try
      {
        return Util.ConvertByteArrayToHexWordString(Util.ConvertBitArrayToByteArray(this.data.ToArray()));
      }
      catch
      {
        return "code error!";
      }
    }

    public override string ToString()
    {
      try
      {
        byte[] byteArray = Util.ConvertBitArrayToByteArray(this.data.ToArray());
        string empty = string.Empty;
        for (int index = 0; index < byteArray.Length; ++index)
        {
          empty += Convert.ToInt16(byteArray[index]).ToString();
          if (index + 1 < byteArray.Length)
            empty += " ";
        }
        return empty;
      }
      catch
      {
        return "code error!";
      }
    }

    public static LLRPBitArray FromBinString(string str)
    {
      LLRPBitArray llrpBitArray = new LLRPBitArray();
      for (int index = 0; index < str.Length; ++index)
        llrpBitArray.Add(str[index] == '1');
      return llrpBitArray;
    }

    public static LLRPBitArray FromString(string str) => LLRPBitArray.FromHexString(str);

    public static LLRPBitArray FromHexString(string str) => LLRPBitArray.FromBinString(Util.ConvertHexStringToBinaryString(str));
  }
}
