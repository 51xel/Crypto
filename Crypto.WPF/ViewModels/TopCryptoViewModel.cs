using Crypto.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.WPF.ViewModels{
    public class TopCryptoViewModel : ViewModelBase {
        DisplayedCoinsStore DisplayedCoinsStore { get; }

        public TopCryptoListingViewModel TopCryptoListingViewModel { get; }
        public TopCryptoSearchingViewModel TopCryptoSearchingViewModel { get; }

        public TopCryptoViewModel(ModalNavigationStore modalNavigationStore) {
            DisplayedCoinsStore = new DisplayedCoinsStore();

            TopCryptoListingViewModel = new TopCryptoListingViewModel(DisplayedCoinsStore, modalNavigationStore);
            TopCryptoSearchingViewModel = new TopCryptoSearchingViewModel(DisplayedCoinsStore);
        }
    }
}
