// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.ECommerce.Ingestion.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class ResponseIndexStatus
    {
        /// <summary>
        /// Initializes a new instance of the ResponseIndexStatus class.
        /// </summary>
        public ResponseIndexStatus()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ResponseIndexStatus class.
        /// </summary>
        /// <param name="region">Possible values include: 'Unknown',
        /// 'EastAsia', 'EastUS2', 'NorthCentralUS', 'NorthEurope', 'WestUS2',
        /// 'SoutheastAsia', 'AustraliaEast', 'AustraliaSoutheast',
        /// 'AustraliaCentral', 'AustraliaCentral2', 'BrazilSouth',
        /// 'CanadaCentral', 'CanadaEast', 'ChinaNorth', 'ChinaEast',
        /// 'ChinaNorth2', 'ChinaEast2', 'WestEurope', 'FranceCentral',
        /// 'FranceSouth', 'GermanyCentral', 'GermanyNortheast',
        /// 'CentralIndia', 'WestIndia', 'SouthIndia', 'JapanEast',
        /// 'JapanWest', 'KoreaCentral', 'KoreaSouth', 'EastUS', 'WestUS',
        /// 'CentralUS', 'SouthCentralUS', 'WestCentralUS', 'SouthAfricaNorth',
        /// 'SouthAfricaWest', 'UKWest', 'UKSouth', 'UAENorth',
        /// 'UAECentral'</param>
        /// <param name="provisioningState">Possible values include: 'Unknown',
        /// 'NotStarted', 'Provisioning', 'Deprovisioning', 'Succeeded',
        /// 'Failed'</param>
        public ResponseIndexStatus(Region? region = default(Region?), string provisioningState = default(string), double? provisioningPercentage = default(double?))
        {
            Region = region;
            ProvisioningState = provisioningState;
            ProvisioningPercentage = provisioningPercentage;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets possible values include: 'Unknown', 'EastAsia',
        /// 'EastUS2', 'NorthCentralUS', 'NorthEurope', 'WestUS2',
        /// 'SoutheastAsia', 'AustraliaEast', 'AustraliaSoutheast',
        /// 'AustraliaCentral', 'AustraliaCentral2', 'BrazilSouth',
        /// 'CanadaCentral', 'CanadaEast', 'ChinaNorth', 'ChinaEast',
        /// 'ChinaNorth2', 'ChinaEast2', 'WestEurope', 'FranceCentral',
        /// 'FranceSouth', 'GermanyCentral', 'GermanyNortheast',
        /// 'CentralIndia', 'WestIndia', 'SouthIndia', 'JapanEast',
        /// 'JapanWest', 'KoreaCentral', 'KoreaSouth', 'EastUS', 'WestUS',
        /// 'CentralUS', 'SouthCentralUS', 'WestCentralUS', 'SouthAfricaNorth',
        /// 'SouthAfricaWest', 'UKWest', 'UKSouth', 'UAENorth', 'UAECentral'
        /// </summary>
        [JsonProperty(PropertyName = "region")]
        public Region? Region { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Unknown', 'NotStarted',
        /// 'Provisioning', 'Deprovisioning', 'Succeeded', 'Failed'
        /// </summary>
        [JsonProperty(PropertyName = "provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "provisioningPercentage")]
        public double? ProvisioningPercentage { get; set; }

    }
}
