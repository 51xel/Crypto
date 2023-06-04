using CryptoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.WPF.ViewModels {
    public class DetailsInfoViewModel : ViewModelBase {
        public decimal PriceUsd { get; }
        public decimal VolumeUsd24Hr { get; }
        public decimal ChangePercent24Hr { get; }

        public DetailsInfoViewModel(Coin coin){
            PriceUsd = Math.Round(coin.PriceUsd, 3);
            VolumeUsd24Hr = Math.Round(coin.VolumeUsd24Hr, 3);
            ChangePercent24Hr = Math.Round(coin.ChangePercent24Hr, 3);
        }
    }
}
