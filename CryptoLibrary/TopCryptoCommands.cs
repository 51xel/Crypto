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
        public static async Task<List<Coin>> GetTopCrypto(int amount = 10) {
            try {
                var response = await QueryEngine.MakeQuery($"assets?limit={amount}");

                var coinResponse = JsonConvert.DeserializeObject<CoinResponseList>(response);

                return coinResponse.Data;
            }
            catch(Exception ex) {
                return null;
            }
        }

        public static async Task<Coin> GetSearchedCrypto(string coinName) {
            try {
                var response = await QueryEngine.MakeQuery($"assets/{coinName}");

                var coinResponse = JsonConvert.DeserializeObject<CoinResponse>(response);

                return coinResponse.Data;
            }
            catch (Exception ex) {
                try {
                    var list = await GetTopCrypto(100);
                    var result = list.FirstOrDefault(e => 
                                                        e.Id == coinName || 
                                                        e.Name == coinName || 
                                                        e.Symbol == coinName || 
                                                        e.Symbol == coinName.ToUpper());
                    return result;
                }
                catch (Exception) {
                    return null;
                }
            }
        }

        public static async Task<List<Market>> GetMarkets(string coinName) {
            try {
                var response = await QueryEngine.MakeQuery($"assets/{coinName}/markets");

                var coinResponse = JsonConvert.DeserializeObject<MarketResponseList>(response);

                return coinResponse.Data;
            }
            catch (Exception ex) {
                return null;
            }
        }
    }
}
