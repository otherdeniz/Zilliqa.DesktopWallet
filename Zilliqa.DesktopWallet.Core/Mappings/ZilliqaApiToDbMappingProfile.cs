using AutoMapper;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.DatabaseSchema;
using ApiModel = Zilliqa.DesktopWallet.ApiClient.Model;

namespace Zilliqa.DesktopWallet.Core.Mappings
{
    public class ZilliqaApiToDbMappingProfile : Profile
    {
        public ZilliqaApiToDbMappingProfile()
        {
            // from "Zilliqa.DesktopWallet.ApiClient.Model"
            // to   "Zilliqa.DesktopWallet.DatabaseSchema.ZilliqaBlockchain"

            CreateMap<ApiModel.Transaction, Transaction>()
                .ForMember(t => t.SenderAddress, s => s.MapFrom(m => m.SenderPubKey.GetAddressFromPublicKey()))
                .AfterMap((s, t) =>
                {
                    t.TransactionFailed = !s.Receipt.Success;
                    if (!string.IsNullOrEmpty(t.Code))
                    {
                        t.TransactionType = (int)TransactionType.ContractDeployment;
                    }
                    else if (!string.IsNullOrEmpty(t.Data))
                    {
                        t.TransactionType = (int)TransactionType.ContractCall;
                    }
                    else
                    {
                        t.TransactionType = (int)TransactionType.Payment;
                    }
                });

            CreateMap<ApiModel.TxBlock, Block>()
                .ForMember(t => t.BlockNumber, s => s.MapFrom(m => int.Parse(m.BlockNum)))
                .ForMember(t => t.Timestamp, s => s.MapFrom(m => m.Header.Timestamp.UnixTimestampToDateTime()))
                .ForMember(t => t.DSBlockNum, s => s.MapFrom(m => int.Parse(m.Header.DSBlockNum)))
                .ForMember(t => t.GasLimit, s => s.MapFrom(m => long.Parse(m.Header.GasLimit)))
                .ForMember(t => t.GasUsed, s => s.MapFrom(m => long.Parse(m.Header.GasUsed)))
                .ForMember(t => t.MinerPubKey, s => s.MapFrom(m => m.Header.MinerPubKey))
                .ForMember(t => t.NumMicroBlocks, s => s.MapFrom(m => m.Header.NumMicroBlocks))
                .ForMember(t => t.NumTxns, s => s.MapFrom(m => m.Header.NumTxns))
                .ForMember(t => t.Rewards, s => s.MapFrom(m => long.Parse(m.Header.Rewards)))
                .ForMember(t => t.TxnFees, s => s.MapFrom(m => long.Parse(m.Header.TxnFees)))
                .ForMember(t => t.Version, s => s.MapFrom(m => m.Header.Version));
        }
    }
}
