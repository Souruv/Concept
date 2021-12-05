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
    public class GetAllBrainCondensateHandlingSettingQuery : IRequest<List<BrainCondensateHandlingDto>>
    {
        public class GetAllBrainCondensateHandlingSettingQueryHandler : IRequestHandler<GetAllBrainCondensateHandlingSettingQuery, List<BrainCondensateHandlingDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllBrainCondensateHandlingSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<BrainCondensateHandlingDto>> Handle(GetAllBrainCondensateHandlingSettingQuery request, CancellationToken cancellationToken)
            {
                var condensateHandling = _unitOfWork.BrainCondensateHandlingRepository.Filter(x => x.IsDeleted == false).ToList();

                return _mapper.Map<List<BrainCondensateHandling>, List<BrainCondensateHandlingDto>>(condensateHandling);
            }
        }
    }
}
