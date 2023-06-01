using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto.WPF.ViewModels{
    public class TopCryptoListingItemViewModel : ViewModelBase{
        public string Name { get; set; }
        public decimal Price { get; set; }

        ICommand ClickCryptoCommand { get; }

        public TopCryptoListingItemViewModel(string name, decimal price) {
            Name = name;
            Price = price;
        }
    }
}
