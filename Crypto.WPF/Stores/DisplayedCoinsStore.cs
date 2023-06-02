using CryptoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.WPF.Stores {
    public class DisplayedCoinsStore {
        public List<Coin> Coins { get; set; }

        public event Action DisplayedCoinsStoreChanged;

        public void Update() {
            DisplayedCoinsStoreChanged?.Invoke();
        }
    }
}
