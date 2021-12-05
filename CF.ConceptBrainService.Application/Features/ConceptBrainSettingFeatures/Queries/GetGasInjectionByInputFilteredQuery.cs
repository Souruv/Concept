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
    public class GetGasInjectionByInputFilteredQuery : IRequest<List<BrainGasInjectionDto>>
    {
        public string? HydrocarbonType { get; set; }
        public bool? HCDewpoint { get; set; }
        public bool? WaterContentDewpoint { get; set; }
        public decimal? AgFlowRate { get; set; }
        public decimal? GasInjectionFlowRate { get; set; }
        public string? GasInjectionPressure { get; set; }
        public decimal? GasLiftFlowRate { get; set; }
        public string? GasLiftPressure { get; set; }
        public bool? GasDisposalReInjection { get; set; }
        public bool? NAGReservoir { get; set; }
        public bool? NAGSeparateTrain { get; set; }
        public string? AdditionalNagFlowRate { get; set; }
        public string? AdditionalNagPressure { get; set; }
        public bool? NearByGasField { get; set; }
        public bool? NearByGasFieldProcessed { get; set; }
        public string? NearByGasFieldFlowRate { get; set; }
        public string? NearByGasFieldPressure { get; set; }
        public string? AdditionalGasRequired { get; set; }
        public bool? GasAvailableToExportDispose { get; set; }

        public class GetGasInjectionByInputFilteredQueryHandler : IRequestHandler<GetGasInjectionByInputFilteredQuery, List<BrainGasInjectionDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRuleEngine<BrainGasInjectionDto, GasHandlingInputParamDto> _ruleEngine;
            public GetGasInjectionByInputFilteredQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IRuleEngine<BrainGasInjectionDto, GasHandlingInputParamDto> ruleEngine)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _ruleEngine = ruleEngine;
            }
            public async Task<List<BrainGasInjectionDto>> Handle(GetGasInjectionByInputFilteredQuery request, CancellationToken cancellationToken)
            {
                GasHandlingInputParamDto gasHandlingInputParamDto = new GasHandlingInputParamDto();
                gasHandlingInputParamDto.HydrocarbonType = request.HydrocarbonType;
                gasHandlingInputParamDto.HCDewpoint = request.HCDewpoint;
                gasHandlingInputParamDto.WaterContentDewpoint = request.WaterContentDewpoint;
                gasHandlingInputParamDto.AgFlowRate = request.AgFlowRate;
                gasHandlingInputParamDto.GasInjectionFlowRate = request.GasInjectionFlowRate;
                gasHandlingInputParamDto.GasInjectionPressure = request.GasInjectionPressure;
                gasHandlingInputParamDto.GasLiftFlowRate = request.GasLiftFlowRate;
                gasHandlingInputParamDto.GasLiftPressure = request.GasLiftPressure;
                gasHandlingInputParamDto.GasDisposalReInjection = request.GasDisposalReInjection;
                gasHandlingInputParamDto.NAGReservoir = request.NAGReservoir;
                gasHandlingInputParamDto.NAGSeparateTrain = request.NAGSeparateTrain;
                gasHandlingInputParamDto.AdditionalNagFlowRate = request.AdditionalNagFlowRate;
                gasHandlingInputParamDto.AdditionalNagPressure = request.AdditionalNagPressure;
                gasHandlingInputParamDto.NearByGasField = request.NearByGasField;
                gasHandlingInputParamDto.NearByGasFieldProcessed = request.NearByGasFieldProcessed;
                gasHandlingInputParamDto.NearByGasFieldFlowRate = request.NearByGasFieldFlowRate;
                gasHandlingInputParamDto.NearByGasFieldPressure = request.NearByGasFieldPressure;
                gasHandlingInputParamDto.AdditionalGasRequired = request.AdditionalGasRequired;
                gasHandlingInputParamDto.GasAvailableToExportDispose = request.GasAvailableToExportDispose;

                var gasInjection = _unitOfWork.BrainGasInjectionRepository.Filter(x => x.IsDeleted == false).ToList();
                var gasInjectionDto = _mapper.Map<List<BrainGasInjection>, List<BrainGasInjectionDto>>(gasInjection);
                return _ruleEngine.EvaluateAndGetResult(gasHandlingInputParamDto, gasInjectionDto, FormulaFieldName.GASINJECTION);
            }
        }
    }
}
