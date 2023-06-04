using Crypto.WPF.Commands;
using Crypto.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto.WPF.ViewModels {
    public class TopCryptoSearchingButtonViewModel : ViewModelBase {
        public ICommand SearchCommand { get; }

        public TopCryptoSearchingButtonViewModel(SearchedCoinStore searchedCoin, DisplayedCoinsStore displayedCoinsStore){
            SearchCommand = new SearchCryptoCommand(searchedCoin, displayedCoinsStore);
        }
    }
}
