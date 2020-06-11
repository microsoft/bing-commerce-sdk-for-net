using BingCommerceAlerts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BingCommerceAlerts.Responses
{
    public class AlertResponse
    {
        public List<Alert> Alerts { get; set; }
    }

    public class Alert
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public AlertSettings Settings { get; set; }
    }

    public class AlertSettings
    {
        public Enabled Enabled { get; set; }

        public int AggregationDurationInMinutes { get; set; }

        public int FrequencyInMinutes { get; set; }

        public int TimeWindowInMinutes { get; set; }

        public Severity SeverityLevel { get; set; }

        public Operator AlertOperator { get; set; }

        public int AlertThreshold { get; set; }

        public TriggerBasis TriggerBasis { get; set; }

        public Operator TriggerOperator { get; set; }

        public int TriggerThreshold { get; set; }
    }
}
