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
    public class GetExternalWaterInjectionByInputFilteredSettingQuery : IRequest<List<BrainExternalWaterInjectionDto>>
    {
        public string? AvailabilityOfDisposalReservoir { get; set; }
        public string? Location { get; set; }
        public decimal? ProducedWaterFlowrate { get; set; }
        public decimal? WaterInjectionFlowrate { get; set; }
        public decimal? WaterDisposalFlowrate { get; set; }
        public class GetExternalWaterInjectionByInputFilteredSettingQueryHandler : IRequestHandler<GetExternalWaterInjectionByInputFilteredSettingQuery, List<BrainExternalWaterInjectionDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRuleEngine<BrainExternalWaterInjectionDto, WaterHandlingInputParamDto> _ruleEngine;
            public GetExternalWaterInjectionByInputFilteredSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IRuleEngine<BrainExternalWaterInjectionDto, WaterHandlingInputParamDto> ruleEngine)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _ruleEngine = ruleEngine;
            }
            public async Task<List<BrainExternalWaterInjectionDto>> Handle(GetExternalWaterInjectionByInputFilteredSettingQuery request, CancellationToken cancellationToken)
            {
                WaterHandlingInputParamDto waterHandlingInputParamDto = new WaterHandlingInputParamDto();
                waterHandlingInputParamDto.AvailabilityOfDisposalReservoir = request.AvailabilityOfDisposalReservoir;
                waterHandlingInputParamDto.Location = request.Location;
                waterHandlingInputParamDto.ProducedWaterFlowrate = request.ProducedWaterFlowrate;
                waterHandlingInputParamDto.WaterInjectionFlowrate = request.WaterInjectionFlowrate;
                waterHandlingInputParamDto.WaterDisposalFlowrate = request.WaterDisposalFlowrate;


                var externalWaterInjection = _unitOfWork.BrainExternalWaterInjectionRepository.Filter(x => x.IsDeleted == false).ToList();
                var externalWaterInjectionDto = _mapper.Map<List<BrainExternalWaterInjection>, List<BrainExternalWaterInjectionDto>>(externalWaterInjection);
                return _ruleEngine.EvaluateAndGetResult(waterHandlingInputParamDto, externalWaterInjectionDto, FormulaFieldName.EXTERNALWATERINJECTION);
            }
        }
    }
}
