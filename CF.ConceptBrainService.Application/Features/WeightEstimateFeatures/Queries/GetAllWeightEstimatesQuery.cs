using AutoMapper;
using AutoMapper.QueryableExtensions;
using CF.ConceptBrainService.Application.Common.Interfaces;
using CF.ConceptBrainService.Application.Features.WeightEstimateFeatures.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ConceptBrainService.Application.Features.WeightEstimateFeatures.Queries
{
    public class GetAllWeightEstimatesQuery : IRequest<IEnumerable<LookupGenericWeightEstimateDto>>
    {
        public class GetAllWeightEstimatesQueryHandler : IRequestHandler<GetAllWeightEstimatesQuery, IEnumerable<LookupGenericWeightEstimateDto>>
        {
            private readonly IMapper mapper;
            private readonly IUnitOfWork unitOfWork;
            public GetAllWeightEstimatesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                this.mapper = mapper;
                this.unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<LookupGenericWeightEstimateDto>> Handle(GetAllWeightEstimatesQuery request, CancellationToken cancellationToken)
            {
                var weightEstimates =  unitOfWork.LookupGenericWeightEstimateRepository.Filter(x => !x.IsDeleted,
                      source => source.Include(x => x.Equipment));

                if (weightEstimates==null)
                {
                    return new List<LookupGenericWeightEstimateDto>();
                }                
                
                return await weightEstimates.ProjectTo<LookupGenericWeightEstimateDto>(mapper.ConfigurationProvider).ToListAsync();
            }
        }
    }
}
