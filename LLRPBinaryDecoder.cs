// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.LLRPBinaryDecoder
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using Org.LLRP.LTK.LLRPV1.DataType;
using System.Collections;
using System.IO;
using System.Net;

namespace Org.LLRP.LTK.LLRPV1
{
  public class LLRPBinaryDecoder
  {
    public const int MIN_HDR = 10;

    public static void Decode_Envelope(byte[] hdr, out LLRPBinaryDecoder.LLRP_Envelope env)
    {
      BinaryReader binaryReader = new BinaryReader((Stream) new MemoryStream(hdr, 0, 10));
      env = new LLRPBinaryDecoder.LLRP_Envelope();
      ushort hostOrder = (ushort) IPAddress.NetworkToHostOrder((short) binaryReader.ReadUInt16());
      env.ver = (byte) ((uint) hostOrder >> 10);
      env.msg_type = (ENUM_LLRP_MSG_TYPE) ((int) hostOrder & 1023);
      env.msg_len = (uint) IPAddress.NetworkToHostOrder((int) binaryReader.ReadUInt32());
      env.msg_id = (uint) IPAddress.NetworkToHostOrder((int) binaryReader.ReadUInt32());
    }

    public static void Decode(ref byte[] packet, out Message msg)
    {
      LLRPBinaryDecoder.LLRP_Envelope env;
      LLRPBinaryDecoder.Decode_Envelope(packet, out env);
      BitArray bitArray = Util.ConvertByteArrayToBitArray(packet);
      int cursor = 0;
      switch (env.msg_type)
      {
        case ENUM_LLRP_MSG_TYPE.GET_READER_CAPABILITIES:
          msg = (Message) MSG_GET_READER_CAPABILITIES.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.GET_READER_CONFIG:
          msg = (Message) MSG_GET_READER_CONFIG.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.SET_READER_CONFIG:
          msg = (Message) MSG_SET_READER_CONFIG.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.CLOSE_CONNECTION_RESPONSE:
          msg = (Message) MSG_CLOSE_CONNECTION_RESPONSE.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.GET_READER_CAPABILITIES_RESPONSE:
          msg = (Message) MSG_GET_READER_CAPABILITIES_RESPONSE.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.GET_READER_CONFIG_RESPONSE:
          msg = (Message) MSG_GET_READER_CONFIG_RESPONSE.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.SET_READER_CONFIG_RESPONSE:
          msg = (Message) MSG_SET_READER_CONFIG_RESPONSE.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.CLOSE_CONNECTION:
          msg = (Message) MSG_CLOSE_CONNECTION.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.ADD_ROSPEC:
          msg = (Message) MSG_ADD_ROSPEC.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.DELETE_ROSPEC:
          msg = (Message) MSG_DELETE_ROSPEC.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.START_ROSPEC:
          msg = (Message) MSG_START_ROSPEC.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.STOP_ROSPEC:
          msg = (Message) MSG_STOP_ROSPEC.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.ENABLE_ROSPEC:
          msg = (Message) MSG_ENABLE_ROSPEC.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.DISABLE_ROSPEC:
          msg = (Message) MSG_DISABLE_ROSPEC.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.GET_ROSPECS:
          msg = (Message) MSG_GET_ROSPECS.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.ADD_ROSPEC_RESPONSE:
          msg = (Message) MSG_ADD_ROSPEC_RESPONSE.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.DELETE_ROSPEC_RESPONSE:
          msg = (Message) MSG_DELETE_ROSPEC_RESPONSE.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.START_ROSPEC_RESPONSE:
          msg = (Message) MSG_START_ROSPEC_RESPONSE.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.STOP_ROSPEC_RESPONSE:
          msg = (Message) MSG_STOP_ROSPEC_RESPONSE.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.ENABLE_ROSPEC_RESPONSE:
          msg = (Message) MSG_ENABLE_ROSPEC_RESPONSE.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.DISABLE_ROSPEC_RESPONSE:
          msg = (Message) MSG_DISABLE_ROSPEC_RESPONSE.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.GET_ROSPECS_RESPONSE:
          msg = (Message) MSG_GET_ROSPECS_RESPONSE.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.ADD_ACCESSSPEC:
          msg = (Message) MSG_ADD_ACCESSSPEC.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.DELETE_ACCESSSPEC:
          msg = (Message) MSG_DELETE_ACCESSSPEC.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.ENABLE_ACCESSSPEC:
          msg = (Message) MSG_ENABLE_ACCESSSPEC.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.DISABLE_ACCESSSPEC:
          msg = (Message) MSG_DISABLE_ACCESSSPEC.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.GET_ACCESSSPECS:
          msg = (Message) MSG_GET_ACCESSSPECS.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.ADD_ACCESSSPEC_RESPONSE:
          msg = (Message) MSG_ADD_ACCESSSPEC_RESPONSE.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.DELETE_ACCESSSPEC_RESPONSE:
          msg = (Message) MSG_DELETE_ACCESSSPEC_RESPONSE.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.ENABLE_ACCESSSPEC_RESPONSE:
          msg = (Message) MSG_ENABLE_ACCESSSPEC_RESPONSE.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.DISABLE_ACCESSSPEC_RESPONSE:
          msg = (Message) MSG_DISABLE_ACCESSSPEC_RESPONSE.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.GET_ACCESSSPECS_RESPONSE:
          msg = (Message) MSG_GET_ACCESSSPECS_RESPONSE.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.GET_REPORT:
          msg = (Message) MSG_GET_REPORT.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.RO_ACCESS_REPORT:
          msg = (Message) MSG_RO_ACCESS_REPORT.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.KEEPALIVE:
          msg = (Message) MSG_KEEPALIVE.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.READER_EVENT_NOTIFICATION:
          msg = (Message) MSG_READER_EVENT_NOTIFICATION.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.ENABLE_EVENTS_AND_REPORTS:
          msg = (Message) MSG_ENABLE_EVENTS_AND_REPORTS.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.KEEPALIVE_ACK:
          msg = (Message) MSG_KEEPALIVE_ACK.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.ERROR_MESSAGE:
          msg = (Message) MSG_ERROR_MESSAGE.FromBitArray(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        case ENUM_LLRP_MSG_TYPE.CUSTOM_MESSAGE:
          msg = (Message) CustomMsgDecodeFactory.DecodeCustomMessage(ref bitArray, ref cursor, (int) env.msg_len * 8);
          break;
        default:
          throw new MalformedPacket("Unrecognized message " + (object) env.msg_type);
      }
    }

    public struct LLRP_Envelope
    {
      public byte ver;
      public ENUM_LLRP_MSG_TYPE msg_type;
      public uint msg_len;
      public uint msg_id;
    }
  }
}
