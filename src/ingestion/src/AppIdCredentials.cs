namespace Microsoft.Bing.ECommerce.Ingestion
{
    using Microsoft.Rest;
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;

    public class AppIdCredentials : ServiceClientCredentials
    {
        private readonly string appId;

        public AppIdCredentials(string appId)
        {
            this.appId = appId ?? throw new ArgumentNullException(nameof(appId));
        }

        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var builder = new UriBuilder(request.RequestUri);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["appid"] = this.appId;
            builder.Query = query.ToString();
            request.RequestUri = builder.Uri;

            return Task.CompletedTask;
        }
    }
}
