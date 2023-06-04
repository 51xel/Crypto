using Crypto.WPF.Stores;
using CryptoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.WPF.Commands {
    public class SearchCryptoCommand : CommandBase {
        private SearchedCoinStore _searchedCoin { get; }
        private DisplayedCoinsStore _displayedCoinsStore { get; }

        public SearchCryptoCommand(SearchedCoinStore searchedCoin, DisplayedCoinsStore displayedCoinsStore) {
            _searchedCoin = searchedCoin;
            _displayedCoinsStore = displayedCoinsStore;
        }

        public override void Execute(object parameter) {
            if (!String.IsNullOrWhiteSpace(_searchedCoin.Name)) {
                var coin = TopCryptoCommands.GetSearchedCrypto(_searchedCoin.Name);

                _displayedCoinsStore.Coins.Clear();

                if (coin != null && !String.IsNullOrWhiteSpace(coin.Name)) {
                    _displayedCoinsStore.Coins.Add(coin);
                }

                _displayedCoinsStore.Update();
            }
            else {
                _displayedCoinsStore.Coins = TopCryptoCommands.GetTopCrypto();
                _displayedCoinsStore.Update();
            }
        }
    }
}
