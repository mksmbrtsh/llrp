// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.CustomParamDecodeFactory
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Collections;
using System.Reflection;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class CustomParamDecodeFactory
  {
    public static Hashtable vendorExtensionIDTypeHash;
    public static Hashtable vendorExtensionNameTypeHash;
    public static Hashtable vendorExtensionAssemblyHash;

    public static void LoadVendorExtensionAssembly(Assembly asm)
    {
      if (CustomParamDecodeFactory.vendorExtensionIDTypeHash == null)
        CustomParamDecodeFactory.vendorExtensionIDTypeHash = new Hashtable();
      if (CustomParamDecodeFactory.vendorExtensionNameTypeHash == null)
        CustomParamDecodeFactory.vendorExtensionNameTypeHash = new Hashtable();
      if (CustomParamDecodeFactory.vendorExtensionAssemblyHash == null)
        CustomParamDecodeFactory.vendorExtensionAssemblyHash = new Hashtable();
      string name = asm.GetName().Name;
      if (CustomParamDecodeFactory.vendorExtensionAssemblyHash.ContainsKey((object) name))
        return;
      CustomParamDecodeFactory.vendorExtensionAssemblyHash.Add((object) name, (object) asm);
      try
      {
        foreach (Type type in asm.GetTypes())
        {
          if (type.BaseType == typeof (PARAM_Custom))
          {
            string typeName = type.Namespace + "." + type.Name;
            PARAM_Custom instance = (PARAM_Custom) asm.CreateInstance(typeName);
            string str = instance.VendorID.ToString() + "-" + (object) instance.SubType;
            if (!CustomParamDecodeFactory.vendorExtensionIDTypeHash.ContainsKey((object) str))
              CustomParamDecodeFactory.vendorExtensionIDTypeHash.Add((object) str, (object) type);
            if (!CustomParamDecodeFactory.vendorExtensionNameTypeHash.ContainsKey((object) type.Name))
              CustomParamDecodeFactory.vendorExtensionNameTypeHash.Add((object) type.Name, (object) type);
          }
        }
      }
      catch
      {
        Console.WriteLine("LVEA failed", (object) asm);
      }
    }

    public static ICustom_Parameter DecodeCustomParameter(
      ref BitArray bit_array,
      ref int cursor,
      int length)
    {
      if (cursor >= length)
        return (ICustom_Parameter) null;
      int num1 = cursor;
      PARAM_Custom paramCustom = PARAM_Custom.FromBitArray(ref bit_array, ref cursor, length);
      if (paramCustom == null)
        return (ICustom_Parameter) null;
      string str = paramCustom.VendorID.ToString() + "-" + (object) paramCustom.SubType;
      if (CustomParamDecodeFactory.vendorExtensionIDTypeHash != null)
      {
        int num2 = cursor;
        try
        {
          MethodInfo method = ((Type) CustomParamDecodeFactory.vendorExtensionIDTypeHash[(object) str]).GetMethod("FromBitArray");
          if (method == null)
            return (ICustom_Parameter) null;
          cursor = num1;
          object[] parameters = new object[3]
          {
            (object) bit_array,
            (object) cursor,
            (object) length
          };
          object obj = method.Invoke((object) null, parameters);
          cursor = (int) parameters[1];
          return (ICustom_Parameter) obj;
        }
        catch
        {
          cursor = num2;
        }
      }
      return (ICustom_Parameter) paramCustom;
    }

    public static ICustom_Parameter DecodeXmlNodeToCustomParameter(XmlNode node)
    {
      string[] strArray = node.Name.Split(':');
      string str = "PARAM_" + strArray[strArray.Length - 1];
      if (str == "PARAM_Custom")
        return (ICustom_Parameter) PARAM_Custom.FromXmlNode(node);
      if (CustomParamDecodeFactory.vendorExtensionNameTypeHash != null)
      {
        try
        {
          Type type = (Type) CustomParamDecodeFactory.vendorExtensionNameTypeHash[(object) str];
          if (type != null)
          {
            MethodInfo method = type.GetMethod("FromXmlNode");
            if (method == null)
              return (ICustom_Parameter) null;
            object[] parameters = new object[1]
            {
              (object) node
            };
            return (ICustom_Parameter) method.Invoke((object) null, parameters);
          }
        }
        catch
        {
        }
      }
      return (ICustom_Parameter) null;
    }
  }
}
