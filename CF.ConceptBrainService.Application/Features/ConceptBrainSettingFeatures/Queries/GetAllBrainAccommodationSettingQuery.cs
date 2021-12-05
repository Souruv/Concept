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
    public class GetAllBrainAccommodationSettingQuery : IRequest<List<BrainAccommodationDto>>
    {
        public class GetAllBrainAccommodationSettingQueryHandler : IRequestHandler<GetAllBrainAccommodationSettingQuery, List<BrainAccommodationDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllBrainAccommodationSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<BrainAccommodationDto>> Handle(GetAllBrainAccommodationSettingQuery request, CancellationToken cancellationToken)
            {
                var accomodation = _unitOfWork.BrainAccommodationRepository.Filter(x => x.IsDeleted == false).ToList();

                return _mapper.Map<List<BrainAccommodation>, List<BrainAccommodationDto>>(accomodation);
            }
        }
    }
}
