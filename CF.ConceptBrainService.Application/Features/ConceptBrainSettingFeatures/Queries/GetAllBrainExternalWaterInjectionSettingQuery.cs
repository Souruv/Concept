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
    public class GetAllBrainExternalWaterInjectionSettingQuery : IRequest<List<BrainExternalWaterInjectionDto>>
    {
        public class GetAllBrainExternalWaterInjectionSettingQueryHandler : IRequestHandler<GetAllBrainExternalWaterInjectionSettingQuery, List<BrainExternalWaterInjectionDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllBrainExternalWaterInjectionSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<List<BrainExternalWaterInjectionDto>> Handle(GetAllBrainExternalWaterInjectionSettingQuery request, CancellationToken cancellationToken)
            {
                var extternalWaterInjection = _unitOfWork.BrainExternalWaterInjectionRepository.Filter(x => x.IsDeleted == false).ToList();

                return _mapper.Map<List<BrainExternalWaterInjection>, List<BrainExternalWaterInjectionDto>>(extternalWaterInjection);
            }
        }
    }
}
