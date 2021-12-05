using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class ProjectRevisionPostDto
    {
       public Guid Id { get; set; }
        public int RevisionNo { get; set; }
        public Guid ProjectStageId { get; set; }
        public int RevisionStatus { get; set; }
        public DateTime? ExpecedFirstResponseBy { get; set; }
        public string? Remarks { get; set; }
        public string? ServiecRequestNUmber { get; set; }

    }
}
