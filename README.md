
# Bing for Commerce .NET SDK

## Overview

This contains the generated SDKs that can help developers integrate with Bing for Commerce platform, both on the Search and Ingestion sides. The repository also contains unit tests and samples that can show you quick examples for how to use the SDKs.

For more details about the project, please refer to the [Bing for Commerce main repository](https://github.com/microsoft/bing-commerce), or [Bing for Commerce API Documentation](https://commerce.bing.com/docs/product-search/).

## Getting Started

### Prerequisites

* [.NET Core SDK version 2.1 or later](https://dotnet.microsoft.com/download/dotnet-core).
* [Bing for Commerce Account](https://commerce.bing.com/).

### Install the package

Coming soon.

### Authenticate the client

Bing for Commerce APIs use Bearer Tokens for authentication. You can use the [Bing for Commerce Portal Documentation](https://commerce.bing.com/docs/Portal%20Documentation/#manage-keys-and-tokens) for help creating one.

## Usage

### Required namespaces

You will need to either add `using` statements for the following namespaces, or fully qualify each reference to the Bing for Commerce SDK when you're trying to use them.

#### Ingestion namespaces:
~~~csharp
using Microsoft.Bing.Commerce.Ingestion;
using Microsoft.Bing.Commerce.Ingestion.Models;
~~~

#### Search namespaces:
~~~csharp
using Microsoft.Bing.Commerce.Search;
using Microsoft.Bing.Commerce.Search.Models;
~~~

### Create the SDK client object

Creating the SDK client object SDK are the first step you need to do in order to call the Bing for Commerce services APis. You will need first to get an access token with the proper access scope as described [here](https://commerce.bing.com/docs/Portal%20Documentation/#manage-keys-and-tokens).

#### Create the Ingestion SDK Client
~~~csharp
private static BingCommerceIngestion CreateSearchClient(string accessToken)
{
    return new BingCommerceIngestion(new Microsoft.Rest.TokenCredentials(accessToken));
}
~~~

#### Create the Search SDK Client
~~~csharp
private static BingCommerceSearch CreateSearchClient(string accessToken)
{
    return new BingCommerceSearch(new Microsoft.Rest.TokenCredentials(accessToken));
}
~~~

### Manage your Index

You can create and manage you index using the Bing for Commerce portal. However, you could also use the SDK to manage your indexes.

#### Create an index
~~~csharp
private async Task<ResponseIndex> CreateIndex(BingCommerceIngestion ingestionclient, string tenantId, string indexName)
{
    // Prepare the index fields
    var idField = new IndexField()
    {
        Name = "ProductId",
        Type = IndexFieldType.ProductId, // Exactly one Product Id field is required while creating an index.
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

    // Create the request using the prepared fields
    var newIndexReq = new Index()
    {
        Name = indexName,
        Description = "My sample index",
        Fields = { idField, titleField, descriptionField }
    };

    // Send the request, create the index
    var createResponse = await ingestionClient.CreateIndexAsync(tenantId, body: newIndexReq);

    return createResponse.Indexes[0];
}
~~~

#### Get all indexes
~~~csharp
var allIndexes = await ingestionClient.GetAllIndexesAsync(tenantId);
~~~

#### Get an index by Id
~~~csharp
var myIndex = ingestionClient.GetIndexAsync(tenantId, indexId);
~~~

### Pushing data

The APIs to push data to Bing for Commerce are asynchronous, where the service / SDK contains two separate APIs to serve this, one for the push itself, and another to track down the status.

The content that you will be pushing to your index catalog needs to match the index configuration that you have the index created with, and it can be in any of the following formats:
* JSon Array.
* ND-JSon (New-Line Delimited JSon).
* CSV.
* TSV.

Please note however that if you have a transformation config added to your index, the format of the pushed data needs to match that of what your transformation script is expecting.

#### Push Data
~~~csharp
private async Task<String> PushData(BingCommerceIngestion ingestionClient, string tenantId, string indexId, string content)
{
    var pushResponse = await ingestionClient.PushDataUpdateAsync(content, tenantId, indexId);

    return pushResponse.UpdateId;
}
~~~

#### Push Data Status
~~~csharp
private async Task<String> PushDataStatus(BingCommerceIngestion ingestionClient, string tenantId, string indexId, string pushDataUpdateId)
{
    var pushResponse = await ingestionClient.PushDataStatusAsync(tenantId, indexId, pushDataUpdateId);

    // returns the overall status for the push call.
    //
    // You can get the status for each record being updated by accessing status.Records list.
    return pushResponse.Status;
}
~~~

### Search Query

You can use the Search SDK to do queries on your Bing for Commerce indexes given that you have an access token with the proper scope. 

#### Simple Search Query
There are few cusomizations that you can still apply to the simple search query api by providing different values for different API arguments (like: market, language, field select, order configuration, pagination, facet discovery and query alteration toggle).
~~~csharp
private async Task<ResponseItemsBase> SimpleSearch(BingCommerceSearch searchClient, string tenantId, string indexId, string queryTerm) {

    var response = await searchClient.Search.GetAsync(queryTerm, tenandId, indexId);

    return response.Items;
}
~~~

#### Advanced Search Query
You can do a lot more customization (like filering, boosting, ...etc) to your advanced search query by providing a detailed search query description for how you want your results to be.
~~~csharp
private async Task<ResponseItemsBase> AdvancedSearch(BingCommerceSearch searchClient, string tenantId, string indexId) {

    // Prepare the Search request.
    var request = new CommerceSearchPostRequest()
    {
        Query = new RequestQuery() 
        { 
            MatchAll = "Product",
            Filter = new StringSetCondition()
            {
                Values = new List<string>() { "1", "2" },
                Field = "ProductId"
            }
        },
        Items = new RequestItems()
        {
            Select = new[] { "_itemId", "name" }
        },
        Aggregations = new List<RequestAggregationBase>() 
        { 
            new RequestDiscoverFacets() 
            {
                Name = "discovered facets"
            } 
        }
    };

    // Send the search request.
    var response = await searchClient.Search.PostAsync(request, tenantId, indexId);

    return response.Items;
}
~~~

### Transformation Script Management
You can upload a custom configuration that you might need applied to the data you push to your index automatically. Please refer to the [Bing for Commerce docs](https://commerce.bing.com/docs/product-search/#transformation-script-management-api) for more details about how to create a valid transformation config.

#### Create or Update the transformation config
~~~csharp
string myScript = GetMyTransformationScript();
TransformationConfigResponse createScriptResponse = await ingestionClient.CreateOrUpdateTransformationConfigAsync(myScript, tenantId, indexId);
~~~

#### Get the existing tranformation config
~~~csharp
// Note that the getTransformationConfig will throw a 400 Bad Request if your index doesn't have a transformation config.
TransformationConfigResponse readScriptResponse = await ingestionClient.GetTransformationConfigAsync(tenantId, indexId);
string myScript = readScriptResponse.Value;
~~~

#### Delete the transformation config
~~~csharp
TransformationConfigResponse deleteScriptResponse = await ingestionClient.DeleteTransformationConfigAsync(tenantId, indexId);
~~~

### Transformation Script Tryout
Before you associate a transformation script to your index, you can use the transformation tryout apis to make sure that your index works with your data and the SDK before actually associating it to your index.

#### Upload a tranformation config tryout
~~~csharp
private async Task<string> UploadTransformationTryout(BingCommerceIngestion ingestionClient, string script)
{
    var createScriptResponse = await ingestionClient.UploadTryOutConfigAsync(script);

    return createScriptResponse.TryOutId;
}
~~~

#### Test the transformation config tryout
~~~csharp
private async Task<bool> ExecuteTransformationTryout(BingCommerceIngestion ingestionClient, string data, string tryoutId)
{
    var executeResponse = await ingestionClient.ExecuteTryOutConfigAsync(data, tryoutId);

    return executeResponse.Status == "Succeeded";
}
~~~

## Samples

Please take a look at the [sample](./samples/) for a quick example for how to use the SDK in order to manage your indexes, push data to your index catalog and perform search queries on your data.


## Contributing

For details on contributing to this repository, see the [contributing guide](./CONTRIBUTING.md).

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
