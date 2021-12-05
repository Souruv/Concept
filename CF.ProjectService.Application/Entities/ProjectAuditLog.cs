using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Entities
{
    public class ProjectAuditLog : BaseEntity
    {
        public AuditLogStatus AuditLogStatus { get; set; }
        public Guid RevisionId { get; set; }
        public DateTime ActionOn { get; set; }
        public Guid ActionByUserId { get; set; }
        public string RespondedRemarks { get; set; }
        public string Message { get; set; }

        public ProjectRevision ProjectRevision { get; set; }
        public AppUser ActionByUser { get; set; }
    }

    public class AuditLogMessage
    {
        //When COE submitted project to TM
        public const string COE_SubmitProject = "Kickstarted this project!";

        //When TM assigned project team
        public const string TM_AssignTeam = "Project team assigned!";

        //When TM returned project to COE
        public const string TM_ReturnProject = "Project has been returned!";

        //When TM/FEE TP/FEE updated value in Environmental and Infrastructure Data tabs
        public const string UpdateEnviromental = "Environmental Data has been updated!";
        public const string UpdateInfrastructureData = "Infrastructure Data has been updated!";

        //When FEE has completed concept bookmarking and cost estimating
        public const string FEE_Completed = "Concept developed, and cost estimated!";

        //When CE has completed cost calibration
        public const string CE_Completed = "Costs have been calibrated!";

        //When project already in Costimator process and FEE updated concept bookmark
        //When CE already completed cost calibration and FEE updated concept bookmark
        public const string FEE_Updated = "FEE has updated the concept bookmark!";

        //When COE save change Well Cost
        public const string UpdateWellCost = "Well Cost Input has been updated!";

        // Optional
        public const string COE_Resubmitted = "Project has been resubmitted!";
    }
}
