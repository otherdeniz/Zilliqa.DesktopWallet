﻿namespace Zilliqa.DesktopWallet.Core.ViewModel.ValueModel
{
    public class TransactionIdValue
    {
        public static bool TryParse(string value, out TransactionIdValue? result)
        {
            if (value.StartsWith("0x") && value.Length > 2)
            {
                value = value.Substring(2);
            }
            if (value.Length == 64)
            {
                //TODO: add Hex-Regex
                result = new TransactionIdValue(value);
                return true;
            }

            result = null;
            return false;
        }

        public TransactionIdValue(string transactionId)
        {
            if (transactionId.StartsWith("0x"))
            {
                TransactionId = transactionId.Substring(2);
            }
            else
            {
                TransactionId = transactionId;
            }
        }

        /// <summary>
        /// without leading '0x'
        /// </summary>
        public string TransactionId { get; }

        public override string ToString()
        {
            return $"0x {TransactionId}";
        }
    }
}