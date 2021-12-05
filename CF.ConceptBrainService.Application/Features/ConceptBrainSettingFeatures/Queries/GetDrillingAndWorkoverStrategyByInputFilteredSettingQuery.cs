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
    public class GetDrillingAndWorkoverStrategyByInputFilteredSettingQuery : IRequest<List<BrainDrillingAndWorkoverStrategyDto>>
    {
        public string? TreeType { get; set; }
        public int? WaterDepth { get; set; }
        public class GetDrillingAndWorkoverStrategyByInputFilteredSettingQueryHandler : IRequestHandler<GetDrillingAndWorkoverStrategyByInputFilteredSettingQuery, List<BrainDrillingAndWorkoverStrategyDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRuleEngine<BrainDrillingAndWorkoverStrategyDto, DrillingAndWorkoverStrategyInputParamDto> _ruleEngine;
            public GetDrillingAndWorkoverStrategyByInputFilteredSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IRuleEngine<BrainDrillingAndWorkoverStrategyDto, DrillingAndWorkoverStrategyInputParamDto> ruleEngine)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _ruleEngine = ruleEngine;
            }
            public async Task<List<BrainDrillingAndWorkoverStrategyDto>> Handle(GetDrillingAndWorkoverStrategyByInputFilteredSettingQuery request, CancellationToken cancellationToken)
            {
                DrillingAndWorkoverStrategyInputParamDto drillingAndWorkoverStrategyInputParamDto = new DrillingAndWorkoverStrategyInputParamDto();
                drillingAndWorkoverStrategyInputParamDto.TreeType = request.TreeType;
                drillingAndWorkoverStrategyInputParamDto.WaterDepth = request.WaterDepth;

                var drillingAndWorkoverStrategy = _unitOfWork.BrainDrillingAndWorkoverStrategyRepository.Filter(x => x.IsDeleted == false).ToList();
                var drillingAndWorkoverStrategyDto = _mapper.Map<List<BrainDrillingAndWorkoverStrategy>, List<BrainDrillingAndWorkoverStrategyDto>>(drillingAndWorkoverStrategy);
                return _ruleEngine.EvaluateAndGetResult(drillingAndWorkoverStrategyInputParamDto, drillingAndWorkoverStrategyDto, FormulaFieldName.DRILLINGANDWORKOVERSTRATEGY);
            }
        }
    }
}
