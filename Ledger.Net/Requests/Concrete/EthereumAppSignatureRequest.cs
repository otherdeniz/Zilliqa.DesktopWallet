﻿namespace Ledger.Net.Requests
{
    public class EthereumAppSignatureRequest : RequestBase
    {
        public override byte Argument1 => 0;
        public override byte Argument2 => 0;
        public override byte Cla => Constants.CLA;
        public override byte Ins => SignTransaction ? Constants.ETHEREUM_SIGN_TX : Constants.ETHEREUM_SIGN_MESSAGE;

        public bool SignTransaction { get; }

        public EthereumAppSignatureRequest(bool signTransaction, byte[] data) : base(data)
        {
            SignTransaction = signTransaction;
        }
    }
}
