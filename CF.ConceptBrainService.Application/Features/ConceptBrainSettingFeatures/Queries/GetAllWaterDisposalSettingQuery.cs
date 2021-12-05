using CF.ConceptBrainService.Application.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using AutoMapper;
using CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto;
using CF.ConceptBrainService.Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Queries
{
    public class GetAllWaterDisposalSettingQuery : IRequest<List<BrainWaterDisposalDto>>
    {
        public class GetAllWaterDisposalQueryHanlder : IRequestHandler<GetAllWaterDisposalSettingQuery, List<BrainWaterDisposalDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllWaterDisposalQueryHanlder(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<BrainWaterDisposalDto>> Handle(GetAllWaterDisposalSettingQuery request, CancellationToken cancellationToken)
            {
                var waterDisposal = _unitOfWork.BrainWaterDisposalRepository.Filter(x => x.IsDeleted == false).ToList();

                return _mapper.Map<List<BrainWaterDisposal>, List<BrainWaterDisposalDto>>(waterDisposal);
            }
        }
    }
}
