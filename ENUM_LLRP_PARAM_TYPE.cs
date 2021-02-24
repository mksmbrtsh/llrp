// Decompiled with JetBrains decompiler
// Type: Org.LLRP.LTK.LLRPV1.ENUM_LLRP_PARAM_TYPE
// Assembly: LLRP, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null
// MVID: B7459025-14F1-49D6-9002-DE41A125DA72
// Assembly location: C:\gosniias\NARA\multi_llrp_uhf_rdr\multi_llrp_uhf_rdr\bin\Debug\LLRP.dll

using System;

namespace Org.LLRP.LTK.LLRPV1
{
  [Serializable]
  public enum ENUM_LLRP_PARAM_TYPE
  {
    AntennaID = 1,
    FirstSeenTimestampUTC = 2,
    FirstSeenTimestampUptime = 3,
    LastSeenTimestampUTC = 4,
    LastSeenTimestampUptime = 5,
    PeakRSSI = 6,
    ChannelIndex = 7,
    TagSeenCount = 8,
    ROSpecID = 9,
    InventoryParameterSpecID = 10, // 0x0000000A
    C1G2_CRC = 11, // 0x0000000B
    C1G2_PC = 12, // 0x0000000C
    EPC_96 = 13, // 0x0000000D
    SpecIndex = 14, // 0x0000000E
    AccessSpecID = 16, // 0x00000010
    OpSpecID = 17, // 0x00000011
    C1G2SingulationDetails = 18, // 0x00000012
    UTCTimestamp = 128, // 0x00000080
    Uptime = 129, // 0x00000081
    GeneralDeviceCapabilities = 137, // 0x00000089
    ReceiveSensitivityTableEntry = 139, // 0x0000008B
    PerAntennaAirProtocol = 140, // 0x0000008C
    GPIOCapabilities = 141, // 0x0000008D
    LLRPCapabilities = 142, // 0x0000008E
    RegulatoryCapabilities = 143, // 0x0000008F
    UHFBandCapabilities = 144, // 0x00000090
    TransmitPowerLevelTableEntry = 145, // 0x00000091
    FrequencyInformation = 146, // 0x00000092
    FrequencyHopTable = 147, // 0x00000093
    FixedFrequencyTable = 148, // 0x00000094
    PerAntennaReceiveSensitivityRange = 149, // 0x00000095
    ROSpec = 177, // 0x000000B1
    ROBoundarySpec = 178, // 0x000000B2
    ROSpecStartTrigger = 179, // 0x000000B3
    PeriodicTriggerValue = 180, // 0x000000B4
    GPITriggerValue = 181, // 0x000000B5
    ROSpecStopTrigger = 182, // 0x000000B6
    AISpec = 183, // 0x000000B7
    AISpecStopTrigger = 184, // 0x000000B8
    TagObservationTrigger = 185, // 0x000000B9
    InventoryParameterSpec = 186, // 0x000000BA
    RFSurveySpec = 187, // 0x000000BB
    RFSurveySpecStopTrigger = 188, // 0x000000BC
    AccessSpec = 207, // 0x000000CF
    AccessSpecStopTrigger = 208, // 0x000000D0
    AccessCommand = 209, // 0x000000D1
    LLRPConfigurationStateValue = 217, // 0x000000D9
    Identification = 218, // 0x000000DA
    GPOWriteData = 219, // 0x000000DB
    KeepaliveSpec = 220, // 0x000000DC
    AntennaProperties = 221, // 0x000000DD
    AntennaConfiguration = 222, // 0x000000DE
    RFReceiver = 223, // 0x000000DF
    RFTransmitter = 224, // 0x000000E0
    GPIPortCurrentState = 225, // 0x000000E1
    EventsAndReports = 226, // 0x000000E2
    ROReportSpec = 237, // 0x000000ED
    TagReportContentSelector = 238, // 0x000000EE
    AccessReportSpec = 239, // 0x000000EF
    TagReportData = 240, // 0x000000F0
    EPCData = 241, // 0x000000F1
    RFSurveyReportData = 242, // 0x000000F2
    FrequencyRSSILevelEntry = 243, // 0x000000F3
    ReaderEventNotificationSpec = 244, // 0x000000F4
    EventNotificationState = 245, // 0x000000F5
    ReaderEventNotificationData = 246, // 0x000000F6
    HoppingEvent = 247, // 0x000000F7
    GPIEvent = 248, // 0x000000F8
    ROSpecEvent = 249, // 0x000000F9
    ReportBufferLevelWarningEvent = 250, // 0x000000FA
    ReportBufferOverflowErrorEvent = 251, // 0x000000FB
    ReaderExceptionEvent = 252, // 0x000000FC
    RFSurveyEvent = 253, // 0x000000FD
    AISpecEvent = 254, // 0x000000FE
    AntennaEvent = 255, // 0x000000FF
    ConnectionAttemptEvent = 256, // 0x00000100
    ConnectionCloseEvent = 257, // 0x00000101
    LLRPStatus = 287, // 0x0000011F
    FieldError = 288, // 0x00000120
    ParameterError = 289, // 0x00000121
    C1G2LLRPCapabilities = 327, // 0x00000147
    C1G2UHFRFModeTable = 328, // 0x00000148
    C1G2UHFRFModeTableEntry = 329, // 0x00000149
    C1G2InventoryCommand = 330, // 0x0000014A
    C1G2Filter = 331, // 0x0000014B
    C1G2TagInventoryMask = 332, // 0x0000014C
    C1G2TagInventoryStateAwareFilterAction = 333, // 0x0000014D
    C1G2TagInventoryStateUnawareFilterAction = 334, // 0x0000014E
    C1G2RFControl = 335, // 0x0000014F
    C1G2SingulationControl = 336, // 0x00000150
    C1G2TagInventoryStateAwareSingulationAction = 337, // 0x00000151
    C1G2TagSpec = 338, // 0x00000152
    C1G2TargetTag = 339, // 0x00000153
    C1G2Read = 341, // 0x00000155
    C1G2Write = 342, // 0x00000156
    C1G2Kill = 343, // 0x00000157
    C1G2Lock = 344, // 0x00000158
    C1G2LockPayload = 345, // 0x00000159
    C1G2BlockErase = 346, // 0x0000015A
    C1G2BlockWrite = 347, // 0x0000015B
    C1G2EPCMemorySelector = 348, // 0x0000015C
    C1G2ReadOpSpecResult = 349, // 0x0000015D
    C1G2WriteOpSpecResult = 350, // 0x0000015E
    C1G2KillOpSpecResult = 351, // 0x0000015F
    C1G2LockOpSpecResult = 352, // 0x00000160
    C1G2BlockEraseOpSpecResult = 353, // 0x00000161
    C1G2BlockWriteOpSpecResult = 354, // 0x00000162
    Custom = 1023, // 0x000003FF
  }
}
