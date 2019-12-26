// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.ECommerce.Search.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class StringSetCondition : SetConditionBase
    {
        /// <summary>
        /// Initializes a new instance of the StringSetCondition class.
        /// </summary>
        public StringSetCondition()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the StringSetCondition class.
        /// </summary>
        /// <param name="operatorProperty">Possible values include: 'In',
        /// 'NotIn'</param>
        public StringSetCondition(string field = default(string), SetOperator? operatorProperty = default(SetOperator?), IList<string> values = default(IList<string>))
            : base(field, operatorProperty)
        {
            Values = values;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "values")]
        public IList<string> Values { get; set; }

    }
}
