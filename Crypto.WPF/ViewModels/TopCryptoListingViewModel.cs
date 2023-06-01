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

        public TopCryptoListingViewModel() {
            _topCryptoListingItemViewModels = new ObservableCollection<TopCryptoListingItemViewModel>();

            _topCryptoListingItemViewModels.Add(new TopCryptoListingItemViewModel("Bitcoin1", 12331));
            _topCryptoListingItemViewModels.Add(new TopCryptoListingItemViewModel("Bitcoin2", 1235331));
            _topCryptoListingItemViewModels.Add(new TopCryptoListingItemViewModel("Bitcoin3", 1623131));
            _topCryptoListingItemViewModels.Add(new TopCryptoListingItemViewModel("Bitcoin4", 12333741));
        }
    }
}
