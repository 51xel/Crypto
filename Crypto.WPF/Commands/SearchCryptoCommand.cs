using Crypto.WPF.Stores;
using CryptoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.WPF.Commands {
    public class SearchCryptoCommand : AsyncCommandBase {
        private SearchedCoinStore _searchedCoin { get; }
        private DisplayedCoinsStore _displayedCoinsStore { get; }

        public SearchCryptoCommand(SearchedCoinStore searchedCoin, DisplayedCoinsStore displayedCoinsStore) {
            _searchedCoin = searchedCoin;
            _displayedCoinsStore = displayedCoinsStore;
        }

        public override async Task ExecuteAsync(object parameter) {
            if (!String.IsNullOrWhiteSpace(_searchedCoin.Name)) {
                var coin = await TopCryptoCommands.GetSearchedCrypto(_searchedCoin.Name);

                _displayedCoinsStore.Coins.Clear();

                if (coin != null && !String.IsNullOrWhiteSpace(coin.Name)) {
                    _displayedCoinsStore.Coins.Add(coin);
                }

                _displayedCoinsStore.Update();
            }
            else {
                _displayedCoinsStore.Coins = await TopCryptoCommands.GetTopCrypto();
                _displayedCoinsStore.Update();
            }
        }
    }
}
