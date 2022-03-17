using Catalog.Entities;
using NUnit.Framework;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Catalog.Controllers;
using Catalog.Repositories;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Catalog.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class GetProductsAvailableInTheCatalogStepDefinitions
    {
        private readonly HttpClient _client = new HttpClient { BaseAddress = new Uri("http://localhost:8000") };
        private IEnumerable<Product>? _products;


        private CatalogController _catalogController;


        [SetUp]
        public void SetUp()
        {
            var subProductRepository = Substitute.For<IProductRepository>();
            var subLogger = Substitute.For<ILogger<CatalogController>>();
            _catalogController = new CatalogController(subProductRepository, subLogger);
        }

        [Given(@"I have do not have any products in the catalog")]
        public void GivenIHaveNotAddedAnyProductsToTheCatalog()
        {
            //RunAsync().GetAwaiter().GetResult();
        }

        [When(@"I view the products available")]
        public void WhenIViewTheProductsPage()
        {
            GetProducts("/api/v1/catalog").GetAwaiter().GetResult();
        }

        [Then(@"I should see no products")]
        public void ThenIShouldSeeNoProducts()
        {
            Assert.That(_products.Count(), Is.EqualTo(6));
        }

        async Task GetProducts(string path)
        {
            HttpResponseMessage response = await _client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                _products = response.Content.ReadFromJsonAsync<Product[]>().Result;
            }
        }

        /*
        async Task<IEnumerable<Product>> GetProducts(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            //string stringContent;
            if (response.IsSuccessStatusCode)
            {
                //stringContent = response.Content.ReadAsStringAsync().Result;
                products = response.Content.ReadFromJsonAsync<Product[]>().Result;
            }
            //return products;
        }
        async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:8000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new product
                Product product = new Product
                {
                    Name = "Gizmo",
                    Price = 100,
                    Category = "Widgets"
                };

                //var url = await CreateProductAsync(product);


                // Get the product
                products = await GetProducts("/api/v1/catalog");


                Console.WriteLine(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        */
    }
}
