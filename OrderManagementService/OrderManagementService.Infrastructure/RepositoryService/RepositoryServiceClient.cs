using Newtonsoft.Json;
using OrderManagementService.Application.Interfaces;
using OrderManagementService.Application.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrderManagementService.Infrastructure.RepositoryService
{
    /// <summary>
    /// Service to interact with the repository service for retrieving information.
    /// This class implements the <see cref="IRepositoryServiceClient"/> interface.
    /// </summary>
    public class RepositoryServiceClient : IRepositoryServiceClient
    {
        private readonly HttpClient _httpClient;

        public RepositoryServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OrderDTO?> GetOrderByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/order/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<OrderDTO>(content)!;
            }

            return null;
        }

        public async Task<ProductDTO?> GetProductByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/product/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductDTO>(content)!;
            }

            return null;
        }
    }
}
