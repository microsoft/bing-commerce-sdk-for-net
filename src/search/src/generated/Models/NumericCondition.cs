// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bing.Commerce.Search.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Defines an equivalence condition for a numeric field. It can appear in
    /// a filter, a boost, or a filter aggregation.
    /// </summary>
    public partial class NumericCondition : FieldConditionBase
    {
        /// <summary>
        /// Initializes a new instance of the NumericCondition class.
        /// </summary>
        public NumericCondition()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the NumericCondition class.
        /// </summary>
        /// <param name="field">The name of the field.</param>
        /// <param name="value">The value to compare the field against.</param>
        /// <param name="operatorProperty">The comparison operator. Default is
        /// `gt`. Possible values include: 'Eq', 'Ne', 'Gt', 'Lt', 'Ge',
        /// 'Le'</param>
        public NumericCondition(string field = default(string), double? value = default(double?), ComparisonOperator? operatorProperty = default(ComparisonOperator?))
            : base(field)
        {
            Value = value;
            OperatorProperty = operatorProperty;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the value to compare the field against.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public double? Value { get; set; }

        /// <summary>
        /// Gets or sets the comparison operator. Default is `gt`. Possible
        /// values include: 'Eq', 'Ne', 'Gt', 'Lt', 'Ge', 'Le'
        /// </summary>
        [JsonProperty(PropertyName = "operator")]
        public ComparisonOperator? OperatorProperty { get; set; }

    }
}
