using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary {
    public class Coin {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal PriceUsd { get; set; }
        public decimal VolumeUsd24Hr { get; set; }
        public decimal ChangePercent24Hr { get; set; }
        public long Time { get; set; }
    }
}
