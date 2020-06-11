using BingCommerceAlerts.Models;
using BingCommerceAlerts.Responses;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BingCommerceAlerts
{
    class Program
    {
        static readonly string AlertOptionsApi = "https://commerce.bing.com/api/devops/v1/{0}/alerts/options";
        static readonly string AlertGroupApi = "https://commerce.bing.com/api/devops/v1/{0}/alerts/group";
        static readonly string AlertCreateOrUpdateApi = "https://commerce.bing.com/api/devops/v1/{0}/indexes/{1}/alerts/{2}";
        static readonly string AlertGetApi = "https://commerce.bing.com/api/devops/v1/{0}/indexes/{1}/alerts/";

        static HttpClient HttpClient;

        /// <summary>
        /// Sample program to onboard to Bing Commerce Alerting Service
        /// Fill in the placeholders with the corresponding information to run the APIs
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var accessToken = "ACCESS_TOKEN";
            var tenantId = new Guid("TENANT_ID");
            var indexId = new Guid("INDEX_ID");
            var emailAddress = "EMAIL_ADDRESS";

            OnboardAlertsAysnc(accessToken, tenantId, indexId, emailAddress).Wait();
        }

        /// <summary>
        /// Simple task to get alert options, create alert group, alert alerts, and get alerts
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="tenantId"></param>
        /// <param name="indexId"></param>
        /// <param name="emaildAddress"></param>
        /// <see cref="https://commerce.bing.com/docs/product-search/#alert-api"/>
        /// <returns></returns>
        static async Task OnboardAlertsAysnc(
            string accessToken, 
            Guid tenantId, 
            Guid indexId, 
            string emaildAddress)
        {
            HttpClient = new HttpClient();

            var alertOptions = await GetAlertOptionsAsync(accessToken, tenantId);

            var alertGroup = await CreateOrUpdateAlertGroupAsync(accessToken, tenantId, Enabled.True, emaildAddress);

            var alertSettings = new AlertSettings
            {
                Enabled = Enabled.True,
                AggregationDurationInMinutes = 5, 
                FrequencyInMinutes = 5, 
                TimeWindowInMinutes = 5, 
                SeverityLevel = Severity.Sev3, 
                AlertOperator = Operator.GreaterThan, 
                AlertThreshold = 0, 
                TriggerBasis = TriggerBasis.Total, 
                TriggerOperator = Operator.GreaterThan, 
                TriggerThreshold = 0
            };

            await CreateOrUpdateAlertAsync(accessToken, tenantId, indexId, alertOptions.AlertOptions.FirstOrDefault().Id, alertSettings);
            await CreateOrUpdateAlertAsync(accessToken, tenantId, indexId, alertOptions.AlertOptions.LastOrDefault().Id, alertSettings);

            var alerts = await GetAlertsAsync(accessToken, tenantId, indexId);
        }

        /// <summary>
        /// Get the list of predefined alerts and their corresponding IDs and descriptions
        /// </summary>
        /// <param name="accessToken">Access token</param>
        /// <param name="tenantId">Tenant Id</param>
        /// <see cref="https://commerce.bing.com/docs/product-search/#get-options"/>
        /// <returns></returns>
        static async Task<AlertOptionsResponse> GetAlertOptionsAsync(
            string accessToken,
            Guid tenantId)
        {
            var alertOptionsUri = string.Format(AlertOptionsApi, tenantId.ToString());

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(alertOptionsUri)
            };

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await HttpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();

            var alertOptions = JsonConvert.DeserializeObject<AlertOptionsResponse>(result);

            return alertOptions;
        }

        /// <summary>
        /// Create or update the tenant's alert group
        /// </summary>
        /// <param name="accessToken">Access token</param>
        /// <param name="tenantId">Tenant Id</param>
        /// <param name="enabled">State of the alert group</param>
        /// <param name="emailAddress">Contact email address</param>
        /// <see cref="https://commerce.bing.com/docs/product-search/#create-update-alert-group"/>
        /// <returns></returns>
        static async Task<AlertGroupResponse> CreateOrUpdateAlertGroupAsync(
            string accessToken,
            Guid tenantId,
            Enabled enabled,
            string emailAddress)
        {
             var alertGroupUri = string.Format(AlertGroupApi, tenantId.ToString());

            string alertGroupSettings = $"{{'Enabled':'{enabled.ToString()}', 'EmailAddress':'{emailAddress}' }}";
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(alertGroupSettings, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Put,
                RequestUri = new Uri(alertGroupUri)
            };

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await HttpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();

            var alertGroup = JsonConvert.DeserializeObject<AlertGroupResponse>(result);

            return alertGroup;
           
        }

        /// <summary>
        /// Create or update an index alert with the specified settings
        /// </summary>
        /// <param name="accessToken">Access token</param>
        /// <param name="tenantId">Tenant Id</param>
        /// <param name="indexId">Index Id</param>
        /// <param name="alertTypeId">Alert option Id</param>
        /// <param name="alertSettings">Alert settings</param>
        /// <see cref="https://commerce.bing.com/docs/product-search/#create-update-alert"/>
        /// <returns></returns>
        static async Task CreateOrUpdateAlertAsync(
            string accessToken,
            Guid tenantId, 
            Guid indexId,
            string alertTypeId, 
            AlertSettings alertSettings)
        {
            var alertUri = string.Format(AlertCreateOrUpdateApi, tenantId.ToString(), indexId.ToString(), alertTypeId);

            var alertSettingsContent = $"{{ " +
                $"'Enabled' : '{alertSettings.Enabled}', " +
                $"'AggregationDurationInMinutes' : '{alertSettings.AggregationDurationInMinutes}', " +
                $"'FrequencyInMinutes': '{alertSettings.FrequencyInMinutes}', " +
                $"'TimeWindowInMinutes': '{alertSettings.TimeWindowInMinutes}', " +
                $"'SeverityLevel': '{alertSettings.SeverityLevel}', " +
                $"'AlertOperator' : '{alertSettings.AlertOperator}', " +
                $"'AlertThreshold' : '{alertSettings.AlertThreshold}', " +
                $"'TriggerBasis': '{alertSettings.TriggerBasis}', " +
                $"'TriggerOperator' : '{alertSettings.TriggerOperator}'," +
                $"'TriggerThreshold' : '{alertSettings.TriggerThreshold}' }}";

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(alertSettingsContent, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Put,
                RequestUri = new Uri(alertUri)
            };

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await HttpClient.SendAsync(request);
        }

        /// <summary>
        /// Gets a list of all the alerts deployed for the given tenantId and indexId
        /// </summary>
        /// <param name="accessToken">Access token</param>
        /// <param name="tenantId">Tenant Id</param>
        /// <param name="indexId">Index Id</param>
        /// <see cref="https://commerce.bing.com/docs/product-search/#get-all-alerts"/>
        /// <returns></returns>
        static async Task<AlertResponse> GetAlertsAsync(
            string accessToken,
            Guid tenantId,
            Guid indexId)
        {
            var alertUri = string.Format(AlertGetApi, tenantId.ToString(), indexId.ToString());
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(alertUri)
            };

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await HttpClient.SendAsync(request);

            string result = await response.Content.ReadAsStringAsync();

            var alerts = JsonConvert.DeserializeObject<AlertResponse>(result);

            return alerts;
        }
    }
}
