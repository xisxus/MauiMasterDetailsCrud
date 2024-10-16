using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Security;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProductApplication
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService()
        {
            var handler = new HttpClientHandler();
            // Enable unsecure HTTP for development
            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => true;

            _httpClient = new HttpClient(handler);

            // For Android Emulator use 10.0.2.2
            // For physical device, use your computer's IP address
            // Example: "192.168.1.100"
            string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                ? "https://10.0.2.2:7115/"
                : "https://localhost:7115/";

            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<List<ProductCategory>> GetProductCategoriesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ProductCategory>>("ProductCategories");
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error getting categories: {ex.Message}");
                return new List<ProductCategory>();
            }
        }

        public async Task<ProductCategory> GetProductCategoryByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ProductCategory>($"ProductCategories/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting category {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> AddProductCategoryAsync(ProductCategory category)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("ProductCategories", category);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding category: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateProductCategoryAsync(int id, ProductCategory category)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"ProductCategories/{id}", category);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating category {id}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteProductCategoryAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"ProductCategories/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting category {id}: {ex.Message}");
                return false;
            }
        }
    }
}