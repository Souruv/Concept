using CF.ProjectService.Application.Common.Extensions;
using CF.ProjectService.Application.Common.Mappings;
using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class EnviromentalDto : IMapFrom<Enviromental>
    {
        public string Region { get; set; }
        public string Location { get; set; }

        //public string Coordinate { get; set; }
        public string CoordinateLat { get; set; }
        public string CoordinateLon { get; set; }

        public decimal? WaterDepthMin { get; set; }
        public decimal? WaterDepthMax { get; set; }
        public decimal? AmbientTemperatureMin { get; set; }
        public string AmbientTemperatureMinUnit { get; set; }

        public decimal? AmbientTemperatureMax { get; set; }
        public string AmbientTemperatureMaxUnit { get; set; }

        public decimal? SeabedTemperatureMin { get; set; }
        public string SeabedTemperatureMinUnit { get; set; }

        public decimal? SeabedTemperatureMax { get; set; }
        public string SeabedTemperatureMaxUnit { get; set; }

        public bool CheckChange(Enviromental evn)
        {
            return Extensions.HasChangedSameProperties<EnviromentalDto, Enviromental>(
               this,
               evn,
               nameof(Enviromental.AmbientTemperatureMin),
               nameof(Enviromental.AmbientTemperatureMinUnit),
               nameof(Enviromental.AmbientTemperatureMax),
               nameof(Enviromental.AmbientTemperatureMaxUnit),
               nameof(Enviromental.SeabedTemperatureMin),
               nameof(Enviromental.SeabedTemperatureMinUnit),
               nameof(Enviromental.SeabedTemperatureMax),
               nameof(Enviromental.SeabedTemperatureMaxUnit)
            );
        }

        public bool ValidationSaveChange()
        {
            if (this.AmbientTemperatureMin > this.AmbientTemperatureMax
                || this.SeabedTemperatureMin > this.SeabedTemperatureMax
            )
            {
                return false;
            }

            return true;
        }
    }
}
