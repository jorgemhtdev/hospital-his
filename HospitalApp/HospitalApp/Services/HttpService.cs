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
        private const string UrlApi = "YourApi";
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
                    DefaultRequestHeaders = {Authorization = new AuthenticationHeaderValue(tokenType, Settings.AccessToken)}
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
        public async Task<Response> Post<T>(string version, string patch, T model)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");

                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, Settings.AccessToken);
                client.BaseAddress = new Uri(UrlApi);

                var url = $"{version}{patch}";

                var response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = response.StatusCode.ToString(),
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var newRecord = JsonConvert.DeserializeObject<T>(result);

                return new Response
                {
                    IsSuccess = true,
                    Message = "Record added OK",
                    Result = newRecord,
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

        public async Task<Response> PostStatusCode<T>(string version, string patch, T model)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");

                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, Settings.AccessToken);
                client.BaseAddress = new Uri(UrlApi);

                var url = $"{version}{patch}";

                var response = await client.PostAsync(url, content);

                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = JsonConvert.DeserializeObject<MessageResponse>(result).Message
                    };
                };
                
                return new Response
                {
                    IsSuccess = true,
                    Message = "OK",
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
    }
}
