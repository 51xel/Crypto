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
        private ModalNavigationStore _modalNavigationStore;

        private TopCryptoListingItemViewModel _topCryptoListingItemViewModel;
        public TopCryptoListingItemViewModel SelectedTopCryptoListingItem {
            get {
                return _topCryptoListingItemViewModel;
            }
            set {
               _topCryptoListingItemViewModel = value;

                _modalNavigationStore.CurrentViewModel = new DetailsViewModel(_topCryptoListingItemViewModel.Coin, _modalNavigationStore);
            }
        }

        public TopCryptoListingViewModel(DisplayedCoinsStore displayedCoinsStore, ModalNavigationStore modalNavigationStore) {
            _listingItemViewModels = new ObservableCollection<TopCryptoListingItemViewModel>();

            _displayedCoinsStore = displayedCoinsStore;
            _displayedCoinsStore.DisplayedCoinsStoreChanged += DisplayedCoinsStoreChanged;

            _modalNavigationStore = modalNavigationStore;

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

        protected override void Dispose() {
            _displayedCoinsStore.DisplayedCoinsStoreChanged -= DisplayedCoinsStoreChanged;

            base.Dispose();
        }
    }
}
