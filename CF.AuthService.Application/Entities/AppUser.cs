
using CF.AuthService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CF.AuthService.Application.Entities
{
    public class AppUser : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public Guid? RoleId { get; set; }

        public Role? Role { get; set; }



        public Guid? FelStageId { get; set; }

        public FelStage? FelStage { get; set; }

        public bool IsAdmin{ get; set; }
        public string DepartmentName { get; set; }
        public string Area { get; set; }

        public string UserPrincipal { get; set; }

        //public string Department { get; set; }
        public  string FormattedName
        {
            get
            {
                var formattedName = string.Empty;
                if (Name != null && Name.Contains("("))
                {
                    formattedName = Name.Split("(")[0];
                }
                else
                {
                    formattedName = Name;
                }
                return formattedName;
            }
        }


    }
}
