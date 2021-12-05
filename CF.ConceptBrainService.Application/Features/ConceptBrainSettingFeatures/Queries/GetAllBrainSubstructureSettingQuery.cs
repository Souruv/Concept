using CF.ConceptBrainService.Application.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto;
using CF.ConceptBrainService.Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Queries
{
   public class GetAllBrainSubstructureSettingQuery : IRequest<List<BrainSubstructureDto>>
    {
        public class GetAllBrainSubstructureSettingQueryHandler : IRequestHandler<GetAllBrainSubstructureSettingQuery, List<BrainSubstructureDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllBrainSubstructureSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<BrainSubstructureDto>> Handle(GetAllBrainSubstructureSettingQuery request, CancellationToken cancellationToken)
            {
                var subStructure = _unitOfWork.BrainSubstructureRepository.Filter(x => x.IsDeleted == false).ToList();

                return _mapper.Map<List<BrainSubstructure>, List<BrainSubstructureDto>>(subStructure);
            }
        }
    }
}
