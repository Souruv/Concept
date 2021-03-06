using CF.ConceptBrainService.Application.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto;
using CF.ConceptBrainService.Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Queries
{
    public class GetAllBrainDrillingAndWorkoverStrategySettingQuery : IRequest<List<BrainDrillingAndWorkoverStrategyDto>>
    {
        public class GetAllBrainDrillingAndWorkoverStrategySettingQueryHandler : IRequestHandler<GetAllBrainDrillingAndWorkoverStrategySettingQuery, List<BrainDrillingAndWorkoverStrategyDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllBrainDrillingAndWorkoverStrategySettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<BrainDrillingAndWorkoverStrategyDto>> Handle(GetAllBrainDrillingAndWorkoverStrategySettingQuery request, CancellationToken cancellationToken)
            {
                var drillingAndWorkoverStrategy = _unitOfWork.BrainDrillingAndWorkoverStrategyRepository.Filter(x => x.IsDeleted == false).ToList();

                return _mapper.Map<List<BrainDrillingAndWorkoverStrategy>, List<BrainDrillingAndWorkoverStrategyDto>>(drillingAndWorkoverStrategy);
            }
        }
    }
}
