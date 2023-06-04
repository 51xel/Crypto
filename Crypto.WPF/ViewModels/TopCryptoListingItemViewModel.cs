using CryptoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto.WPF.ViewModels{
    public class TopCryptoListingItemViewModel : ViewModelBase{
        public string Name { get; set; }
        public decimal PriceUsd { get; set; }

        public Coin Coin { get; set; }
        public Market Market { get; set; }

        public TopCryptoListingItemViewModel(Coin coin) {
            Name = coin.Name;
            PriceUsd = coin.PriceUsd;

            Coin = coin;
        }

        public TopCryptoListingItemViewModel(Market market) {
            Name = market.ExchangeId;
            PriceUsd = market.PriceUsd;

            Market = market;
        }
    }
}
