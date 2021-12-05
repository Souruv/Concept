using System;
using CF.ConceptBrainService.Application.Entities;
using MediatR;
using System.Collections.Generic;
using AutoMapper;
using CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto;
using CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto.InputDto;
using CF.ConceptBrainService.Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using CF.ConceptBrainService.Application.Services.Interfaces;
using CF.ConceptBrainService.Application.Common.Constants;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Queries
{
    public class GetPressureProtectionByInputFilteredSettingQuery : IRequest<List<BrainPressureProtectionDto>>
    {
        public string? Cithp { get; set; }
        public class GetPressureProtectionByInputFilteredSettingQueryHandler : IRequestHandler<GetPressureProtectionByInputFilteredSettingQuery, List<BrainPressureProtectionDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRuleEngine<BrainPressureProtectionDto, PressureProtectionInputParamDto> _ruleEngine;
            public GetPressureProtectionByInputFilteredSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IRuleEngine<BrainPressureProtectionDto, PressureProtectionInputParamDto> ruleEngine)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _ruleEngine = ruleEngine;
            }
            public async Task<List<BrainPressureProtectionDto>> Handle(GetPressureProtectionByInputFilteredSettingQuery request, CancellationToken cancellationToken)
            {
                PressureProtectionInputParamDto pressureProtectionInputParamDto = new PressureProtectionInputParamDto();
                pressureProtectionInputParamDto.Cithp = float.Parse(request.Cithp);
               

                var pressureProtection = _unitOfWork.BrainPressureProtectionRepository.Filter(x => x.IsDeleted == false).ToList();
                var pressureProtectionDto = _mapper.Map<List<BrainPressureProtection>, List<BrainPressureProtectionDto>>(pressureProtection);
                return _ruleEngine.EvaluateAndGetResult(pressureProtectionInputParamDto, pressureProtectionDto, FormulaFieldName.PRESSUREPROTECTION);
            }
        }
    }
}
