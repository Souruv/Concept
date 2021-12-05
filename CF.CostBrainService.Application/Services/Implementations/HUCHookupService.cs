using AutoMapper;
using AutoMapper.QueryableExtensions;
using CF.CostBrainService.Application.Common.Interfaces;
using CF.CostBrainService.Application.Entities;
using CF.CostBrainService.Application.Features.HUCHookupCost.Dto;
using CF.CostBrainService.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CF.CostBrainService.Application.Services.Implementations
{
    public class HUCHookupService : IHUCHookupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMathHelper _mathHelper;
        private readonly IMapper _mapper;
        private readonly Dictionary<string, string> _countryCurrencies;

        const string MALAYSIA = "Malaysia";
        const string CPPMODULAR = "CPP MODULAR";

        public HUCHookupService(IUnitOfWork _unitOfWork, IMathHelper _mathHelper, IMapper _mapper)
        {
            this._unitOfWork = _unitOfWork;
            this._mathHelper = _mathHelper;
            this._mapper = _mapper;
            this._countryCurrencies
                = new Dictionary<string, string>
                {{"Malaysia","MYR"}
                 ,{"Malaysia - Peninsular Malaysia","MYR"}
                 ,{"Malaysia - Sabah","MYR"}
                 ,{"Malaysia - Sarawak","MYR"}
                 ,{"Worldwide","USD"}
                 ,{"Middle East","USD"}
                 ,{"United States","USD"}
                 ,{"Indonesia","USD"}
                 ,{"Brazil","USD"}
                 ,{"Turkmenistan","USD"}
                 ,{"Mexico","USD"}
                 ,{"Congo","USD"}
                 ,{"Australia","USD"}
                 ,{"Gabon","USD" }
                 ,{"Sudan","USD"}
                 ,{"Suriname","USD"}
                };
        }
        public async Task<HUCDefaultValuesDto> GetHUCDefaultValues(string projectType, string country)
        {
            var HUCDefaultValuesDtoObj = new HUCDefaultValuesDto();

            string countryName = country ?? MALAYSIA;
            string projectTypeName = projectType ?? CPPMODULAR;

            //get the country info
            var countryInfo = await _unitOfWork.CountryRepository.GetSingleAsync(x => x.Name == countryName && x.IsDeleted == false);
            if (countryInfo == null)
            {
                //getting the default value of country malaysia if no record is found for that country
                countryInfo = await _unitOfWork.CountryRepository.GetSingleAsync(x => x.Name == MALAYSIA && x.IsDeleted == false);
            }

            //get the project info
            var projectInfo = await _unitOfWork.MasterProjectTypeRepository.GetSingleAsync(x => x.Type == projectTypeName && x.IsDeleted == false);
            if (projectInfo == null)
            {
                //getting the default value of project CPP MODULAR if no record is found for that project type
                projectInfo = await _unitOfWork.MasterProjectTypeRepository.GetSingleAsync(x => x.Type == CPPMODULAR && x.IsDeleted == false);
            }

            //get the days factor per month info
            var daysFactorperMonthsInfo = _unitOfWork.MasterDaysFactorperMonthRepository.Filter(x => x.MasterProjectType.Type == projectInfo.Type && x.Country.Name == countryInfo.Name && x.IsDeleted == false);
            if (daysFactorperMonthsInfo.Any())
            {
                HUCDefaultValuesDtoObj.MasterDaysFactorperMonth = new List<MasterDaysFactorperMonthDto>();
                HUCDefaultValuesDtoObj.MasterDaysFactorperMonth.AddRange(await daysFactorperMonthsInfo.ProjectTo<MasterDaysFactorperMonthDto>(_mapper.ConfigurationProvider).ToListAsync());
            }

            //get the offshore accomodations info
            var offShoreAccomodationsInfo = _unitOfWork.MasterOffShoreAccomodationRepository.Filter(x => x.MasterProjectType.Type == projectInfo.Type && x.Country.Name == countryInfo.Name && !x.IsDeleted);
            if (offShoreAccomodationsInfo.Any())
            {
                HUCDefaultValuesDtoObj.MasterOffShoreAccomodations = new List<MasterOffShoreAccomodationDto>();
                HUCDefaultValuesDtoObj.MasterOffShoreAccomodations.AddRange(await offShoreAccomodationsInfo.ProjectTo<MasterOffShoreAccomodationDto>(_mapper.ConfigurationProvider).ToListAsync());
            }

            //get the schedule info
            var schedulesInfo = _unitOfWork.MasterScheduleRepository.Filter(x => x.IsDeleted == false);
            if (schedulesInfo.Any())
            {
                HUCDefaultValuesDtoObj.MasterSchedules = new List<MasterScheduleDto>();
                HUCDefaultValuesDtoObj.MasterSchedules.AddRange(await schedulesInfo.ProjectTo<MasterScheduleDto>(_mapper.ConfigurationProvider).ToListAsync());
            }

            //get the sub schedule info
            var subSchedulesInfo = _unitOfWork.MasterSubScheduleRepository.Filter(x => x.IsDeleted == false);
            if (subSchedulesInfo.Any())
            {
                HUCDefaultValuesDtoObj.MasterSubSchedules = new List<MasterSubScheduleDto>();
                HUCDefaultValuesDtoObj.MasterSubSchedules.AddRange(await subSchedulesInfo.ProjectTo<MasterSubScheduleDto>(_mapper.ConfigurationProvider).ToListAsync());
            }

            //get the typical manpower name
            var masterTypicalManpowersInfo = await _unitOfWork.MasterTypicalManpowerRepository.Filter(x => !x.IsDeleted).ToListAsync();

            //get the default manpowers info
            //causing mapping issue with complex object
            var defaultManpowersInfo = await _unitOfWork.DefaultManpowerRepository.Filter(x => x.MasterProjectType.Type == projectInfo.Type && x.Country.Name == countryInfo.Name && !x.IsDeleted).ToListAsync();
            if (defaultManpowersInfo.Any())
            {
                HUCDefaultValuesDtoObj.DefaultManpowers = new List<DefaultManpowerDto>();
                foreach (var (defaultManpower, manPowerName) in from defaultManpower in defaultManpowersInfo
                                                                let manPowerName = masterTypicalManpowersInfo.FirstOrDefault(x => x.Id == defaultManpower.MasterTypicalManpowerId).ManPowerName
                                                                select (defaultManpower, manPowerName))
                {
                    if (string.IsNullOrEmpty(manPowerName))
                        continue;
                    DefaultManpowerDto defaultManpowerDto = new DefaultManpowerDto();
                    defaultManpowerDto.MasterTypicalManPowers = manPowerName;
                    defaultManpowerDto.Duration = defaultManpower.Duration;
                    defaultManpowerDto.Qty = defaultManpower.Qty;
                    defaultManpowerDto.OFFSHOREACCOMODATION = defaultManpower.OFFSHOREACCOMODATION;
                    HUCDefaultValuesDtoObj.DefaultManpowers.Add(defaultManpowerDto);
                }
            }

            //get the default manpowers man hours and rate info
            var defaultManpowerManHrsRates = _unitOfWork.DefaultManpowerManHrsRateRepository.Filter(x => x.Country.Name == countryInfo.Name && !x.IsDeleted);
            if (defaultManpowerManHrsRates.Any())
            {
                HUCDefaultValuesDtoObj.DefaultManpowerManHrsRate = new List<DefaultManpowerManHrsRateDto>();
                foreach (var defaultManpowerManHrsRate in defaultManpowerManHrsRates)
                {
                    var manPowerName = masterTypicalManpowersInfo.FirstOrDefault(x => x.Id == defaultManpowerManHrsRate.MasterTypicalManpowerId).ManPowerName;
                    if (string.IsNullOrEmpty(manPowerName))
                        continue;
                    DefaultManpowerManHrsRateDto defaultManpowerManHrsRateDto = new DefaultManpowerManHrsRateDto();
                    defaultManpowerManHrsRateDto.MasterTypicalManPowers = manPowerName;
                    defaultManpowerManHrsRateDto.MANHOURS = defaultManpowerManHrsRate.MANHOURs;
                    defaultManpowerManHrsRateDto.Rate = defaultManpowerManHrsRate.Rate;
                    HUCDefaultValuesDtoObj.DefaultManpowerManHrsRate.Add(defaultManpowerManHrsRateDto);
                }
            }

            //get the equipment tools manpower percentage
            var defaultEquipmentManPowerPercentages = _unitOfWork.DefaultEquipmentManPowerPercentageRepository.Filter(x => x.IsDeleted == false);
            if (defaultEquipmentManPowerPercentages.Any())
            {
                HUCDefaultValuesDtoObj.DefaultEquipmentManPowerPercentage = new List<DefaultEquipmentManPowerPercentageDto>();
                HUCDefaultValuesDtoObj.DefaultEquipmentManPowerPercentage.AddRange(await defaultEquipmentManPowerPercentages.ProjectTo<DefaultEquipmentManPowerPercentageDto>(_mapper.ConfigurationProvider).ToListAsync());
            }

            //get the default marine spread and others
            var defaultMarineSpreadAndOthersInfo = _unitOfWork.DefaultMarineSpreadAndOthersRepository.Filter(x => x.IsDeleted == false && x.Country.Name == countryInfo.Name);
            if (defaultMarineSpreadAndOthersInfo.Any())
            {
                var defaultMarineSpreadAndOthersObj = await defaultMarineSpreadAndOthersInfo.ProjectTo<DefaultMarineSpreadAndOthersDto>(_mapper.ConfigurationProvider).ToListAsync();

                var defaultMarineSpreadAndOthersCalculatedObj = CalculateMarineSpreadTotalDays(HUCDefaultValuesDtoObj.DefaultManpowers, defaultMarineSpreadAndOthersObj);
                HUCDefaultValuesDtoObj.DefaultMarineSpreadAndOthers = new List<DefaultMarineSpreadAndOthersDto>();
                HUCDefaultValuesDtoObj.DefaultMarineSpreadAndOthers.AddRange(defaultMarineSpreadAndOthersCalculatedObj);
            }

            //get the default fuel and pw values
            var defaultOthersFuelAndPWsInfo = _unitOfWork.DefaultOthersFuelAndPWRepository.Filter(x => x.IsDeleted == false && x.Country.Name == countryInfo.Name);
            if (defaultOthersFuelAndPWsInfo.Any())
            {
                HUCDefaultValuesDtoObj.DefaultOthersFuelAndPW = new List<DefaultOthersFuelAndPWDto>();
                HUCDefaultValuesDtoObj.DefaultOthersFuelAndPW.AddRange(await defaultOthersFuelAndPWsInfo.ProjectTo<DefaultOthersFuelAndPWDto>(_mapper.ConfigurationProvider).ToListAsync());
            }

            //get the default third party first section
            var defaultThirdPartyServicesSectionOnes = _unitOfWork.DefaultThirdPartyServicesSectionOneRepository.Filter(x => x.IsDeleted == false && x.Country.Name == countryInfo.Name);
            if (defaultThirdPartyServicesSectionOnes.Any())
            {
                HUCDefaultValuesDtoObj.DefaultThirdPartyServicesSectionOne = new List<DefaultThirdPartyServicesSectionOneDto>();
                HUCDefaultValuesDtoObj.DefaultThirdPartyServicesSectionOne.AddRange(await defaultThirdPartyServicesSectionOnes.ProjectTo<DefaultThirdPartyServicesSectionOneDto>(_mapper.ConfigurationProvider).ToListAsync());
            }

            //get the default third party two section
            var defaultThirdPartyServicesSectionTwos = _unitOfWork.DefaultThirdPartyServicesSectionTwoRepository.Filter(x => x.IsDeleted == false);
            if (defaultThirdPartyServicesSectionTwos.Any())
            {
                HUCDefaultValuesDtoObj.DefaultThirdPartyServicesSectionTwo = new List<DefaultThirdPartyServicesSectionTwoDto>();
                HUCDefaultValuesDtoObj.DefaultThirdPartyServicesSectionTwo.AddRange(await defaultThirdPartyServicesSectionTwos.ProjectTo<DefaultThirdPartyServicesSectionTwoDto>(_mapper.ConfigurationProvider).ToListAsync());
            }
            //get the default third party three section
            var defaultThirdPartyServicesSectionThrees = _unitOfWork.DefaultThirdPartyServicesSectionThreeRepository.Filter(x => x.IsDeleted == false);
            if (defaultThirdPartyServicesSectionThrees.Any())
            {
                HUCDefaultValuesDtoObj.DefaultThirdPartyServicesSectionThree = new List<DefaultThirdPartyServicesSectionThreeDto>();
                HUCDefaultValuesDtoObj.DefaultThirdPartyServicesSectionThree.AddRange(await defaultThirdPartyServicesSectionThrees.ProjectTo<DefaultThirdPartyServicesSectionThreeDto>(_mapper.ConfigurationProvider).ToListAsync());
            }

            HUCDefaultValuesDtoObj.countryCurrency = GetTheCurrency(countryInfo.Name);
            return HUCDefaultValuesDtoObj;
        }
        public async Task<HUCCostSummaryDto> CalculateHUCCost(HUCInputValuesDto hucInputValuesDto, string filePath)
        {
            // create CostSummaryDto for output
            HUCCostSummaryDto hUCCostSummaryDto = new HUCCostSummaryDto();
            // create list HUCActivitiesDto of CostSummaryDto for output
            var listHUCActivitiesDto = new List<HUCActivitiesDto>();
            //create list huccost of CostSummaryDto for output
            var HUCCostObject = new HUCCostDto();
            List<decimal?> manpowerCost = new List<decimal?>();

            var MasterSchedule = await _unitOfWork.MasterScheduleRepository.Filter(x => x.IsDeleted == false).ToListAsync();
            var MasterProjectType = await _unitOfWork.MasterProjectTypeRepository.GetSingleAsync(x => x.IsDeleted == false && x.Type == hucInputValuesDto.MasterProjectType);
            var Country = await _unitOfWork.CountryRepository.GetSingleAsync(x => x.IsDeleted == false && x.Name == hucInputValuesDto.Country);
            var MasterDaysFactorperMonth = await _unitOfWork.MasterDaysFactorperMonthRepository.Filter(x => x.IsDeleted == false).ToListAsync();
            var MasterOffShoreAccomodation = await _unitOfWork.MasterOffShoreAccomodationRepository.Filter(x => x.IsDeleted == false).ToListAsync();
            var MasterTypicalManpower = await _unitOfWork.MasterTypicalManpowerRepository.Filter(x => x.IsDeleted == false).ToListAsync();

            //insert this assumption id in all the cost calculation
            var requestId = Guid.NewGuid();
            // list value to calculate Marine
            var listDuration = new List<decimal?> { };
            var listOffshore = new List<string> { };
            // list value to calculate other
            var listQty = new List<decimal?> { };
            // list value to calculate cost of thirdPartyTwo
            var listManpowerTotal = new List<decimal?> { };
            // TOTAL COST OF ALL
            decimal? totalCostOfAll = 0;

            #region store and calculate typical manpower cost
            var typicalObject = hucInputValuesDto.TypicalManpowerCost;
            // create list HUCCosA1tDto for output
            var listHUCCosA1tDto = new List<HUCCosA1tDto>();
            // create values to calcaulate WOW
            decimal? sumManpower_Wow = 0;
            decimal? sumDuration_Wow_1 = 0;
            decimal? sumDuration_Wow_2 = 0;
            // calculate totalMan-hours of MAN-HRS COST
            decimal? totalMan_hours = 0;
            decimal? totalCostMan_hours = 0;
            foreach (var item in typicalObject)
            {
                // if masterTypical is WoW, we need to calculate at the end of the code
                if (item.MasterTypicalManpower != "WOW")
                {
                    var masterOffshore = MasterOffShoreAccomodation.Where(x => x.Value == item.MasterOffShoreAccomodation).FirstOrDefault();
                    var masterDaysFactor = MasterDaysFactorperMonth.Where(x => x.DaysFactorPerMonth == item.MasterDaysFactorperMonth).FirstOrDefault();
                    var masterTypical = MasterTypicalManpower.Where(x => x.ManPowerName == item.MasterTypicalManpower).FirstOrDefault();
                    TypicalManpowerCost typicalManpowerCost = new TypicalManpowerCost()
                    {
                        Id = Guid.NewGuid(),

                        MasterOffShoreAccomodationId = masterOffshore == null ? (Nullable<Guid>)null : masterOffshore.Id,
                        MasterDaysFactorperMonthId = masterDaysFactor.Id,
                        MasterTypicalManpowerId = masterTypical.Id,

                        AssumptionId = requestId,

                        DurationDays = item.DurationDays,
                        QTY = item.QTY,
                        MANHOURS = item.MANHOURS,
                        RATE = item.RATE,

                        MasterScheduleId = MasterSchedule.Where(x => x.Name == "MANPOWER").FirstOrDefault().Id,
                        MasterProjectTypeId = MasterProjectType.Id,
                        CountryId = Country.Id,

                        Cost = Calculate("ManpowerTotal", item.DurationDays, item.QTY, item.MANHOURS, item.RATE)
                    };
                    _unitOfWork.TypicalManpowerCostRepository.Insert(typicalManpowerCost);
                    // get value to sumManpower_Wow
                    sumManpower_Wow += typicalManpowerCost.Cost;
                    
                    // get value to sumDuration_Wow_1
                    if (item.MasterTypicalManpower == "ONSHORE INDIRECT" || item.MasterTypicalManpower == "ONSHORE DIRECT" || item.MasterTypicalManpower == "OFFSHORE CAMPAIGN 1" || item.MasterTypicalManpower == "OFFSHORE CAMPAIGN 2" || item.MasterTypicalManpower == "OFFSHORE CAMPAIGN 3 (OPTIONAL)")
                    {
                        sumDuration_Wow_1 += typicalManpowerCost.DurationDays;
                    }
                    // get value to sumDuration_Wow_2
                    if (item.MasterTypicalManpower == "OFFSHORE CAMPAIGN 1" || item.MasterTypicalManpower == "OFFSHORE CAMPAIGN 2" || item.MasterTypicalManpower == "OFFSHORE CAMPAIGN 3 (OPTIONAL)")
                    {
                        sumDuration_Wow_2 += typicalManpowerCost.DurationDays;
                    }

                    // add the cost of each TYPICAL MANPOWER to list
                    manpowerCost.Add(typicalManpowerCost.Cost);
                    // add data to HUCCost of hUCCostSummaryDto

                    var manhoursCostName = MasterTypicalManpower.Where(x => x.ManPowerName == item.MasterTypicalManpower).FirstOrDefault().ManPowerName;
                    listHUCCosA1tDto.Add(new HUCCosA1tDto()
                    {
                        Shedule = MasterSchedule.Where(x => x.Name == "MANPOWER").FirstOrDefault().Code,
                        ManHoursCost = manhoursCostName == "FINAL DOCUMENTATION" ? "ADDITIONAL MANHOURS  (OPTIONAL)" : manhoursCostName,
                        Cost = typicalManpowerCost.Cost,
                        ManHours = Calculate("ManHours", typicalManpowerCost.Cost, typicalManpowerCost.RATE)
                    });
                    //  calculate totalMan-hours of MAN-HRS COST
                    totalMan_hours += Calculate("ManHours", typicalManpowerCost.Cost, typicalManpowerCost.RATE);
                    totalCostMan_hours += typicalManpowerCost.Cost;
                    // add value of ONSHORE INDIRECT ==> OFFSHORE CAMPAIGN 3 (OPTIONAL) to list
                    if (item.MasterTypicalManpower == "ENGINEERING" || item.MasterTypicalManpower == "FINAL DOCUMENTATION" || item.MasterTypicalManpower == "WOW ")
                        continue;
                    listManpowerTotal.Add(typicalManpowerCost.Cost);
                    listDuration.Add((decimal)item.DurationDays);
                    listOffshore.Add(item.MasterOffShoreAccomodation);


                }

            }
            



            HUCSummaryCost manPowerTotalCost_Manpower = new HUCSummaryCost()
            {
                Id = Guid.NewGuid(),
                AssumptionId = requestId,
                MasterScheduleId = MasterSchedule.Where(x => x.Name == "MANPOWER").FirstOrDefault().Id,
                MasterProjectTypeId = MasterProjectType.Id,
                CountryId = Country.Id,
                TotalCost = Calculate("SumManPower", manpowerCost.ToArray())
            };

            //hUCCostSummaryDto.HUCCost.HUCCosA1TDto = new List<HUCCosA1tDto>();
            _unitOfWork.HUCSummaryCostRepository.Insert(manPowerTotalCost_Manpower);
            
            // add data to HUCActivities of hUCCostSummaryDto
            listHUCActivitiesDto.Add(new HUCActivitiesDto()
            {
                Shedule = MasterSchedule.Where(x => x.Name == "MANPOWER").FirstOrDefault().Code,
                HUCActivity = "MAN-HOURS COST ",
                Cost = Calculate("SumManPower", manpowerCost.ToArray())
            }); ; ;
            // add total cost to huccost
            listHUCCosA1tDto.Add(new HUCCosA1tDto()
            {
                Shedule = MasterSchedule.Where(x => x.Name == "MANPOWER").FirstOrDefault().Code,
                ManHoursCost = "TOTAL COST",
                Cost = totalCostMan_hours,
                ManHours = totalMan_hours
            }); ;
            //hUCCostSummaryDto.HUCActivities.Add(new HUCActivitiesDto { Shedule = manPowerTotalCost.MasterSchedule.Code, HUCActivity = manPowerTotalCost.MasterProjectType.Type, Cost = manPowerTotalCost.TotalCost });
            #endregion

            #region store and calculate EQUIPMENT/ TOOLS/ CONSUMABLES

            var equimentToolsConsCost = await _unitOfWork.EquipmentToolsConsCostRepository.Filter(x => x.IsDeleted == false).ToListAsync();
            var Tools_EquipmentObject = hucInputValuesDto.EquipmentToolsConsCosts;
            // create HUCCosA2TDto for output
            var HUCCosA2TDto = new List<HUCCosA2tDto>();

            EquipmentToolsConsCost equipmentToolsConsCost = new EquipmentToolsConsCost()
            {
                Id = Guid.NewGuid(),
                ToolsAndEquip = Tools_EquipmentObject.ToolsAndEquip,
                Consumables = Tools_EquipmentObject.Consumables,
                ManPowerPercentage = Tools_EquipmentObject.ManPowerPercentage,
                AssumptionId = requestId,
                MasterScheduleId = MasterSchedule.Where(x => x.Name == "EQUIPMENT/ TOOLS/ CONSUMABLES").FirstOrDefault().Id,
                MasterProjectTypeId = MasterProjectType.Id,
                CountryId = Country.Id,
                TotalCost = (Tools_EquipmentObject.ManPowerPercentage * Calculate("sum", manpowerCost.ToArray())) / 100
            };
            _unitOfWork.EquipmentToolsConsCostRepository.Insert(equipmentToolsConsCost);
            HUCSummaryCost manPowerTotalCost_Equiment = new HUCSummaryCost()
            {
                Id = Guid.NewGuid(),
                AssumptionId = requestId,
                MasterScheduleId = equipmentToolsConsCost.MasterScheduleId,
                MasterProjectTypeId = MasterProjectType.Id,
                CountryId = Country.Id,
                TotalCost = equipmentToolsConsCost.TotalCost
            };
            _unitOfWork.HUCSummaryCostRepository.Insert(manPowerTotalCost_Equiment);

            // add data to HUCCosA2TDto
            HUCCosA2TDto.Add(new HUCCosA2tDto()
            {
                Shedule = MasterSchedule.Where(x => x.Name == "EQUIPMENT/ TOOLS/ CONSUMABLES").FirstOrDefault().Code,
                EquimentName = "% OF MAN-POWER COST (TOTAL DIRECT ONSHORE & OFFSHORE)",
                Cost = equipmentToolsConsCost.TotalCost,
                Remarks = equipmentToolsConsCost.ManPowerPercentage
            });
            // add data to HUCActivities of hUCCostSummaryDto
            listHUCActivitiesDto.Add(new HUCActivitiesDto()
            {
                Shedule = MasterSchedule.Where(x => x.Name == "EQUIPMENT/ TOOLS/ CONSUMABLES").FirstOrDefault().Code,
                HUCActivity = "EQUIPMENT/ TOOLS/ CONSUMABLES",
                Cost = manPowerTotalCost_Equiment.TotalCost
            }); ; ;
            // add totalCost to HUCCosA2TDto
            HUCCosA2TDto.Add( new HUCCosA2tDto()
            {
                Shedule = MasterSchedule.Where(x => x.Name == "EQUIPMENT/ TOOLS/ CONSUMABLES").FirstOrDefault().Code,
                EquimentName = "TOTAL COST",
                Cost = equipmentToolsConsCost.TotalCost,
                Remarks = 0
            });
            #endregion

            #region store and calculate MATERIALS

            var materialsObject = hucInputValuesDto.MaterialsCostDto;

            // create HUCCostMaterialsDtos for output
            var HUCCostMaterialsDtos = new List<HUCCostMaterialsDto>();
            MaterialsCost materialsCost = new MaterialsCost()
            {
                Id = Guid.NewGuid(),
                AssumptionId = requestId,
                MasterProjectTypeId = MasterProjectType.Id,
                CountryId = Country.Id,
                MasterScheduleId = MasterSchedule.Where(x => x.Name == "MATERIALS").FirstOrDefault().Id,
                NoOfFlowLine = materialsObject.NoOfFlowLine,
                MYRFlowLine = materialsObject.MYRFlowLine,
                Others = materialsObject.Others,
                Cost = Calculate("MATERIALS", materialsObject.NoOfFlowLine, materialsObject.MYRFlowLine)
            };
            _unitOfWork.MaterialsCostRepository.Insert(materialsCost);
            HUCSummaryCost manPowerTotalCost_Materials = new HUCSummaryCost()
            {
                Id = Guid.NewGuid(),
                AssumptionId = requestId,
                MasterScheduleId = materialsCost.MasterScheduleId,
                MasterProjectTypeId = MasterProjectType.Id,
                CountryId = Country.Id,
                TotalCost = materialsCost.Cost
            };
            
            _unitOfWork.HUCSummaryCostRepository.Insert(manPowerTotalCost_Materials);


            // add data to HUCCosA2TDto
            HUCCostMaterialsDtos.Add(new HUCCostMaterialsDto()
            {
                Shedule = MasterSchedule.Where(x => x.Name == "MATERIALS").FirstOrDefault().Code,
                Name = "FLOW LINES",
                Cost = materialsCost.MYRFlowLine,
                FlowLinesQty = hucInputValuesDto.MasterProjectType == "CPP MODULAR" || hucInputValuesDto.MasterProjectType == "CPP INTEGRATED/FPSO/FPS" || hucInputValuesDto.MasterProjectType == "WHP/SATELLITE/ BRIDGE & FLARE" ? null : materialsCost.NoOfFlowLine
            });
            HUCCostMaterialsDtos.Add(new HUCCostMaterialsDto()
            {
                Shedule = MasterSchedule.Where(x => x.Name == "MATERIALS").FirstOrDefault().Code,
                Name = "OTHERS",
                Cost = materialsCost.Others,
                FlowLinesQty = 0
            });

            listHUCActivitiesDto.Add(new HUCActivitiesDto()
            {
                Shedule = MasterSchedule.Where(x => x.Name == "MATERIALS").FirstOrDefault().Code,
                HUCActivity = "MATERIALS ",
                Cost = materialsCost.Cost
            });

            HUCCostMaterialsDtos.Add(new HUCCostMaterialsDto()
            {
                Shedule = MasterSchedule.Where(x => x.Name == "MATERIALS").FirstOrDefault().Code,
                Name = "TOTAL COST",
                Cost = materialsCost.MYRFlowLine + materialsCost.Others,
                FlowLinesQty = 0
            });
            #endregion

            #region store and calculate MARINE SPREAD & OTHERS
            var otherObject = hucInputValuesDto.DefaultOthersFuelAndPWD;
            var marineSpread = hucInputValuesDto.DefaultMarineSpreadAndOthers;
            // create list MarineSpreadOthers for output
            var listMarineSpreadOthers = new List<MarineSpreadOthersDto>();
            decimal? totalCostMarine = 0;
            decimal? totalCostOthers = 0;
            for (int i = 0; i < otherObject.Count; i++)
            {
                // MARINE SPREAD
                MarineSpreadCost marineSpreadCost = new MarineSpreadCost()
                {
                    Id = Guid.NewGuid(),
                    AssumptionId = requestId,
                    MasterScheduleId = MasterSchedule.Where(x => x.Name == "MARINE SPREAD & OTHERS").FirstOrDefault().Id,
                    MasterProjectTypeId = MasterProjectType.Id,
                    MasterSubScheduleId = (Nullable<Guid>)null,
                    VesselType = marineSpread[i].VesselType,
                    QTYMOBDEMOB_Mob_Demob = marineSpread[i].QTYMOBDEMOB_Mob_Demob,
                    MOBDEMOB_Per_Rate = marineSpread[i].MOBDEMOB_Per_Rate,
                    DailyCharacterRate_DCR = marineSpread[i].DailyCharacterRate_DCR,
                    OperationalCost_PerDay = marineSpread[i].OperationalCost_PerDay,
                    TotalDuration_Days = Calculate(marineSpread[i].VesselType, marineSpread[i].QTYMOBDEMOB_Mob_Demob, listDuration, listOffshore)

                };
                marineSpreadCost.Cost = Calculate("Marine", (decimal?)marineSpread[i].QTYMOBDEMOB_Mob_Demob, marineSpread[i].MOBDEMOB_Per_Rate, marineSpread[i].DailyCharacterRate_DCR, marineSpread[i].OperationalCost_PerDay, (decimal?)marineSpreadCost.TotalDuration_Days);

                _unitOfWork.MarineSpreadCostRepository.Insert(marineSpreadCost);

                // OTHERS (FUEL & PW)
                FuelAndPWCost fuelAndPWCost = new FuelAndPWCost()
                {
                    Id = Guid.NewGuid(),
                    AssumptionId = requestId,
                    MasterScheduleId = MasterSchedule.Where(x => x.Name == "MARINE SPREAD & OTHERS").FirstOrDefault().Id,
                    MasterProjectTypeId = MasterProjectType.Id,
                    MasterSubScheduleId = (Nullable<Guid>)null,
                    CountryId = Country.Id,
                    VesselType = otherObject[i].VesselType,
                    Fuel_LTR_DAY = otherObject[i].Fuel_LTR_DAY,
                    PortableWater_MT_Day = otherObject[i].PortableWater_MT_Day,
                    Cost = Calculate("Others", marineSpreadCost.QTYMOBDEMOB_Mob_Demob, marineSpreadCost.TotalDuration_Days, otherObject[i].Fuel_LTR_DAY, otherObject[i].PortableWater_MT_Day)
                };

                _unitOfWork.fuelAndPWCostRepository.Insert(fuelAndPWCost);
                // add value to sumMarineSpread_Wow
                totalCostMarine += marineSpreadCost.Cost;
                totalCostOthers += fuelAndPWCost.Cost;

                // add to output
                listMarineSpreadOthers.Add(new MarineSpreadOthersDto()
                {
                    Shedule = "C1 & C2",
                    MarineSpread = fuelAndPWCost.VesselType,
                    VesselCost = marineSpreadCost.Cost,
                    FuelPWCost = fuelAndPWCost.Cost
                }); ;
            }

            listHUCActivitiesDto.Add(new HUCActivitiesDto()
            {
                Shedule = MasterSchedule.Where(x => x.Name == "MARINE SPREAD & OTHERS").FirstOrDefault().Code,
                HUCActivity = "MARINE SPREAD (VESSEL)",
                Cost = totalCostMarine
            });

            listHUCActivitiesDto.Add(new HUCActivitiesDto()
            {
                Shedule = MasterSchedule.Where(x => x.Name == "MARINE SPREAD & OTHERS").FirstOrDefault().Code,
                HUCActivity = "MARINE SPREAD  (FUEL & PW)",
                Cost = totalCostOthers
            });

            HUCSummaryCost manPowerTotalCost_marineSpread = new HUCSummaryCost()
            {
                Id = Guid.NewGuid(),
                AssumptionId = requestId,
                MasterScheduleId = MasterSchedule.Where(x => x.Name == "MARINE SPREAD & OTHERS").FirstOrDefault().Id,
                MasterProjectTypeId = MasterProjectType.Id,
                CountryId = Country.Id,
                TotalCost = totalCostMarine
            };
            _unitOfWork.HUCSummaryCostRepository.Insert(manPowerTotalCost_marineSpread);
            HUCSummaryCost manPowerTotalCost_others = new HUCSummaryCost()
            {
                Id = Guid.NewGuid(),
                AssumptionId = requestId,
                MasterScheduleId = MasterSchedule.Where(x => x.Name == "MARINE SPREAD & OTHERS").FirstOrDefault().Id,
                MasterProjectTypeId = MasterProjectType.Id,
                CountryId = Country.Id,
                TotalCost = totalCostOthers
            };
            _unitOfWork.HUCSummaryCostRepository.Insert(manPowerTotalCost_others);

            // add totalcost of MARINE SPREAD to huccost
            listMarineSpreadOthers.Add(new MarineSpreadOthersDto()
            {
                Shedule = "listName",
                MarineSpread = "TOTAL COST",
                VesselCost = totalCostMarine,
                FuelPWCost = totalCostOthers
            });
            #endregion

            #region store and calculate THIRD PARTY SERVICES
            decimal? totalCostThird = 0;
            var thirdPartyServices = hucInputValuesDto.DefaultThirdPartyServicesSectionThree;
            var secondPartyServices = hucInputValuesDto.DefaultThirdPartyServicesSectionTwo;
            // create ThirdPartyDtos for ouput
            var listThirdPartyDtos = new List<ThirdPartyDto>();
            ThirdPartyServicesSectionTwoCost thirdPartyServicesSectionTwoCost = new ThirdPartyServicesSectionTwoCost()
            {
                Id = Guid.NewGuid(),
                AssumptionId = requestId,
                MasterProjectTypeId = MasterProjectType.Id,
                CountryId = Country.Id,
                MasterScheduleId = MasterSchedule.Where(x => x.Name == "THIRD PARTY SERVICES").FirstOrDefault().Id,
                Type = secondPartyServices.Type,
                Value = secondPartyServices.Value,
                Cost = Calculate(listManpowerTotal, secondPartyServices.Value, "ThirdPartyTwo")
            };
            totalCostThird += thirdPartyServicesSectionTwoCost.Cost;
            _unitOfWork.ThirdPartyServicesSectionTwoCostRepository.Insert(thirdPartyServicesSectionTwoCost);
            //add to huccost
            listThirdPartyDtos.Add(new ThirdPartyDto()
            {
                Shedule = "D",
                ThirdParty = thirdPartyServicesSectionTwoCost.Type,
                Cost = thirdPartyServicesSectionTwoCost.Cost
            });
            var defaultThirdPartyServicesSectionTwos = _unitOfWork.DefaultThirdPartyServicesSectionTwoRepository.Filter(x => x.IsDeleted == false);
            // get default value of third party one to calculate third party three
            var DefaultThirdPartyServicesSectionOne = new List<DefaultThirdPartyServicesSectionOneDto>();
            var defaultThirdPartyServicesSectionOnes = _unitOfWork.DefaultThirdPartyServicesSectionOneRepository.Filter(x => x.IsDeleted == false && x.Country.Name == Country.Name);
            if (defaultThirdPartyServicesSectionOnes.Any())
            {
                DefaultThirdPartyServicesSectionOne.AddRange(await defaultThirdPartyServicesSectionOnes.ProjectTo<DefaultThirdPartyServicesSectionOneDto>(_mapper.ConfigurationProvider).ToListAsync());
            }

            for (int i = 0; i < thirdPartyServices.Count; i++)
            {
                ThirdPartyServicesSectionThreeCost thirdPartyServicesSectionThreeCost = new ThirdPartyServicesSectionThreeCost()
                {
                    Id = Guid.NewGuid(),
                    Type = thirdPartyServices[i].Type,
                    AssumptionId = requestId,
                    MasterScheduleId = MasterSchedule.Where(x => x.Name == "THIRD PARTY SERVICES").FirstOrDefault().Id,
                    MasterProjectTypeId = MasterProjectType.Id,
                    CountryId = Country.Id,
                    No_Of_MOB_DEMOB = thirdPartyServices[i].No_Of_MOB_DEMOB,
                    Duration_Days = thirdPartyServices[i].Duration_Days,
                    No_Of_Set = thirdPartyServices[i].No_Of_Set,
                    Cost = Calculate("ThirdPartyThree", DefaultThirdPartyServicesSectionOne[i], thirdPartyServices[i].No_Of_MOB_DEMOB, thirdPartyServices[i].Duration_Days, thirdPartyServices[i].No_Of_Set, thirdPartyServices[i].No_Of_Pax)
                };
                totalCostThird += thirdPartyServicesSectionThreeCost.Cost;
                _unitOfWork.ThirdPartyServicesSectionThreeCostRepository.Insert(thirdPartyServicesSectionThreeCost);
                //add to huccost
                listThirdPartyDtos.Add(new ThirdPartyDto()
                {
                    Shedule = "D",
                    ThirdParty = thirdPartyServicesSectionThreeCost.Type,
                    Cost = thirdPartyServicesSectionThreeCost.Cost
                });
            }

            listHUCActivitiesDto.Add(new HUCActivitiesDto()
            {
                Shedule = MasterSchedule.Where(x => x.Name == "THIRD PARTY SERVICES").FirstOrDefault().Code,
                Cost = totalCostThird
            });

            HUCSummaryCost manPowerTotalCost_thirdParty = new HUCSummaryCost()
            {
                Id = Guid.NewGuid(),
                AssumptionId = requestId,
                MasterScheduleId = MasterSchedule.Where(x => x.Name == "THIRD PARTY SERVICES").FirstOrDefault().Id,
                MasterProjectTypeId = MasterProjectType.Id,
                CountryId = Country.Id,
                TotalCost = totalCostThird
            };
            _unitOfWork.HUCSummaryCostRepository.Insert(manPowerTotalCost_thirdParty);
            //
            listThirdPartyDtos.Add(new ThirdPartyDto()
            {
                Shedule = "D",
                ThirdParty = "TOTAL COST",
                Cost = totalCostThird
            });
            #endregion

            #region calculate WOW ( CONTIGENCIES)
            // create list wow for output
            List<WOWDto> wOWDtos = new List<WOWDto>();
            var wowObject = typicalObject.Where(x => x.MasterTypicalManpower == "WOW").FirstOrDefault();
            var masterOffshore_wow = MasterOffShoreAccomodation.Where(x => x.Value == wowObject.MasterOffShoreAccomodation).FirstOrDefault();
            var masterDaysFactor_wow = MasterDaysFactorperMonth.Where(x => x.DaysFactorPerMonth == wowObject.MasterDaysFactorperMonth).FirstOrDefault();
            var masterTypical_wow = MasterTypicalManpower.Where(x => x.ManPowerName == wowObject.MasterTypicalManpower).FirstOrDefault();

            TypicalManpowerCost typicalManpowerCost_Wow = new TypicalManpowerCost()
            {
                Id = Guid.NewGuid(),

                MasterOffShoreAccomodationId = masterOffshore_wow == null ? (Nullable<Guid>)null : masterOffshore_wow.Id,
                MasterDaysFactorperMonthId = masterDaysFactor_wow.Id,
                MasterTypicalManpowerId = masterTypical_wow.Id,
                MasterScheduleId = MasterSchedule.Where(x => x.Name == "MANPOWER").FirstOrDefault().Id,
                MasterProjectTypeId = MasterProjectType.Id,
                CountryId = Country.Id,

                AssumptionId = requestId,
                DurationDays = wowObject.DurationDays,
                QTY = 0,
                MANHOURS = 0,
                RATE = 0,
                Cost = wowObject.DurationDays * Calculate("Wow", sumManpower_Wow, sumDuration_Wow_1, sumDuration_Wow_2, totalCostMarine, totalCostOthers, equipmentToolsConsCost.TotalCost)
            };
            _unitOfWork.TypicalManpowerCostRepository.Insert(typicalManpowerCost_Wow);
            HUCSummaryCost manPowerTotalCost_WOW = new HUCSummaryCost()
            {
                Id = Guid.NewGuid(),
                AssumptionId = requestId,
                MasterScheduleId = MasterSchedule.Where(x => x.Name == "MANPOWER").FirstOrDefault().Id,
                MasterProjectTypeId = MasterProjectType.Id,
                CountryId = Country.Id,
                TotalCost = typicalManpowerCost_Wow.Cost
            };

            _unitOfWork.HUCSummaryCostRepository.Insert(manPowerTotalCost_WOW);
            listHUCActivitiesDto.Add(new HUCActivitiesDto()
            {
                //Shedule = MasterSchedule.Where(x => x.Name == "MANPOWER").FirstOrDefault().Code,
                Shedule = "E",
                HUCActivity = "CONTIGENCIES (WOW)",
                Cost = typicalManpowerCost_Wow.Cost
            });
            #endregion

            #region add data to CONTIGENCIES (WOW)
            wOWDtos.Add(new WOWDto()
            {
                Shedule = "E",
                Name = "MAN-HOURS /EQUIPMENT/ TOOLS/ CONSUMABLES",
                Remark = wowObject.DurationDays,
                Cost = Calculate("WowManhours", typicalManpowerCost_Wow.DurationDays, manPowerTotalCost_Manpower.TotalCost, manPowerTotalCost_Equiment.TotalCost, sumDuration_Wow_1)
            });
            // add value to wow marine
            wOWDtos.Add(new WOWDto()
            {
                Shedule = "E",
                Name = "MARINE SPREAD (VESSEL)",
                Remark = wowObject.DurationDays,
                Cost = Calculate("WowMarine", typicalManpowerCost_Wow.DurationDays, totalCostMarine, sumDuration_Wow_2)
            });
            // add value to others
            wOWDtos.Add(new WOWDto()
            {
                Shedule = "E",
                Name = "OTHERS (FUEL & PW)",
                Remark = wowObject.DurationDays,
                Cost = Calculate("WowOthers", typicalManpowerCost_Wow.DurationDays, totalCostOthers, sumDuration_Wow_2)
            });
            //add value to toal cost
            wOWDtos.Add(new WOWDto()
            {
                Shedule = "E",
                Name = "TOTAL COST",
                Remark = wowObject.DurationDays,
                Cost = typicalManpowerCost_Wow.Cost
            }) ;

            #endregion
            // add value to total cost of HUC ACTIVITIES 
            foreach (var item in listHUCActivitiesDto)
            {
                totalCostOfAll += item.Cost;
            }
            
            listHUCActivitiesDto.Add(new HUCActivitiesDto()
            {
                Shedule = "",
                HUCActivity = "TOTAL HUC COST",
                Cost = totalCostOfAll
            });


            // complete store data to db
            await _unitOfWork.CommitAsync();


            //TODO: need to add total HUC cost for individual and total

            // add list data to huccost
            HUCCostObject.MAN_HOURS_COST = listHUCCosA1tDto;
            HUCCostObject.EQUIPMENT_TOOLS_CONSUMABLES = HUCCosA2TDto;
            HUCCostObject.MATERIALS = HUCCostMaterialsDtos;
            HUCCostObject.MARINE_SPREAD = listMarineSpreadOthers;
            HUCCostObject.THIRD_PARTY_SERVICES = listThirdPartyDtos;
            HUCCostObject.CONTIGENCIES = wOWDtos;

            // add information for id,address...
            hUCCostSummaryDto.HUCCostSummaryId = requestId;
            hUCCostSummaryDto.Country = Country.Name;
            hUCCostSummaryDto.ProjectType = MasterProjectType.Type;
            hUCCostSummaryDto.CountryCurrency = GetTheCurrency(Country.Name);

            // add all list data to ouput
            hUCCostSummaryDto.HUCActivities = listHUCActivitiesDto;
            hUCCostSummaryDto.HUCCost = HUCCostObject;


            await _unitOfWork.CommitAsync();

            // fill data to ExcelFile
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(filePath);
            workbook = FillDataToFile(hUCCostSummaryDto, workbook);
            workbook.SaveToFile(filePath);
            workbook.Save();

            return hUCCostSummaryDto;
        }
        private Workbook FillDataToFile(HUCCostSummaryDto data, Workbook workbook)
        {
            Worksheet worksheet = workbook.Worksheets[0];
            worksheet.Range["E8"].Value = data.ProjectType;
            var activities = data.HUCActivities;
            for (int i = 0; i < activities.Count; i++)
            {
                worksheet.Range[$"F{i + 9}"].Value = activities[i].Cost.ToString();
            }
            var manCost = data.HUCCost.MAN_HOURS_COST;
            for (int i = 0; i < manCost.Count; i++)
            {
                worksheet.Range[$"F{i + 20}"].Value = manCost[i].Cost.ToString();
                worksheet.Range[$"G{i + 20}"].Value = manCost[i].ManHours.ToString();
            }
            //worksheet.Range[$"F27"].Value = data.HUCCost.TotalCostMYR.ToString();
            //worksheet.Range[$"G27"].Value = data.HUCCost.TotalManHours.ToString();

            var equipment = data.HUCCost.EQUIPMENT_TOOLS_CONSUMABLES;
            for (int i = 0; i < equipment.Count; i++)
            {
                worksheet.Range[$"F{i + 30}"].Value = equipment[i].Cost.ToString();
                worksheet.Range["G30"].Value = (equipment[0].Remarks/100).ToString();
            }
            

            var materials = data.HUCCost.MATERIALS;
            for (int i = 0; i < materials.Count; i++)
            {
                worksheet.Range[$"F{i + 34}"].Value = materials[i].Cost.ToString();
                worksheet.Range["G34"].Value = materials[i].FlowLinesQty.ToString();
            }
            
            var marineSpread = data.HUCCost.MARINE_SPREAD;
            for (int i = 0; i < marineSpread.Count; i++)
            {
                worksheet.Range[$"F{i + 39}"].Value = marineSpread[i].VesselCost.ToString();
                worksheet.Range[$"G{i + 39}"].Value = marineSpread[i].FuelPWCost.ToString();
            }
            //worksheet.Range[$"F46"].Value = data.HUCCost.TotalCostOfVessel.ToString();
            //worksheet.Range[$"G46"].Value = data.HUCCost.TotalCostOfFuel_PW.ToString();

            var thirdParty = data.HUCCost.THIRD_PARTY_SERVICES;
            for (int i = 0; i < thirdParty.Count; i++)
            {
                worksheet.Range[$"F{i + 49}"].Value = thirdParty[i].Cost.ToString();
            }
            //worksheet.Range[$"F58"].Value = data.HUCCost.TotalCostOfThirdParty.ToString();

            var contigencies = data.HUCCost.CONTIGENCIES;
            for (int i = 0; i < contigencies.Count; i++)
            {
                worksheet.Range[$"F{i + 61}"].Value = contigencies[i].Cost.ToString();
                worksheet.Range[$"G62"].Value = contigencies[i].Remark.ToString();
            }
            //worksheet.Range[$"F64"].Value = data.HUCCost.TotalCostOfWow.ToString();


            return workbook;
        }
        private List<DefaultMarineSpreadAndOthersDto> CalculateMarineSpreadTotalDays(List<DefaultManpowerDto> defaultManpowerDtos, List<DefaultMarineSpreadAndOthersDto> defaultMarineSpreadAndOthersDtos)
        {

            foreach (var defaultMarineSpreadAndOthersDto in defaultMarineSpreadAndOthersDtos)
            {
                if (defaultMarineSpreadAndOthersDto.VesselType == "ONSHORE INDIRECT" || defaultMarineSpreadAndOthersDto.VesselType == "ONSHORE DIRECT" || defaultMarineSpreadAndOthersDto.VesselType == "OFFSHORE CAMPAIGN 1" || defaultMarineSpreadAndOthersDto.VesselType == "OFFSHORE CAMPAIGN 2" || defaultMarineSpreadAndOthersDto.VesselType == "OFFSHORE CAMPAIGN 3 (OPTIONAL)")
                {
                    var vesselType = defaultManpowerDtos.Where(X => X.OFFSHOREACCOMODATION == defaultMarineSpreadAndOthersDto.VesselType).SkipWhile(x => x.MasterTypicalManPowers != "ENGINEERING" && x.MasterTypicalManPowers != "FINAL DOCUMENTATION" && x.MasterTypicalManPowers != "WOW");
                    if (vesselType.Any())
                    {
                        defaultMarineSpreadAndOthersDto.TotalDuration_Days = vesselType.Sum(x => x.Qty);
                    };
                }
                else
                {
                    if (defaultMarineSpreadAndOthersDto.QTYMOBDEMOB_Mob_Demob > 0)
                    {
                        var vesselType = defaultManpowerDtos.Where(X => X.OFFSHOREACCOMODATION == defaultMarineSpreadAndOthersDto.VesselType).TakeWhile(x => x.MasterTypicalManPowers.Contains("CAMPAIGN 1") && x.MasterTypicalManPowers.Contains("CAMPAIGN 2") && x.MasterTypicalManPowers.Contains("CAMPAIGN 3"));
                        if (vesselType.Any())
                        {
                            defaultMarineSpreadAndOthersDto.TotalDuration_Days = vesselType.Sum(x => x.Qty);
                        };
                    }
                }

            }

            return defaultMarineSpreadAndOthersDtos;
        }
        private string GetTheCurrency(string country = null)
        {
            return _countryCurrencies.FirstOrDefault(x => x.Key == country).Value ?? "MYR";
        }
        private decimal? Calculate(string calculationtype = "ManpowerTotal", params decimal?[] values)
        {
            decimal? cost = 0;
            decimal FuleMry = (decimal)3.7;
            decimal Portable = 30;
            if (calculationtype == "ManpowerTotal" || calculationtype == "MATERIALS")
            {
                cost = 1;
                foreach (decimal value in values)
                {
                    cost *= value;
                }
                return cost;
            }
            // formular of MAN-HOURS
            if (calculationtype == "ManHours")
            {
                cost = values[0] / values[1];
                return cost;
            }
            if (calculationtype == "Marine")
            {
                cost = values[0] * values[1] + (values[2] + values[3]) * values[4];
                return cost;
            }
            if (calculationtype == "Others")
            {

                if (values[0] >= 1)
                {
                    cost = values[0] * ((values[1] * values[2] * FuleMry) + (values[1] * values[3] * Portable));
                }
                return cost;
            }
            if (calculationtype == "sum")
            {
                cost = values.Sum() - values[0];
                return cost;
            }
            if (calculationtype == "Wow")
            {

                cost = (values[0] + values[5]) / values[1] + (values[3] + values[4]) / values[2];
                return cost;
            }
            if (calculationtype == "WowManhours")
            {
                cost = values[0] * (values[1] + values[2]) / values[3];
                return cost;
            }
            if (calculationtype == "WowMarine" || calculationtype == "WowOthers")
            {
                cost = values[0] * values[1] / values[2];
                return cost;
            }
            if (calculationtype == "SumManPower")
            {
                cost = values.Sum();
                return cost;
            }
            else
            {
                cost = values.Sum() - values[0];
            }
            return cost;
        }
        private decimal? Calculate(string criteria, decimal? value, List<decimal?> limits, List<string> range)
        {
            decimal? result = 0;
            if (criteria == "AWB" || criteria == "DP" || criteria == "WORK BOAT" || criteria == "UTILITY VESSEL")
            {

                for (int i = 0; i < range.Count - 1; i++)
                {
                    if (range[i] == criteria)
                    {
                        result += limits[i];
                    }
                }
            }
            else
            {
                if (value > 0)
                {
                    result = limits[2] + limits[3] + limits[4];
                }
                else
                {
                    result = 0;
                }
            }
            return result;

        }
        private decimal? Calculate(List<decimal?> limits, decimal? percen, params string[] values)
        {

            decimal? cost = 0;
            if (values[0] == "ThirdPartyTwo")
            {
                cost = percen * (limits[1] + limits[2] + limits[3] + limits[4]) / 100;
            }
            return cost;
        }
        private decimal? Calculate(string calculationtype, DefaultThirdPartyServicesSectionOneDto defaultData, params decimal?[] values)
        {

            decimal? cost = 0;
            if (calculationtype == "ThirdPartyThree")
            {
                cost = defaultData.MOBANDDEMOB_RATE_RM_MOB * values[0] + defaultData.Equipment_Per_Set * values[1] * values[2] + defaultData.Technician_Per_Set * values[1] * values[3];
            }
            return cost;
        }
    }
}
