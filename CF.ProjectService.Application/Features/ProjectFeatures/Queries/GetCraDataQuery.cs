using AutoMapper;
using CF.ProjectService.Application.Common.Bases;
using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using CF.ProjectService.Application.Services.Interfaces;
using Costimator.Application.Features.ProjectFeatures.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Queries
{
    public class GetCraDataQuery : IRequest<CraReportDto>
    {

        public decimal BaseEstimate { get; set; } //= 89.25M;
        public decimal TotalRiskScore { get; set; } //= 26.266728196M;
        public string EstimateClass { get; set; } //= "5";
        public string Curve { get; set; } //= "A";





        public class GetCraDataQueryHandler : IRequestHandler<GetCraDataQuery, CraReportDto>
        {
            private readonly IMapper _mapper;
            ICraDataService _craDataService;
            public GetCraDataQueryHandler( IMapper mapper, ICraDataService craDataService)
            {
                _mapper = mapper;
                _craDataService = craDataService;
            }
            public async Task<CraReportDto> Handle(GetCraDataQuery query, CancellationToken cancellationToken)
            {
                var retObj = new CraReportDto();
                retObj= await _craDataService.GetCraData(query.BaseEstimate, query.TotalRiskScore, query.EstimateClass, query.Curve);
                return retObj;
                //var retObj = new CraReportDto();
                //retObj.BaseEstimate = (double)query.BaseEstimate;
                ////var accuracyExpressionlist = await _unitOfWork.LookUpCraAccuracyExpressionRepository.Filter(x => !x.IsDeleted).ToListAsync();
                ////var contingencyExpressionlist = await _unitOfWork.LookUpCraContingencyExpressionRepository.Filter(x => !x.IsDeleted).ToListAsync();
                //var accuracyExpression = _unitOfWork.LookUpCraAccuracyExpressionRepository.Filter(x => !x.IsDeleted && x.Curve == query.Curve
                //            && x.EstimateClass == query.EstimateClass).FirstOrDefault().Expression;
                //var contingencyExpression = _unitOfWork.LookUpCraContingencyExpressionRepository.Filter(x => !x.IsDeleted && x.Curve == query.Curve
                //            && x.EstimateClass == query.EstimateClass).FirstOrDefault().Expression;

                //List<ChartSeriesXYDto<double, double>> seriesList = new List<Dto.ChartSeriesXYDto<double, double>>();
                //#region chart data
                ////chart series data/

                //var probabilityDisttributionData = new ChartSeriesXYDto<double, double>();
                //probabilityDisttributionData.Title = "Probability Density Function";
                ////var accuracyExpression = accuracyExpressionlist.Where(x => x.Curve == query.Curve && x.EstimateClass == query.EstimateClass).FirstOrDefault()?.Expression;
                ////var contingencyExpression = contingencyExpressionlist.Where(x => x.Curve == query.Curve && x.EstimateClass == query.EstimateClass).FirstOrDefault()?.Expression;

                //var calculated_PosAcc = _mathHelper.EvaluateExpression(accuracyExpression.Replace("Total_Risk_Score", query.TotalRiskScore.ToString()));
                //var calculated_Contingency = _mathHelper.EvaluateExpression(contingencyExpression.Replace("Total_Risk_Score", query.TotalRiskScore.ToString()));

                //var positive_Accuracy = calculated_PosAcc;

                //if (calculated_PosAcc < 0.102)
                //{
                //    positive_Accuracy = _mathHelper.Ceiling(calculated_PosAcc - 0.002, 0.01);
                //}
                //else if (calculated_PosAcc < 0.205)
                //{
                //    positive_Accuracy = _mathHelper.Ceiling(calculated_PosAcc - 0.005, 0.02);
                //}
                //else
                //{
                //    positive_Accuracy = _mathHelper.Ceiling(calculated_PosAcc - 0.015, 0.05);
                //}

                //var contingency = calculated_Contingency;
                //if (calculated_Contingency < 0.152)
                //{
                //    contingency = _mathHelper.Ceiling(calculated_Contingency - 0.002, 0.01);
                //}
                //else if (calculated_Contingency < 0.245)
                //{
                //    contingency = _mathHelper.Ceiling(calculated_Contingency - 0.005, 0.02);
                //}
                //else
                //{
                //    contingency = _mathHelper.Ceiling(calculated_Contingency - 0.015, 0.05);
                //}

                //var calculated_NegAcc = positive_Accuracy * 0.6D;
                //var negative_Accuracy = calculated_NegAcc;
                //if (calculated_NegAcc < 0.102)
                //{
                //    negative_Accuracy = _mathHelper.Ceiling(calculated_NegAcc - 0.002, 0.01);
                //}
                //else if (calculated_NegAcc < 0.205)
                //{
                //    negative_Accuracy = _mathHelper.Ceiling(calculated_NegAcc - 0.005, 0.02);
                //}
                //else
                //{
                //    negative_Accuracy = _mathHelper.Ceiling(calculated_NegAcc - 0.015, 0.05);
                //}

                //var accuracy_LookUp = positive_Accuracy * 100;
                //var pdfXValues = await _unitOfWork.PdfXValuesRepository.Filter(x => x.PositiveAccurary == accuracy_LookUp).ToListAsync();
                //var pdfYValues = await _unitOfWork.PdfYValuesRepository.Filter(x => x.PositiveAccurary == accuracy_LookUp).ToListAsync();

                //retObj.Contingency = contingency;
                //retObj.P50Estimate = (double)query.BaseEstimate * (1.0D + retObj.Contingency);
                //retObj.P90Estimate = retObj.P50Estimate * (1.0D + positive_Accuracy);
                //retObj.P10Estimate = retObj.P50Estimate * (1.0D - negative_Accuracy);



                //retObj.BaseEstimateContingency = contingency * retObj.BaseEstimate;

                //retObj.ContingencyPercentageOfBase = retObj.BaseEstimateContingency / retObj.BaseEstimate * 100.0;
                //retObj.P10EstimatePercentageOfBase = (retObj.P10Estimate - retObj.P50Estimate) / retObj.P50Estimate * 100.0;
                //retObj.P90EstimatePercentageOfBase = (retObj.P90Estimate - retObj.P50Estimate) / retObj.P50Estimate * 100.0;


                //for (var i = 2; i <= 513; i++)
                //{
                //    //x= HLOOKUP(Accuracy_LookUp, 'PDF X Values'!A$2:W$514,$F2) * P50_Estimate / 100
                //    //y= HLOOKUP(Accuracy_LookUp,'PDF Y Values'!B$2:X$1028,$F57)
                //    double xValue = double.Parse(pdfXValues.Where(x => x.RowIndex == i - 1).FirstOrDefault().Value) * retObj.P50Estimate / 100.0D;
                //    double yValue = double.Parse(pdfYValues.Where(x => x.RowIndex == i - 1).FirstOrDefault().Value);
                //    var ps = new XYValue<double, double> { XValue = xValue, YValue = yValue };

                //    probabilityDisttributionData.Series.Add(i.ToString(), ps);
                //}


                //retObj.ProbabilityDensityP50EstimateY = probabilityDisttributionData.Series.Values.Where(x => x.XValue <= (retObj.P50Estimate + 0.05))
                //    .Select(obj => new { obj, diff = obj.XValue - (retObj.P50Estimate + 0.05) })
                //    .OrderByDescending(p => p.diff).First().obj.YValue;
                //retObj.ProbabilityDensityP90EstimateY = probabilityDisttributionData.Series.Values.Where(x => x.XValue <= (retObj.P90Estimate + 0.05))
                //    .Select(obj => new { obj, diff = obj.XValue - (retObj.P90Estimate + 0.05) })
                //    .OrderByDescending(p => p.diff).First().obj.YValue;
                //retObj.ProbabilityDensityP10EstimateY = probabilityDisttributionData.Series.Values.Where(x => x.XValue <= (retObj.P10Estimate + 0.05))
                //    .Select(obj => new { obj, diff = obj.XValue - (retObj.P10Estimate + 0.05) })
                //    .OrderByDescending(p => p.diff).First().obj.YValue;

                //#endregion
                //retObj.ProbabilityDensityData = probabilityDisttributionData;


                ////var probabilityOfUnderrunList = new string[] {"0%","1%","5%","10%","15%","20%","25%","30%","35%","40%","45%",
                ////    "50%","55%","60%","65%","70%","75%","80%","85%","90%","95%","99%","100%" };

                ////for now keep it decimal, will consider string later
                //var probabilityOfUnderrunList = new decimal[] {0,1,5,10,15,20,25,30,35,40,45,50,
                //    55,60,65,70,75,80,85,90,95,99,100 };

                //var cumProbabilityData = new ChartSeriesXYDto<double, double>();
                //cumProbabilityData.Title = "Cum. Probability";

                //List<CraReportCostRangeDto> costRangeTable = new List<CraReportCostRangeDto>();
                //var sCurveValues = await _unitOfWork.SCurveCalcsRepository.Filter(x => x.PositiveAccurary == accuracy_LookUp).ToListAsync();
                //for (var i = 0; i < probabilityOfUnderrunList.Length; i++)
                //{
                //    CraReportCostRangeDto costRangeRow = new CraReportCostRangeDto();

                //    costRangeRow.ProbabilityOfUnderRun = probabilityOfUnderrunList[i];
                //    costRangeRow.IndicatedFundingAmount = decimal.Parse(sCurveValues.Where(x => x.Percent == (probabilityOfUnderrunList[i] / 100).ToString()).FirstOrDefault().Value) * (decimal)retObj.P50Estimate / 100.0M;
                //    costRangeRow.EstimatedContingency = costRangeRow.IndicatedFundingAmount - query.BaseEstimate;
                //    costRangeRow.PercentageOfBaseEstimate = 100 * costRangeRow.IndicatedFundingAmount / query.BaseEstimate;

                //    costRangeTable.Add(costRangeRow);

                //    var ps = new XYValue<double, double> { XValue = (double)costRangeRow.IndicatedFundingAmount, YValue = (double)costRangeRow.ProbabilityOfUnderRun };

                //    cumProbabilityData.Series.Add(i.ToString(), ps);

                //    //cs.Series.Add(s, ps);
                //}

                //retObj.CumProbabilityP50EstimateY = cumProbabilityData.Series.Values.Where(x => x.XValue <= (retObj.P50Estimate + 0.05))
                //    .Select(obj => new { obj, diff = obj.XValue - (retObj.P50Estimate + 0.05) })
                //    .OrderByDescending(p => p.diff).First().obj.YValue;
                //retObj.CumProbabilityP90EstimateY = cumProbabilityData.Series.Values.Where(x => x.XValue <= (retObj.P90Estimate + 0.05))
                //    .Select(obj => new { obj, diff = obj.XValue - (retObj.P90Estimate + 0.05) })
                //    .OrderByDescending(p => p.diff).First().obj.YValue;
                //retObj.CumProbabilityP10EstimateY = cumProbabilityData.Series.Values.Where(x => x.XValue <= (retObj.P10Estimate + 0.05))
                //    .Select(obj => new { obj, diff = obj.XValue - (retObj.P10Estimate + 0.05) })
                //    .OrderByDescending(p => p.diff).First().obj.YValue;


                //retObj.CostRangeTable = costRangeTable;
                //retObj.CumProbabilityData = cumProbabilityData;

                //return retObj;
            }





        }



    }
}
