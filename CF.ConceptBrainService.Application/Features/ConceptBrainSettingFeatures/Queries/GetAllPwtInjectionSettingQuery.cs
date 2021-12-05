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
    public class GetAllPwtInjectionSettingQuery : IRequest<List<BrainPWTInjectionDto>>
    {
        public class GetAllPwtInjectionSettingQueryHandler : IRequestHandler<GetAllPwtInjectionSettingQuery, List<BrainPWTInjectionDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllPwtInjectionSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<BrainPWTInjectionDto>> Handle(GetAllPwtInjectionSettingQuery request, CancellationToken cancellationToken)
            {
                var pwtInjection = _unitOfWork.BrainPWTInjectionRepository.Filter(x => x.IsDeleted == false).ToList();

                return _mapper.Map<List<BrainPWTInjection>, List<BrainPWTInjectionDto>>(pwtInjection);
            }
        }
    }
}
