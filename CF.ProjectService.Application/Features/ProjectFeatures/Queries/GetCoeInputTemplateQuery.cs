using AutoMapper;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Queries
{
    public class GetCoeInputTemplateQuery : IRequest<MemoryStream>
    {
       
        public class DownloadCoeInputTemplateQueryHandler : IRequestHandler<GetCoeInputTemplateQuery, MemoryStream>
        {
            private readonly IAzureStorageService _storage;

            private readonly IConfiguration _iConfig;
            public DownloadCoeInputTemplateQueryHandler(IAzureStorageService storage, IConfiguration iConfig)
            {
                _storage = storage;
                _iConfig = iConfig;
            }
            public async Task<MemoryStream> Handle(GetCoeInputTemplateQuery command, CancellationToken cancellationToken)
            {
                return await _storage.GetFile(_iConfig.GetValue<string>("AzureStrorage:ConnectionStrings"),
                    _iConfig.GetValue<string>("AzureStrorage:TemplateContainerName"),
                    _iConfig.GetValue<string>("AzureStrorage:CoeInputTemplateFileName"));
            }

        }
    }
}
