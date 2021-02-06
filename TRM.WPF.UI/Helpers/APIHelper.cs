using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using TRM.WPF.UI.Models;

namespace TRM.WPF.UI.Helpers
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient _apiClient { get; set; }

        public APIHelper()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            string baseUrl = ConfigurationManager.AppSettings["baseUrl"];

            _apiClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };

            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticatedUser> AuthenticateAsync(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            using (HttpResponseMessage response = await _apiClient.PostAsync("/Token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<AuthenticatedUser>(await response.Content.ReadAsStringAsync());

                    return result;
                }

                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
