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
    public class GetWeightEstimateByIdQuery : IRequest<IEnumerable<LookupGenericWeightEstimateDto>>
    {
        public int? WBSId { get; set; }

        public class GetWeightEstimateByIdQueryHandler : IRequestHandler<GetWeightEstimateByIdQuery, IEnumerable<LookupGenericWeightEstimateDto>>
        {
            private readonly IMapper mapper;
            private readonly IUnitOfWork unitOfWork;
            public GetWeightEstimateByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                this.mapper = mapper;
                this.unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<LookupGenericWeightEstimateDto>> Handle(GetWeightEstimateByIdQuery request, CancellationToken cancellationToken)
            {
                if (request.WBSId == null)
                    return new List<LookupGenericWeightEstimateDto>();

                var weightEstimates = unitOfWork.LookupGenericWeightEstimateRepository.Filter(x => !x.IsDeleted && x.Equipment.WBSId == request.WBSId,
                      source => source.Include(x => x.Equipment));

                if (weightEstimates == null)
                {
                    return null;
                }

                return await weightEstimates.ProjectTo<LookupGenericWeightEstimateDto>(mapper.ConfigurationProvider).ToListAsync();
            }
        }
    }
}
