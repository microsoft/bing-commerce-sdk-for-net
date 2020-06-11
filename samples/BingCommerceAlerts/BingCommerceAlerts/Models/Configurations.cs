using System;
using System.Collections.Generic;
using System.Text;

namespace BingCommerceAlerts.Models
{
    public enum Enabled
    {
        False = 0,
        True = 1
    }

    public enum Severity
    {
        Sev0 = 0,
        Sev1 = 1, 
        Sev2 = 2, 
        Sev3 = 3,
        Sev4 = 4
    }

    public enum TriggerBasis
    {
        Consecutive = 0, 
        Total = 1
    }

    public enum Operator
    {
        LessThan = 2,
        EqualTo = 1, 
        GreaterThan = 0 
    }
}
