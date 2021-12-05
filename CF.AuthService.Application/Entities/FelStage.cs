
using CF.AuthService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CF.AuthService.Application.Entities
{
    public class FelStage : BaseEntity
    {
        public string Name { get; set; }
        public int SortOrder { get; set; }
    }
}
