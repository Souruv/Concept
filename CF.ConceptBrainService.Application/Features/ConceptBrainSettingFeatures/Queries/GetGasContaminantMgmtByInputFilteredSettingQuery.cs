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
    public class GetGasContaminantMgmtByInputFilteredSettingQuery : IRequest<List<BrainGasContaminantMgmtDto>>
    {
        public string? Location { get; set; }
        public int? FeedCo2 { get; set; }
        public int? ExportCo2 { get; set; }
        public class GetGasContaminantMgmtByInputFilteredSettingQueryHandler : IRequestHandler<GetGasContaminantMgmtByInputFilteredSettingQuery, List<BrainGasContaminantMgmtDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRuleEngine<BrainGasContaminantMgmtDto, BrainGasContaminantMgmtInputParamDto> _ruleEngine;
            public GetGasContaminantMgmtByInputFilteredSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IRuleEngine<BrainGasContaminantMgmtDto, BrainGasContaminantMgmtInputParamDto> ruleEngine)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _ruleEngine = ruleEngine;
            }
            public async Task<List<BrainGasContaminantMgmtDto>> Handle(GetGasContaminantMgmtByInputFilteredSettingQuery request, CancellationToken cancellationToken)
            {
                BrainGasContaminantMgmtInputParamDto brainGasContaminantMgmtInputParamDto = new BrainGasContaminantMgmtInputParamDto();
                brainGasContaminantMgmtInputParamDto.Location = request.Location;
                brainGasContaminantMgmtInputParamDto.FeedCo2 = request.FeedCo2;
                brainGasContaminantMgmtInputParamDto.ExportCo2 = request.ExportCo2;


                var gasContaminantMgmt = _unitOfWork.BrainGasContaminantMgmtRepository.Filter(x => x.IsDeleted == false).ToList();
                var gasContaminantMgmtDto = _mapper.Map<List<BrainGasContaminantMgmt>, List<BrainGasContaminantMgmtDto>>(gasContaminantMgmt);
                return _ruleEngine.EvaluateAndGetResult(brainGasContaminantMgmtInputParamDto, gasContaminantMgmtDto, FormulaFieldName.GASCONTAINATMGMT);
            }
        }
    }
}
