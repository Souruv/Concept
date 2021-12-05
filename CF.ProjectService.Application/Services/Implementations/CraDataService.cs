using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Services.Implementations
{
    public class CraDataService : ICraDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMathHelper _mathHelper;
        public CraDataService(IUnitOfWork unitOfWork, IMathHelper mathHelper)
        {
            _unitOfWork = unitOfWork;
            _mathHelper = mathHelper;
        }
   
        public async Task<CraReportDto> GetCraData(decimal baseEstimate, decimal totalRiskScore, string estimateClass, string curve)
        {
            var retObj = new CraReportDto();
            retObj.BaseEstimate = (double)baseEstimate;
            var accuracyExpression = _unitOfWork.LookUpCraAccuracyExpressionRepository.Filter(x => !x.IsDeleted && x.Curve == curve
                        && x.EstimateClass == estimateClass).FirstOrDefault().Expression;
            var contingencyExpression = _unitOfWork.LookUpCraContingencyExpressionRepository.Filter(x => !x.IsDeleted && x.Curve == curve
                        && x.EstimateClass == estimateClass).FirstOrDefault().Expression;

            List<ChartSeriesXYDto<double, double>> seriesList = new List<ChartSeriesXYDto<double, double>>();
            #region chart data
            //chart series data/

            var probabilityDisttributionData = new ChartSeriesXYDto<double, double>();
            probabilityDisttributionData.Title = "Probability Density Function";            
            var calculated_PosAcc = _mathHelper.EvaluateExpression(accuracyExpression.Replace("Total_Risk_Score", totalRiskScore.ToString()));
            var calculated_Contingency = _mathHelper.EvaluateExpression(contingencyExpression.Replace("Total_Risk_Score", totalRiskScore.ToString()));

            var positive_Accuracy = calculated_PosAcc;

            if (calculated_PosAcc < 0.102)
            {
                positive_Accuracy = _mathHelper.Ceiling(calculated_PosAcc - 0.002, 0.01);
            }
            else if (calculated_PosAcc < 0.205)
            {
                positive_Accuracy = _mathHelper.Ceiling(calculated_PosAcc - 0.005, 0.02);
            }
            else
            {
                positive_Accuracy = _mathHelper.Ceiling(calculated_PosAcc - 0.015, 0.05);
            }

            var contingency = calculated_Contingency;
            if (calculated_Contingency < 0.152)
            {
                contingency = _mathHelper.Ceiling(calculated_Contingency - 0.002, 0.01);
            }
            else if (calculated_Contingency < 0.245)
            {
                contingency = _mathHelper.Ceiling(calculated_Contingency - 0.005, 0.02);
            }
            else
            {
                contingency = _mathHelper.Ceiling(calculated_Contingency - 0.015, 0.05);
            }

            var calculated_NegAcc = positive_Accuracy * 0.6D;
            var negative_Accuracy = calculated_NegAcc;
            if (calculated_NegAcc < 0.102)
            {
                negative_Accuracy = _mathHelper.Ceiling(calculated_NegAcc - 0.002, 0.01);
            }
            else if (calculated_NegAcc < 0.205)
            {
                negative_Accuracy = _mathHelper.Ceiling(calculated_NegAcc - 0.005, 0.02);
            }
            else
            {
                negative_Accuracy = _mathHelper.Ceiling(calculated_NegAcc - 0.015, 0.05);
            }

            var accuracy_LookUp = positive_Accuracy * 100;
            var pdfXValues = await _unitOfWork.LookUpCraPdfXValueRepository.Filter(x => x.PositiveAccurary == accuracy_LookUp).ToListAsync();
            var pdfYValues = await _unitOfWork.LookUpCraPdfYValueRepository.Filter(x => x.PositiveAccurary == accuracy_LookUp).ToListAsync();

            retObj.Contingency = contingency;
            retObj.P50Estimate = (double)baseEstimate * (1.0D + retObj.Contingency);
            retObj.P90Estimate = retObj.P50Estimate * (1.0D + positive_Accuracy);
            retObj.P10Estimate = retObj.P50Estimate * (1.0D - negative_Accuracy);



            retObj.BaseEstimateContingency = contingency * retObj.BaseEstimate;

            retObj.ContingencyPercentageOfBase = retObj.BaseEstimateContingency / retObj.BaseEstimate * 100.0;
            retObj.P10EstimatePercentageOfBase = (retObj.P10Estimate - retObj.P50Estimate) / retObj.P50Estimate * 100.0;
            retObj.P90EstimatePercentageOfBase = (retObj.P90Estimate - retObj.P50Estimate) / retObj.P50Estimate * 100.0;


            for (var i = 2; i <= 513; i++)
            {
                double xValue = double.Parse(pdfXValues.Where(x => x.RowIndex == i - 1).FirstOrDefault().Value) * retObj.P50Estimate / 100.0D;
                double yValue = double.Parse(pdfYValues.Where(x => x.RowIndex == i - 1).FirstOrDefault().Value);
                var ps = new XYValue<double, double> { XValue = xValue, YValue = yValue };

                probabilityDisttributionData.Series.Add(i.ToString(), ps);
            }


            retObj.ProbabilityDensityP50EstimateY = probabilityDisttributionData.Series.Values.Where(x => x.XValue <= (retObj.P50Estimate + 0.05))
                .Select(obj => new { obj, diff = obj.XValue - (retObj.P50Estimate + 0.05) })
                .OrderByDescending(p => p.diff).First().obj.YValue;
            retObj.ProbabilityDensityP90EstimateY = probabilityDisttributionData.Series.Values.Where(x => x.XValue <= (retObj.P90Estimate + 0.05))
                .Select(obj => new { obj, diff = obj.XValue - (retObj.P90Estimate + 0.05) })
                .OrderByDescending(p => p.diff).First().obj.YValue;
            retObj.ProbabilityDensityP10EstimateY = probabilityDisttributionData.Series.Values.Where(x => x.XValue <= (retObj.P10Estimate + 0.05))
                .Select(obj => new { obj, diff = obj.XValue - (retObj.P10Estimate + 0.05) })
                .OrderByDescending(p => p.diff).First().obj.YValue;

            #endregion
            retObj.ProbabilityDensityData = probabilityDisttributionData;


            //var probabilityOfUnderrunList = new string[] {"0%","1%","5%","10%","15%","20%","25%","30%","35%","40%","45%",
            //    "50%","55%","60%","65%","70%","75%","80%","85%","90%","95%","99%","100%" };
            var probabilityOfUnderrunList = new decimal[] {0,1,5,10,15,20,25,30,35,40,45,50,
                    55,60,65,70,75,80,85,90,95,99,100 };

            var cumProbabilityData = new ChartSeriesXYDto<double, double>();
            cumProbabilityData.Title = "Cum. Probability";

            List<CraReportCostRangeDto> costRangeTable = new List<CraReportCostRangeDto>();
            var sCurveValues = await _unitOfWork.LookUpCraSCurveValueRepository.Filter(x => x.PositiveAccurary == accuracy_LookUp).ToListAsync();
            for (var i = 0; i < probabilityOfUnderrunList.Length; i++)
            {
                CraReportCostRangeDto costRangeRow = new CraReportCostRangeDto();

                costRangeRow.ProbabilityOfUnderRun = probabilityOfUnderrunList[i];
                costRangeRow.IndicatedFundingAmount = decimal.Parse(sCurveValues.Where(x => x.Percent == (probabilityOfUnderrunList[i] / 100).ToString()).FirstOrDefault().Value) * (decimal)retObj.P50Estimate / 100.0M;
                costRangeRow.EstimatedContingency = costRangeRow.IndicatedFundingAmount - baseEstimate;
                costRangeRow.PercentageOfBaseEstimate = 100 * costRangeRow.IndicatedFundingAmount / baseEstimate;

                costRangeTable.Add(costRangeRow);

                var ps = new XYValue<double, double> { XValue = (double)costRangeRow.IndicatedFundingAmount, YValue = (double)costRangeRow.ProbabilityOfUnderRun };

                cumProbabilityData.Series.Add(i.ToString(), ps);
            }

            retObj.CumProbabilityP50EstimateY = cumProbabilityData.Series.Values.Where(x => x.XValue <= (retObj.P50Estimate + 0.05))
                .Select(obj => new { obj, diff = obj.XValue - (retObj.P50Estimate + 0.05) })
                .OrderByDescending(p => p.diff).First().obj.YValue;
            retObj.CumProbabilityP90EstimateY = cumProbabilityData.Series.Values.Where(x => x.XValue <= (retObj.P90Estimate + 0.05))
                .Select(obj => new { obj, diff = obj.XValue - (retObj.P90Estimate + 0.05) })
                .OrderByDescending(p => p.diff).First().obj.YValue;
            retObj.CumProbabilityP10EstimateY = cumProbabilityData.Series.Values.Where(x => x.XValue <= (retObj.P10Estimate + 0.05))
                .Select(obj => new { obj, diff = obj.XValue - (retObj.P10Estimate + 0.05) })
                .OrderByDescending(p => p.diff).First().obj.YValue;


            retObj.CostRangeTable = costRangeTable;
            retObj.CumProbabilityData = cumProbabilityData;

            return retObj;
        }
    }
}
