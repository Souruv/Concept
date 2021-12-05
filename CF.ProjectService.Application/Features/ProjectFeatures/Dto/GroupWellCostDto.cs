using CF.ProjectService.Application.Common.Mappings;
using CF.ProjectService.Application.Entities;
using System;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class GroupWellCostDto
    {
        public bool IsDone { get; set; }
        public PWellCostDto P10 { get; set; }
        public PWellCostDto P50 { get; set; }
        public PWellCostDto P90 { get; set; }

        public GroupWellCostDto()
        {
            P10 = new PWellCostDto();
            P50 = new PWellCostDto();
            P90 = new PWellCostDto();
        }
    }

    public class PWellCostDto
    {
        public WellCostDto OilProducer { get; private set; }
        public WellCostDto GasProducer { get; private set; }

        public PWellCostDto()
        {
            OilProducer = new WellCostDto();
            GasProducer = new WellCostDto();
        }

        public void SetGas(WellCostDto gas, decimal wells)
        {
            if (gas == null)
            {
                GasProducer = new WellCostDto();
            }
            else
            {
                GasProducer = gas;
            }

            GasProducer.Wells = wells;
        }

        public void SetOil(WellCostDto oil, decimal wells)
        {
            if (oil == null)
            {
                OilProducer = new WellCostDto();
            }
            else
            {
                OilProducer = oil;
            }

            OilProducer.Wells = wells;
        }
    }

    public class WellCostDto : IMapFrom<WellCost>
    {
        public decimal? Wells { get; set; }
        public decimal? P50Cost { get; set; }
        public decimal? P80Cost { get; set; }
        public decimal? P50OutputCost { get; set; }
        public decimal? P80OutputCost { get; set; }
        public decimal? Duration { get; set; }
        public string Remarks { get; set; }
    }
}
