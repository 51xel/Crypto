using Crypto.WPF.Stores;
using CryptoLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.WPF.ViewModels{
    public class TopCryptoListingViewModel : ViewModelBase {
        private readonly ObservableCollection<TopCryptoListingItemViewModel> _topCryptoListingItemViewModels;
        public IEnumerable<TopCryptoListingItemViewModel> TopCryptoListingItemViewModels { get { return _topCryptoListingItemViewModels; } }
        public bool HasTopCryptoListingItemViewModels { get { return _topCryptoListingItemViewModels.Count != 0; } }
        private DisplayedCoinsStore _displayedCoinsStore { get; }

        public TopCryptoListingViewModel(DisplayedCoinsStore displayedCoinsStore) {
            _topCryptoListingItemViewModels = new ObservableCollection<TopCryptoListingItemViewModel>();

            _displayedCoinsStore = displayedCoinsStore;
            _displayedCoinsStore.DisplayedCoinsStoreChanged += DisplayedCoinsStoreChanged;

            UpdateListing(TopCryptoCommands.GetTopCrypto());
        }

        private void DisplayedCoinsStoreChanged() {
            UpdateListing(_displayedCoinsStore.Coins);
        }

        public void UpdateListing(List<Coin> list) {
            if (list != null) {
                _topCryptoListingItemViewModels.Clear();

                if (list.Count != 0) {
                    _displayedCoinsStore.Coins = list;
                }

                foreach (var element in list) {
                    element.PriceUsd = Math.Round(element.PriceUsd, 3);
                    _topCryptoListingItemViewModels.Add(new TopCryptoListingItemViewModel(element));
                }

                OnPropertyChanged(nameof(HasTopCryptoListingItemViewModels));
            }
        }
    }
}
