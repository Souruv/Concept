using System;
using System.Collections.Generic;
using System.Text;

namespace CF.AuthService.Application.Features.UserFeatures.Dto
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid? FelStageId { get; set; }
        public string Area { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
