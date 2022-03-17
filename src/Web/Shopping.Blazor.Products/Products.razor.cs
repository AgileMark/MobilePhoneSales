using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.Blazor.Products.Models;
using Shopping.Blazor.Products.Services;
using Shopping.Blazor.Products.Models;
using Shopping.Blazor.Products.Services;

namespace Shopping.Blazor.Products
{
    public partial class Products
    {
        private readonly ICatalogService _catalogService;
        public Products(ICatalogService catalogService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));

        }
        public Products()
        {
            _catalogService = new CatalogService(new HttpClient { BaseAddress = new Uri("http://localhost:8000") });
            //var t = Task.Run(() => OnGetAsync());
            //t.Wait();
        }
        protected override async Task OnInitializedAsync()
        {
            //await Task.CompletedTask;
            ProductList = await _catalogService.GetCatalog();
        }

        public async Task OnGetAsync()
        {
            //var productList = await _catalogService.GetCatalog();
            ProductList = await _catalogService.GetCatalog();
            /*
            CategoryList = productList.Select(p => p.Category).Distinct();

            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                ProductList = productList.Where(p => p.Category == categoryName);
                SelectedCategory = categoryName;
            }
            else
            {
                ProductList = productList;
            }
            */
            //ProductList = productList;

        }

        public IEnumerable<Product> ProductList { get; set; } = new List<Product>();

    }
}
