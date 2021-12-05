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
    public class GetTreeTypeByInputFilteredQuery : IRequest<List<BrainTreeTypeDto>>
    {
        public string? Location { get; set; }
        public int? NumberOfWell { get; set; }
        public int? WaterDepth { get; set; }
        
        public class GetTreeTypeByInputFilteredQueryHandlder : IRequestHandler<GetTreeTypeByInputFilteredQuery, List<BrainTreeTypeDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRuleEngine<BrainTreeTypeDto, TreeTypeInputParamDto> _ruleEngine;
            public GetTreeTypeByInputFilteredQueryHandlder(IUnitOfWork unitOfWork, IMapper mapper, IRuleEngine<BrainTreeTypeDto, TreeTypeInputParamDto> ruleEngine)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
               _ruleEngine = ruleEngine;
            }

            public async Task<List<BrainTreeTypeDto>> Handle(GetTreeTypeByInputFilteredQuery request, CancellationToken cancellationToken)
            {
                TreeTypeInputParamDto treeTypeInputParamDto = new TreeTypeInputParamDto();
                treeTypeInputParamDto.Location = request.Location;
                treeTypeInputParamDto.NumberOfWell = request.NumberOfWell;
                treeTypeInputParamDto.WaterDepth = request.WaterDepth;

                var treeType = _unitOfWork.BrainTreeTypeRepository.Filter(x => x.IsDeleted == false).ToList();
                var treeTypeDto = _mapper.Map<List<BrainTreeType>, List<BrainTreeTypeDto>>(treeType);
                return _ruleEngine.EvaluateAndGetResult(treeTypeInputParamDto, treeTypeDto, FormulaFieldName.TREETYPE);
            }
        }
    }
}
