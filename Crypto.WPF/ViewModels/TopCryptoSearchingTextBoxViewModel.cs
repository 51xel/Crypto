using Crypto.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.WPF.ViewModels {
    public class TopCryptoSearchingTextBoxViewModel : ViewModelBase {
        private string _name;
        private SearchedCoinStore _searchedCoin;

        public string Name {
            get {
                return _name;
            }
            set {
                _name = value;
                _searchedCoin.Name = value;
            }
        }

        public TopCryptoSearchingTextBoxViewModel(SearchedCoinStore searchedCoin) {
            _searchedCoin =  searchedCoin;
        }
    }
}
