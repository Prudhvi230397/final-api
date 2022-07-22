using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdminMicroServices.ViewModel
{
    public class IdentityServerToken
    {
        public  async Task<string> GetApiToken()
        {
            var url = "http://localhost:5000/connect/token";
            var client = new HttpClient();
            string grant_type = "client_credentials";
            string client_id = "clientAdmin";
            string client_secret = "secretAdmin";
            string scope = "AirLineMicroservices";

            var form = new Dictionary<string, string>
                {
                    {"grant_type", grant_type},
                    {"client_id", client_id},
                    {"client_secret", client_secret},
                    {"scope", scope},
                };

            HttpResponseMessage tokenResponse = await client.PostAsync(url, new FormUrlEncodedContent(form));
            var jsonContent = await tokenResponse.Content.ReadAsStringAsync();
            Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);
            return tok.AccessToken;
        }
    }
    internal class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
}
