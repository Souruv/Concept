using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CF.ProjectService.Application.Services.Implementations
{
    public class UtcCostService : IUtcCostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UtcCostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<decimal> GetDefaultUtcCost(Guid revisionId)
        {
            var listUtcCost = new List<UTCCost>();
            var environmentalData = await _unitOfWork.EnviromentalRepository.GetSingleAsync(x => x.ProjectRevisionId == revisionId && !x.IsDeleted);
            var drillingCentersData = await _unitOfWork.DrillingCenterRepository.Filter(x => x.ProjectRevisionId == revisionId && !x.IsDeleted).ToListAsync();
            //var listCountry = await _unitOfWork.CountryRepository.Filter(x => x.IsDeleted == false).ToListAsync();
            var allCosts = await _unitOfWork.UTCCostRepository.Filter(x =>
            ((environmentalData.Location == "Onshore" && x.WaterDepthGroup == environmentalData.Location)
                || (environmentalData.Location != "Onshore" && x.WaterDepthGroup != "Onshore")
            )
                && x.IsDeleted == false && x.CountryId == null,
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
            var utcCostValue = listUtcCost.Where(x => x.Country == null).OrderBy(x => x.Utc).First().Utc;


            return utcCostValue;
        }


    }
}
