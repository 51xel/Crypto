using System;
using System.Net;
using Newtonsoft.Json;

namespace CryptoLibrary {
    public class QueryEngine {
        public static async Task<string> MakeQuery(string query) {
            string apiUrl = "https://api.coincap.io/v2/";

            using (HttpClient client = new HttpClient()) {
                var response = client.GetStringAsync(apiUrl + query).Result;
                return response;
            }
        }
    }
}
