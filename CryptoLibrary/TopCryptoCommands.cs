using Newtonsoft.Json;

namespace CryptoLibrary {
    internal class CoinResponse {
        public List<Coin> Data { get; set; }
    }

    internal class CoinResponseTest {
        public Coin Data { get; set; }
    }

    public class TopCryptoCommands {
        public static List<Coin> GetTopCrypto(int amount = 10) {
            try {
                var response = QueryEngine.MakeQuery($"assets?limit={amount}").Result;

                var coinResponse = JsonConvert.DeserializeObject<CoinResponse>(response);

                return coinResponse.Data;
            }catch(Exception ex) {
                return null;
            }
        }

        public static Coin GetSearchedCrypto(string name) {
            try {
                var response = QueryEngine.MakeQuery($"assets/{name}").Result;

                var coinResponse = JsonConvert.DeserializeObject<CoinResponseTest>(response);

                return coinResponse.Data;
            }
            catch (Exception ex) {
                return null;
            }
        }
    }
}
