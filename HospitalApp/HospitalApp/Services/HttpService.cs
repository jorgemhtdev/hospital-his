namespace HospitalApp.Services
{
    using Model;
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class HttpService
    {
        #region Constant
        private const string UrlApi = "YOURAPI";
        private const string tokenType = "bearer";
        protected const string FirstVersion = "/api";
        #endregion

        protected async Task<TokenResponse> GetToken(string email, string password)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(UrlApi)
                };
                var response = await client.PostAsync("Token", 
                    new StringContent($"grant_type=password&username={email}&password={password}", Encoding.UTF8, "application/json"));
                var resultJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TokenResponse>(resultJson);
            }
            catch
            {
                return null;
            }
        }

        #region Get

        #endregion

        #region Post

        #endregion
    }
}
