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
    public class GetProjectExcelDataById : IRequest<ExcelRootDto>
    {

        public Guid RevisionId { get; set; }


        public class GetExcelDataByIdQueryHandler : IRequestHandler<GetProjectExcelDataById, ExcelRootDto>
        {
            private readonly ICosmosDbService _db;
            private readonly ICosmosWellService _well;
            public GetExcelDataByIdQueryHandler(ICosmosDbService db, ICosmosWellService well)
            {
                _db = db;
                _well = well;
            }
            public async Task<ExcelRootDto> Handle(GetProjectExcelDataById query, CancellationToken cancellationToken)
            {
                var retObj = new ExcelRootDto();
                var jsObject = new ExcelCFPlusDto();

                
                // await _db.AddItemAsync(CoeInputObject, request.RevisionId.ToString());
                jsObject = await _well.GetItemAsync(query.RevisionId.ToString());

                //check if empty, then return empty
                if (jsObject == null) return retObj;

                retObj.HydrocarbonType = jsObject.CoeInput.HydrocarbonType;

                retObj.ProductionStartYear = jsObject.CoeInput.ProductionStartYear;
                retObj.ProductionLife = jsObject.CoeInput.ProductionLife;
                retObj.GasOilRatio = jsObject.CoeInput.GOR;
                retObj.LiquidGasRatio = jsObject.CoeInput.LGR;
                retObj.Location = jsObject.CoeInput.Location;
                retObj.CoordinateLat = jsObject.CoeInput.CoordinateLat;
                retObj.CoordinateLon = jsObject.CoeInput.CoordinateLon;
                //retObj.CondensateGasRatio = jsObject.CoeInput.c;
                retObj.WaxAppearanceTemperature = jsObject.CoeInput.WAT;
                //retObj.APIGravity = jsObject.CoeInput.ApiGravity;
                retObj.NumberofDrillingCenter = jsObject.CoeInput.NumberofDrillingCenter;

                var gasRateColumnTitle = "GAS RATE (NAG)";
                if (retObj.HydrocarbonType == "Oil")
                {
                    gasRateColumnTitle = "GAS RATE (AG)";
                }

                for (var i = 1; i <= retObj.NumberofDrillingCenter; i++)
                {
                    var jsDcDetail = jsObject.CoeInput.DrillingCenter[i - 1];
                    var dc = new ExcelDcDetail();
                    dc.DcName = "DC " + i;
                    dc.Nature = jsDcDetail.Nature;
                    dc.TieInLocation =jsDcDetail.TieInLocation;
                    dc.TieInLocationDistance = jsDcDetail.Distance;
                    if (retObj.HydrocarbonType == "Oil")
                    {
                        dc.HcProducers.MinValue = new[] { jsDcDetail.P10.OilProducerWell, jsDcDetail.P50.OilProducerWell, jsDcDetail.P90.OilProducerWell }.Min();
                        dc.HcProducers.MaxValue = new[] { jsDcDetail.P10.OilProducerWell, jsDcDetail.P50.OilProducerWell, jsDcDetail.P90.OilProducerWell }.Max();
                        //Math.Max(jsDcDetail.P10.OilProducerWell, Math.Max(jsDcDetail.P50.OilProducerWell, jsDcDetail.P90.OilProducerWell));

                        dc.HcInitialProduction.MinValue = GetMaxValueOfSheetOfDc(jsObject.P90Sheet, dc.DcName, "OIL RATE");
                        dc.HcInitialProduction.MaxValue = GetMaxValueOfSheetOfDc(jsObject.P10Sheet, dc.DcName, "OIL RATE");
                    }
                    else
                    {
                        dc.HcProducers.MinValue = new[] { jsDcDetail.P10.GasProducerWell, jsDcDetail.P50.GasProducerWell, jsDcDetail.P90.GasProducerWell }.Min();
                        dc.HcProducers.MaxValue = new[] { jsDcDetail.P10.GasProducerWell, jsDcDetail.P50.GasProducerWell, jsDcDetail.P90.GasProducerWell }.Max();
                        //Math.Max(jsDcDetail.P10.GasProducerWell, Math.Max(jsDcDetail.P50.GasProducerWell, jsDcDetail.P90.GasProducerWell));

                        dc.HcInitialProduction.MinValue = GetMaxValueOfSheetOfDc(jsObject.P90Sheet, dc.DcName, gasRateColumnTitle);
                        dc.HcInitialProduction.MaxValue = GetMaxValueOfSheetOfDc(jsObject.P10Sheet, dc.DcName, gasRateColumnTitle);
                    }

                    //dc.Fthp.MinValue = GetMinValueOfSheetOfDc(jsObject.P10Sheet, dc.DcName, "FTHP");//Abandonment Pressure (Sasi will update excel)
                    dc.Fthp.MinValue = jsObject.CoeInput.AbandonmentPressure;

                    if (jsObject.CoeInput.HydrocarbonType == "Gas" || jsObject.CoeInput.HydrocarbonType == "Oil")
                    {
                        dc.Fthp.MaxValue = GetMaxValueOfSheetOfDc(jsObject.P10Sheet, dc.DcName, "FTHP");

                        dc.Ftht.MinValue = GetMinValueOfDc(jsObject, dc.DcName, "FTHT");
                        dc.Ftht.MaxValue = GetMaxValueOfDc(jsObject, dc.DcName, "FTHT");
                    }
                    else
                    {
                        //oil
                        var oilFthpMaxValue = GetMaxValueOfSheetOfDc(jsObject.P10Sheet, dc.DcName, "OIL FTHP");
                        var oilFthtMinValue = GetMinValueOfDc(jsObject, dc.DcName, "OIL FTHT");
                        var oilFthtMaxValue = GetMaxValueOfDc(jsObject, dc.DcName, "OIL FTHT");

                        //gas
                        var gasFthpMaxValue = GetMaxValueOfSheetOfDc(jsObject.P10Sheet, dc.DcName, "GAS FTHP");
                        var gasFthtMinValue = GetMinValueOfDc(jsObject, dc.DcName, "GAS FTHT");
                        var gasFthtMaxValue = GetMaxValueOfDc(jsObject, dc.DcName, "GAS FTHT");

                        dc.Fthp.MaxValue = new[] { oilFthpMaxValue, gasFthpMaxValue }.Max();

                        dc.Ftht.MinValue = new[] { oilFthtMinValue, gasFthtMinValue }.Min();
                        dc.Ftht.MaxValue = new[] { oilFthtMaxValue, gasFthtMaxValue }.Max();

                    }

                    dc.Cithp = jsDcDetail.CITHP;
                    dc.APIGravity = jsDcDetail.MaxOilItem.APIGravity; //jsObject.CoeInput.ApiGravity;
                    dc.ArtificialLift = jsDcDetail.ArtificialLiftType;//need updated excel

                    dc.GaxFlowRatePerwell.MinValue = GetMinValueOfDc(jsObject, dc.DcName, gasRateColumnTitle);
                    dc.GaxFlowRatePerwell.MaxValue = GetMaxValueOfDc(jsObject, dc.DcName, gasRateColumnTitle);

                    dc.MaxSurfaceInjectionPressure = 0.0M;//need updated excel

                    //IMPROVED RECOVERY (WATER INJECTION)
                    dc.IRWI_NumberOfWells.MinValue = new[] { jsDcDetail.P10.WaterInjectorWell, jsDcDetail.P50.WaterInjectorWell, jsDcDetail.P90.WaterInjectorWell }.Min();
                    //Math.Min(jsDcDetail.P10.WaterInjectorWell, Math.Min(jsDcDetail.P50.WaterInjectorWell, jsDcDetail.P90.WaterInjectorWell));
                    dc.IRWI_NumberOfWells.MaxValue = new[] { jsDcDetail.P10.WaterInjectorWell, jsDcDetail.P50.WaterInjectorWell, jsDcDetail.P90.WaterInjectorWell }.Max();
                    //Math.Max(jsDcDetail.P10.WaterInjectorWell, Math.Max(jsDcDetail.P50.WaterInjectorWell, jsDcDetail.P90.WaterInjectorWell));


                    dc.IRWI_InjectionFlowRate = GetMaxValueOfDc(jsObject, dc.DcName, "WATER INJECTION RATE");
                    dc.IRWI_SurfaceInjectionPressure = GetMaxValueOfDc(jsObject, dc.DcName, "WATER INJECTION PRESSURE");
                    dc.IRWI_HasValue = (dc.IRWI_NumberOfWells.MinValue != null || dc.IRWI_NumberOfWells.MaxValue != null
                        || dc.IRWI_InjectionFlowRate != null || dc.IRWI_SurfaceInjectionPressure != null);

                    //IMPROVED RECOVERY (GAS INJECTION)
                    dc.IRGI_NumberOfWells.MinValue = new[] { jsDcDetail.P10.GasInjectorWell, jsDcDetail.P50.GasInjectorWell, jsDcDetail.P90.GasInjectorWell }.Min();
                    dc.IRGI_NumberOfWells.MaxValue = new[] { jsDcDetail.P10.GasInjectorWell, jsDcDetail.P50.GasInjectorWell, jsDcDetail.P90.GasInjectorWell }.Max();
                    dc.IRGI_InjectionFlowRate = GetMaxValueOfDc(jsObject, dc.DcName, "GAS INJECTION RATE");
                    dc.IRGI_SurfaceInjectionPressure = GetMaxValueOfDc(jsObject, dc.DcName, "GAS INJECTION PRESSURE");
                    dc.IRGI_HasValue = (dc.IRGI_NumberOfWells.MinValue != null || dc.IRGI_NumberOfWells.MaxValue != null
                        || dc.IRGI_InjectionFlowRate != null || dc.IRGI_SurfaceInjectionPressure != null);


                    dc.Co2 = new[] { jsDcDetail.MaxOilItem.CarbonDioxide, decimal.Parse(jsDcDetail.MaxGasItem.CarbonDioxide) }.Max();
                    dc.H2s = new[] { jsDcDetail.MaxOilItem.HydrogenSulphide, jsDcDetail.MaxGasItem.HydrogenSulphide }.Max();
                    dc.Mercury = new[] { jsDcDetail.MaxOilItem.Mercury, jsDcDetail.MaxGasItem.Mercury }.Max(); //jsDcDetail.Mercury;
                    dc.WaxAppearanceTemperature = jsDcDetail.MaxOilItem.WAT;// new[] { jsDcDetail.MaxOilItem.WAT, jsDcDetail.MaxGasItem.wa }.Max(); //jsObject.CoeInput.WAT;
                    dc.Mercaptan = new[] { jsDcDetail.MaxOilItem.Mercaptan, jsDcDetail.MaxGasItem.Mercaptan }.Max();
                    dc.Salt = jsDcDetail.MaxOilItem.Salt;

                    retObj.DcList.Add(dc);
                }


                #region chart data
                //chart series data/
                var chartTitles = new string[] { "Oil Production Rate", "Gas Production Rate", "Water Production Rate", "Gas Condensate Rate" };
                //var jsonProperty = new string[] { "OIL RATE", gasRateColumnTitle, "PRODUCED WATER RATE", "CONDENSATE RATE" };
                var jsonProperty = new Dictionary<string, string[]>();// { "OIL RATE", gasRateColumnTitle, "PRODUCED WATER RATE", "CONDENSATE RATE" };
                jsonProperty["Oil Production Rate"] = new string[] { "OIL RATE" };
                jsonProperty["Gas Production Rate"] = new string[] { "GAS RATE (AG)","GAS RATE (AG)"  };
                jsonProperty["Water Production Rate"] = new string[] { "PRODUCED WATER RATE","PRODUCED WATER RATE FOR OIL WELL", "PRODUCED WATER RATE FOR GAS WELL" };
                jsonProperty["Gas Condensate Rate"] = new string[] { "CONDENSATE RATE" };
                var series = new string[] { "P10", "P50", "P90" };

                var titleIndex = 0;
                foreach (var title in chartTitles)
                {
                    var cs = new ChartSeries();
                    cs.Title = title;
                    foreach (var s in series)
                    {
                        var ps = new Dictionary<string, decimal?>();
                        
                        for (var i = 0; i < jsObject.CoeInput.ProductionLife; i++)
                        {

                            for (var j = 0; j < 12; j++)
                            {
                                string monthName = new DateTime(2010, j + 1, 1).ToString("MMM", CultureInfo.InvariantCulture);
                                var monthYearValue = monthName + "-" + ((int)jsObject.CoeInput.ProductionStartYear + (int)i).ToString();
                                decimal? value = 0.0M;
                                if (s == "P10")
                                {
                                    //value = GetSumOfAllDc(jsObject.P10Sheet, monthYearValue, jsonProperty[titleIndex]);
                                    foreach (var jp in jsonProperty[title])
                                    {
                                        value+= GetSumOfAllDc(jsObject.P10Sheet, monthYearValue, jp)??0.0M;
                                    }
                                }
                                else if (s == "P50")
                                {
                                    //value = GetSumOfAllDc(jsObject.P50Sheet, monthYearValue, jsonProperty[titleIndex]);
                                    foreach (var jp in jsonProperty[title])
                                    {
                                        value += GetSumOfAllDc(jsObject.P10Sheet, monthYearValue, jp) ?? 0.0M;
                                    }
                                }
                                else
                                {
                                    //value = GetSumOfAllDc(jsObject.P90Sheet, monthYearValue, jsonProperty[titleIndex]);
                                    foreach (var jp in jsonProperty[title])
                                    {
                                        value += GetSumOfAllDc(jsObject.P10Sheet, monthYearValue, jp) ?? 0.0M;
                                    }

                                }
                                ps.Add(monthYearValue, value);

                            }
                        }

                        cs.Series.Add(s, ps);
                    }
                    retObj.ChartsData.Add(cs);
                    titleIndex++;
                }
                /*
                var chardSeriesObjOilRate = new ChartSeries();
                chardSeriesObjOilRate.Title = "Oil Production Rate";
                var jsonPropertyNameOilRate = "OIL RATE";

                var chardSeriesObjGasRate = new ChartSeries();
                chardSeriesObjGasRate.Title = "Gas Production Rate";
                var jsonPropertyNameGasRate = gasRateColumnTitle;

                var chardSeriesObjWaterProductionRate = new ChartSeries();
                chardSeriesObjWaterProductionRate.Title = "Water Production Rate";
                var jsonPropertyNameProductionRate = "PRODUCED WATER RATE";

                var chardSeriesObjGasCondensateRate = new ChartSeries();
                chardSeriesObjGasCondensateRate.Title = "Gas Condensate Rate";
                var jsonPropertyNameGasCondensateRate = "CONDENSATE RATE";

                for (var i = 0; i < jsObject.CoeInput.ProductionLife; i++)
                {

                    for (var j = 0; j < 12; j++)
                    {


                        string monthName = new DateTime(2010, j + 1, 1).ToString("MMM", CultureInfo.InvariantCulture);
                        var sName = monthName + "-" + ((int)jsObject.CoeInput.ProductionStartYear + (int)i).ToString();
                        decimal value = (1 * j + 100) * 10;
                        //decimal value = jsObject.P10Sheet.FirstOrDefault(x => x.Type == jsonPropertyName)
                        //    .DrillingCenter.Select(x => x.ListDataOfWell.Where(y => y.Month == monthName)
                        //            .Select(y => y.Total))).Sum();
                        chardSeriesObjOilRate.Values.Add(sName, GetSumOfAllDc(jsObject.P10Sheet, sName, "OIL RATE"));
                        chardSeriesObjGasRate.Values.Add(sName, value + 20);
                        chardSeriesObjWaterProductionRate.Values.Add(sName, value + 40);
                        chardSeriesObjGasCondensateRate.Values.Add(sName, value + 60);
                    }

                }
                retObj.ChartsData.Add(chardSeriesObjOilRate);
                retObj.ChartsData.Add(chardSeriesObjGasRate);
                retObj.ChartsData.Add(chardSeriesObjWaterProductionRate);
                retObj.ChartsData.Add(chardSeriesObjGasCondensateRate);

                */
                #endregion

                //if HC = Oil, graphs are Oil Production Rate, Water Production Rate, Gas Production Rate
                //if HC = Gas, graphs are Gas Production Rate, Water Production Rate, Gas Condensate Rate
                //var oilProductionRate = jsObject.P10Sheet.FirstOrDefault(x => x.Type == "OIL RATE").DrillingCenter
                //    .Select(y => y.ListDataOfWell.Select(x => new { Month = x.Month, Value = x.Total })).ToList();
                return retObj;
            }


            private decimal? GetMinValueOfDc(ExcelCFPlusDto jsObject, string dcName, string fieldName)
            {
                var minP10 = GetMinValueOfSheetOfDc(jsObject.P10Sheet, dcName, fieldName);
                var minP50 = GetMinValueOfSheetOfDc(jsObject.P50Sheet, dcName, fieldName);
                var minP90 = GetMinValueOfSheetOfDc(jsObject.P90Sheet, dcName, fieldName);

                return new[] { minP10, minP50, minP90 }.Min();//Math.Min(minP10.Value, Math.Min(mMinP50.Value, minP90.Value)); 
            }

            private decimal? GetMaxValueOfDc(ExcelCFPlusDto jsObject, string dcName, string fieldName)
            {
                var maxP10 = GetMaxValueOfSheetOfDc(jsObject.P10Sheet, dcName, fieldName);
                var maxP50 = GetMaxValueOfSheetOfDc(jsObject.P50Sheet, dcName, fieldName);
                var maxP90 = GetMaxValueOfSheetOfDc(jsObject.P90Sheet, dcName, fieldName);

                return new[] { maxP10, maxP50, maxP90 }.Max();//Math.Max(maxP10.Value, Math.Max(maxP50.Value, maxP90.Value));
            }

            private decimal? GetSumOfAllDc(List<ExcelPPDto> sheet, string monthYearValue, string fieldName)
            {
                var sum = sheet.FirstOrDefault(x => x.Type == fieldName)?
                    .DrillingCenter
                    .Select(x => x.ListDataOfWell.Where(y => y.Month == monthYearValue)?.Select(y => y.Total)?.Sum())?
                    .Sum();
                return sum;//Math.Max(maxP10.Value, Math.Max(maxP50.Value, maxP90.Value));
            }
            private decimal? GetMinValueOfSheetOfDc(List<ExcelPPDto> sheet, string dcName, string fieldName)
            {
                return sheet.FirstOrDefault(x => x.Type == fieldName)?
                    .DrillingCenter.Where(x => x.Name == dcName)?
                    .Select(x => x.ListDataOfWell?.Select(y => y.WellValue?.Min())?.Min())?
                    .Min();

            }

            private decimal? GetMaxValueOfSheetOfDc(List<ExcelPPDto> sheet, string dcName, string fieldName)
            {
                return sheet.FirstOrDefault(x => x.Type == fieldName)?
                    .DrillingCenter.Where(x => x.Name == dcName)?
                    .Select(x => x.ListDataOfWell?.Select(y => y.WellValue?.Max())?.Max())?
                    .Max();

            }



        }



    }
}
