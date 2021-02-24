// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.CustomMsgDecodeFactory
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Collections;
using System.Reflection;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class CustomMsgDecodeFactory
  {
    public static Hashtable vendorExtensionIDTypeHash;
    public static Hashtable vendorExtensionNameTypeHash;
    public static Hashtable vendorExtensionAssemblyHash;

    public static void LoadVendorExtensionAssembly(Assembly asm)
    {
      if (CustomMsgDecodeFactory.vendorExtensionIDTypeHash == null)
        CustomMsgDecodeFactory.vendorExtensionIDTypeHash = new Hashtable();
      if (CustomMsgDecodeFactory.vendorExtensionNameTypeHash == null)
        CustomMsgDecodeFactory.vendorExtensionNameTypeHash = new Hashtable();
      if (CustomMsgDecodeFactory.vendorExtensionAssemblyHash == null)
        CustomMsgDecodeFactory.vendorExtensionAssemblyHash = new Hashtable();
      string name = asm.GetName().Name;
      if (CustomMsgDecodeFactory.vendorExtensionAssemblyHash.ContainsKey((object) name))
        return;
      CustomMsgDecodeFactory.vendorExtensionAssemblyHash.Add((object) name, (object) asm);
      try
      {
        foreach (Type type in asm.GetTypes())
        {
          if (type.BaseType == typeof (MSG_CUSTOM_MESSAGE))
          {
            string typeName = type.Namespace + "." + type.Name;
            MSG_CUSTOM_MESSAGE instance = (MSG_CUSTOM_MESSAGE) asm.CreateInstance(typeName);
            string str = instance.VendorID.ToString() + "-" + (object) instance.SubType;
            if (!CustomMsgDecodeFactory.vendorExtensionIDTypeHash.ContainsKey((object) str))
              CustomMsgDecodeFactory.vendorExtensionIDTypeHash.Add((object) str, (object) type);
            if (!CustomMsgDecodeFactory.vendorExtensionNameTypeHash.ContainsKey((object) type.Name))
              CustomMsgDecodeFactory.vendorExtensionNameTypeHash.Add((object) type.Name, (object) type);
          }
        }
      }
      catch
      {
        Console.WriteLine("LVEA failed", (object) asm);
      }
    }

    public static MSG_CUSTOM_MESSAGE DecodeCustomMessage(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (MSG_CUSTOM_MESSAGE) null;
      int num1 = cursor;
      MSG_CUSTOM_MESSAGE msgCustomMessage = MSG_CUSTOM_MESSAGE.FromBitArray(ref bit_array, ref cursor, length);
      if (msgCustomMessage == null)
        return (MSG_CUSTOM_MESSAGE) null;
      string str = msgCustomMessage.VendorID.ToString() + "-" + (object) msgCustomMessage.SubType;
      if (CustomMsgDecodeFactory.vendorExtensionIDTypeHash != null)
      {
        int num2 = cursor;
        try
        {
          MethodInfo method = ((Type) CustomMsgDecodeFactory.vendorExtensionIDTypeHash[(object) str]).GetMethod("FromBitArray");
          if (method == null)
            return (MSG_CUSTOM_MESSAGE) null;
          cursor = num1;
          object[] parameters = new object[3]
          {
            (object) bit_array,
            (object) cursor,
            (object) length
          };
          object obj = method.Invoke((object) null, parameters);
          cursor = (int) parameters[1];
          return (MSG_CUSTOM_MESSAGE) obj;
        }
        catch
        {
          cursor = num2;
        }
      }
      return msgCustomMessage;
    }

    public static MSG_CUSTOM_MESSAGE DecodeXmlNodeToCustomMessage(
      XmlNode node,
      string xmlstr)
    {
      if (CustomMsgDecodeFactory.vendorExtensionNameTypeHash != null)
      {
        string[] strArray = node.Name.Split(':');
        string str = "MSG_" + strArray[strArray.Length - 1];
        try
        {
          Type type = (Type) CustomMsgDecodeFactory.vendorExtensionNameTypeHash[(object) str];
          if (type != null)
          {
            MethodInfo method = type.GetMethod("FromString");
            if (method == null)
              return (MSG_CUSTOM_MESSAGE) null;
            object[] parameters = new object[1]
            {
              (object) xmlstr
            };
            return (MSG_CUSTOM_MESSAGE) method.Invoke((object) null, parameters);
          }
        }
        catch
        {
        }
      }
      return (MSG_CUSTOM_MESSAGE) null;
    }
  }
}
