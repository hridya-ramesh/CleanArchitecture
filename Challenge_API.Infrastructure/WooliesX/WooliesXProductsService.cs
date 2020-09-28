using Challenge_API.Application.Interfaces;
using Challenge_API.Application.Interfaces.Request;
using Challenge_API.Application.Interfaces.Response;
using Challenge_API.Infrastructure.WooliesX.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_API.Infrastructure.WooliesX
{
    public class WooliesXProductsService : IWooliesXProductService
    {
        private readonly WooliesAPI _wooliesAPI;
        private readonly HttpClient _httpClient;
        public WooliesXProductsService(IOptions<WooliesAPI> apiOptions, IHttpClientFactory factory)
        {
            _wooliesAPI = apiOptions.Value;
            _httpClient = factory.CreateClient();
        }
        public async Task<List<Product>> GetProducts()
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, _wooliesAPI.ProductsUrl + $"/products/?token={_wooliesAPI.Token}");
            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"{response.StatusCode} - Failed to retrieve product details from API " + responseContent);
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Product>>(content);
        }
        public async Task<List<ShopperHistory>> GetShopperHistory()
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, _wooliesAPI.ProductsUrl + $"/shopperHistory/?token={_wooliesAPI.Token}");
            var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"{response.StatusCode} - Failed to retrieve shopper history details from API " + responseContent);
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ShopperHistory>>(content);
        }
        public User GetUser()
        {
            return new User { Name = _wooliesAPI.TestUser, Token = _wooliesAPI.TestToken };
        }
        public async Task<decimal> GetTrolleyTotal(TrolleyDetails trolleyDetails)
        {
            var requestJson = JsonConvert.SerializeObject(trolleyDetails);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, _wooliesAPI.ProductsUrl + $"/trolleyCalculator?token={_wooliesAPI.Token}")
            {
                Content = content
            };
            var response = await _httpClient.SendAsync(requestMessage);
            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"{response.StatusCode} - Failed to retrieve shopper trolley details from API " + responseContent);
            }
            var trolleyResponse = await response.Content.ReadAsStringAsync();
            decimal trolleyTotal;
            decimal.TryParse(trolleyResponse,out  trolleyTotal);
            return trolleyTotal;
        }
    }
}
