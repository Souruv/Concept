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
    public class GetAllOilHandlingSettingQuery : IRequest<List<BrainOilHandlingDto>>
    {
        public class GetAllOilHandlingSettingQueryHandler : IRequestHandler<GetAllOilHandlingSettingQuery, List<BrainOilHandlingDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllOilHandlingSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<BrainOilHandlingDto>> Handle(GetAllOilHandlingSettingQuery request, CancellationToken cancellationToken)
            {
                var oilHandling = _unitOfWork.BrainOilHandlingRepository.Filter(x => x.IsDeleted == false).ToList();

                return _mapper.Map<List<BrainOilHandling>, List<BrainOilHandlingDto>>(oilHandling);
            }
        }
    }
}
