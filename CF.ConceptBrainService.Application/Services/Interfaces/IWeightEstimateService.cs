using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.ConceptBrainService.Application.Services.Interfaces
{
    public interface IWeightEstimateService
    {
        public Task<int> GetMaxWBSId();
    }
}
