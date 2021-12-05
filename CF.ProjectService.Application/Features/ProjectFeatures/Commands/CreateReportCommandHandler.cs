using AutoMapper;
using CF.ProjectService.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Commands
{
    public class CreateReportCommand : IRequest<MemoryStream>
    {
        public decimal BaseEstimate { get; set; }
        public decimal TotalRiskScore { get; set; }
        public string EstimateClass { get; set; }
        public string Curve { get; set; }
        public Guid RevisionId { get; set; }
        public string Type { get; set; }


        public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, MemoryStream>
        {
            private readonly IMapper _mapper;
            IProjectReportService _projectReportService;
            private readonly IHostingEnvironment _env;

            public CreateReportCommandHandler(IMapper mapper, IProjectReportService projectReportService, IHostingEnvironment env)
            {
                _mapper = mapper;
                _projectReportService = projectReportService;
                _env = env;
            }
            public async Task<MemoryStream> Handle(CreateReportCommand command, CancellationToken cancellationToken)
            {
                Spire.License.LicenseProvider.SetLicenseFileName(_env.WebRootPath + "\\license.elic.xml");

                string filePath = _env.WebRootPath + "\\Templates\\CRA Report Template.xlsx";

                var memoryStream = await _projectReportService.CreateCRAReport(command.BaseEstimate, command.TotalRiskScore, command.EstimateClass, command.Curve, command.RevisionId, filePath, command.Type);
                return memoryStream;
            }

        }
    }
}
