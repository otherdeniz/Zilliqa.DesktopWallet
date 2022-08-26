using AutoMapper;
using Zilliqa.DesktopWallet.Core.Api.Coingecko.Model;

namespace Zilliqa.DesktopWallet.Core.Mappings
{
    public class CoingeckoMappingProfile : Profile
    {
        public CoingeckoMappingProfile()
        {
            CreateMap<CoinPriceMarketData, CoinHistoryMarketData>();

            CreateMap<CoinPrice, CoinHistory>();
        }
    }
}
