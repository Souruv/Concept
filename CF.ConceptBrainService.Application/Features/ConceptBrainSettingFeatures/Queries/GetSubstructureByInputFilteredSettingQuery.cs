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
using System;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Queries
{
    public class GetSubstructureByInputFilteredSettingQuery : IRequest<List<BrainSubstructureDto>>
    {
        public string? Location { get; set; }
        public string? TreeType { get; set; }
        public string? NoOfConductors { get; set; }
        public string? WaterDepth { get; set; }
        public string? TopsideWeight { get; set; }
        public string? ProcessingScheme { get; set; }
        public class GetSubstructureByInputFilteredSettingQueryHandler : IRequestHandler<GetSubstructureByInputFilteredSettingQuery, List<BrainSubstructureDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRuleEngine<BrainSubstructureDto, SubstructureInputParamDto> _ruleEngine;
            public GetSubstructureByInputFilteredSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IRuleEngine<BrainSubstructureDto, SubstructureInputParamDto> ruleEngine)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _ruleEngine = ruleEngine;
            }
            public async Task<List<BrainSubstructureDto>> Handle(GetSubstructureByInputFilteredSettingQuery request, CancellationToken cancellationToken)
            {
                SubstructureInputParamDto substructureInputParamDto = new SubstructureInputParamDto();
                substructureInputParamDto.Location = request.Location;
                substructureInputParamDto.TreeType = request.TreeType;
                substructureInputParamDto.NoOfConductors = Convert.ToInt32(request.NoOfConductors);
                substructureInputParamDto.WaterDepth = Convert.ToInt32(request.WaterDepth);
                substructureInputParamDto.TopsideWeight = Convert.ToInt32(request.TopsideWeight);
                substructureInputParamDto.ProcessingScheme = request.ProcessingScheme;


                var substructure = _unitOfWork.BrainSubstructureRepository.Filter(x => x.IsDeleted == false).ToList();
                var substructureDto = _mapper.Map<List<BrainSubstructure>, List<BrainSubstructureDto>>(substructure);
                return _ruleEngine.EvaluateAndGetResult(substructureInputParamDto, substructureDto, FormulaFieldName.SUBSTRUCTURE);
            }
        }
    }
}
