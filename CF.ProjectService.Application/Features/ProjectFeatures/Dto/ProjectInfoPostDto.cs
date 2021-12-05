using CF.ProjectService.Application.Features.UserFeatures.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class ProjectInfoPostDto
    {
        public string File { get; set; }

        public decimal? TargetUnitTechnicalCost { get; set; }
        public string? Utc { get; set; }
        public DateTime? ExpectedRespondDate { get; set; }



        public string Remarks { get; set; }

        public string ServiceRequest { get; set; }
        public string Name { get; set; }

        public string ProjectType { get; set; }

        public Guid Stage { get; set; }

        public IList<Guid> Nature { get; set; }
        public string Business { get; set; }
        public string Area { get; set; }
        public string Asset { get; set; }

        public AppUserDto[]? ProjectManagerList { get; set; }

        public AppUserDto[]? ProductionTechnologistList { get; set; }

        public AppUserDto[]? GeologistList { get; set; }

        public AppUserDto[]? GeoPhysicistList { get; set; }

        public AppUserDto[]? ReservoirEngineerList { get; set; }

        public AppUserDto[]? PetroPhysicistList { get; set; }

        public AppUserDto[]? WellsEngineerList { get; set; }

        public AppUserDto[]? CompletionEngineerList { get; set; }
    }
}
