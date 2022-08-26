using AutoMapper;
using Zilliqa.DesktopWallet.Core.Mappings;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public sealed class MappingService
    {
        public static MappingService Instance { get; } = new();

        private MappingService()
        {
            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ZilstreamApiMappingProfile());
                cfg.AddProfile(new ZilliqaApiToDbMappingProfile());
                cfg.AddProfile(new CoingeckoMappingProfile());
            }).CreateMapper();
        }

        public IMapper Mapper { get; }

    }
}
