using System.ComponentModel;
using System.Drawing;
using Zilliqa.DesktopWallet.ApiClient.ViewblockApi.Model;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Data.Images;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    [DetailsTitle("IconModel", "Name", "Description")]
    [GridSearchable(nameof(SearchTerm))]
    public class EcosystemViewModel : IDetailsLabel
    {
        public static List<EcosystemViewModel> CreateViewModelList()
        {
            return CryptometaFile.Instance.Ecosystems
                .Select(e => new EcosystemViewModel(e))
                .OrderBy(e => e.CategoryPriority())
                .ThenBy(e => e.Category)
                .ThenBy(e => e.Name)
                .ToList();
        }

        public EcosystemViewModel(CryptometaEcosystem cryptometaEcosystem)
        {
            CryptometaEcosystem = cryptometaEcosystem;
        }

        [Browsable(false)]
        public CryptometaEcosystem CryptometaEcosystem { get; }

        [Browsable(false)]
        public IconModel IconModel => LogoImages.Instance.GetImage(CryptometaEcosystem.Key);

        [Browsable(false)]
        public string SearchTerm => $"{Name.ToLower()}|{Category.ToLower()}|{Description.ToLower()}";

        [DisplayName(" ")]
        public Image? Icon16 => IconModel.Icon16;

        [ColumnWidth(150)] 
        public string Name => CryptometaEcosystem.Name;

        [ColumnWidth(250)] 
        public string Description => CryptometaEcosystem.Description;

        public string Category => CryptometaEcosystem.Categories?.FirstOrDefault() ?? "";

        [DisplayName("Addresses")]
        public int AddressCount => CryptometaEcosystem.Addresses?.Length ?? 0;

        [Browsable(false)]
        [DetailsProperty(DetailsPropertyType.TextList)]
        public string[] Categories => CryptometaEcosystem.Categories ?? new string[]{};

        [Browsable(false)]
        [DetailsProperty(DetailsPropertyType.AddressList)]
        public string[] Addresses => CryptometaEcosystem.Addresses ?? new string[] { };

        [Browsable(false)]
        [DetailsProperty(DetailsPropertyType.Url)]
        public string Website => CryptometaEcosystem.Web;

        [Browsable(false)]
        [DetailsChildProperties(null)]
        public CryptometaLinks Links => CryptometaEcosystem.Links;

        public string GetUniqueId()
        {
            return $"Ecosystem-{Name}";
        }

        public string GetDisplayTitle()
        {
            return $"Ecosystem: {Name}";
        }

        private int CategoryPriority()
        {
            switch (Category)
            {
                case "exchange":
                    return 1;
                case "dex":
                    return 2;
                case "wallet":
                    return 3;
                case "":
                    return 10;
            }
            return 9;
        }

    }
}
