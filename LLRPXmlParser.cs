// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.LLRPXmlParser
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System.Xml;

namespace Org.LLRP.LTK.LLRPV1
{
  public class LLRPXmlParser
  {
    public static void ParseXMLToLLRPMessage(
      string xmlstr,
      out Message msg,
      out ENUM_LLRP_MSG_TYPE type)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(xmlstr);
      XmlNode documentElement = (XmlNode) xmlDocument.DocumentElement;
      switch (documentElement.Name)
      {
        case "CUSTOM_MESSAGE":
          msg = (Message) MSG_CUSTOM_MESSAGE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.CUSTOM_MESSAGE;
          break;
        case "GET_READER_CAPABILITIES":
          msg = (Message) MSG_GET_READER_CAPABILITIES.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.GET_READER_CAPABILITIES;
          break;
        case "GET_READER_CAPABILITIES_RESPONSE":
          msg = (Message) MSG_GET_READER_CAPABILITIES_RESPONSE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.GET_READER_CAPABILITIES_RESPONSE;
          break;
        case "ADD_ROSPEC":
          msg = (Message) MSG_ADD_ROSPEC.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.ADD_ROSPEC;
          break;
        case "ADD_ROSPEC_RESPONSE":
          msg = (Message) MSG_ADD_ROSPEC_RESPONSE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.ADD_ROSPEC_RESPONSE;
          break;
        case "DELETE_ROSPEC":
          msg = (Message) MSG_DELETE_ROSPEC.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.DELETE_ROSPEC;
          break;
        case "DELETE_ROSPEC_RESPONSE":
          msg = (Message) MSG_DELETE_ROSPEC_RESPONSE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.DELETE_ROSPEC_RESPONSE;
          break;
        case "START_ROSPEC":
          msg = (Message) MSG_START_ROSPEC.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.START_ROSPEC;
          break;
        case "START_ROSPEC_RESPONSE":
          msg = (Message) MSG_START_ROSPEC_RESPONSE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.START_ROSPEC_RESPONSE;
          break;
        case "STOP_ROSPEC":
          msg = (Message) MSG_STOP_ROSPEC.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.STOP_ROSPEC;
          break;
        case "STOP_ROSPEC_RESPONSE":
          msg = (Message) MSG_STOP_ROSPEC_RESPONSE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.STOP_ROSPEC_RESPONSE;
          break;
        case "ENABLE_ROSPEC":
          msg = (Message) MSG_ENABLE_ROSPEC.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.ENABLE_ROSPEC;
          break;
        case "ENABLE_ROSPEC_RESPONSE":
          msg = (Message) MSG_ENABLE_ROSPEC_RESPONSE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.ENABLE_ROSPEC_RESPONSE;
          break;
        case "DISABLE_ROSPEC":
          msg = (Message) MSG_DISABLE_ROSPEC.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.DISABLE_ROSPEC;
          break;
        case "DISABLE_ROSPEC_RESPONSE":
          msg = (Message) MSG_DISABLE_ROSPEC_RESPONSE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.DISABLE_ROSPEC_RESPONSE;
          break;
        case "GET_ROSPECS":
          msg = (Message) MSG_GET_ROSPECS.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.GET_ROSPECS;
          break;
        case "GET_ROSPECS_RESPONSE":
          msg = (Message) MSG_GET_ROSPECS_RESPONSE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.GET_ROSPECS_RESPONSE;
          break;
        case "ADD_ACCESSSPEC":
          msg = (Message) MSG_ADD_ACCESSSPEC.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.ADD_ACCESSSPEC;
          break;
        case "ADD_ACCESSSPEC_RESPONSE":
          msg = (Message) MSG_ADD_ACCESSSPEC_RESPONSE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.ADD_ACCESSSPEC_RESPONSE;
          break;
        case "DELETE_ACCESSSPEC":
          msg = (Message) MSG_DELETE_ACCESSSPEC.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.DELETE_ACCESSSPEC;
          break;
        case "DELETE_ACCESSSPEC_RESPONSE":
          msg = (Message) MSG_DELETE_ACCESSSPEC_RESPONSE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.DELETE_ACCESSSPEC_RESPONSE;
          break;
        case "ENABLE_ACCESSSPEC":
          msg = (Message) MSG_ENABLE_ACCESSSPEC.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.ENABLE_ACCESSSPEC;
          break;
        case "ENABLE_ACCESSSPEC_RESPONSE":
          msg = (Message) MSG_ENABLE_ACCESSSPEC_RESPONSE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.ENABLE_ACCESSSPEC_RESPONSE;
          break;
        case "DISABLE_ACCESSSPEC":
          msg = (Message) MSG_DISABLE_ACCESSSPEC.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.DISABLE_ACCESSSPEC;
          break;
        case "DISABLE_ACCESSSPEC_RESPONSE":
          msg = (Message) MSG_DISABLE_ACCESSSPEC_RESPONSE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.DISABLE_ACCESSSPEC_RESPONSE;
          break;
        case "GET_ACCESSSPECS":
          msg = (Message) MSG_GET_ACCESSSPECS.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.GET_ACCESSSPECS;
          break;
        case "GET_ACCESSSPECS_RESPONSE":
          msg = (Message) MSG_GET_ACCESSSPECS_RESPONSE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.GET_ACCESSSPECS_RESPONSE;
          break;
        case "GET_READER_CONFIG":
          msg = (Message) MSG_GET_READER_CONFIG.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.GET_READER_CONFIG;
          break;
        case "GET_READER_CONFIG_RESPONSE":
          msg = (Message) MSG_GET_READER_CONFIG_RESPONSE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.GET_READER_CONFIG_RESPONSE;
          break;
        case "SET_READER_CONFIG":
          msg = (Message) MSG_SET_READER_CONFIG.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.SET_READER_CONFIG;
          break;
        case "SET_READER_CONFIG_RESPONSE":
          msg = (Message) MSG_SET_READER_CONFIG_RESPONSE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.SET_READER_CONFIG_RESPONSE;
          break;
        case "CLOSE_CONNECTION":
          msg = (Message) MSG_CLOSE_CONNECTION.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.CLOSE_CONNECTION;
          break;
        case "CLOSE_CONNECTION_RESPONSE":
          msg = (Message) MSG_CLOSE_CONNECTION_RESPONSE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.CLOSE_CONNECTION_RESPONSE;
          break;
        case "GET_REPORT":
          msg = (Message) MSG_GET_REPORT.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.GET_REPORT;
          break;
        case "RO_ACCESS_REPORT":
          msg = (Message) MSG_RO_ACCESS_REPORT.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.RO_ACCESS_REPORT;
          break;
        case "KEEPALIVE":
          msg = (Message) MSG_KEEPALIVE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.KEEPALIVE;
          break;
        case "KEEPALIVE_ACK":
          msg = (Message) MSG_KEEPALIVE_ACK.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.KEEPALIVE_ACK;
          break;
        case "READER_EVENT_NOTIFICATION":
          msg = (Message) MSG_READER_EVENT_NOTIFICATION.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.READER_EVENT_NOTIFICATION;
          break;
        case "ENABLE_EVENTS_AND_REPORTS":
          msg = (Message) MSG_ENABLE_EVENTS_AND_REPORTS.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.ENABLE_EVENTS_AND_REPORTS;
          break;
        case "ERROR_MESSAGE":
          msg = (Message) MSG_ERROR_MESSAGE.FromString(xmlstr);
          type = ENUM_LLRP_MSG_TYPE.ERROR_MESSAGE;
          break;
        default:
          type = (ENUM_LLRP_MSG_TYPE) 0;
          msg = (Message) CustomMsgDecodeFactory.DecodeXmlNodeToCustomMessage(documentElement, xmlstr);
          if (msg == null)
            break;
          type = ENUM_LLRP_MSG_TYPE.CUSTOM_MESSAGE;
          break;
      }
    }
  }
}
