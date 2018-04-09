namespace HospitalApp.Services
{
    using HospitalApp.Helpers;
    using Model;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    public class HttpService
    {
        #region Constant
        private const string UrlApi = "YOUR_API";
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
        public async Task<Response> Get<T>(string version, string patch)
        {
            try
            {
                var client = new HttpClient()
                {
                    BaseAddress = new Uri(UrlApi),
                    DefaultRequestHeaders =
                    {
                        Authorization = new AuthenticationHeaderValue(tokenType, Settings.AccessToken)
                    }
                };

                var url = $"{version}{patch}";

                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result);

                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
        #endregion

        #region Post

        #endregion
    }
}
