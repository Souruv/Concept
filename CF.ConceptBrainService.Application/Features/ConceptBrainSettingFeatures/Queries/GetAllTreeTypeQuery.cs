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
    public class GetAllTreeTypeQuery : IRequest<List<BrainTreeTypeDto>>
    {
        public class GetAllTreeTypeQueryHandler : IRequestHandler<GetAllTreeTypeQuery, List<BrainTreeTypeDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllTreeTypeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<List<BrainTreeTypeDto>> Handle(GetAllTreeTypeQuery request, CancellationToken cancellationToken)
            {
                var treeType = _unitOfWork.BrainTreeTypeRepository.Filter(x=> x.IsDeleted == false).ToList();

                return _mapper.Map<List<BrainTreeType>, List<BrainTreeTypeDto>>(treeType);
            }
        }
    }
}
