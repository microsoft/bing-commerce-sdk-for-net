using Microsoft.Bing.ECommerce.Ingestion;
using Microsoft.Bing.ECommerce.Search;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bing.ECommerce.Search.Models;
using Microsoft.Bing.ECommerce.Ingestion.Models;
using Index = Microsoft.Bing.ECommerce.Ingestion.Models.Index;

namespace BingECommerceSamples
{
    class Program
    {
        private readonly static string TENANT_ID = Environment.GetEnvironmentVariable("TENANT_ID");
        private readonly static string APPID = Environment.GetEnvironmentVariable("APPID");
        private readonly static string INDEX_NAME = "SampleIndex";

        static async Task Main(string[] args)
        {
            var ingestionClient = CreateIngestionClient();
            var searchClient = CreateSearchClient();

            var indexId = await EnsureIndex(ingestionClient);
            Console.WriteLine($"Working with index: {indexId}");

            // Push some data
            Console.WriteLine("Pushing some JSONArray data.");
            var products = new List<MyProduct>() {
                new MyProduct() { ProductId = "1", ProductTitle = "My First Product", ProductDescription = "The first product I have", ProductPrice = 100.0, ProductDetailsUrl = "http://www.bing.com/my-first-product", arbitraryText = "random text", arbitraryNumber = 52.4 },
                new MyProduct() { ProductId = "2", ProductTitle = "My Second Product", ProductDescription = "The second product I have", ProductPrice = 10.0, ProductDetailsUrl = "http://www.bing.com/my-second-product", arbitraryText = "another random text", arbitraryNumber = 88.8 }
            };
            await PushData(ingestionClient, indexId, CreateJSON(products));

            Console.WriteLine("Pushing ND-JSON data.");
            var serializedProducts = products.Select(p => CreateJSON(p));
            await PushData(ingestionClient, indexId, string.Join('\n', serializedProducts));

            Console.WriteLine("Pushing CSV data.");
            await PushData(ingestionClient, indexId, CreateCSV(products));

            var getMatches = await GetSearch(searchClient, indexId);
            Console.WriteLine($"found [{getMatches}] products with get.");

            var postMatches = await PostSearch(searchClient, indexId);
            Console.WriteLine($"found [{getMatches}] products with post.");
        }

        private static async Task<long> PostSearch(BingECommerceSearch client, string indexId)
        {
            var query = new RequestQuery()
            {
                Filter = new StringSetCondition()
                {
                    Values = new List<string>() { "1", "2" },
                    Field = "ProductId"
                }
            };

            var request = new ECommerceSearchPostRequest()
            {
                Query = query,
                Items = new RequestItems()
                {
                    Select = new List<string>() { "*" }
                },
                Aggregations = new List<RequestAggregationBase>() { new RequestDiscoverFacets() { Name = "discovered facets" } }
            };

            var response = await client.Search.PostAsync(TENANT_ID, indexId, request);

            return response.Items.TotalEstimatedMatches.Value;
        }

        private static async Task<long> GetSearch(BingECommerceSearch client, string indexId)
        {
            var response = await client.Search.GetAsync(TENANT_ID, indexId, q: "first");

            return response.Items.TotalEstimatedMatches.Value;
        }

        private static string CreateCSV(List<MyProduct> products)
        {
            return string.Join('\n',
                products.Select(p => $"{p.ProductId},{p.ProductTitle},{p.ProductDescription},{p.ProductPrice},{p.ProductDetailsUrl},{p.arbitraryText},{p.arbitraryNumber}"));
        }

        private static async Task<string> PushData(BingECommerceIngestion ingestionClient, string indexId, string content)
        {
            var pushResponse = await ingestionClient.PushDataUpdateAsync(content, TENANT_ID, indexId);

            return pushResponse.UpdateId;
        }

        private static string CreateJSON(object products)
        {
            return JsonConvert.SerializeObject(products);
        }

        private static async Task<string> EnsureIndex(BingECommerceIngestion client)
        {
            Console.WriteLine($"Trying to find the index with name: {INDEX_NAME}.");
            var allIndexes = await client.GetAllIndexesAsync(TENANT_ID);
            foreach(var index in allIndexes.Indexes)
            {
                if (index.Name == INDEX_NAME)
                {
                    return index.Id;
                }
            }

            Console.WriteLine("Index was not found, now creating one.");

            // Prepare the index fields
            var idField = new IndexField()
            {
                Name = "ProductId",
                Type = IndexFieldType.ProductId,
                Filterable = true,
                Retrievable = true
            };
            var titleField = new IndexField()
            {
                Name = "ProductTitle",
                Type = IndexFieldType.Title,
                Filterable = true,
                Searchable = true
            };
            var descriptionField = new IndexField()
            {
                Name = "ProductDescription",
                Type = IndexFieldType.Description,
                Filterable = true,
                Searchable = true
            };
            var priceField = new IndexField()
            {
                Name = "ProductPrice",
                Type = IndexFieldType.Price,
                Filterable = true,
                Sortable = true
            };
            var urlField = new IndexField()
            {
                Name = "ProductDetailsUrl",
                Type = IndexFieldType.Url,
                Retrievable = true
            };
            var arbitraryTextField = new IndexField()
            {
                Name = "arbitraryText",
                Type = IndexFieldType.String,
                Searchable = true
            };
            var arbitraryNumberField = new IndexField()
            {
                Name = "arbitraryNumber",
                Type = IndexFieldType.Number,
                Facetable = true
            };

            // Create the request using the prepared fields
            var newIndexReq = new Index()
            {
                Name = INDEX_NAME,
                Description = "Created with dotnet sdk sample",
                Fields = { idField, titleField, descriptionField, priceField, urlField, arbitraryTextField, arbitraryNumberField }
            };

            // Send the request, create the index
            var createResponse = await client.CreateIndexAsync(TENANT_ID, body: newIndexReq);

            return createResponse.Indexes[0].Id;
        }

        private static BingECommerceSearch CreateSearchClient()
        {
            Console.WriteLine($"Creating the search client with app id : {APPID}");

            return new BingECommerceSearch(new Microsoft.Bing.ECommerce.Search.AppIdCredentials(APPID));
        }

        private static BingECommerceIngestion CreateIngestionClient()
        {
            Console.WriteLine($"Creating the ingestion client with app id : {APPID}");

            return new BingECommerceIngestion(new Microsoft.Bing.ECommerce.Ingestion.AppIdCredentials(APPID));
        }
    }

    internal class MyProduct
    {
        public string ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDetailsUrl { get; set; }
        public string arbitraryText { get; set; }
        public double arbitraryNumber { get; set; }
    }
}
