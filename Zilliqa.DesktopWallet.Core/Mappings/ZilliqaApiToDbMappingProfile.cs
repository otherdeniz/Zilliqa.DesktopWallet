using AutoMapper;
using Zilliqa.DesktopWallet.ApiClient.Utils;
using ApiModel = Zilliqa.DesktopWallet.ApiClient.Model;
using DbModel = Zilligraph.Database.Schema.ZilliqaBlockchain;

namespace Zilliqa.DesktopWallet.Core.Mappings
{
    public class ZilliqaApiToDbMappingProfile : Profile
    {
        public ZilliqaApiToDbMappingProfile()
        {
            // from "Zilliqa.DesktopWallet.ApiClient.Model"
            // to   "Zilligraph.Database.Schema.ZilliqaBlockchain"
            CreateMap<ApiModel.Transaction, DbModel.Transaction>()
                .ForMember(t => t.SenderAddress, s => s.MapFrom(m => m.SenderPubKey.GetAddressFromPublicKey()));


        }
    }
}
