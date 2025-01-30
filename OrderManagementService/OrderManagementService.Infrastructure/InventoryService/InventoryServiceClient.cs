using Newtonsoft.Json;
using OrderManagementService.Application.Interfaces;
using OrderManagementService.Application.Models.DTOs;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrderManagementService.Infrastructure.InventoryService
{
    /// <summary>
    /// Service to interact with the inventory service for retrieving information.
    /// This class implements the <see cref="IInventoryServiceClient"/> interface.
    /// </summary>
    public class InventoryServiceClient : IInventoryServiceClient
    {
        private readonly HttpClient _httpClient;

        public InventoryServiceClient(HttpClient httpClient)
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
