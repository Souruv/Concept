
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.AuthService.Application.Features.UserFeatures.Dto
{
    public class CreateUsersResponseDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }        
        public bool IsExist { get; set; }
    }
}
