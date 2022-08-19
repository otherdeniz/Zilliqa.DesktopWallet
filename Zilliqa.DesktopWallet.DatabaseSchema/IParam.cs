namespace Zilliqa.DesktopWallet.DatabaseSchema;

public interface IParam
{
    string Type { get; set; }

    string Vname { get; set; }

    object Value { get; set; }
}