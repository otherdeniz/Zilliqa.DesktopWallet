using System.Text;
using Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Responses.Abstract;

namespace Zilliqa.DesktopWallet.Device.Ledger.LedgerNet.Responses.Concrete
{
	public class GetCoinVersionResponse: ResponseBase
	{
        private const int CoinLengthPos = 5;
		private const int SpacerLength = 2;

        public string CoinName { get; }
		public string ShortCoinName { get; }

        public GetCoinVersionResponse(byte[] data) : base(data)
		{
            if (!IsSuccess)
            {
                return;
            }

            if (data == null) throw new ArgumentNullException(nameof(data));

            var coinLength = data[CoinLengthPos];
			var shortCoinNameStartPos = CoinLengthPos + SpacerLength + coinLength;
			var shortCoinLength = data[shortCoinNameStartPos - 1];

			var responseList = data.ToList();

			var coinNameData = responseList.GetRange(6, coinLength).ToArray();
			var shortCoinNameData = responseList.GetRange(shortCoinNameStartPos, shortCoinLength).ToArray();

			CoinName = Encoding.ASCII.GetString(coinNameData);
			ShortCoinName = Encoding.ASCII.GetString(shortCoinNameData);
		}
    }
}