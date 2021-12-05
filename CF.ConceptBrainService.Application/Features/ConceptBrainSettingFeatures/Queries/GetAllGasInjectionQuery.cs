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
    public class GetAllGasInjectionQuery : IRequest<List<BrainGasInjectionDto>>
    {
        public class GetAllGasInjectionQueryHandler : IRequestHandler<GetAllGasInjectionQuery, List<BrainGasInjectionDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllGasInjectionQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<BrainGasInjectionDto>> Handle(GetAllGasInjectionQuery request, CancellationToken cancellationToken)
            {
                var gasInjection = _unitOfWork.BrainGasInjectionRepository.Filter(x => x.IsDeleted == false).ToList();

                return _mapper.Map<List<BrainGasInjection>, List<BrainGasInjectionDto>>(gasInjection);
            }
        }
    }
}
