using Crypto.WPF.Stores;
using CryptoLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.WPF.ViewModels{
    public class DetailsListingViewModel : ViewModelBase {
        private readonly ObservableCollection<TopCryptoListingItemViewModel> _listingItemViewModels;
        public IEnumerable<TopCryptoListingItemViewModel> ListingItemViewModels { get { return _listingItemViewModels; } }
        public bool HasListingItemViewModels { get { return _listingItemViewModels.Count != 0; } }

        public DetailsListingViewModel(List<Market> markets) {
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
    }
}
