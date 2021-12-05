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
    public class GetAllBrainGasContaminantMgmtSettingQuery : IRequest<List<BrainGasContaminantMgmtDto>>
    {
        public class GetAllBrainGasContaminantMgmtSettingQueryHandler : IRequestHandler<GetAllBrainGasContaminantMgmtSettingQuery, List<BrainGasContaminantMgmtDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllBrainGasContaminantMgmtSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<BrainGasContaminantMgmtDto>> Handle(GetAllBrainGasContaminantMgmtSettingQuery request, CancellationToken cancellationToken)
            {
                var gasContaminantMgmt = _unitOfWork.BrainGasContaminantMgmtRepository.Filter(x => x.IsDeleted == false).ToList();

                return _mapper.Map<List<BrainGasContaminantMgmt>, List<BrainGasContaminantMgmtDto>>(gasContaminantMgmt);
            }
        }
    }
}
