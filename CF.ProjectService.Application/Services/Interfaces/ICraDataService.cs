using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Services.Interfaces
{
    public interface ICraDataService
    {
        public Task<CraReportDto> GetCraData(decimal baseEstimate, decimal totalRiskScore, string estimateClass, string curve);



    }
}
