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
    public class GetPwtInjectionByInputFilteredSettingQuery : IRequest<List<BrainPWTInjectionDto>>
    {
        public string? AvailabilityOfDisposalReservoir { get; set; }
        public string? Location { get; set; }
        public decimal? ProducedWaterFlowrate { get; set; }
        public decimal? WaterInjectionFlowrate { get; set; }
        public decimal? WaterDisposalFlowrate { get; set; }

        public class GetPwtInjectionByInputFilteredSettingQueryHandler : IRequestHandler<GetPwtInjectionByInputFilteredSettingQuery, List<BrainPWTInjectionDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRuleEngine<BrainPWTInjectionDto, WaterHandlingInputParamDto> _ruleEngine;
            public GetPwtInjectionByInputFilteredSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IRuleEngine<BrainPWTInjectionDto, WaterHandlingInputParamDto> ruleEngine)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _ruleEngine = ruleEngine;
            }
            public async Task<List<BrainPWTInjectionDto>> Handle(GetPwtInjectionByInputFilteredSettingQuery request, CancellationToken cancellationToken)
            {
                WaterHandlingInputParamDto waterHandlingInputParamDto = new WaterHandlingInputParamDto();
                waterHandlingInputParamDto.AvailabilityOfDisposalReservoir = request.AvailabilityOfDisposalReservoir;
                waterHandlingInputParamDto.Location = request.Location;
                waterHandlingInputParamDto.ProducedWaterFlowrate = request.ProducedWaterFlowrate;
                waterHandlingInputParamDto.WaterInjectionFlowrate = request.WaterInjectionFlowrate;
                waterHandlingInputParamDto.WaterDisposalFlowrate = request.WaterDisposalFlowrate;


                var pwtInjection = _unitOfWork.BrainPWTInjectionRepository.Filter(x => x.IsDeleted == false).ToList();
                var pwtInjectionDto = _mapper.Map<List<BrainPWTInjection>, List<BrainPWTInjectionDto>>(pwtInjection);
                return _ruleEngine.EvaluateAndGetResult(waterHandlingInputParamDto, pwtInjectionDto, FormulaFieldName.PWTINJECTION);
            }
        }
    }
}
