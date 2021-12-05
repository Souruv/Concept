using CF.CostBrainService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CF.CostBrainService.Application.Entities
{
    public class AppUser : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public int Role { get; set; }

        public string DepartmentName { get; set; }

        public string UserPrincipal { get; set; }

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
