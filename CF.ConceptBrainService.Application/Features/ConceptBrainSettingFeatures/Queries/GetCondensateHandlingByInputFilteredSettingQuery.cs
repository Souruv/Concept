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
    public class GetCondensateHandlingByInputFilteredSettingQuery : IRequest<List<BrainCondensateHandlingDto>>
    {
        public string? ProcessingScheme { get; set; }
        public string? EvacuationScheme { get; set; }
        public bool? CondensateExport { get; set; }
        public bool? HcDewPoint { get; set; }
        public class GetCondensateHandlingByInputFilteredSettingQueryHandler : IRequestHandler<GetCondensateHandlingByInputFilteredSettingQuery, List<BrainCondensateHandlingDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRuleEngine<BrainCondensateHandlingDto, CondensateHandlingInputParamDto> _ruleEngine;
            public GetCondensateHandlingByInputFilteredSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IRuleEngine<BrainCondensateHandlingDto, CondensateHandlingInputParamDto> ruleEngine)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _ruleEngine = ruleEngine;
            }
            public async Task<List<BrainCondensateHandlingDto>> Handle(GetCondensateHandlingByInputFilteredSettingQuery request, CancellationToken cancellationToken)
            {
                CondensateHandlingInputParamDto condensateHandlingInputParamDto = new CondensateHandlingInputParamDto();
                condensateHandlingInputParamDto.ProcessingScheme = request.ProcessingScheme;
                condensateHandlingInputParamDto.EvacuationScheme = request.EvacuationScheme;
                condensateHandlingInputParamDto.CondensateExport = request.CondensateExport;
                condensateHandlingInputParamDto.HcDewPoint = request.HcDewPoint;

                var condensateHandling = _unitOfWork.BrainCondensateHandlingRepository.Filter(x => x.IsDeleted == false).ToList();
                var condensateHandlingDto = _mapper.Map<List<BrainCondensateHandling>, List<BrainCondensateHandlingDto>>(condensateHandling);
                return _ruleEngine.EvaluateAndGetResult(condensateHandlingInputParamDto, condensateHandlingDto, FormulaFieldName.GASCONDENSATEHANDLING);
            }
        }
    }
}
