using CF.ProjectService.Application.Common.Mappings;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class RevisionTeamMemberDto : IMapFrom<RevisionTeamMember>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public AppUserDto User { get; set; }

        public bool IsDelete {get;set;}

        public Guid RevisionId { get; set; }
        public ProjectRevision Revision { get; set; }

        public int Type { get; set; }
    }
}
