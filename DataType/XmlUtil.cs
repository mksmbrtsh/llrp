// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.DataType.XmlUtil
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;
using System.Collections;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1.DataType
{
  public class XmlUtil
  {
    public static string GetNodeAttribute(
      XmlNode node,
      string child_node_name,
      string attribute_name)
    {
      foreach (XmlNode childNode in node.ChildNodes)
      {
        if (childNode.Name == child_node_name || childNode.LocalName == child_node_name)
        {
          XmlNode namedItem = childNode.Attributes.GetNamedItem(attribute_name);
          if (namedItem != null)
            return namedItem.InnerText;
          break;
        }
      }
      return string.Empty;
    }

    public static string GetNodeValue(XmlNode node, string child_node_name)
    {
      foreach (XmlNode childNode in node.ChildNodes)
      {
        if (childNode.Name == child_node_name || childNode.LocalName == child_node_name)
          return childNode.InnerText;
      }
      return string.Empty;
    }

    [Obsolete("Buggy, use GetXmlNodes that passes XmlNamespaceManager")]
    public static XmlNodeList GetXmlNodes(XmlNode node, string child_node_name)
    {
      if (node.NamespaceURI == null)
        return node.SelectNodes(child_node_name);
      XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
      nsmgr.AddNamespace("llrp", node.NamespaceURI);
      return node.SelectNodes("llrp:" + child_node_name, nsmgr);
    }

    public static XmlNodeList GetXmlNodes(
      XmlNode node,
      string child_node_name,
      XmlNamespaceManager nsmgr)
    {
      IEnumerator enumerator = nsmgr.GetEnumerator();
      XmlNodeList xmlNodeList;
      string xpath;
      for (xmlNodeList = node.SelectNodes(child_node_name, nsmgr); xmlNodeList.Count == 0 && enumerator.MoveNext(); xmlNodeList = node.SelectNodes(xpath, nsmgr))
      {
        string current = (string) enumerator.Current;
        xpath = !("" != current) ? child_node_name : current + ":" + child_node_name;
      }
      return xmlNodeList;
    }

    public static XmlNodeList GetXmlNodeChildren(XmlNode node, string child_node_name) => node.SelectSingleNode(child_node_name)?.ChildNodes;

    [Obsolete("Buggy, use GetXmlNodeCustomChildren that passes XmlNamespaceManager")]
    public static ArrayList GetXmlNodeCustomChildren(XmlNode node)
    {
      ArrayList arrayList = new ArrayList();
      foreach (XmlNode childNode in node.ChildNodes)
      {
        if (childNode.Name.Contains(":"))
          arrayList.Add((object) childNode);
      }
      return arrayList;
    }

    public static ArrayList GetXmlNodeCustomChildren(
      XmlNode node,
      XmlNamespaceManager nsmgr)
    {
      ArrayList arrayList = new ArrayList();
      foreach (XmlNode selectNode in node.SelectNodes("llrp:Custom", nsmgr))
        arrayList.Add((object) selectNode);
      foreach (XmlNode childNode in node.ChildNodes)
      {
        if (childNode.Name.Contains(":") && !arrayList.Contains((object) childNode))
          arrayList.Add((object) childNode);
      }
      return arrayList;
    }

    public static ArrayList GetXmlNodeCustomChildren(
      XmlNode node,
      string[] excl,
      XmlNamespaceManager nsmgr)
    {
      ArrayList arrayList = new ArrayList();
      foreach (XmlNode selectNode in node.SelectNodes("llrp:Custom", nsmgr))
        arrayList.Add((object) selectNode);
      foreach (XmlNode childNode in node.ChildNodes)
      {
        string[] strArray = childNode.Name.Split(':');
        if (1 < strArray.Length)
        {
          string str1 = strArray[strArray.Length - 1];
          bool flag = false;
          foreach (string str2 in excl)
          {
            if (str1 == str2)
            {
              flag = true;
              break;
            }
          }
          if (!flag)
            arrayList.Add((object) childNode);
        }
      }
      return arrayList;
    }

    public static string GetNodeAttrValue(XmlNode node, string attr_name)
    {
      foreach (XmlAttribute attribute in (XmlNamedNodeMap) node.Attributes)
      {
        if (attribute.Name == attr_name)
          return attribute.Value;
      }
      return string.Empty;
    }
  }
}
