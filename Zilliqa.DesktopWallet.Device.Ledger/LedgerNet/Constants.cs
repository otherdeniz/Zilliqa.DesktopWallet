namespace Zilliqa.DesktopWallet.Device.Ledger.LedgerNet
{
    public static class Constants
    {
        public const byte CLA = 0xE0;

        public const byte P1_FIRST = 0x00;
        public const byte P1_MORE = 0x80;
        public const byte P1_LAST = 0x90;
        public const byte P1_SIGN = 0x10;

        public const int DEFAULT_CHANNEL = 0x0101;
        public const int LEDGER_HID_PACKET_SIZE = 64;
        public const int LEDGER_MAX_DATA_SIZE = 240; //What should this be? I hear that the Ledger accepts 240 bytes, but is that including or excluding the 5 byte header?
        public const int LEDGER_STREAM_DATA_SIZE = 128; // Stream in batches of this number of bytes each.
        public const int TAG_APDU = 0x05;

        public const byte BTCHIP_INS_GET_WALLET_PUBLIC_KEY = 0x40;
        public const byte BTCHIP_INS_GET_COIN_VER = 22;

        public const byte COMMAND_GET_WALLET_PUBLIC_KEY = 0x02;
        public const byte COMMAND_SIGN_TX = 0x04;
        public const byte COMMAND_SIGN_MESSAGE = 0x08;

        public const int SuccessStatusCode = 0x9000;
        public const int SecurityNotValidStatusCode = 0x6982;
        public const int InstructionNotSupportedStatusCode = 0x6D00;
        public const int IncorrectLengthStatusCode = 0x6700;
    }
}
