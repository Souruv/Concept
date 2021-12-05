using AutoMapper;
using CF.ConceptBrainService.Application.Common.Interfaces;
using CF.ConceptBrainService.Application.Entities;
using CF.ConceptBrainService.Application.Features.PipelineSizeSettingFeatures.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ConceptBrainService.Application.Features.PipelineSizeSettingFeatures.Queries
{
    public class GetFlowlineSizeSettingsQuery : IRequest<List<FlowlineBoundaryDto>>
    {
        public int FlowlineType { get; set; }
        public class GetFlowlineSizeSettingsQueryHandler : IRequestHandler<GetFlowlineSizeSettingsQuery, List<FlowlineBoundaryDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetFlowlineSizeSettingsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<FlowlineBoundaryDto>> Handle(GetFlowlineSizeSettingsQuery query, CancellationToken cancellationToken)
            {
                var flowlineBoundaries = _unitOfWork.FlowlineBoundaryRepository.Filter(x => x.FlowlineType == query.FlowlineType && x.IsDeleted == false).ToList();
                
                    var flowlineBoundaryDtos = _mapper.Map<List<FlowlineBoundary>, List<FlowlineBoundaryDto>>(flowlineBoundaries);
                
                return flowlineBoundaryDtos;
            }
        }
    }
}
