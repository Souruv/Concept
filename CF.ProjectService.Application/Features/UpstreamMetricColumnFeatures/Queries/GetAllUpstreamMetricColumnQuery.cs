using CF.ProjectService.Application.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CF.ProjectService.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CF.ProjectService.Application.Features.UpstreamMetricColumnFeatures.Dto;

namespace CF.ProjectService.Application.Features.UpstreamMetricColumnFeatures.Queries
{
    public class GetAllUpstreamMetricColumnQuery : IRequest<IEnumerable<UpstreamMetricColumnDto>>
    {

        public class GetAllUpstreamMetricColumnQueryHandler : IRequestHandler<GetAllUpstreamMetricColumnQuery, IEnumerable<UpstreamMetricColumnDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllUpstreamMetricColumnQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<IEnumerable<UpstreamMetricColumnDto>> Handle(GetAllUpstreamMetricColumnQuery query, CancellationToken cancellationToken)
            {
                var list =  _unitOfWork.UpstreamMetricColumnRepository.Filter(x=>!x.IsDeleted);
                if (list == null)
                {
                    return null;
                }
                
                return await list.ProjectTo<UpstreamMetricColumnDto>(_mapper.ConfigurationProvider).ToListAsync();
            }
        }
    }
}
