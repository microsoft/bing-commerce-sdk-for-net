using System;
using System.Collections.Generic;
using System.Text;

namespace BingCommerceAlerts.Responses
{
    public class AlertGroupResponse
    {
        public AlertGroupSettings AlertGroupSettings { get; set; }
    }

    public class AlertGroupSettings
    {
        public string Enabled { get; set; }

        public string EmailAddress { get; set; }
    }
}
