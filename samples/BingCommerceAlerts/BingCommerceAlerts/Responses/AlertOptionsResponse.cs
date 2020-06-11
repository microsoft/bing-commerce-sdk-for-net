using System;
using System.Collections.Generic;
using System.Text;

namespace BingCommerceAlerts.Responses
{
    public class AlertOptionsResponse
    {
        public List<AlertOption> AlertOptions { get; set; }
    }

    public class AlertOption
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
