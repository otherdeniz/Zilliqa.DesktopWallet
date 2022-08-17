using AutoMapper;
using Zilliqa.DesktopWallet.ApiClient.ZilstreamApi.Model;
using Zilliqa.DesktopWallet.Core.Data.Model;

namespace Zilliqa.DesktopWallet.Core.Mappings
{
    public class ZilstreamApiMappingProfile : Profile
    {
        public ZilstreamApiMappingProfile()
        {
            // from "Zilliqa.DesktopWallet.ApiClient.ZilstreamApi.Model"
            // to   "Zilliqa.DesktopWallet.Core.Data.Model"
            CreateMap<ZilstreamToken, TokenModel>();
            CreateMap<ZilstreamTokenMarketData, TokenMarketDataModel>();
        }
    }
}
