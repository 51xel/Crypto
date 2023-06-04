using Newtonsoft.Json;

namespace CryptoLibrary {
    internal class CoinResponseList {
        public List<Coin> Data { get; set; }
    }

    internal class CoinResponse {
        public Coin Data { get; set; }
    }

    internal class MarketResponseList {
        public List<Market> Data { get; set; }
    }

    public class TopCryptoCommands {
        public static List<Coin> GetTopCrypto(int amount = 10) {
            try {
                var response = QueryEngine.MakeQuery($"assets?limit={amount}").Result;

                var coinResponse = JsonConvert.DeserializeObject<CoinResponseList>(response);

                return coinResponse.Data;
            }
            catch(Exception ex) {
                return null;
            }
        }

        public static Coin GetSearchedCrypto(string coinName) {
            try {
                var response = QueryEngine.MakeQuery($"assets/{coinName}").Result;

                var coinResponse = JsonConvert.DeserializeObject<CoinResponse>(response);

                return coinResponse.Data;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public static List<Market> GetMarkets(string coinName) {
            try {
                var response = QueryEngine.MakeQuery($"assets/{coinName}/markets").Result;

                var coinResponse = JsonConvert.DeserializeObject<MarketResponseList>(response);

                return coinResponse.Data;
            }
            catch (Exception ex) {
                return null;
            }
        }
    }
}
