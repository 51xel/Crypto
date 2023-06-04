﻿using Crypto.WPF.Commands;
using Crypto.WPF.Stores;
using CryptoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto.WPF.ViewModels {
    public class DetailsViewModel : ViewModelBase {
        public DetailsListingViewModel DetailsListingViewModel { get; }
        public DetailsInfoViewModel DetailsInfoViewModel { get; }

        public ICommand HomeCommand { get; }

        private Coin _coin;
        public string Name {
            get {
                return _coin.Name;
            }
        }

        public DetailsViewModel(Coin coin, NavigationStore navigationStore) {
            _coin = coin;

            var markets = TopCryptoCommands.GetMarkets(_coin.Id);

            DetailsListingViewModel = new DetailsListingViewModel(markets);
            DetailsInfoViewModel = new DetailsInfoViewModel(_coin);

            HomeCommand = new HomeCommand(navigationStore);
        }
    }
}
