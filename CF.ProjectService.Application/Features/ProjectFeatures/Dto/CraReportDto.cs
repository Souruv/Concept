using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{


    public class CraReportDto
    {
        public ChartSeriesXYDto<double, double> ProbabilityDensityData { get; set; }
        public ChartSeriesXYDto<double, double> CumProbabilityData { get; set; }
        public List<CraReportCostRangeDto> CostRangeTable { get; set; }
        public double BaseEstimate { get; set; }
        public double Contingency { get; set; }
        public double P50Estimate { get; set; }
        public double P10Estimate { get; set; }
   
        public double P90Estimate { get; set; }

        public double ProbabilityDensityP50EstimateY { get; set; }
        public double ProbabilityDensityP10EstimateY { get; set; }

        public double ProbabilityDensityP90EstimateY { get; set; }

        public double CumProbabilityP50EstimateY { get; set; }
        public double CumProbabilityP10EstimateY { get; set; }

        public double CumProbabilityP90EstimateY { get; set; }

        public double ContingencyPercentageOfBase { get; set; }
        public double P10EstimatePercentageOfBase { get; set; }
        public double P90EstimatePercentageOfBase { get; set; }
        public double BaseEstimateContingency { get; internal set; }
    }
    public class CraReportCostRangeDto
    {
        public decimal ProbabilityOfUnderRun { get; set; }

        public decimal IndicatedFundingAmount { get; set; }
        public decimal EstimatedContingency { get; set; }
        public decimal PercentageOfBaseEstimate { get; set; }

    }

}
