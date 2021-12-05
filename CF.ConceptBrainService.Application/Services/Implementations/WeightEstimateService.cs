
using CF.ConceptBrainService.Application.Common.Interfaces;
using CF.ConceptBrainService.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.ConceptBrainService.Application.Services.Implementations
{
    public class WeightEstimateService : IWeightEstimateService
    {
        private readonly IUnitOfWork _unitOfWork;
        public WeightEstimateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> GetMaxWBSId()
        {
            var countObject = await _unitOfWork.EquimentRepository.Filter(x => !x.IsDeleted).ToListAsync();
            var listWBSId = countObject.Select(x => x.WBSId).ToList();
            var maxId = listWBSId.Max();
            return maxId;
        }
    }
}
