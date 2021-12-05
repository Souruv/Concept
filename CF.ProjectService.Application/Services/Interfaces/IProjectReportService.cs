using System;
using System.IO;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Services.Interfaces
{
    public interface IProjectReportService
    {
        Task<MemoryStream> CreateCRAReport(decimal baseEstimate, decimal totalRiskScore, string estimateClass, string curve, Guid revisionId, string filePath, string fileType);
    }
}
