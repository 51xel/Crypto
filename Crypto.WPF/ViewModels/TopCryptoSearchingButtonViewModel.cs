using Crypto.WPF.Commands;
using Crypto.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto.WPF.ViewModels {
    public class TopCryptoSearchingButtonViewModel {
        private SearchedCoinStore _searchedCoin { get; }
        private DisplayedCoinsStore _displayedCoinsStore { get; }

        public ICommand SearchCommand { get; }

        public TopCryptoSearchingButtonViewModel(SearchedCoinStore searchedCoin, DisplayedCoinsStore displayedCoinsStore){
            _searchedCoin = searchedCoin;
            _displayedCoinsStore = displayedCoinsStore;

            SearchCommand = new SearchCryptoCommand(_searchedCoin, _displayedCoinsStore);
        }
    }
}
