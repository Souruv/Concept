using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Common.Enums
{
    public enum RevisionStatus
    {
        //Draft = 1,
        //Submitted = 2,
        //Returned = 3,
        //TeamAssigned = 4,
        //ReSubmitted = 5,
        //Rejected = 6

        Draft = 1,
        PendingMobilisation = 2,
        Returned = 3,
        PendingConceptDevelopmentAndCostEstimation = 4,
        ReSubmitted = 5,
        PendingCostAnalysis = 6,
        Completed = 7

    }
}
