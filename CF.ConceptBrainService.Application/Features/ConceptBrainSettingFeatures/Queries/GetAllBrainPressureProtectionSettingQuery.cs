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
    public class GetAllBrainPressureProtectionSettingQuery : IRequest<List<BrainPressureProtectionDto>>
    {
        public class GetAllBrainPressureProtectionSettingQueryHandler : IRequestHandler<GetAllBrainPressureProtectionSettingQuery, List<BrainPressureProtectionDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllBrainPressureProtectionSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<BrainPressureProtectionDto>> Handle(GetAllBrainPressureProtectionSettingQuery request, CancellationToken cancellationToken)
            {
                var pressureProtection = _unitOfWork.BrainPressureProtectionRepository.Filter(x => x.IsDeleted == false).ToList();

                return _mapper.Map<List<BrainPressureProtection>, List<BrainPressureProtectionDto>>(pressureProtection);
            }
        }
    }
}
