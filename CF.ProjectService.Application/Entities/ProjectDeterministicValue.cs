using System;
using System.Collections.Generic;
using System.Text;
using CF.ProjectService.Application.Entities.Base;

namespace CF.ProjectService.Application.Entities
{
    public class ProjectDeterministicValue : BaseEntity
    {
        public int Score { get; set; }
        public string Comments { get; set; }
        public Guid DeterministicValueId { get; set; }
        public Guid ProjectRevisionId { get; set; }
        public DeterministicValue DeterministicValue { get;  set; }
        public ProjectRevision ProjectRevision { get; set; }
    }
}
