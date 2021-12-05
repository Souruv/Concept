using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Entities.Base;
using Stateless;

namespace CF.ProjectService.Application.Entities
{
    public enum ProjectTrigger
    {
        Draft,
        Submit,
        Approve,
        AssignTeam,
        Reject,
        Return,
        SaveWell
    };
    public class ProjectRevision : BaseEntity
    {

        public Guid ProjectId { get; set; }
        public int RevisionNo { get; set; }
        public Guid ProjectStageId { get; set; }
        public int RevisionStatus { get; set; }
        public decimal? TargetUnitTechnicalCost { get; set; }
        public string? UtcCountry { get; set; }
        public DateTime? ExpecedFirstResponseBy { get; set; }
        public string? Remarks { get; set; }
        public string? ServiecRequestNUmber { get; set; }

        public Guid? SubmittedByUserId { get; set; }
        public DateTime? SubmittedOn { get; set; }

        // public Guid? EnviromentalId {get;set; }
        public Guid? RespondedByUserId { get; set; }
        public DateTime? RespondedOn { get; set; }
        public AppUser RespondedByUser { get; set; }
        public string? RespondedRemarks { get; set; }

        public bool IsAcknowledged { get; set; }

        public Enviromental Enviromental { get; set; }
        public FieldsData FieldsData { get; set; }

        public InfrastructureData InfrastructureData { get; set; }
        public Project Project { get; set; }
        public IList<DrillingCenterData> DrillingCenter { get; set; }
        public IList<WellCost> WellCosts { get; set; }
        public AppUser SubmittedByUser { get; set; }
        public ProjectStage ProjectStage { get; set; }
        public IList<RevisionTeamMember> RevisionTeamMembers { get; private set; } = new List<RevisionTeamMember>();

        StateMachine<int, ProjectTrigger> _machine;
        int _state = (int)Common.Enums.RevisionStatus.Draft;
        public void Submit()
        {
            this.ConfigureWorkflow();

            if (!_machine.PermittedTriggers.Contains(ProjectTrigger.Submit))
            {
                throw new Exception("submit not permitted");
            }

            _machine.Fire(ProjectTrigger.Submit);

            //RevisionStatus = (int)Common.Enums.RevisionStatus.Submitted;
            RevisionStatus = (int)_machine.State;
            SubmittedOn = DateTime.Now;


        }
        public void AssignTeam()
        {
            this.ConfigureWorkflow();
            if (!_machine.PermittedTriggers.Contains(ProjectTrigger.AssignTeam))
            {
                throw new Exception("assgin team not permitted");
            }

            _machine.Fire(ProjectTrigger.AssignTeam);
            RevisionStatus = (int)_machine.State;
            RespondedOn = DateTime.Now;
        }

        /// <summary>
        /// ProjectRevision object needs to include ProjectUsers object to be able to call this method exactly
        /// </summary>
        public void SaveWell()
        {
            this.ConfigureWorkflow();
            if (!_machine.PermittedTriggers.Contains(ProjectTrigger.SaveWell))
            {
                throw new Exception("Save well not permitted");
            }

            _machine.Fire(ProjectTrigger.SaveWell);
            RevisionStatus = (int)_machine.State;
            RespondedOn = DateTime.Now;
        }

        public void Approve()
        {
            this.ConfigureWorkflow();
            if (!_machine.PermittedTriggers.Contains(ProjectTrigger.Approve))
            {
                throw new Exception("approve not permitted");
            }

            _machine.Fire(ProjectTrigger.Approve);
            RevisionStatus = (int)_machine.State;
            RespondedOn = DateTime.Now;
        }

        public void Reject()
        {
            this.ConfigureWorkflow();
            if (!_machine.PermittedTriggers.Contains(ProjectTrigger.Reject))
            {
                throw new Exception("reject not permitted");
            }

            _machine.Fire(ProjectTrigger.Reject);
            RevisionStatus = (int)_machine.State;
            RespondedOn = DateTime.Now;

        }

        public void Return()
        {
            this.ConfigureWorkflow();
            if (!_machine.PermittedTriggers.Contains(ProjectTrigger.Return))
            {
                throw new Exception("return not permitted");
            }

            _machine.Fire(ProjectTrigger.Return);
            RevisionStatus = (int)_machine.State;
            RespondedOn = DateTime.Now;
        }

        private void ConfigureWorkflow()
        {
            _machine = new StateMachine<int, ProjectTrigger>(this.RevisionStatus);

            _machine.Configure((int)Common.Enums.RevisionStatus.Draft)
                .Permit(ProjectTrigger.Submit, (int)Common.Enums.RevisionStatus.PendingMobilisation);

            _machine.Configure((int)Common.Enums.RevisionStatus.PendingMobilisation)
                .PermitIf(ProjectTrigger.AssignTeam, (int)Common.Enums.RevisionStatus.PendingConceptDevelopmentAndCostEstimation, () => this.WellCosts != null && this.WellCosts.Any())
                .PermitReentryIf(ProjectTrigger.AssignTeam, () => this.WellCosts != null && !this.WellCosts.Any())
                .PermitIf(ProjectTrigger.SaveWell, (int)Common.Enums.RevisionStatus.PendingConceptDevelopmentAndCostEstimation, () => CheckTeamAssignAlready())
                .PermitReentryIf(ProjectTrigger.SaveWell, () => !CheckTeamAssignAlready())
                .PermitIf(ProjectTrigger.Return, (int)Common.Enums.RevisionStatus.Returned)
                .PermitReentryIf(ProjectTrigger.Submit);

            _machine.Configure((int)Common.Enums.RevisionStatus.Returned)
                .PermitReentry(ProjectTrigger.SaveWell)
                .Permit(ProjectTrigger.Submit, (int)Common.Enums.RevisionStatus.ReSubmitted);

            /*_machine.Configure((int)Common.Enums.RevisionStatus.PendingConceptDevelopmentAndCostEstimation)
               .Permit(Trigger.Submit, (int)Common.Enums.RevisionStatus.PendingMobilisation)
               .PermitReentry(Trigger.AssignTeam);*/

            _machine.Configure((int)Common.Enums.RevisionStatus.ReSubmitted)
                .PermitReentry(ProjectTrigger.Submit)
                .PermitIf(ProjectTrigger.AssignTeam, (int)Common.Enums.RevisionStatus.PendingConceptDevelopmentAndCostEstimation, () => this.WellCosts != null && this.WellCosts.Any())
                .PermitReentryIf(ProjectTrigger.AssignTeam, () => this.WellCosts != null && !this.WellCosts.Any())
                .PermitIf(ProjectTrigger.SaveWell, (int)Common.Enums.RevisionStatus.PendingConceptDevelopmentAndCostEstimation, () => CheckTeamAssignAlready())
                .PermitReentryIf(ProjectTrigger.SaveWell, () => !CheckTeamAssignAlready())
                .Permit(ProjectTrigger.Return, (int)Common.Enums.RevisionStatus.Returned);

            _machine.Configure((int)Common.Enums.RevisionStatus.PendingCostAnalysis)
                .Permit(ProjectTrigger.Submit, (int)Common.Enums.RevisionStatus.PendingMobilisation);
        }

        private bool CheckTeamAssignAlready()
        {
            return this.Project.ProjectUsers.Any(x => !x.IsDeleted
                && (x.Type == (int)ProjectUserType.FETechnicalProfessional
                    || x.Type == (int)ProjectUserType.FEEngineer
                    || x.Type == (int)ProjectUserType.CETechnicalProfessional
                    || x.Type == (int)ProjectUserType.CEEngineer
                ));
        }
    }
}
