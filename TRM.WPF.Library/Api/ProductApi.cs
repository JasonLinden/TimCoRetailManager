using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TRM.WPF.Library.Api.Interfaces;
using TRM.WPF.Library.Models;

namespace TRM.WPF.Library.Api
{
    public class ProductApi : IProductApi
    {
        private readonly IAPIHelper _apiHelper;

        public ProductApi(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Product"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<ProductModel>>(await response.Content.ReadAsStringAsync());

                    return result;
                }
                else
                    throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
