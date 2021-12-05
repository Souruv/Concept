using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using System.Threading.Tasks;

namespace CF.CostBrainService.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IEquipmentRepository EquipmentRepository { get; }
        public IEquipmentCostRepository EquipmentCostRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public IFabricationRepository FabricationRepository { get; }
        public ICostSummaryStructureRepository CostSummaryStructureRepository { get; }
        public ICostSummarySubTotalRepository CostSummarySubTotalRepository { get; }
        public IMasterGeneralSettingsRepository MasterGeneralSettingsRepository { get; }
        public IGeneralSettingsDetailsRepository GeneralSettingsDetailsRepository { get; }
        public IGeneralSettingsValuesRepository GeneralSettingsValuesRepository { get; }          
        public IMasterProjectTypeRepository MasterProjectTypeRepository { get; }
        public IMasterDaysFactorperMonthRepository MasterDaysFactorperMonthRepository { get; }
        public IMasterOffShoreAccomodationRepository MasterOffShoreAccomodationRepository { get; }
        public IMasterScheduleRepository MasterScheduleRepository { get; }
        public IMasterSubScheduleRepository MasterSubScheduleRepository { get; }
        public IMasterTypicalManpowerRepository MasterTypicalManpowerRepository { get; }
        public IDefaultManpowerRepository DefaultManpowerRepository { get; }
        public IDefaultManpowerManHrsRateRepository DefaultManpowerManHrsRateRepository { get; }
        public IDefaultEquipmentManPowerPercentageRepository DefaultEquipmentManPowerPercentageRepository { get; }
        public IDefaultMarineSpreadAndOthersRepository DefaultMarineSpreadAndOthersRepository { get; }
        public IDefaultOthersFuelAndPWRepository DefaultOthersFuelAndPWRepository { get; }
        public IDefaultThirdPartyServicesSectionOneRepository DefaultThirdPartyServicesSectionOneRepository { get; }
        public IDefaultThirdPartyServicesSectionTwoRepository DefaultThirdPartyServicesSectionTwoRepository { get; }
        public IDefaultThirdPartyServicesSectionThreeRepository DefaultThirdPartyServicesSectionThreeRepository { get; }
        public ITypicalManpowerCostRepository TypicalManpowerCostRepository { get; }
        public IHUCSummaryCostRepository HUCSummaryCostRepository { get; }
        public IEquipmentToolsConsCostRepository EquipmentToolsConsCostRepository { get; }
        public IMaterialsCostRepository MaterialsCostRepository { get; }
        public IMarineSpreadCostRepository MarineSpreadCostRepository { get; }
        public IFuelAndPWCostRepository fuelAndPWCostRepository { get; }
        public IThirdPartyServicesSectionTwoCostRepository ThirdPartyServicesSectionTwoCostRepository { get; }
        public IThirdPartyServicesSectionThreeCostRepository ThirdPartyServicesSectionThreeCostRepository { get; }
        public ITICostCalculationRepository TICostCalculationRepository { get; }

        public int Commit();
        public Task<int> CommitAsync();
        public void DetachEntity<T>(T entity);
    }
}
