using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.UTCCostFeature.Queries
{
    public class GetUTCCostQuery : IRequest<int?>
    {
        public Guid? Country { get; set; }

       public string Location {get;set;}

        public IEnumerable<DCInfoPost> DCInfos {get;set;}

     




        public class GetUTCCostCommandHandler : IRequestHandler<GetUTCCostQuery, int?>
        {
            public IUnitOfWork _unitOfWork;

            public GetUTCCostCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<int?> Handle(GetUTCCostQuery request, CancellationToken cancellationToken)
            {
                var listUtcCost = new List<int?>();

                foreach (var item in request.DCInfos)
                {
                    var cost = new UTCCost();
                    if(request.Location == "Onshore")
                    {
                        cost =  await _unitOfWork.UTCCostRepository.GetSingleAsync(x => x.Nature.ToLower() == item.Nature.ToLower() && x.CountryId == request.Country 
                                && x.WaterDepthGroup == "Onshore"
                                && x.IsDeleted == false);
                    }
                    else
                    {
                         cost = await _unitOfWork.UTCCostRepository.GetSingleAsync(x => x.Nature.ToLower() == item.Nature.ToLower() && x.CountryId == request.Country 
                                && ( (x.WaterDepthMin == null && x.WaterDepthMax != null && item.Waterdepth < x.WaterDepthMax ) || (x.WaterDepthMax == null && x.WaterDepthMin != null && item.Waterdepth > x.WaterDepthMin )|| (x.WaterDepthMin < item.Waterdepth && x.WaterDepthMax > item.Waterdepth))
                                && x.IsDeleted == false);
                    }
                   

                    listUtcCost.Add(cost?.Utc);
                }
                return listUtcCost.Max();


            }
        }
    }
}
