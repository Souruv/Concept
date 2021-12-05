using AutoMapper;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Entities.Base;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Commands
{
    public class UploadExcelCommand : IRequest<bool>
    {

        public Guid RevisionId { get; set; }
        public IFormFile File { get; set; }


        public class UploadExcelCommandHandler : IRequestHandler<UploadExcelCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ICosmosDbService _db;
            private readonly ICosmosWellService _well;
            private readonly ILoggedInUserService _loggedInUserService;

            private readonly IUtcCostService _utcCostService;
            public UploadExcelCommandHandler(IUnitOfWork unitOfWork, ICosmosDbService db, ICosmosWellService well, ILoggedInUserService loggedInUserService
                , IUtcCostService utcCostService)
            {
                _unitOfWork = unitOfWork;
                _db = db;
                _well = well;
                _loggedInUserService = loggedInUserService;
                _utcCostService = utcCostService;
            }
            public async Task<bool> Handle(UploadExcelCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var CoeInputObject = new ExcelFieldsDataDto();
                    var PPSheets = new ExcelCFPlusDto();
                    var PP10Object = new List<ExcelPPDto>();
                    var PP50Object = new List<ExcelPPDto>();
                    var PP90Object = new List<ExcelPPDto>();
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (var package = new ExcelPackage(request.File.OpenReadStream()))
                    {
                        //read data CoeInput
                        CoeInputObject = ReadCoeInput(package, request.RevisionId);
                        //read data P10 Sheet
                        // the max rows of PPSheet
                        int numberOfRows = 4 + (int)CoeInputObject.ProductionLife * 12;
                        PP10Object = ReadDataPPSheet(package, CoeInputObject, 1, numberOfRows);
                        PPSheets.P10Sheet = PP10Object;
                        //read data P50 Sheet
                        PP50Object = ReadDataPPSheet(package, CoeInputObject, 2, numberOfRows);
                        PPSheets.P50Sheet = PP50Object;
                        //read data P50 Sheet
                        PP90Object = ReadDataPPSheet(package, CoeInputObject, 3, numberOfRows);
                        PPSheets.P90Sheet = PP90Object;

                        PPSheets.Id = request.RevisionId;

                        PPSheets.CoeInput = CoeInputObject;
                    }



                    //insert fields data
                    var fieldsData = StoreFieldsData(CoeInputObject);
                    var fieldsDataExisting = await _unitOfWork.FieldsDataRepository.Filter(x => x.ProjectRevisionId == request.RevisionId).FirstOrDefaultAsync();
                    if (fieldsDataExisting == null)
                    {
                        fieldsData.ProjectRevisionId = request.RevisionId;
                        _unitOfWork.FieldsDataRepository.Insert(fieldsData);
                    }
                    else
                    {
                        fieldsData.Id = fieldsDataExisting.Id;
                        fieldsData.ProjectRevisionId = fieldsDataExisting.ProjectRevisionId;
                        fieldsData.CreatedByUserId = fieldsDataExisting.CreatedByUserId;
                        _unitOfWork.FieldsDataRepository.Update(fieldsData);
                    }

                    // insert enviromental data
                    var enviromental = StoreEnviromental(CoeInputObject);
                    var enviromentalDataExisting = await _unitOfWork.EnviromentalRepository.Filter(x => x.ProjectRevisionId == request.RevisionId).FirstOrDefaultAsync();
                    if (enviromentalDataExisting == null)
                    {
                        enviromental.ProjectRevisionId = request.RevisionId;
                        _unitOfWork.EnviromentalRepository.Insert(enviromental);
                    }
                    else
                    {
                        enviromental.Id = enviromentalDataExisting.Id;
                        enviromental.ProjectRevisionId = enviromentalDataExisting.ProjectRevisionId;
                        enviromental.CreatedByUserId = enviromentalDataExisting.CreatedByUserId;
                        _unitOfWork.EnviromentalRepository.Update(enviromental);
                    }

                    //insert list drilling and p10,p50,p90
                    var drilling = StoreDrillingCenter(CoeInputObject.DrillingCenter);
                    for (int i = 0; i < drilling.Count; i++)
                    {
                        var drillingExisting = await _unitOfWork.DrillingCenterRepository.Filter(x => x.Name == ("DC " + $"{i + 1}") && x.ProjectRevisionId == request.RevisionId).FirstOrDefaultAsync();
                        //insert or update drilling center
                        if (drillingExisting == null)
                        {
                            drilling[i].ProjectRevisionId = request.RevisionId;
                            drilling[i].Id = Guid.NewGuid();
                            _unitOfWork.DrillingCenterRepository.Insert(drilling[i]);
                        }
                        else
                        {
                            drilling[i].Id = drillingExisting.Id;
                            drilling[i].CreatedByUserId = drillingExisting.CreatedByUserId;
                            drilling[i].ProjectRevisionId = drillingExisting.ProjectRevisionId;
                            _unitOfWork.DrillingCenterRepository.Update(drilling[i]);
                        }
                        var p10Existing = await _unitOfWork.CoeInputP10Repository.Filter(x => x.DrillingCenterId == drilling[i].Id).FirstOrDefaultAsync();
                        var p50Existing = await _unitOfWork.CoeInputP50Repository.Filter(x => x.DrillingCenterId == drilling[i].Id).FirstOrDefaultAsync();
                        var p90Existing = await _unitOfWork.CoeInputP90Repository.Filter(x => x.DrillingCenterId == drilling[i].Id).FirstOrDefaultAsync();

                        //insert p10,p50,p90
                        var p10 = StorePPSheet<CoeInputP10>(PP10Object, i + 1);
                        if (p10Existing == null)
                        {
                            p10.DrillingCenterId = drilling[i].Id;
                            _unitOfWork.CoeInputP10Repository.Insert(p10);
                        }
                        else
                        {
                            p10.Id = p10Existing.Id;
                            p10.CreatedByUserId = p10Existing.CreatedByUserId;
                            p10.DrillingCenterId = p10Existing.DrillingCenterId;
                            _unitOfWork.CoeInputP10Repository.Update(p10);
                        }

                        var p50 = StorePPSheet<CoeInputP50>(PP50Object, i + 1);
                        if (p50Existing == null)
                        {
                            p50.DrillingCenterId = drilling[i].Id;
                            _unitOfWork.CoeInputP50Repository.Insert(p50);
                        }
                        else
                        {
                            p50.Id = p50Existing.Id;
                            p50.CreatedByUserId = p50Existing.CreatedByUserId;
                            p50.DrillingCenterId = p50Existing.DrillingCenterId;
                            _unitOfWork.CoeInputP50Repository.Update(p50);
                        }

                        var p90 = StorePPSheet<CoeInputP90>(PP90Object, i + 1);
                        if (p90Existing == null)
                        {
                            p90.DrillingCenterId = drilling[i].Id;
                            _unitOfWork.CoeInputP90Repository.Insert(p90);
                        }
                        else
                        {
                            p90.Id = p90Existing.Id;
                            p90.CreatedByUserId = p90Existing.CreatedByUserId;
                            p90.DrillingCenterId = p90Existing.DrillingCenterId;
                            _unitOfWork.CoeInputP90Repository.Update(p90);
                        }
                    }
                    await _unitOfWork.CommitAsync();

                    //return PPSheets;
                    await _db.AddItemAsync(CoeInputObject, request.RevisionId.ToString());

                    await _well.AddItemAsync(PPSheets, PPSheets.Id.ToString());

                    var projectInvision = await _unitOfWork.RevisionRepository.GetSingleAsync(x => x.Id == request.RevisionId);
                    if (projectInvision.TargetUnitTechnicalCost == null)
                    {
                        projectInvision.UtcCountry = "default";
                        projectInvision.TargetUnitTechnicalCost = await _utcCostService.GetDefaultUtcCost(request.RevisionId);
                    }

                    _unitOfWork.RevisionRepository.Update(projectInvision);

                    var projectId = projectInvision.ProjectId;
                    //// update project
                    var project = await _unitOfWork.ProjectRepository.GetSingleAsync(x => x.Id == projectId);
                    project.FileName = request.File.FileName;
                    _unitOfWork.ProjectRepository.Update(project);

                    await _unitOfWork.CommitAsync();

                    //return CoeInputObject;
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// store fields data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static FieldsData StoreFieldsData(ExcelFieldsDataDto data)
        {
            var fieldsData = new FieldsData()
            {
                HydrocacbornType = data.HydrocarbonType,
                HydrocacbornTypeUnit = data.HydrocarbonTypeUnit,
                NumberOfDriliingCenter = data.NumberofDrillingCenter,
                ProductStartYear = data.ProductionStartYear,
                ProductionLife = data.ProductionLife,
                ProductionLifeUnit = data.ProductionLifeUnit,
                AbandonmentPressure = data.AbandonmentPressure,
                AbandonmentPressureUnit = data.AbandonmentPressureUnit,
                AvailabilityWater = data.AvailabilityWaterDisposalReservoir,
                WaterDisposalLocation = data.WaterDisposalLocation,
                AvailabilityNAG = data.AvailabilityNAGReservoir,
                AvailabilityNearbyField = data.AvailabilityNAGReservoir,
                AvailableAmountOfGas = data.AvailableAmountGasTobeSupplied,
                AvailableAmountOfGasUnit = data.AvailableAmountGasTobeSuppliedUnit,
                OperatingPressure = data.OperatingPressure,
                OperatingPressureUnit = data.OperatingPressureUnit,
                GasDisposalByReinjection = data.GasDisposalByReinjection
            };
            return fieldsData;
        }
        /// <summary>
        /// store pp sheet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sheet"></param>
        /// <param name="numberOfDc"></param>
        /// <returns></returns>
        private static T StorePPSheet<T>(List<ExcelPPDto> sheet, int numberOfDc) where T : BasePP
        {
            var ppData = new BasePP()
            {
                OilRateMax = GetMaxValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "OIL RATE"),
                OilRateMin = GetMinValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "OIL RATE"),

                GasRateAGMax = GetMaxValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "GAS RATE (AG)"),
                GasRateAGMin = GetMinValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "GAS RATE (AG)"),

                WaterRateOilMax = GetMaxValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "PRODUCED WATER RATE FOR OIL WELL"),
                WaterRateOilMin = GetMinValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "PRODUCED WATER RATE FOR OIL WELL"),

                OilFTHPMax = GetMaxValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "OIL FTHP"),
                OilFTHPMin = GetMinValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "OIL FTHP"),

                OilFTHTMax = GetMaxValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "OIL FTHT"),
                OilFTHTMin = GetMinValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "OIL FTHT"),

                GasRateNAGMax = GetMaxValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "GAS RATE (NAG)"),
                GasRateNAGMin = GetMinValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "GAS RATE (NAG)"),

                CondensateRateMax = GetMaxValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "CONDENSATE RATE"),
                CondensateRateMin = GetMinValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "CONDENSATE RATE"),

                WaterRateGasMax = GetMaxValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "PRODUCED WATER RATE FOR GAS WELL"),
                WaterRateGasMin = GetMinValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "PRODUCED WATER RATE FOR GAS WELL"),

                GasFTHPMax = GetMaxValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "GAS FTHP"),
                GasFTHPMin = GetMinValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "GAS FTHP"),

                GasFTHTMax = GetMaxValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "GAS FTHT"),
                GasFTHTMin = GetMinValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "GAS FTHT"),

                WaterInjectionRateMax = GetMaxValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "WATER INJECTION RATE"),
                WaterInjectionRateMin = GetMinValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "WATER INJECTION RATE"),

                WaterInjectionPressureMax = GetMaxValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "WATER INJECTION PRESSURE"),
                WaterInjectionPressureMin = GetMinValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "WATER INJECTION PRESSURE"),

                GasInjectionRateMax = GetMaxValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "GAS INJECTION RATE"),
                GasInjectionRateMin = GetMinValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "GAS INJECTION RATE"),

                GasInjectionPressureMax = GetMaxValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "GAS INJECTION PRESSURE"),
                GasInjectionPressureMin = GetMinValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "GAS INJECTION PRESSURE"),


                GasLiftRateMax = GetMaxValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "GAS LIFT RATE"),
                GasLiftRateMin = GetMinValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "GAS LIFT RATE"),


                GasLiftPressureMax = GetMaxValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "GAS LIFT PRESSURE"),
                GasLiftPressureMin = GetMinValueOfSheetOfDc(sheet, "DC " + $"{numberOfDc}", "GAS LIFT PRESSURE"),

            };
            //return (T)Activator.CreateInstance(typeof(T),ppData);
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(ppData));
        }
        private static decimal? GetMaxValueOfSheetOfDc(List<ExcelPPDto> sheet, string dcName, string header)
        {
            return sheet.FirstOrDefault(x => x.Type == header)?
                .DrillingCenter.Where(x => x.Name == dcName)?
                .Select(x => x.ListDataOfWell?.Select(y => y.WellValue?.Max())?.Max())?.Max();
        }

        /// <summary>
        /// return min value of all dc base on the header
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="dcName"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        private static decimal? GetMinValueOfSheetOfDc(List<ExcelPPDto> sheet, string dcName, string header)
        {
            return sheet.FirstOrDefault(x => x.Type == header)?
                .DrillingCenter.Where(x => x.Name == dcName)?
                .Select(x => x.ListDataOfWell?.Select(y => y.WellValue?.Min())?.Min())?.Min();
        }

        /// <summary>
        /// store enviromental
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static Enviromental StoreEnviromental(ExcelFieldsDataDto data)
        {
            var enviromental = new Enviromental()
            {
                Location = data.Location,
                CoordinateLat = data.CoordinateLat,
                CoordinateLon = data.CoordinateLon,
                AmbientTemperatureMin = data.AmbientTemperatureMin,
                AmbientTemperatureMinUnit = data.AmbientTemperatureMinUnit,
                AmbientTemperatureMax = data.AmbientTemperatureMax,
                AmbientTemperatureMaxUnit = data.AmbientTemperatureMaxUnit,
                SeabedTemperatureMin = data.SeabedTemperatureMin,
                SeabedTemperatureMinUnit = data.SeabedTemperatureMinUnit,
                SeabedTemperatureMax = data.SeabedTemperatureMax,
                SeabedTemperatureMaxUnit = data.SeabedTemperatureMaxUnit,
            };
            return enviromental;
        }
        /// <summary>
        /// store drillingcenterdata
        /// </summary>
        /// <param name="drillingData"></param>
        /// <returns></returns>
        private static List<DrillingCenterData> StoreDrillingCenter(List<ExcelDrillingCenterDto> drillingData)
        {
            List<DrillingCenterData> datas = new List<DrillingCenterData>();
            foreach (var item in drillingData)
            {
                var data = new DrillingCenterData()
                {
                    Name = item.Name,
                    HydroCarbonType = item.HyDroCarbonType,
                    HydroCarbonTypeUnit = item.HyDroCarbonTypeUnit,
                    WaterDepth = item.WaterDepth,
                    WaterDepthUnit = item.WaterDepthUnit,
                    Nature = item.Nature,
                    NatureUnit = item.NatureUnit,
                    CITHP = item.CITHP,
                    CITHPUnit = item.CITHPUnit,
                    TieInLocation = item.TieInLocation,
                    TieInLocationUnit = item.TieInLocationUnit,
                    Distance = item.Distance,
                    DistanceUnit = item.DistanceUnit,
                    ArtificialLiftType = item.ArtificialLiftType,
                    ArtificialLiftTypeUnit = item.ArtificialLiftTypeUnit,
                    PowerRequirementPerWell = item.PowerRequirementPerWell,
                    PowerRequirementPerWellUnit = item.PowerRequirementPerWellUnit,
                    P10_OilProducerWell = item.P10.OilProducerWell,
                    P10_GasProducerWell = item.P10.GasProducerWell,
                    P10_WaterInjectorWell = item.P10.WaterInjectorWell,
                    P10_GasInjectorWell = item.P10.GasInjectorWell,
                    P10_GasLiftWell = item.P10.GasLiftWell,
                    P10_PumpedWell = item.P10.PumpedWell,

                    P50_OilProducerWell = item.P50.OilProducerWell,
                    P50_GasProducerWell = item.P50.GasProducerWell,
                    P50_WaterInjectorWell = item.P50.WaterInjectorWell,
                    P50_GasInjectorWell = item.P50.GasInjectorWell,
                    P50_GasLiftWell = item.P50.GasLiftWell,
                    P50_PumpedWell = item.P50.PumpedWell,

                    P90_OilProducerWell = item.P90.OilProducerWell,
                    P90_GasProducerWell = item.P90.GasProducerWell,
                    P90_WaterInjectorWell = item.P90.WaterInjectorWell,
                    P90_GasInjectorWell = item.P90.GasInjectorWell,
                    P90_GasLiftWell = item.P90.GasLiftWell,
                    P90_PumpedWell = item.P90.PumpedWell,

                    MinOil_CarbonDioxide = item.MinOilItem.CarbonDioxide,
                    MinOil_CarbonDioxideUnit = item.MinOilItem.CarbonDioxideUnit,
                    MinOil_HydrogenSulphide = item.MinOilItem.HydrogenSulphide,
                    MinOil_HydrogenSulphideUnit = item.MinOilItem.HydrogenSulphideUnit,
                    MinOil_Salt = item.MinOilItem.Salt,
                    MinOil_Mercaptan = item.MinOilItem.Mercaptan,
                    MinOil_MercaptanUnit = item.MinOilItem.MercaptanUnit,
                    MinOil_Mercury = item.MinOilItem.Mercury,
                    MinOil_MercuryUnit = item.MinOilItem.MercuryUnit,
                    MinOil_WAT = item.MinOilItem.WAT,
                    MinOil_WATUnit = item.MinOilItem.WATUnit,
                    MinOil_Sand = item.MinOilItem.Sand,
                    MinOil_SandUnit = item.MinOilItem.SandUnit,
                    MinOil_ApiGravity = item.MinOilItem.APIGravity,
                    MinOil_ApiGravityUnit = item.MinOilItem.APIGravityUnit,

                    MaxOil_CarbonDioxide = item.MaxOilItem.CarbonDioxide,
                    MaxOil_CarbonDioxideUnit = item.MaxOilItem.CarbonDioxideUnit,
                    MaxOil_HydrogenSulphide = item.MaxOilItem.HydrogenSulphide,
                    MaxOil_HydrogenSulphideUnit = item.MaxOilItem.HydrogenSulphideUnit,
                    MaxOil_Salt = item.MaxOilItem.Salt,
                    MaxOil_Mercaptan = item.MaxOilItem.Mercaptan,
                    MaxOil_MercaptanUnit = item.MaxOilItem.MercaptanUnit,
                    MaxOil_Mercury = item.MaxOilItem.Mercury,
                    MaxOil_MercuryUnit = item.MaxOilItem.MercuryUnit,
                    MaxOil_WAT = item.MaxOilItem.WAT,
                    MaxOil_WATUnit = item.MaxOilItem.WATUnit,
                    MaxOil_Sand = item.MaxOilItem.Sand,
                    MaxOil_SandUnit = item.MaxOilItem.SandUnit,
                    MaxOil_ApiGravity = item.MaxOilItem.APIGravity,
                    MaxOil_ApiGravityUnit = item.MaxOilItem.APIGravityUnit,

                    MinGas_CarbonDioxide = item.MinGasItem.CarbonDioxide,
                    MinGas_CarbonDioxideUnit = item.MinGasItem.CarbonDioxideUnit,
                    MinGas_HydrogenSulphideUnit = item.MinGasItem.HydrogenSulphideUnit,
                    MinGas_HydrogenSulphide = item.MinGasItem.HydrogenSulphide,
                    MinGas_Mercaptan = item.MinGasItem.Mercaptan,
                    MinGas_MercaptanUnit = item.MinGasItem.MercaptanUnit,
                    MinGas_Mercury = item.MinGasItem.Mercury,
                    MinGas_MercuryUnit = item.MinGasItem.MercuryUnit,
                    MinGas_Sand = item.MinGasItem.Sand,
                    MinGas_SandUnit = item.MinGasItem.SandUnit,

                    MaxGas_CarbonDioxide = item.MaxGasItem.CarbonDioxide,
                    MaxGas_CarbonDioxideUnit = item.MaxGasItem.CarbonDioxideUnit,
                    MaxGas_HydrogenSulphideUnit = item.MaxGasItem.HydrogenSulphideUnit,
                    MaxGas_HydrogenSulphide = item.MaxGasItem.HydrogenSulphide,
                    MaxGas_Mercaptan = item.MaxGasItem.Mercaptan,
                    MaxGas_MercaptanUnit = item.MaxGasItem.MercaptanUnit,
                    MaxGas_Mercury = item.MaxGasItem.Mercury,
                    MaxGas_MercuryUnit = item.MaxGasItem.MercuryUnit,
                    MaxGas_Sand = item.MinGasItem.Sand,
                    MaxGas_SandUnit = item.MaxGasItem.SandUnit,

                    GOR = item.GOR,
                    GORUnit = item.GORUnit,
                    LGR = item.LGR,
                    LGRUnit = item.LGRUnit,
                    CGR = item.CGR,
                    CGRUnit = item.CGRUnit,
                    WellTestRequirement = item.WellTestRequirement,
                    WellTestRequirementUnit = item.WellTestRequirementUnit,


                };
                datas.Add(data);
            }

            return datas;
        }
        /// <summary>
        /// read data of pp sheet
        /// </summary>
        /// <param name="package"></param>
        /// <param name="CoeInputObject"></param>
        /// <param name="sheetNumber"></param>
        /// <param name="numberOfRows"></param>
        /// <returns></returns>
        private static List<ExcelPPDto> ReadDataPPSheet(ExcelPackage package, ExcelFieldsDataDto CoeInputObject, int sheetNumber, int numberOfRows)
        {
            var PPObject = new List<ExcelPPDto>();
            var sheetPP = package.Workbook.Worksheets[sheetNumber];
            var headers = sheetPP.Cells[sheetPP.Dimension.Start.Row, sheetPP.Dimension.Start.Column + 1, 1, sheetPP.Dimension.End.Column]
                .Select(firstRowCell => firstRowCell.Text).ToArray();
            headers = headers.Where(x => x != "").ToArray();
            var units = new List<string>();
            foreach (var item in headers)
            {
                units.Add(sheetPP.Cells[2, FindIndexByValue(item, sheetPP)].Value.ToString());
            }
            var drillingObject = CoeInputObject.DrillingCenter;
            var listnumWell_1 = new List<int>();
            var listnumWell_2 = new List<int>();
            var listnumWell_3 = new List<int>();
            var listnumWell_4 = new List<int>();
            var listnumWell_5 = new List<int>();
            var listnumWell_6 = new List<int>();
            foreach (var item in drillingObject)
            {
                switch (sheetNumber)
                {
                    case 1:
                        listnumWell_1.Add(item.P10.OilProducerWell);
                        listnumWell_2.Add(item.P10.GasProducerWell);
                        listnumWell_3.Add(item.P10.WaterInjectorWell);
                        listnumWell_4.Add(item.P10.GasInjectorWell);
                        listnumWell_5.Add(item.P10.GasLiftWell);
                        listnumWell_6.Add(item.P10.PumpedWell);
                        break; ;
                    case 2:
                        listnumWell_1.Add(item.P50.OilProducerWell);
                        listnumWell_2.Add(item.P50.GasProducerWell);
                        listnumWell_3.Add(item.P50.WaterInjectorWell);
                        listnumWell_4.Add(item.P50.GasInjectorWell);
                        listnumWell_5.Add(item.P50.GasLiftWell);
                        listnumWell_6.Add(item.P50.PumpedWell);
                        break;
                    case 3:
                        listnumWell_1.Add(item.P90.OilProducerWell);
                        listnumWell_2.Add(item.P90.GasProducerWell);
                        listnumWell_3.Add(item.P90.WaterInjectorWell);
                        listnumWell_4.Add(item.P90.GasInjectorWell);
                        listnumWell_5.Add(item.P90.GasLiftWell);
                        listnumWell_6.Add(item.P90.PumpedWell);
                        break;
                    default:
                        break;
                }

            }
            var listIndex = new List<int>();
            var listnumWell = new List<int>();
            var groupCheck = new List<string>()
            {
                "OIL RATE", "GAS RATE (AG)", "PRODUCED WATER RATE FOR OIL WELL",
                "GAS RATE (NAG)","CONDENSATE RATE","PRODUCED WATER RATE FOR GAS WELL",
                "WATER INJECTION RATE", "GAS INJECTION RATE",
                "GAS LIFT RATE",

            };
            for (int i = 0; i < headers.Length; i++)
            {
                var PPData = new ExcelPPDto();
                var listDC = new List<DrillingCenter>();
                if (headers[i] == "OIL RATE" || headers[i] == "GAS RATE (AG)" || headers[i] == "PRODUCED WATER RATE FOR OIL WELL" || headers[i] == "OIL FTHP" || headers[i] == "OIL FTHT")
                {
                    listnumWell = listnumWell_1;
                }
                if (headers[i] == "GAS RATE (NAG)" || headers[i] == "CONDENSATE RATE" || headers[i] == "PRODUCED WATER RATE FOR GAS WELL" || headers[i] == "GAS FTHP" || headers[i] == "GAS FTHT")
                {
                    listnumWell = listnumWell_2;
                }
                if (headers[i] == "WATER INJECTION RATE" || headers[i] == "WATER INJECTION PRESSURE")
                {
                    listnumWell = listnumWell_3;
                }
                if (headers[i] == "GAS INJECTION RATE" || headers[i] == "GAS INJECTION PRESSURE")
                {
                    listnumWell = listnumWell_4;
                }
                if (headers[i] == "GAS LIFT RATE" || headers[i] == "GAS LIFT PRESSURE")
                {
                    listnumWell = listnumWell_5;
                }
                listIndex = GetIndexOfDc(sheetPP, headers[i], listnumWell);
                for (int j = 0; j < listnumWell.Count; j++)
                {
                    if (listnumWell[j] > 0)
                    {
                        var data = GetDataForDC(package, sheetNumber, listIndex[j], listnumWell[j], j + 1, numberOfRows);
                        listDC.Add(data);
                    }
                }
                // to get total of dc
                if (groupCheck.Contains(headers[i]))
                {
                    for (int j = 0; j < numberOfRows - 5; j++)
                    {
                        decimal totalOfDc = 0;
                        for (int k = 0; k < listDC.Count; k++)
                        {
                            totalOfDc += listDC[k].ListDataOfWell[j].Total;
                        }
                        if (listDC.Count > 0)
                        {
                            listDC[0].ListDataOfWell[j].TotalOfDc = totalOfDc;
                        }
                    }
                }

                PPData.DrillingCenter = listDC;
                PPData.Type = headers[i];
                PPData.Unit = units[i];

                PPObject.Add(PPData);
            }
            return PPObject;
        }

        /// <summary>
        /// get list data about start column of dc
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="Header"></param>
        /// <param name="sumWell"></param>
        /// <returns></returns>
        private static List<int> GetIndexOfDc(ExcelWorksheet worksheet, string header, List<int> sumWell)
        {
            var tempCount = 0;
            var groupCheck = new List<string>()
            {
                "OIL RATE", "GAS RATE (AG)", "PRODUCED WATER RATE FOR OIL WELL",
                "GAS RATE (NAG)","CONDENSATE RATE","PRODUCED WATER RATE FOR GAS WELL",
                "WATER INJECTION RATE", "GAS INJECTION RATE",
                "GAS LIFT RATE",

            };

            // to get number of well and add data to list

            if (groupCheck.IndexOf(header) >= 0)
            {
                tempCount = 1;
            }
            var listIndex = new List<int>();
            var startIndex = FindIndexByValue(header, worksheet);
            foreach (var item in sumWell)
            {
                if (item == 0)
                {
                    listIndex.Add(0);
                }
                else
                {
                    listIndex.Add(startIndex);
                    startIndex = startIndex + item + tempCount;
                }
            }
            return listIndex;
        }
        /// <summary>
        /// get all data from each DC
        /// </summary>
        /// <param name="package"></param>
        /// <param name="startColumn"></param>
        /// <param name="numberOfWell"></param>
        /// <param name="numberOfDc"></param>
        /// <returns></returns>
        private static DrillingCenter GetDataForDC(ExcelPackage package, int sheetNumber, int startColumn, int numberOfWell, int numberOfDc, int numberOfRows)
        {
            var drillingData = new DrillingCenter();
            var sheet = package.Workbook.Worksheets[sheetNumber];
            var listWell = new List<Well>();
            for (int k = 5; k <= numberOfRows; k++)
            {
                var month = sheet.Cells[k, 1].Text.ToString();
                var wells = new List<decimal>();
                decimal total = 0;
                for (int f = 0; f < numberOfWell; f++)
                {
                    var temp = sheet.Cells[k, startColumn + f].Value?.ToString() == null ? 0 : decimal.Parse(sheet.Cells[k, startColumn + f].Value.ToString());
                    wells.Add(temp);
                    total += temp;

                }
                var dataOfWell = new Well()
                {
                    Month = month,
                    WellValue = wells,
                    Total = total
                };
                listWell.Add(dataOfWell);
            }
            drillingData.ListDataOfWell = listWell;
            drillingData.Name = $"DC {numberOfDc}";
            return drillingData;
        }
        /// <summary>
        /// find start index of column by name
        /// </summary>
        /// <param name="keyWord"></param>
        /// <param name="worksheet"></param>
        /// <returns></returns>
        private static int FindIndexByValue(string keyWord, ExcelWorksheet worksheet)
        {
            int rowStart = worksheet.Dimension.Start.Row;
            int rowEnd = worksheet.Dimension.End.Row;

            string cellRange = rowStart.ToString() + ":" + rowEnd.ToString();
            var searchCell = from cell in worksheet.Cells[cellRange] //you can define your own range of cells for lookup
                             where cell.Value?.ToString() == keyWord
                             select cell.Start.Column;
            return searchCell.Any() ? searchCell.First() : -1;
        }
        public static ExcelFieldsDataDto ReadCoeInput(ExcelPackage package, Guid id)
        {
            var CoeInputObject = new ExcelFieldsDataDto();
            var DrillingObject = new List<ExcelDrillingCenterDto>();
            var CoeInput = package.Workbook.Worksheets[0];
            CoeInputObject.Id = id;
            CoeInputObject.HydrocarbonType = CoeInput.Cells[2, 5].Value?.ToString();
            CoeInputObject.HydrocarbonTypeUnit = CoeInput.Cells[2, 4].Value?.ToString();
            CoeInputObject.NumberofDrillingCenter = int.Parse(CoeInput.Cells[3, 5].Value.ToString());
            CoeInputObject.ProductionStartYear = CoeInput.Cells[4, 5].Value?.ToString() == null || CoeInput.Cells[4, 5].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[4, 5].Value?.ToString());
            CoeInputObject.ProductionStartYearUnit = CoeInput.Cells[4, 4].Value?.ToString();
            CoeInputObject.ProductionLife = CoeInput.Cells[5, 5].Value?.ToString() == null || CoeInput.Cells[5, 5].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[5, 5].Value?.ToString());
            CoeInputObject.ProductionLifeUnit = CoeInput.Cells[5, 4].Value?.ToString();
            CoeInputObject.AbandonmentPressure = CoeInput.Cells[6, 5].Value?.ToString() == null || CoeInput.Cells[6, 5].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[6, 5].Value?.ToString());
            CoeInputObject.AbandonmentPressureUnit = CoeInput.Cells[6, 4].Value?.ToString();

            CoeInputObject.AvailabilityWaterDisposalReservoir = CoeInput.Cells[7, 5].Value?.ToString();
            CoeInputObject.AvailabilityWaterDisposalReservoirUnit = CoeInput.Cells[7, 4].Value?.ToString();

            CoeInputObject.WaterDisposalLocation = CoeInput.Cells[8, 5].Value?.ToString() == null || CoeInput.Cells[8, 5].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[8, 5].Value?.ToString());
            CoeInputObject.WaterDisposalLocationUnit = CoeInput.Cells[8, 4].Value?.ToString();

            CoeInputObject.AvailabilityNAGReservoir = CoeInput.Cells[9, 5].Value?.ToString();
            CoeInputObject.AvailabilityNAGReservoirUnit = CoeInput.Cells[9, 4].Value?.ToString();

            CoeInputObject.AvailabilityNearbyGasField = CoeInput.Cells[10, 5].Value?.ToString();
            CoeInputObject.AvailabilityNearbyGasFieldUnit = CoeInput.Cells[10, 4].Value?.ToString();

            CoeInputObject.AvailableAmountGasTobeSupplied = CoeInput.Cells[11, 5].Value?.ToString() == null || CoeInput.Cells[11, 5].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[11, 5].Value?.ToString());
            CoeInputObject.AvailableAmountGasTobeSuppliedUnit = CoeInput.Cells[11, 4].Value?.ToString();

            CoeInputObject.OperatingPressure = CoeInput.Cells[12, 5].Value?.ToString() == null || CoeInput.Cells[12, 5].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[12, 5].Value?.ToString());
            CoeInputObject.OperatingPressureUnit = CoeInput.Cells[12, 4].Value?.ToString();

            CoeInputObject.GasDisposalByReinjection = CoeInput.Cells[13, 5].Value?.ToString();

            CoeInputObject.Location = CoeInput.Cells[15, 5].Value?.ToString();
            //CoeInputObject.LocationUnit = CoeInput.Cells[15, 4].Value?.ToString();

            CoeInputObject.CoordinateLat = CoeInput.Cells[16, 5].Value?.ToString();
            CoeInputObject.CoordinateLon = CoeInput.Cells[17, 5].Value?.ToString();
            //CoeInputObject.CoordinateUnit = CoeInput.Cells[15,4].Value?.ToString();
            CoeInputObject.AmbientTemperatureMin = CoeInput.Cells[18, 5].Value?.ToString() == null || CoeInput.Cells[18, 5].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[18, 5].Value?.ToString());
            CoeInputObject.AmbientTemperatureMinUnit = CoeInput.Cells[18, 4].Value?.ToString();
            CoeInputObject.AmbientTemperatureMax = CoeInput.Cells[19, 5].Value?.ToString() == null || CoeInput.Cells[19, 5].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[19, 5].Value?.ToString());
            CoeInputObject.AmbientTemperatureMaxUnit = CoeInput.Cells[19, 4].Value?.ToString();
            CoeInputObject.SeabedTemperatureMin = CoeInput.Cells[20, 5].Value?.ToString() == null || CoeInput.Cells[20, 5].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[20, 5].Value?.ToString());
            CoeInputObject.SeabedTemperatureMinUnit = CoeInput.Cells[20, 4].Value?.ToString();
            CoeInputObject.SeabedTemperatureMax = CoeInput.Cells[21, 5].Value?.ToString() == null || CoeInput.Cells[21, 5].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[21, 5].Value?.ToString());
            CoeInputObject.SeabedTemperatureMaxUnit = CoeInput.Cells[21, 4].Value?.ToString();


            //CoeInputObject.GOR = CoeInput.Cells[6, 3].Value?.ToString() == null || CoeInput.Cells[6, 3].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[6, 3].Value?.ToString());
            //CoeInputObject.GORUnit = CoeInput.Cells[6, 4].Value?.ToString();
            //CoeInputObject.LGR = CoeInput.Cells[7, 3].Value?.ToString() == null || CoeInput.Cells[7, 3].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[7, 3].Value?.ToString());
            //CoeInputObject.LGRUnit = CoeInput.Cells[7, 4].Value?.ToString();
            //CoeInputObject.CGR = CoeInput.Cells[8, 3].Value?.ToString() == null || CoeInput.Cells[8, 3].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[8, 3].Value?.ToString());
            //CoeInputObject.CGRUnit = CoeInput.Cells[8, 4].Value?.ToString();
            //CoeInputObject.WAT = CoeInput.Cells[9, 3].Value?.ToString() == null || CoeInput.Cells[9, 3].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[9, 3].Value?.ToString());
            //CoeInputObject.WATUnit = CoeInput.Cells[9, 4].Value?.ToString();
            //CoeInputObject.ApiGravity = CoeInput.Cells[10, 3].Value?.ToString() == null || CoeInput.Cells[10, 3].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[10, 3].Value?.ToString());
            //CoeInputObject.ApiGravityUnit = CoeInput.Cells[10, 4].Value?.ToString();


            var numberOfDc = int.Parse(CoeInput.Cells[3, 5].Value.ToString());

            for (int i = 0; i < numberOfDc; i++)
            {
                DrillingObject.Add(new ExcelDrillingCenterDto()
                {
                    Name = CoeInput.Cells[1, i * 4 + 10].Value?.ToString(),
                    HyDroCarbonType = CoeInput.Cells[2, i * 4 + 10].Value?.ToString(),
                    HyDroCarbonTypeUnit = CoeInput.Cells[2, 9].Value?.ToString(),

                    Nature = CoeInput.Cells[3, i * 4 + 10].Value?.ToString(),
                    NatureUnit = CoeInput.Cells[3, 9].Value?.ToString(),

                    WaterDepth = CoeInput.Cells[4, i * 4 + 10].Value?.ToString() == null ? 0 : decimal.Parse(CoeInput.Cells[4, i * 4 + 10].Value?.ToString()),
                    WaterDepthUnit = CoeInput.Cells[4, 9].Value?.ToString(),

                    CITHP = CoeInput.Cells[5, i * 4 + 10].Value?.ToString() == null ? 0 : decimal.Parse(CoeInput.Cells[5, i * 4 + 10].Value?.ToString()),
                    CITHPUnit = CoeInput.Cells[5, 9].Value?.ToString(),

                    TieInLocation = CoeInput.Cells[7, i * 4 + 10].Value?.ToString(),
                    TieInLocationUnit = CoeInput.Cells[7, 9].Value?.ToString(),

                    Distance = CoeInput.Cells[8, i * 4 + 10].Value?.ToString() == null || CoeInput.Cells[8, i * 4 + 10].Value?.ToString() == "To Lock this cell" ? 0 : decimal.Parse(CoeInput.Cells[8, i * 4 + 10].Value?.ToString()),
                    DistanceUnit = CoeInput.Cells[8, 9].Value?.ToString(),

                    ArtificialLiftType = CoeInput.Cells[10, i * 4 + 10].Value?.ToString(),
                    ArtificialLiftTypeUnit = CoeInput.Cells[10, 9].Value?.ToString(),

                    PowerRequirementPerWell = CoeInput.Cells[11, i * 4 + 10].Value?.ToString() == null || CoeInput.Cells[11, i * 4 + 10].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[11, i * 4 + 10].Value?.ToString()),
                    PowerRequirementPerWellUnit = CoeInput.Cells[11, 9].Value?.ToString(),

                    P10 = new ExcelDrillingObjectDto()
                    {
                        OilProducerWell = CoeInput.Cells[13, i * 4 + 10].Value?.ToString() == null ? 0 : int.Parse(CoeInput.Cells[13, i * 4 + 10].Value?.ToString()),
                        GasProducerWell = CoeInput.Cells[14, i * 4 + 10].Value?.ToString() == null ? 0 : int.Parse(CoeInput.Cells[14, i * 4 + 10].Value?.ToString()),
                        WaterInjectorWell = CoeInput.Cells[15, i * 4 + 10].Value?.ToString() == null ? 0 : int.Parse(CoeInput.Cells[15, i * 4 + 10].Value?.ToString()),
                        GasInjectorWell = CoeInput.Cells[16, i * 4 + 10].Value?.ToString() == null ? 0 : int.Parse(CoeInput.Cells[16, i * 4 + 10].Value?.ToString()),
                        GasLiftWell = CoeInput.Cells[17, i * 4 + 10].Value?.ToString() == null ? 0 : int.Parse(CoeInput.Cells[17, i * 4 + 10].Value?.ToString()),
                        PumpedWell = CoeInput.Cells[18, i * 4 + 10].Value?.ToString() == null ? 0 : int.Parse(CoeInput.Cells[18, i * 4 + 10].Value?.ToString())
                    },
                    P50 = new ExcelDrillingObjectDto()
                    {
                        OilProducerWell = CoeInput.Cells[13, i * 4 + 11].Value?.ToString() == null ? 0 : int.Parse(CoeInput.Cells[13, i * 4 + 11].Value?.ToString()),
                        GasProducerWell = CoeInput.Cells[14, i * 4 + 11].Value?.ToString() == null ? 0 : int.Parse(CoeInput.Cells[14, i * 4 + 11].Value?.ToString()),
                        WaterInjectorWell = CoeInput.Cells[15, i * 4 + 11].Value?.ToString() == null ? 0 : int.Parse(CoeInput.Cells[15, i * 4 + 11].Value?.ToString()),
                        GasInjectorWell = CoeInput.Cells[16, i * 4 + 11].Value?.ToString() == null ? 0 : int.Parse(CoeInput.Cells[16, i * 4 + 11].Value?.ToString()),
                        GasLiftWell = CoeInput.Cells[17, i * 4 + 11].Value?.ToString() == null ? 0 : int.Parse(CoeInput.Cells[17, i * 4 + 11].Value?.ToString()),
                        PumpedWell = CoeInput.Cells[18, i * 4 + 11].Value?.ToString() == null ? 0 : int.Parse(CoeInput.Cells[18, i * 4 + 11].Value?.ToString())
                    },
                    P90 = new ExcelDrillingObjectDto()
                    {
                        OilProducerWell = CoeInput.Cells[13, i * 4 + 13].Value?.ToString() == null ? 0 : int.Parse(CoeInput.Cells[13, i * 4 + 13].Value?.ToString()),
                        GasProducerWell = CoeInput.Cells[14, i * 4 + 13].Value?.ToString() == null ? 0 : int.Parse(CoeInput.Cells[14, i * 4 + 13].Value?.ToString()),
                        WaterInjectorWell = CoeInput.Cells[15, i * 4 + 13].Value?.ToString() == null ? 0 : int.Parse(CoeInput.Cells[15, i * 4 + 13].Value?.ToString()),
                        GasInjectorWell = CoeInput.Cells[16, i * 4 + 13].Value?.ToString() == null ? 0 : int.Parse(CoeInput.Cells[16, i * 4 + 13].Value?.ToString()),
                        GasLiftWell = CoeInput.Cells[17, i * 4 + 13].Value?.ToString() == null ? 0 : int.Parse(CoeInput.Cells[17, i * 4 + 13].Value?.ToString()),
                        PumpedWell = CoeInput.Cells[18, i * 4 + 13].Value?.ToString() == null ? 0 : int.Parse(CoeInput.Cells[18, i * 4 + 13].Value?.ToString())
                    },
                    MinOilItem = new OilFluidSpecification()
                    {
                        CarbonDioxide = CoeInput.Cells[20, i * 4 + 10].Text?.ToString() == null ? 0 : decimal.Parse(CoeInput.Cells[20, i * 4 + 10].Text?.ToString()),
                        CarbonDioxideUnit = CoeInput.Cells[20, 9].Value?.ToString(),
                        HydrogenSulphide = CoeInput.Cells[21, i * 4 + 10].Value?.ToString() == null ? 0 : decimal.Parse(CoeInput.Cells[21, i * 4 + 10].Value?.ToString()),
                        HydrogenSulphideUnit = CoeInput.Cells[21, 9].Value?.ToString(),
                        Salt = CoeInput.Cells[22, i * 4 + 10].Value?.ToString() == null || CoeInput.Cells[22, i * 4 + 10].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[22, i * 4 + 10].Value?.ToString()),
                        SaltUnit = CoeInput.Cells[22, 9].Value?.ToString(),
                        Mercaptan = CoeInput.Cells[23, i * 4 + 10].Value?.ToString() == null || CoeInput.Cells[23, i * 4 + 10].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[23, i * 4 + 10].Value?.ToString()),
                        MercaptanUnit = CoeInput.Cells[23, 9].Value?.ToString(),
                        Mercury = CoeInput.Cells[24, i * 4 + 10].Value?.ToString() == null || CoeInput.Cells[24, i * 4 + 10].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[24, i * 4 + 10].Value?.ToString()),
                        MercuryUnit = CoeInput.Cells[24, 9].Value?.ToString(),
                        WAT = CoeInput.Cells[25, i * 4 + 10].Value?.ToString() == null || CoeInput.Cells[25, i * 4 + 10].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[25, i * 4 + 10].Value?.ToString()),
                        WATUnit = CoeInput.Cells[25, 9].Value?.ToString(),
                        APIGravity = CoeInput.Cells[26, i * 4 + 10].Value?.ToString() == null || CoeInput.Cells[26, i * 4 + 10].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[26, i * 4 + 10].Value?.ToString()),
                        APIGravityUnit = CoeInput.Cells[26, 9].Value?.ToString(),
                        Sand = CoeInput.Cells[27, i * 4 + 10].Value?.ToString(),
                        SandUnit = CoeInput.Cells[27, 9].Value?.ToString(),

                    },
                    MaxOilItem = new OilFluidSpecification()
                    {
                        CarbonDioxide = CoeInput.Cells[20, i * 4 + 12].Text?.ToString() == null ? 0 : decimal.Parse(CoeInput.Cells[20, i * 4 + 12].Text?.ToString()),
                        CarbonDioxideUnit = CoeInput.Cells[20, 9].Value?.ToString(),
                        HydrogenSulphide = CoeInput.Cells[21, i * 4 + 12].Value?.ToString() == null ? 0 : decimal.Parse(CoeInput.Cells[21, i * 4 + 12].Value?.ToString()),
                        HydrogenSulphideUnit = CoeInput.Cells[21, 9].Value?.ToString(),
                        Salt = CoeInput.Cells[22, i * 4 + 12].Value?.ToString() == null || CoeInput.Cells[22, i * 4 + 12].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[22, i * 4 + 12].Value?.ToString()),
                        SaltUnit = CoeInput.Cells[22, 9].Value?.ToString(),
                        Mercaptan = CoeInput.Cells[23, i * 4 + 12].Value?.ToString() == null || CoeInput.Cells[23, i * 4 + 12].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[23, i * 4 + 12].Value?.ToString()),
                        MercaptanUnit = CoeInput.Cells[23, 9].Value?.ToString(),
                        Mercury = CoeInput.Cells[24, i * 4 + 12].Value?.ToString() == null || CoeInput.Cells[24, i * 4 + 12].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[24, i * 4 + 12].Value?.ToString()),
                        MercuryUnit = CoeInput.Cells[24, 9].Value?.ToString(),
                        WAT = CoeInput.Cells[25, i * 4 + 12].Value?.ToString() == null || CoeInput.Cells[25, i * 4 + 12].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[25, i * 4 + 12].Value?.ToString()),
                        WATUnit = CoeInput.Cells[25, 9].Value?.ToString(),
                        APIGravity = CoeInput.Cells[26, i * 4 + 12].Value?.ToString() == null || CoeInput.Cells[26, i * 4 + 12].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[26, i * 4 + 12].Value?.ToString()),
                        APIGravityUnit = CoeInput.Cells[26, 9].Value?.ToString(),
                        Sand = CoeInput.Cells[27, i * 4 + 12].Value?.ToString(),
                        SandUnit = CoeInput.Cells[27, 9].Value?.ToString(),

                    },
                    MinGasItem = new GasFluidSpecification()
                    {

                        CarbonDioxide = CoeInput.Cells[29, i * 4 + 10].Text?.ToString(),
                        CarbonDioxideUnit = CoeInput.Cells[29, 9].Value?.ToString(),
                        HydrogenSulphide = CoeInput.Cells[30, i * 4 + 10].Value?.ToString() == null ? 0 : decimal.Parse(CoeInput.Cells[30, i * 4 + 10].Value?.ToString()),
                        HydrogenSulphideUnit = CoeInput.Cells[30, 9].Value?.ToString(),

                        Mercaptan = CoeInput.Cells[31, i * 4 + 10].Value?.ToString() == null || CoeInput.Cells[31, i * 4 + 10].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[31, i * 4 + 10].Value?.ToString()),
                        MercaptanUnit = CoeInput.Cells[31, 9].Value?.ToString(),
                        Mercury = CoeInput.Cells[32, i * 4 + 10].Value?.ToString() == null || CoeInput.Cells[32, i * 4 + 10].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[32, i * 4 + 10].Value?.ToString()),
                        MercuryUnit = CoeInput.Cells[32, 9].Value?.ToString(),

                        Sand = CoeInput.Cells[33, i * 4 + 10].Value?.ToString(),
                        SandUnit = CoeInput.Cells[33, 9].Value?.ToString(),

                    },
                    MaxGasItem = new GasFluidSpecification()
                    {
                        CarbonDioxide = CoeInput.Cells[29, i * 4 + 12].Text?.ToString(),
                        CarbonDioxideUnit = CoeInput.Cells[29, 9].Value?.ToString(),
                        HydrogenSulphide = CoeInput.Cells[30, i * 4 + 12].Value?.ToString() == null ? 0 : decimal.Parse(CoeInput.Cells[30, i * 4 + 12].Value?.ToString()),
                        HydrogenSulphideUnit = CoeInput.Cells[30, 9].Value?.ToString(),

                        Mercaptan = CoeInput.Cells[31, i * 4 + 12].Value?.ToString() == null || CoeInput.Cells[31, i * 4 + 12].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[31, i * 4 + 12].Value?.ToString()),
                        MercaptanUnit = CoeInput.Cells[31, 9].Value?.ToString(),
                        Mercury = CoeInput.Cells[32, i * 4 + 12].Value?.ToString() == null || CoeInput.Cells[32, i * 4 + 12].Value?.ToString() == "N/A" ? 0 : decimal.Parse(CoeInput.Cells[32, i * 4 + 12].Value?.ToString()),
                        MercuryUnit = CoeInput.Cells[32, 9].Value?.ToString(),

                        Sand = CoeInput.Cells[33, i * 4 + 12].Value?.ToString(),
                        SandUnit = CoeInput.Cells[33, 9].Value?.ToString(),
                    },
                    WellTestRequirement = CoeInput.Cells[35, i * 4 + 10].Value?.ToString(),
                    WellTestRequirementUnit = CoeInput.Cells[35, 9].Value?.ToString(),
                    GOR = CoeInput.Cells[36, i * 4 + 10].Value?.ToString(),
                    GORUnit = CoeInput.Cells[36, 9].Value?.ToString(),
                    LGR = CoeInput.Cells[37, i * 4 + 10].Value?.ToString(),
                    LGRUnit = CoeInput.Cells[37, 9].Value?.ToString(),
                    CGR = CoeInput.Cells[38, i * 4 + 10].Value?.ToString(),
                    CGRUnit = CoeInput.Cells[38, 9].Value?.ToString(),

                }); ;
                CoeInputObject.DrillingCenter = DrillingObject;

            }

            return CoeInputObject;
        }
    }
}
