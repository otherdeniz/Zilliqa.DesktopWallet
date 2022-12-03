namespace Zilliqa.DesktopWallet.Device.Ledger.LedgerNet
{
    public interface ICoinInfo
    {
        App App { get;  }
        uint CoinNumber { get;  }
        string FullName { get; }
        bool IsSegwit { get;  }
        string ShortName { get;  }
    }
}