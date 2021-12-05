using System;
using System.Collections.Generic;
using System.Text;

namespace CF.AuthService.Application.Entities
{
   public class UserServiceBus
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public string DepartmentName { get; set; }
        public string UserPrincipal { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedByUserId { get; set; }
    }
}
