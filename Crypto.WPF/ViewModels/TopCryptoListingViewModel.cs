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
        private readonly ObservableCollection<TopCryptoListingItemViewModel> _listingItemViewModels;
        public IEnumerable<TopCryptoListingItemViewModel> ListingItemViewModels { get { return _listingItemViewModels; } }
        public bool HasListingItemViewModels { get { return _listingItemViewModels.Count != 0; } }

        private DisplayedCoinsStore _displayedCoinsStore { get; }
        private NavigationStore _navigationStore;

        private TopCryptoListingItemViewModel _topCryptoListingItemViewModel;
        public TopCryptoListingItemViewModel SelectedTopCryptoListingItem {
            get {
                return _topCryptoListingItemViewModel;
            }
            set {
               _topCryptoListingItemViewModel = value;

                _navigationStore.CurrentViewModel = new DetailsViewModel(_topCryptoListingItemViewModel.Coin, _navigationStore);
            }
        }

        public TopCryptoListingViewModel(DisplayedCoinsStore displayedCoinsStore, NavigationStore navigationStore) {
            _listingItemViewModels = new ObservableCollection<TopCryptoListingItemViewModel>();

            _displayedCoinsStore = displayedCoinsStore;
            _displayedCoinsStore.DisplayedCoinsStoreChanged += DisplayedCoinsStoreChanged;

            _navigationStore = navigationStore;

            UpdateListing(TopCryptoCommands.GetTopCrypto());
        }

        private void DisplayedCoinsStoreChanged() {
            UpdateListing(_displayedCoinsStore.Coins);
        }

        public void UpdateListing(List<Coin> list) {
            if (list != null) {
                _listingItemViewModels.Clear();

                if (list.Count != 0) {
                    _displayedCoinsStore.Coins = list;
                }

                foreach (var element in list) {
                    element.PriceUsd = Math.Round(element.PriceUsd, 3);
                    _listingItemViewModels.Add(new TopCryptoListingItemViewModel(element));
                }

                OnPropertyChanged(nameof(HasListingItemViewModels));
            }
        }

        public async void UpdateListing(Task<List<Coin>> list) {
            var result = await list;
            UpdateListing(result);
        }

        protected override void Dispose() {
            _displayedCoinsStore.DisplayedCoinsStoreChanged -= DisplayedCoinsStoreChanged;

            base.Dispose();
        }
    }
}
