﻿using CF.ProjectService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Entities
{
    public class EvacuationOptionProducedWater : BaseEvacuationOptions
    {
        public decimal? OilInWater { get; set; }
    }
}
