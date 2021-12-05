using AutoMapper;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.UTCCostFeature.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.UTCCostFeature.Queries
{
    public class GetCountryListWithCostQuery : IRequest<List<CountryWithCost>>
    {
        public Guid RevisionId { get; set; }

        public class GetCountryListQueryHandler : IRequestHandler<GetCountryListWithCostQuery, List<CountryWithCost>>
        {

            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;

            public GetCountryListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }


            public async Task<List<CountryWithCost>> Handle(GetCountryListWithCostQuery request, CancellationToken cancellationToken)
            {

                var environmentalData = await _unitOfWork.EnviromentalRepository.GetSingleAsync(x => x.ProjectRevisionId == request.RevisionId && !x.IsDeleted);
                var drillingCentersData = await _unitOfWork.DrillingCenterRepository.Filter(x => x.ProjectRevisionId == request.RevisionId && !x.IsDeleted).ToListAsync();
                //var listCountry = await _unitOfWork.CountryRepository.Filter(x => x.IsDeleted == false).ToListAsync();
                if (environmentalData != null && drillingCentersData != null)
                {
                    var listUtcCost = new List<UTCCost>();
                    var allCosts = await _unitOfWork.UTCCostRepository.Filter(x =>
                                ((environmentalData.Location == "Onshore" && x.WaterDepthGroup == environmentalData.Location) || (environmentalData.Location != "Onshore" && x.WaterDepthGroup != "Onshore"))
                                && x.IsDeleted == false,
                                source => source.Include(x => x.Country)).ToListAsync();

                    foreach (var dc in drillingCentersData)
                    {
                        var costs = allCosts.Where(x => x.Nature.ToLower() == dc.Nature.ToLower()
                                       && (
                                            (environmentalData.Location == "Onshore") ||
                                            (
                                                 (x.WaterDepthMin == null || dc.WaterDepth >= x.WaterDepthMin)
                                              && (x.WaterDepthMax == null || dc.WaterDepth <= x.WaterDepthMax)
                                            )
                                        )
                                       && x.IsDeleted == false).ToList();

                        listUtcCost.AddRange(costs);
                    }

                    var list = listUtcCost.GroupBy(p => p.CountryId, (key, g) => g.OrderByDescending(y => y.Utc).First()).ToList();
                    //listUtcCost.GroupBy(x=>x.CountryId).Max(x=>x.c)
                    return list.Select(x => new CountryWithCost { Country = (x.Country == null ? "Default" : x.Country.CountryName), Value = x.Utc, SortOrder = (x.Country == null ? 1 : x.Country.SortOrder) }).OrderBy(x => x.SortOrder).ToList();
                    //return _mapper.Map<List<CountryWithCost>>(listCountry);
                }
                else
                {
                    return null;
                }

            }
        }
    }
}
