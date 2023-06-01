using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.WPF.ViewModels{
    public class TopCryptoViewModel : ViewModelBase {
        public TopCryptoListingViewModel TopCryptoListingViewModel { get;  }
        public TopCryptoSearchingViewModel TopCryptoSearchingViewModel { get; }

        public TopCryptoViewModel(){
            TopCryptoListingViewModel = new TopCryptoListingViewModel();
            TopCryptoSearchingViewModel = new TopCryptoSearchingViewModel();
        }
    }
}
