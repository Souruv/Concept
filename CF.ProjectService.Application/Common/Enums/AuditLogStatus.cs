using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Common.Enums
{
    public enum AuditLogStatus
    {
        Submitted = 1,
        Returned = 2,
        TeamAssigned = 3,
        UpdatedEnvironmental = 4,
        UpdatedInfrastructure = 5,
        ReSubmitted = 6,
        UpdatedWelCost = 7
    }
}
