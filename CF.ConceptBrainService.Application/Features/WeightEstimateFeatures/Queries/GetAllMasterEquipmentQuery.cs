using AutoMapper;
using AutoMapper.QueryableExtensions;
using CF.ConceptBrainService.Application.Common.Interfaces;
using CF.ConceptBrainService.Application.Features.WeightEstimateFeatures.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ConceptBrainService.Application.Features.WeightEstimateFeatures.Queries
{
    public class GetAllMasterEquipmentQuery : IRequest<IEnumerable<EquipmentMasterDto>>
    {
        public class GetAllMasterEquipmentQueryHandler : IRequestHandler<GetAllMasterEquipmentQuery, IEnumerable<EquipmentMasterDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public GetAllMasterEquipmentQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<IEnumerable<EquipmentMasterDto>> Handle(GetAllMasterEquipmentQuery request, CancellationToken cancellationToken)
            {
                var masterEquipment = _unitOfWork.EquipmentMasterRepository.Filter(x => !x.IsDeleted);

                if (masterEquipment == null)
                {
                    return new List<EquipmentMasterDto>();
                }

                return await masterEquipment.ProjectTo<EquipmentMasterDto>(_mapper.ConfigurationProvider).ToListAsync();
            }
        }
    }
}
