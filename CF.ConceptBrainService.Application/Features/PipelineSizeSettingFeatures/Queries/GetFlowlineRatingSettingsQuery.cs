using CF.ConceptBrainService.Application.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CF.ConceptBrainService.Application.Common.Interfaces;
using AutoMapper;
using CF.ConceptBrainService.Application.Features.PipelineSizeSettingFeatures.Dto;

namespace CF.ConceptBrainService.Application.Features.PipelineSizeSettingFeatures.Queries
{
    public class GetFlowlineRatingSettingsQuery : IRequest<List<PipelineRatingBoundaryDto>>
    {
        public class GetFlowlineRatingSettingsQueryHandler : IRequestHandler<GetFlowlineRatingSettingsQuery, List<PipelineRatingBoundaryDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetFlowlineRatingSettingsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<PipelineRatingBoundaryDto>> Handle(GetFlowlineRatingSettingsQuery query, CancellationToken cancellationToken)
            {
                var pipelineRating = _unitOfWork.PipelineRatingRepository.Filter(x=>x.IsDeleted==false).ToList();
                if (pipelineRating == null) return null;

                return _mapper.Map<List<PipelineRatingBoundary>, List<PipelineRatingBoundaryDto>>(pipelineRating);
            }
        }
    }
}
