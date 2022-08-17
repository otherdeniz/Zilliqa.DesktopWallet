using AutoMapper;
using Zilliqa.DesktopWallet.Core.Mappings;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public sealed class MappingService
    {
        public static MappingService Instance { get; } = new MappingService();

        private MappingService()
        {
            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ZilstreamApiMappingProfile());
                cfg.AddProfile(new ZilliqaApiToDbMappingProfile());
            }).CreateMapper();
        }

        public IMapper Mapper { get; }

    }
}
