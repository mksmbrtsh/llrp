// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.DataType.Util
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Collections;
using System.Globalization;
using System.Text;

namespace Org.LLRP.LTK.LLRPV1.DataType
{
  public class Util
  {
        /// <summary>
        /// Split string to string array based on specified seperator and string length
        /// </summary>
        /// <param name="str">string to be splitted</param>
        /// <param name="seperator">char array of seperators</param>
        /// <param name="splitted_string_length">length of each splitted string</param>
        /// <returns></returns>
        public static string[] SplitString(string str, char[] seperator, UInt16 splitted_string_length)
        {
            string[] s = str.Split(seperator);

            //if no seperator used.
            if (s.Length <= 1 && str.Length > splitted_string_length)
            {
                int remainder = 0;
                int length = (int)Math.DivRem(str.Length, splitted_string_length, out remainder);
                str = str.PadLeft(remainder, '0');

                string[] tmp_str = new string[remainder > 0 ? (length + 1) : length];
                for (int i = 0; i < tmp_str.Length; i++)
                {
                    try
                    {
                        for (int j = 0; j < splitted_string_length; j++) tmp_str[i] += str[splitted_string_length * i + j];
                    }
                    catch { }
                }
                return tmp_str;
            }
            else
                return s;
        }


        public static string ConvertByteArrayToHexString(byte[] byte_array)
    {
      string empty = string.Empty;
      try
      {
        for (int index = 0; index < byte_array.Length; ++index)
          empty += string.Format("{0:X2}", (object) byte_array[index]);
      }
      catch
      {
      }
      return empty;
    }

    public static string ConvertSignedByteArrayToHexString(sbyte[] byte_array)
    {
      string empty = string.Empty;
      try
      {
        for (int index = 0; index < byte_array.Length; ++index)
          empty += string.Format("{0:X2}", (object) byte_array[index]);
      }
      catch
      {
      }
      return empty;
    }

    public static string ConvertByteArrayToHexWordString(byte[] byte_array)
    {
      string empty = string.Empty;
      try
      {
        for (int index = 0; index < byte_array.Length; index += 2)
          empty += string.Format("{0:X2}{0:X2} ", (object) byte_array[index], (object) byte_array[index + 1]);
      }
      catch
      {
      }
      return empty;
    }

    public static string ConvertSignedByteArrayToHexWordString(sbyte[] byte_array)
    {
      string empty = string.Empty;
      try
      {
        for (int index = 0; index < byte_array.Length; index += 2)
          empty += string.Format("{0:X2}{0:X2} ", (object) byte_array[index], (object) byte_array[index + 1]);
      }
      catch
      {
      }
      return empty;
    }

    public static byte[] ConvertBitArrayToByteArray(bool[] bit_array)
    {
      int num1 = bit_array.Length % 8;
      int length1 = num1 > 0 ? bit_array.Length + 8 - num1 : bit_array.Length;
      int length2 = length1 / 8;
      bool[] flagArray = new bool[length1];
      Array.Copy((Array) bit_array, (Array) flagArray, bit_array.Length);
      byte[] numArray = new byte[length2];
      for (int index1 = 0; index1 < length2; ++index1)
      {
        byte num2 = 0;
        for (int index2 = 0; index2 < 8; ++index2)
          num2 = (byte) ((int) (byte) ((uint) num2 << 1) + (flagArray[index1 * 8 + index2] ? 1 : 0));
        numArray[index1] = num2;
      }
      return numArray;
    }

    public static BitArray ConvertByteArrayToBitArray(byte[] data)
    {
      BitArray bitArray = new BitArray(data.Length * 8);
      try
      {
        for (int index1 = 0; index1 < data.Length; ++index1)
        {
          for (int index2 = 0; index2 < 8; ++index2)
            bitArray[index1 * 8 + index2] = ((int) data[index1] >> 7 - index2 & 1) == 1;
        }
      }
      catch
      {
      }
      return bitArray;
    }

    public static int DetermineFieldLength(ref BitArray bit_array, ref int cursor) => (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 16);

    public static object CalculateVal(ref BitArray bit_array, ref int cursor, int len)
    {
      ulong num = 0;
      try
      {
        for (int index = 0; index < len; ++index)
        {
          num <<= 1;
          if (cursor >= bit_array.Length)
            return (object) 0;
          num += bit_array[cursor] ? 1UL : 0UL;
          ++cursor;
        }
      }
      catch
      {
      }
      return (object) num;
    }

    public static void ConvertBitArrayToObj(
      ref BitArray bit_array,
      ref int cursor,
      out object obj,
      Type type,
      int field_len)
    {
      if (type.Equals(typeof (bool)))
      {
        obj = (object) bit_array[cursor];
        ++cursor;
      }
      else if (type.Equals(typeof (byte)))
        obj = (object) (byte) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 8);
      else if (type.Equals(typeof (sbyte)))
        obj = (object) (sbyte) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 8);
      else if (type.Equals(typeof (ushort)))
        obj = (object) (ushort) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 16);
      else if (type.Equals(typeof (short)))
        obj = (object) (short) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 16);
      else if (type.Equals(typeof (uint)))
        obj = (object) (uint) (ulong) Util.CalculateVal(ref bit_array, ref cursor, field_len);
      else if (type.Equals(typeof (int)))
        obj = (object) (int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 32);
      else if (type.Equals(typeof (ulong)))
        obj = (object) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 64);
      else if (type.Equals(typeof (long)))
        obj = (object) (long) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 64);
      else if (type.Equals(typeof (string)))
      {
        string str = string.Empty;
        for (int index = 0; index < field_len; ++index)
        {
          try
          {
            byte val = (byte) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 8);
            UTF8Encoding utF8Encoding = new UTF8Encoding();
            byte[] bytes = new byte[1]{ val };
            str += utF8Encoding.GetString(bytes);
          }
          catch
          {
          }
        }
        if (field_len > 1 && str[field_len - 1] == char.MinValue)
          str = str.Substring(0, field_len - 1) + (object) '.';
        obj = (object) str;
      }
      else if (type.Equals(typeof (ByteArray)))
      {
        obj = (object) new ByteArray();
        for (int index = 0; index < field_len; ++index)
          ((ByteArray) obj).Add((byte) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 8));
      }
      else if (type.Equals(typeof (SignedByteArray)))
      {
        obj = (object) new SignedByteArray();
        for (int index = 0; index < field_len; ++index)
          ((SignedByteArray) obj).Add((sbyte) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 8));
      }
      else if (type.Equals(typeof (UInt16Array)))
      {
        obj = (object) new UInt16Array();
        for (int index = 0; index < field_len; ++index)
          ((UInt16Array) obj).Add((ushort) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 16));
      }
      else if (type.Equals(typeof (Int16Array)))
      {
        obj = (object) new Int16Array();
        for (int index = 0; index < field_len; ++index)
          ((Int16Array) obj).Add((short) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 16));
      }
      else if (type.Equals(typeof (UInt32Array)))
      {
        obj = (object) new UInt32Array();
        for (int index = 0; index < field_len; ++index)
          ((UInt32Array) obj).Add((uint) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 32));
      }
      else if (type.Equals(typeof (Int32Array)))
      {
        obj = (object) new Int32Array();
        for (int index = 0; index < field_len; ++index)
          ((Int32Array) obj).Add((int) (ulong) Util.CalculateVal(ref bit_array, ref cursor, 32));
      }
      else if (type.Equals(typeof (TwoBits)))
      {
        obj = (object) new TwoBits(bit_array[cursor], bit_array[cursor + 1]);
        cursor += 2;
      }
      else if (type.Equals(typeof (BitArray)))
      {
        obj = (object) new BitArray(field_len);
        for (int index = 0; index < field_len; ++index)
        {
          ((BitArray) obj)[index] = bit_array[cursor];
          ++cursor;
        }
      }
      else if (type.Equals(typeof (LLRPBitArray)))
      {
        obj = (object) new LLRPBitArray();
        int num1 = field_len % 8;
        int num2 = num1 > 0 ? field_len + 8 - num1 : field_len;
        for (int index = 0; index < num2; ++index)
        {
          if (index < field_len)
            ((LLRPBitArray) obj).Add(bit_array[cursor]);
          ++cursor;
        }
      }
      else
        obj = (object) (uint) (ulong) Util.CalculateVal(ref bit_array, ref cursor, field_len);
    }

    public static BitArray ConvertIntToBitArray(uint val, int length)
    {
      BitArray bitArray = new BitArray(length);
      string str = Convert.ToString((long) val, 2).PadLeft(length, '0');
      for (int index = 0; index < length; ++index)
        bitArray[index] = str[index] == '1';
      return bitArray;
    }

    public static BitArray ConvertObjToBitArray(object obj, int length)
    {
      Type type = obj.GetType();
      string empty = string.Empty;
      if (type.Equals(typeof (bool)))
        return new BitArray(1) { [0] = (bool) obj };
      if (type.Equals(typeof (TwoBits)))
        return new BitArray(2)
        {
          [0] = ((TwoBits) obj)[0],
          [1] = ((TwoBits) obj)[1]
        };
      if (type.Equals(typeof (byte)))
      {
        BitArray bitArray = new BitArray(8);
        string str = Convert.ToString((byte) obj, 2).PadLeft(8, '0');
        for (int index = 0; index < 8; ++index)
          bitArray[index] = str[index] == '1';
        return bitArray;
      }
      if (type.Equals(typeof (sbyte)))
      {
        BitArray bitArray = new BitArray(8);
        string str1 = Convert.ToString((short) (sbyte) obj, 2).PadLeft(8, '0');
        string str2 = str1.Substring(str1.Length - 8);
        for (int index = 0; index < 8; ++index)
          bitArray[index] = str2[index] == '1';
        return bitArray;
      }
      if (type.Equals(typeof (ushort)))
      {
        BitArray bitArray = new BitArray(16);
        string str = Convert.ToString((int) (ushort) obj, 2).PadLeft(16, '0');
        for (int index = 0; index < 16; ++index)
          bitArray[index] = str[index] == '1';
        return bitArray;
      }
      if (type.Equals(typeof (short)))
      {
        BitArray bitArray = new BitArray(16);
        string str = Convert.ToString((short) obj, 2).PadLeft(16, '0');
        for (int index = 0; index < 16; ++index)
          bitArray[index] = str[index] == '1';
        return bitArray;
      }
      if (type.Equals(typeof (uint)))
      {
        BitArray bitArray = new BitArray(32);
        string str = Convert.ToString((long) (uint) obj, 2).PadLeft(32, '0');
        for (int index = 0; index < 32; ++index)
          bitArray[index] = str[index] == '1';
        return bitArray;
      }
      if (type.Equals(typeof (int)))
      {
        BitArray bitArray = new BitArray(32);
        string str = Convert.ToString((int) obj, 2).PadLeft(32, '0');
        for (int index = 0; index < 32; ++index)
          bitArray[index] = str[index] == '1';
        return bitArray;
      }
      if (type.Equals(typeof (ulong)))
      {
        BitArray bitArray = new BitArray(64);
        string str = Convert.ToString((long) (ulong) obj, 2).PadLeft(64, '0');
        for (int index = 0; index < 64; ++index)
          bitArray[index] = str[index] == '1';
        return bitArray;
      }
      if (type.Equals(typeof (long)))
      {
        BitArray bitArray = new BitArray(64);
        string str = Convert.ToString((long) obj, 2).PadLeft(64, '0');
        for (int index = 0; index < 64; ++index)
          bitArray[index] = str[index] == '1';
        return bitArray;
      }
      if (type.Equals(typeof (string)))
      {
        BitArray bitArray = new BitArray(((string) obj).Length * 8);
        for (int index1 = 0; index1 < ((string) obj).Length; ++index1)
        {
          string str = Convert.ToString((int) ((string) obj)[index1], 2).PadLeft(8, '0');
          for (int index2 = 0; index2 < 8; ++index2)
            bitArray[index1 * 8 + index2] = str[index2] == '1';
        }
        return bitArray;
      }
      if (type.Equals(typeof (BitArray)))
      {
        int count = ((BitArray) obj).Count;
        BitArray bitArray = new BitArray(count);
        for (int index = 0; index < count; ++index)
          bitArray[index] = ((BitArray) obj)[index];
        return bitArray;
      }
      if (type.Equals(typeof (LLRPBitArray)))
      {
        int count = ((LLRPBitArray) obj).Count;
        int num = count % 8;
        int length1 = num > 0 ? count + (8 - num) : count;
        BitArray bitArray = new BitArray(length1);
        for (int index = 0; index < length1; ++index)
          bitArray[index] = index < count && ((LLRPBitArray) obj)[index];
        return bitArray;
      }
      if (type.Equals(typeof (ByteArray)))
      {
        BitArray bitArray = new BitArray(((ByteArray) obj).Count * 8);
        for (int index1 = 0; index1 < ((ByteArray) obj).Count; ++index1)
        {
          string str = Convert.ToString(((ByteArray) obj)[index1], 2).PadLeft(8, '0');
          for (int index2 = 0; index2 < 8; ++index2)
            bitArray[index1 * 8 + index2] = str[index2] == '1';
        }
        return bitArray;
      }
      if (type.Equals(typeof (SignedByteArray)))
      {
        BitArray bitArray = new BitArray(((SignedByteArray) obj).Count * 8);
        for (int index1 = 0; index1 < ((SignedByteArray) obj).Count; ++index1)
        {
          string str = Convert.ToString((short) ((SignedByteArray) obj)[index1], 2).PadLeft(8, '0');
          for (int index2 = 0; index2 < 8; ++index2)
            bitArray[index1 * 8 + index2] = str[index2] == '1';
        }
        return bitArray;
      }
      if (type.Equals(typeof (UInt16Array)))
      {
        BitArray bitArray = new BitArray(((UInt16Array) obj).Count * 16);
        for (int index1 = 0; index1 < ((UInt16Array) obj).Count; ++index1)
        {
          string str = Convert.ToString((int) ((UInt16Array) obj)[index1], 2).PadLeft(16, '0');
          for (int index2 = 0; index2 < 16; ++index2)
            bitArray[index1 * 16 + index2] = str[index2] == '1';
        }
        return bitArray;
      }
      if (type.Equals(typeof (Int16Array)))
      {
        BitArray bitArray = new BitArray(((Int16Array) obj).Count * 16);
        for (int index1 = 0; index1 < ((Int16Array) obj).Count; ++index1)
        {
          string str = Convert.ToString(((Int16Array) obj)[index1], 2).PadLeft(16, '0');
          for (int index2 = 0; index2 < 16; ++index2)
            bitArray[index1 * 16 + index2] = str[index2] == '1';
        }
        return bitArray;
      }
      if (type.Equals(typeof (UInt32Array)))
      {
        BitArray bitArray = new BitArray(((UInt32Array) obj).Count * 32);
        for (int index1 = 0; index1 < ((UInt32Array) obj).Count; ++index1)
        {
          string str = Convert.ToString((long) ((UInt32Array) obj)[index1], 2).PadLeft(32, '0');
          for (int index2 = 0; index2 < 32; ++index2)
            bitArray[index1 * 32 + index2] = str[index2] == '1';
        }
        return bitArray;
      }
      if (type.Equals(typeof (Int32Array)))
      {
        BitArray bitArray = new BitArray(((Int32Array) obj).Count * 32);
        for (int index1 = 0; index1 < ((Int32Array) obj).Count; ++index1)
        {
          string str = Convert.ToString(((Int32Array) obj)[index1], 2).PadLeft(32, '0');
          for (int index2 = 0; index2 < 32; ++index2)
            bitArray[index1 * 32 + index2] = str[index2] == '1';
        }
        return bitArray;
      }
      BitArray bitArray1 = new BitArray(length);
      string str3 = Convert.ToString((int) obj, 2).PadLeft(length, '0');
      for (int index = 0; index < length; ++index)
        bitArray1[index] = str3[index] == '1';
      return bitArray1;
    }

    public static string ConvertLongToString(long lControlWord)
    {
      string str1 = lControlWord.ToString("X");
      string str2 = "";
      int num = 8 - str1.Length;
      if (num < 0)
        return (string) null;
      for (int index = 0; index < num; ++index)
        str2 += "0";
      return str2 + str1;
    }

    public static byte[] ConvertHexStringToByteArray(string str)
    {
      float length1 = (float) str.Length;
      int length2 = (int) Math.Ceiling((double) length1 / 2.0);
      byte[] numArray = new byte[length2];
      string str1 = (double) (length2 * 2) <= (double) length1 ? str : "0" + str;
      for (int index1 = 0; index1 < length2; ++index1)
      {
        int index2 = index1 * 2;
        string str2 = new string(new char[2]
        {
          str1[index2],
          str1[index2 + 1]
        });
        try
        {
          numArray[index1] = Convert.ToByte(str2, 16);
        }
        catch (OverflowException ex)
        {
          Console.WriteLine("Conversion from string to byte overflowed.");
        }
        catch (FormatException ex)
        {
          Console.WriteLine("The string is not formatted as a byte.");
        }
        catch (ArgumentNullException ex)
        {
          Console.WriteLine("The string is null.");
        }
      }
      return numArray;
    }

    public static string CovertHexStringToString(string strHexString)
    {
      byte[] byteArray = Util.ConvertHexStringToByteArray(strHexString);
      int length = byteArray.Length;
      char[] chArray = new char[length];
      for (int index = 0; index < length; ++index)
        chArray[index] = (char) byteArray[index];
      return new string(chArray);
    }

    public static string CovertStringToHexString(string strString)
    {
      char[] charArray = strString.ToCharArray();
      int length = charArray.Length;
      byte[] byte_array = new byte[length];
      for (int index = 0; index < length; ++index)
        byte_array[index] = (byte) charArray[index];
      return Util.ConvertByteArrayToHexString(byte_array);
    }

    public static string ConvertHexStringToBinaryString(string strHex)
    {
      string empty = string.Empty;
      int length = strHex.Length;
      try
      {
        for (int index = 0; index < length; ++index)
          empty += Util.CharToBinaryString(strHex[index]);
      }
      catch (Exception ex)
      {
        throw ex;
      }
      return empty;
    }

    public static string ConvertBinaryStringToHexString(string strBinary)
    {
      StringBuilder stringBuilder = new StringBuilder();
      string str1 = strBinary;
      while (str1.Length > 0)
      {
        int startIndex = str1.Length > 4 ? str1.Length - 4 : 0;
        int num = str1.Length > 4 ? 4 : str1.Length;
        string strBinary1 = str1.Substring(startIndex, num);
        str1 = str1.Remove(startIndex, num);
        string str2 = Convert.ToString((long) Util.ConvertBinaryStringToDecimal(strBinary1), 16);
        stringBuilder = stringBuilder.Insert(0, str2);
      }
      return stringBuilder.ToString().ToUpper();
    }

    public static ulong ConvertBinaryStringToDecimal(string strBinary)
    {
      ulong num1 = 0;
      if (strBinary.Length > 64)
        throw new Exception("String is longer than 64 bits, less than 64 bits is required");
      for (int length = strBinary.Length; length > 0; --length)
      {
        if (strBinary[length - 1] != '1' && strBinary[length - 1] != '0')
          throw new Exception("String is not in binary string format");
        ulong num2 = strBinary[length - 1] == '1' ? 1UL : 0UL;
        num1 += num2 << strBinary.Length - length;
      }
      return num1;
    }

    public static string ConvertDecimalToBinaryString(ulong dec, int strLen)
    {
      string empty = string.Empty;
      string str = Convert.ToString((long) dec, 2);
      if (str.Length > strLen)
        throw new Exception("Converted string is longer than expected!");
      int length = str.Length;
      return str.PadLeft(strLen, '0');
    }

    public static string ConvertDecimalToDecimalString(ulong dec, int strLen)
    {
      string empty = string.Empty;
      string str = dec.ToString();
      if (str.Length > strLen)
        throw new Exception("Converted string is longer than expected!");
      int length = str.Length;
      return str.PadLeft(strLen, '0');
    }

    public static object ParseValueTypeFromString(string rawval, string type, string format)
    {
      string utcTime = rawval.Trim();
      try
      {
        switch (type)
        {
          case "u1":
            return utcTime == "1" || utcTime == "0" ? (object) (utcTime == "1") : (object) Convert.ToBoolean(utcTime);
          case "u8":
            switch (format)
            {
              case "Hex":
                return (object) Convert.ToByte(utcTime, 16);
              default:
                return (object) Convert.ToByte(utcTime, 10);
            }
          case "s8":
            switch (format)
            {
              case "Hex":
                return (object) Convert.ToSByte(utcTime, 16);
              default:
                return (object) Convert.ToSByte(utcTime, 10);
            }
          case "u16":
            switch (format)
            {
              case "Hex":
                return (object) Convert.ToUInt16(utcTime, 16);
              default:
                return (object) Convert.ToUInt16(utcTime, 10);
            }
          case "s16":
            switch (format)
            {
              case "Hex":
                return (object) Convert.ToInt16(utcTime, 16);
              default:
                return (object) Convert.ToInt16(utcTime, 10);
            }
          case "u32":
            switch (format)
            {
              case "Hex":
                return (object) Convert.ToUInt32(utcTime, 16);
              default:
                return (object) Convert.ToUInt32(utcTime, 10);
            }
          case "s32":
            switch (format)
            {
              case "Hex":
                return (object) Convert.ToInt32(utcTime, 16);
              default:
                return (object) Convert.ToInt32(utcTime, 10);
            }
          case "u64":
            switch (format)
            {
              case "Hex":
                return (object) Convert.ToUInt64(utcTime, 16);
              case "Datetime":
                return (object) Util.ConvertUTCTimeToMicroseconds(utcTime);
              default:
                return (object) Convert.ToUInt64(utcTime, 10);
            }
          default:
            throw new Exception(string.Format("Can't parse {0} to {1} as format {2}", (object) utcTime, (object) type, (object) format));
        }
      }
      catch
      {
        throw new Exception(string.Format("Can't parse {0} to {1} as format {2}", (object) utcTime, (object) type, (object) format));
      }
    }

    public static string ConvertValueTypeToString(object val, string type, string format)
    {
      try
      {
        switch (type)
        {
          case "u1":
            return Convert.ToString((bool) val).ToLower();
          case "u8":
            switch (format)
            {
              case "Hex":
                return Convert.ToString((byte) val, 16);
              default:
                return ((byte) val).ToString();
            }
          case "s8":
            switch (format)
            {
              case "Hex":
                return Convert.ToString((short) (sbyte) val, 16);
              default:
                return ((sbyte) val).ToString();
            }
          case "u16":
            switch (format)
            {
              case "Hex":
                return Convert.ToString((int) (ushort) val, 16);
              default:
                return ((ushort) val).ToString();
            }
          case "s16":
            switch (format)
            {
              case "Hex":
                return Convert.ToString((short) val, 16);
              default:
                return ((short) val).ToString();
            }
          case "u32":
            switch (format)
            {
              case "Hex":
                return Convert.ToString((long) (uint) val, 16);
              default:
                return ((uint) val).ToString();
            }
          case "s32":
            switch (format)
            {
              case "Hex":
                return Convert.ToString((int) val, 16);
              default:
                return ((int) val).ToString();
            }
          case "u64":
            switch (format)
            {
              case "Hex":
                return Convert.ToString((long) (ulong) val, 16);
              case "Datetime":
                return Util.ConvertMicrosecondsToUTCTimeString((ulong) val);
              default:
                return ((ulong) val).ToString();
            }
          default:
            throw new Exception(string.Format("Can't parse {0} to {1} as format {2}", val, (object) type, (object) format));
        }
      }
      catch
      {
        throw new Exception(string.Format("Can't parse {0} to {1} as format {2}", val, (object) type, (object) format));
      }
    }

    public static string ConvertArrayTypeToString(object val, string type, string format)
    {
      try
      {
        switch (type)
        {
          case "u1v":
          case "u96":
            switch (format)
            {
              case "Hex":
                return ((LLRPBitArray) val).ToHexString();
              default:
                return ((LLRPBitArray) val).ToString();
            }
          case "bytesToEnd":
          case "u8v":
            switch (format)
            {
              case "Hex":
                return ((ByteArray) val).ToHexString();
              default:
                return ((ByteArray) val).ToString();
            }
          case "s8v":
            switch (format)
            {
              case "Hex":
                return ((SignedByteArray) val).ToHexString();
              default:
                return ((SignedByteArray) val).ToString();
            }
          case "u16v":
            switch (format)
            {
              case "Hex":
                return ((UInt16Array) val).ToHexString();
              default:
                return ((UInt16Array) val).ToString();
            }
          case "s16v":
            switch (format)
            {
              case "Hex":
                return ((Int16Array) val).ToHexString();
              default:
                return ((Int16Array) val).ToString();
            }
          case "u32v":
            switch (format)
            {
              case "Hex":
                return ((UInt32Array) val).ToHexString();
              default:
                return ((UInt32Array) val).ToString();
            }
          case "s32v":
            switch (format)
            {
              case "Hex":
                return ((Int32Array) val).ToHexString();
              default:
                return ((Int32Array) val).ToString();
            }
          case "utf8v":
            return (string) val;
          default:
            throw new Exception(string.Format("Can't parse {0} to {1} as format {2}", val, (object) type, (object) format));
        }
      }
      catch
      {
        throw new Exception(string.Format("Can't parse {0} to {1} as format {2}", val, (object) type, (object) format));
      }
    }

    public static object ParseArrayTypeFromString(string rawval, string type, string format)
    {
      string str = rawval.Trim();
      try
      {
        switch (type)
        {
          case "u1v":
          case "u96":
            switch (format)
            {
              case "Hex":
                return (object) LLRPBitArray.FromHexString(str);
              default:
                return (object) LLRPBitArray.FromString(str);
            }
          case "bytesToEnd":
          case "u8v":
            switch (format)
            {
              case "Hex":
                return (object) ByteArray.FromHexString(str);
              default:
                return (object) ByteArray.FromString(str);
            }
          case "s8v":
            switch (format)
            {
              case "Hex":
                return (object) SignedByteArray.FromHexString(str);
              default:
                return (object) SignedByteArray.FromString(str);
            }
          case "u16v":
            switch (format)
            {
              case "Hex":
                return (object) UInt16Array.FromHexString(str);
              default:
                return (object) UInt16Array.FromString(str);
            }
          case "s16v":
            switch (format)
            {
              case "Hex":
                return (object) Int16Array.FromHexString(str);
              default:
                return (object) Int16Array.FromString(str);
            }
          case "u32v":
            switch (format)
            {
              case "Hex":
                return (object) UInt32Array.FromHexString(str);
              default:
                return (object) UInt32Array.FromString(str);
            }
          case "s32v":
            switch (format)
            {
              case "Hex":
                return (object) Int32Array.FromHexString(str);
              default:
                return (object) Int32Array.FromString(str);
            }
          case "utf8v":
            return (object) str;
          default:
            throw new Exception(string.Format("{0} is unsupported type.", (object) type));
        }
      }
      catch
      {
        throw new Exception(string.Format("Can't parse {0} to {1} as format {2}", (object) str, (object) type, (object) format));
      }
    }

    private static string CharToBinaryString(char c)
    {
      switch (c)
      {
        case '0':
          return "0000";
        case '1':
          return "0001";
        case '2':
          return "0010";
        case '3':
          return "0011";
        case '4':
          return "0100";
        case '5':
          return "0101";
        case '6':
          return "0110";
        case '7':
          return "0111";
        case '8':
          return "1000";
        case '9':
          return "1001";
        case 'A':
        case 'a':
          return "1010";
        case 'B':
        case 'b':
          return "1011";
        case 'C':
        case 'c':
          return "1100";
        case 'D':
        case 'd':
          return "1101";
        case 'E':
        case 'e':
          return "1110";
        case 'F':
        case 'f':
          return "1111";
        default:
          throw new Exception("Input is not a  Hex. string");
      }
    }

    private static string ConvertMicrosecondsToUTCTimeString(ulong microseconds)
    {
      DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
      dateTime = new DateTime(dateTime.Ticks + 10L * (long) microseconds, DateTimeKind.Utc);
      return string.Format("{00}.{1:000000}", (object) dateTime.ToString("s"), (object) (microseconds % 1000000UL));
    }

    private static ulong ConvertUTCTimeToMicroseconds(string utcTime)
    {
      try
      {
        DateTime result;
        DateTime.TryParse(utcTime, (IFormatProvider) null, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out result);
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return (ulong) (result.Ticks - dateTime.Ticks) / 10UL;
      }
      catch
      {
        return 0;
      }
    }

    public static string Indent(string to_indent)
    {
      char[] separator = new char[1]{ '\n' };
      string[] strArray = to_indent.Replace("\r", "").Split(separator, StringSplitOptions.RemoveEmptyEntries);
      string str1 = "";
      foreach (string str2 in strArray)
        str1 = str1 + "  " + str2 + "\r\n";
      return str1;
    }
  }
}
