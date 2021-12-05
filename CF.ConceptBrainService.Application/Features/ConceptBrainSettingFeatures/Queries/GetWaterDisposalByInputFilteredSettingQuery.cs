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
    public class GetWaterDisposalByInputFilteredSettingQuery : IRequest<List<BrainWaterDisposalDto>>
    {
        public string? AvailabilityOfDisposalReservoir { get; set; }
        public string? Location { get; set; }
        public decimal? ProducedWaterFlowrate { get; set; }
        public decimal? WaterInjectionFlowrate { get; set; }
        public decimal? WaterDisposalFlowrate { get; set; }

        public class GetWaterDisposalByInputFilteredSettingQueryHandler : IRequestHandler<GetWaterDisposalByInputFilteredSettingQuery, List<BrainWaterDisposalDto>>
        {
                private readonly IMapper _mapper;
                private readonly IUnitOfWork _unitOfWork;
                private readonly IRuleEngine<BrainWaterDisposalDto, WaterHandlingInputParamDto> _ruleEngine;
            public GetWaterDisposalByInputFilteredSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IRuleEngine<BrainWaterDisposalDto, WaterHandlingInputParamDto> ruleEngine)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _ruleEngine = ruleEngine;
            }

            public async Task<List<BrainWaterDisposalDto>> Handle(GetWaterDisposalByInputFilteredSettingQuery request, CancellationToken cancellationToken)
            {
                WaterHandlingInputParamDto waterHandlingInputParamDto = new WaterHandlingInputParamDto();
                waterHandlingInputParamDto.AvailabilityOfDisposalReservoir = request.AvailabilityOfDisposalReservoir;
                waterHandlingInputParamDto.Location = request.Location;
                waterHandlingInputParamDto.ProducedWaterFlowrate = request.ProducedWaterFlowrate;
                waterHandlingInputParamDto.WaterInjectionFlowrate = request.WaterInjectionFlowrate;
                waterHandlingInputParamDto.WaterDisposalFlowrate = request.WaterDisposalFlowrate;


                var waterDisposal = _unitOfWork.BrainWaterDisposalRepository.Filter(x => x.IsDeleted == false).ToList();
                var waterDisposalDto = _mapper.Map<List<BrainWaterDisposal>, List<BrainWaterDisposalDto>>(waterDisposal);
                return _ruleEngine.EvaluateAndGetResult(waterHandlingInputParamDto, waterDisposalDto, FormulaFieldName.WATERDISPOSAL);
            }
        }
    }
}
