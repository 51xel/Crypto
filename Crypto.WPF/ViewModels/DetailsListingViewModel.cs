using CryptoLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Crypto.WPF.ViewModels{
    public class DetailsListingViewModel : ViewModelBase {
        private readonly ObservableCollection<TopCryptoListingItemViewModel> _listingItemViewModels;
        public IEnumerable<TopCryptoListingItemViewModel> ListingItemViewModels { get { return _listingItemViewModels; } }
        public bool HasListingItemViewModels { get { return _listingItemViewModels.Count != 0; } }

        private TopCryptoListingItemViewModel _listingItemViewModel;
        public TopCryptoListingItemViewModel SelectedListingItem {
            get {
                return _listingItemViewModel;
            }
            set {
                _listingItemViewModel = value;
                OpenBrowser();
            }
        }

        public DetailsListingViewModel(Task<List<Market>> markets) {
            _listingItemViewModels = new ObservableCollection<TopCryptoListingItemViewModel>();

            UpdateListing(markets);
        }

        public void UpdateListing(List<Market> list) {
            if (list != null) {
                _listingItemViewModels.Clear();

                foreach (var element in list) {
                    element.PriceUsd = Math.Round(element.PriceUsd, 3);
                    _listingItemViewModels.Add(new TopCryptoListingItemViewModel(element));
                }

                OnPropertyChanged(nameof(HasListingItemViewModels));
            }
        }

        public async void UpdateListing(Task<List<Market>> list) {
            var result = await list;
            UpdateListing(result);
        }

        private void OpenBrowser() {
            try {
                Process.Start(new ProcessStartInfo {
                    FileName = "cmd",
                    Arguments = $"/c start https://coincap.io/exchanges/{_listingItemViewModel.Market.ExchangeId.ToLower()}",
                    UseShellExecute = false,
                    CreateNoWindow = true
                });
            }
            catch (Exception ex) { }
        }
    }
}
