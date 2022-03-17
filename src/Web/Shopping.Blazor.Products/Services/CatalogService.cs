using Shopping.Blazor.Products.Extensions;
using Shopping.Blazor.Products.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopping.Blazor.Products.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;        

        public CatalogService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<Product>> GetCatalog()
        {
            var response = await _client.GetAsync("/api/v1/Catalog");
            return await response.ReadContentAs<List<Product>>();
        }

        public async Task<Product> GetCatalog(string id)
        {
            var response = await _client.GetAsync($"/Catalog/{id}");
            return await response.ReadContentAs<Product>();
        }

        public async Task<IEnumerable<Product>> GetCatalogByCategory(string category)
        {
            var response = await _client.GetAsync($"/Catalog/GetProductByCategory/{category}");
            return await response.ReadContentAs<List<Product>>();
        }

        public async Task<Product> CreateCatalog(Product model)
        {            
            var response = await _client.PostAsJson($"/Catalog", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<Product>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }        
    }
}
