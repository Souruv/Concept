using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto.InputDto
{
    public class WaterHandlingInputParamDto
    {
        public string? AvailabilityOfDisposalReservoir { get; set; }
        public string? Location { get; set; }
        public decimal? ProducedWaterFlowrate { get; set; }
        public decimal? WaterInjectionFlowrate { get; set; }
        public decimal? WaterDisposalFlowrate { get; set; }
        public bool? PwtGreaterThanWif
        {
            get
            {
                return ProducedWaterFlowrate > WaterInjectionFlowrate;
            }
        }
        public bool? PwtLessThanInjection
        {
            get
            {
                return ProducedWaterFlowrate < WaterInjectionFlowrate;
            }
        }
        public bool? PwtGreaterThanZero
        {
            get
            {
                return ProducedWaterFlowrate > 0;
            }
        }
        public bool? InjReqGreaterThanZero
        {
            get
            {
                return WaterInjectionFlowrate > 0;
            }
        }
    }
}
