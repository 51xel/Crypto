using Crypto.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.WPF.ViewModels {
    public class TopCryptoSearchingViewModel : ViewModelBase {
        public SearchedCoinStore SearchedCoin { get; }

        public TopCryptoSearchingButtonViewModel TopCryptoSearchingButtonViewModel { get; }
        public TopCryptoSearchingTextBoxViewModel TopCryptoSearchingTextBoxViewModel { get; }

        public TopCryptoSearchingViewModel(DisplayedCoinsStore displayedCoinsStore) {
            SearchedCoin = new SearchedCoinStore();

            TopCryptoSearchingButtonViewModel = new TopCryptoSearchingButtonViewModel(SearchedCoin, displayedCoinsStore);
            TopCryptoSearchingTextBoxViewModel = new TopCryptoSearchingTextBoxViewModel(SearchedCoin);
        }
    }
}
