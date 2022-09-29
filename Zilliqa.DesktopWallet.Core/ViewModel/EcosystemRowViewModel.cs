using System.ComponentModel;
using System.Drawing;
using Zilliqa.DesktopWallet.ApiClient.ViewblockApi.Model;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Data.Images;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class EcosystemRowViewModel
    {
        public static List<EcosystemRowViewModel> CreateViewModel()
        {
            return CryptometaFile.Instance.Ecosystems
                .Select(e => new EcosystemRowViewModel(e))
                .OrderBy(e => e.CategoryPriority())
                .ThenBy(e => e.Category)
                .ThenBy(e => e.Name)
                .ToList();
        }

        public EcosystemRowViewModel(CryptometaEcosystem cryptometaEcosystem)
        {
            CryptometaEcosystem = cryptometaEcosystem;
        }

        [Browsable(false)]
        public CryptometaEcosystem CryptometaEcosystem { get; }

        [Browsable(false)]
        public IconModel IconModel => LogoImages.Instance.GetImage(CryptometaEcosystem.Key);

        [DisplayName(" ")]
        public Image? Icon16 => IconModel.Icon16;

        [ColumnWidth(150)] 
        public string Name => CryptometaEcosystem.Name;

        [ColumnWidth(250)] 
        public string Description => CryptometaEcosystem.Description;

        public string Category => CryptometaEcosystem.Categories?.FirstOrDefault() ?? "";

        public int Addresses => CryptometaEcosystem.Addresses?.Length ?? 0;

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
