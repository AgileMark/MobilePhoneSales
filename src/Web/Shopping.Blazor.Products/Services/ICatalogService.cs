using Shopping.Blazor.Products.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Blazor.Products.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<Product>> GetCatalog();
        Task<IEnumerable<Product>> GetCatalogByCategory(string category);
        Task<Product> GetCatalog(string id);
        Task<Product> CreateCatalog(Product model);
    }
}
