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
    public class GetOilHandlingByInputFilteredSettingQuery : IRequest<List<BrainOilHandlingDto>>
    {
        public string? ProcessingScheme { get; set; }
        public string? EvacuationScheme { get; set; }
        public bool? Desalting { get; set; }
        public bool? H2SRemoval { get; set; }
        public class GetOilHandlingByInputFilteredSettingQueryHandler : IRequestHandler<GetOilHandlingByInputFilteredSettingQuery, List<BrainOilHandlingDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRuleEngine<BrainOilHandlingDto, OilHandlingInputParamDto> _ruleEngine;
            public GetOilHandlingByInputFilteredSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IRuleEngine<BrainOilHandlingDto, OilHandlingInputParamDto> ruleEngine)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _ruleEngine = ruleEngine;
            }

            public async Task<List<BrainOilHandlingDto>> Handle(GetOilHandlingByInputFilteredSettingQuery request, CancellationToken cancellationToken)
            {
                OilHandlingInputParamDto oilHandlingInputParamDto = new OilHandlingInputParamDto();
                oilHandlingInputParamDto.ProcessingScheme = request.ProcessingScheme;
                oilHandlingInputParamDto.EvacuationScheme = request.EvacuationScheme;
                oilHandlingInputParamDto.Desalting =request.Desalting;
                oilHandlingInputParamDto.H2SRemoval =request.H2SRemoval;

                var oilHandling = _unitOfWork.BrainOilHandlingRepository.Filter(x => x.IsDeleted == false).ToList();
                var OilHandlingDto = _mapper.Map<List<BrainOilHandling>, List<BrainOilHandlingDto>>(oilHandling);
                return _ruleEngine.EvaluateAndGetResult(oilHandlingInputParamDto, OilHandlingDto, FormulaFieldName.OILHANDLING);
            }
        }
    }
}
