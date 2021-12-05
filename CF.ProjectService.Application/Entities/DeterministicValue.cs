using System;
using System.Collections.Generic;
using System.Text;
using CF.ProjectService.Application.Entities.Base;

namespace CF.ProjectService.Application.Entities
{
    public class DeterministicValue : BaseEntity
    {
        public string Section { get; set; }
        public string SubSection { get; set; }
        public int Score { get; set; }
        public string GuideLines { get; set; }
    }
}
