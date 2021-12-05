using CF.CostBrainService.Application.Common.Interfaces;
using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities.Base;
using CF.CostBrainService.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.CostBrainService.Persistence
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ApplicationDbContext _context;
        private IUserRepository _userRepository;
        private IEquipmentRepository _equipmentRepository;
        private IEquipmentCostRepository _equipmentCostRepository;
        private ICountryRepository _countryRepository;
        private IFabricationRepository _fabricationRepository;
        private ICostSummaryStructureRepository _costSummaryStructureRepository;
        private ICostSummarySubTotalRepository _costSummarySubTotalRepository;
        private IMasterGeneralSettingsRepository _masterGeneralSettingsRepository;
        private IGeneralSettingsDetailsRepository _generalSettingsDetailsRepository;
        private IGeneralSettingsValuesRepository _generalSettingsValuesRepository;
        private IMasterProjectTypeRepository _masterProjectTypeRepository;
        private IMasterDaysFactorperMonthRepository _masterDaysFactorperMonthRepository;
        private IMasterOffShoreAccomodationRepository _masterOffShoreAccomodationRepository;
        private IMasterScheduleRepository _masterScheduleRepository;
        private IMasterSubScheduleRepository _masterSubScheduleRepository;
        private IMasterTypicalManpowerRepository _masterTypicalManpowerRepository;
        private IDefaultManpowerRepository _defaultManpowerRepository;
        private IDefaultManpowerManHrsRateRepository _defaultManpowerManHrsRateRepository;
        private IDefaultEquipmentManPowerPercentageRepository _defaultEquipmentManPowerPercentageRepository;
        private IDefaultMarineSpreadAndOthersRepository _defaultMarineSpreadAndOthersRepository;
        private IDefaultOthersFuelAndPWRepository _defaultOthersFuelAndPWRepository;
        private IDefaultThirdPartyServicesSectionOneRepository _defaultThirdPartyServicesSectionOneRepository;
        private IDefaultThirdPartyServicesSectionTwoRepository _defaultThirdPartyServicesSectionTwoRepository;
        private IDefaultThirdPartyServicesSectionThreeRepository _defaultThirdPartyServicesSectionThreeRepository;
        private ITypicalManpowerCostRepository _typicalManpowerCostRepository;
        private IHUCSummaryCostRepository _hUCSummaryCostRepository;
        private IEquipmentToolsConsCostRepository _equipmentToolsConsCostRepository;
        private IMaterialsCostRepository _materialsCostRepository;
        private IMarineSpreadCostRepository _marineSpreadCostRepository;
        private IFuelAndPWCostRepository _fuelAndPWCostRepository;
        private IThirdPartyServicesSectionTwoCostRepository _thirdPartyServicesSectionTwoCostRepository;
        private IThirdPartyServicesSectionThreeCostRepository _thirdPartyServicesSectionThreeCostRepository;
        private ITICostCalculationRepository _tiCostCalculationRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {

                if (this._userRepository == null)
                {
                    this._userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }
        public IEquipmentRepository EquipmentRepository
        {
            get
            {

                if (this._equipmentRepository == null)
                {
                    this._equipmentRepository = new EquipmentRepository(_context);
                }
                return _equipmentRepository;
            }
        }
        public IEquipmentCostRepository EquipmentCostRepository
        {
            get
            {

                if (this._equipmentCostRepository == null)
                {
                    this._equipmentCostRepository = new EquipmentCostRepository(_context);
                }
                return _equipmentCostRepository;
            }
        }

        public ICountryRepository CountryRepository
        {
            get
            {

                if (this._countryRepository == null)
                {
                    this._countryRepository = new CountryRepository(_context);
                }
                return _countryRepository;
            }
        }
        public IFabricationRepository FabricationRepository
        {
            get
            {

                if (this._fabricationRepository == null)
                {
                    this._fabricationRepository = new FabricationRepository(_context);
                }
                return _fabricationRepository;
            }
        }
        public ICostSummaryStructureRepository CostSummaryStructureRepository
        {
            get
            {

                if (this._costSummaryStructureRepository == null)
                {
                    this._costSummaryStructureRepository = new CostSummaryStructureRepository(_context);
                }
                return _costSummaryStructureRepository;
            }
        }
        public ICostSummarySubTotalRepository CostSummarySubTotalRepository
        {
            get
            {

                if (this._costSummarySubTotalRepository == null)
                {
                    this._costSummarySubTotalRepository = new CostSummarySubTotalRepository(_context);
                }
                return _costSummarySubTotalRepository;
            }
        }
        public IMasterGeneralSettingsRepository MasterGeneralSettingsRepository
        {
            get
            {

                if (this._masterGeneralSettingsRepository == null)
                {
                    this._masterGeneralSettingsRepository = new MasterGeneralSettingsRepository(_context);
                }
                return _masterGeneralSettingsRepository;
            }
        }
        public IGeneralSettingsDetailsRepository GeneralSettingsDetailsRepository
        {
            get
            {

                if (this._generalSettingsDetailsRepository == null)
                {
                    this._generalSettingsDetailsRepository = new GeneralSettingsDetailsRepository(_context);
                }
                return _generalSettingsDetailsRepository;
            }
        }
        public IGeneralSettingsValuesRepository GeneralSettingsValuesRepository
        {
            get
            {

                if (this._generalSettingsValuesRepository == null)
                {
                    this._generalSettingsValuesRepository = new GeneralSettingsValuesRepository(_context);
                }
                return _generalSettingsValuesRepository;
            }
        }

        public IMasterProjectTypeRepository MasterProjectTypeRepository
        {
            get
            {
                if (this._masterProjectTypeRepository == null)
                {
                    this._masterProjectTypeRepository = new MasterProjectTypeRepository(_context);
                }
                return _masterProjectTypeRepository;
            }
        }

        public IMasterDaysFactorperMonthRepository MasterDaysFactorperMonthRepository
        {
            get
            {
                if (this._masterDaysFactorperMonthRepository == null)
                {
                    this._masterDaysFactorperMonthRepository = new MasterDaysFactorperMonthRepository(_context);
                }
                return _masterDaysFactorperMonthRepository;
            }
        }

        public IMasterOffShoreAccomodationRepository MasterOffShoreAccomodationRepository
        {
            get
            {
                if (this._masterOffShoreAccomodationRepository == null)
                {
                    this._masterOffShoreAccomodationRepository = new MasterOffShoreAccomodationRepository(_context);
                }
                return _masterOffShoreAccomodationRepository;
            }
        }

        public IMasterScheduleRepository MasterScheduleRepository
        {
            get
            {
                if (this._masterScheduleRepository == null)
                {
                    this._masterScheduleRepository = new MasterScheduleRepository(_context);
                }
                return _masterScheduleRepository;
            }
        }

        public IMasterSubScheduleRepository MasterSubScheduleRepository
        {
            get
            {
                if (this._masterSubScheduleRepository == null)
                {
                    this._masterSubScheduleRepository = new MasterSubScheduleRepository(_context);
                }
                return _masterSubScheduleRepository;
            }
        }

        public IMasterTypicalManpowerRepository MasterTypicalManpowerRepository
        {
            get
            {
                if (this._masterTypicalManpowerRepository == null)
                {
                    this._masterTypicalManpowerRepository = new MasterTypicalManpowerRepository(_context);
                }
                return _masterTypicalManpowerRepository;
            }
        }

        public IDefaultManpowerRepository DefaultManpowerRepository
        {
            get
            {
                if (this._defaultManpowerRepository == null)
                {
                    this._defaultManpowerRepository = new DefaultManpowerRepository(_context);
                }
                return _defaultManpowerRepository;
            }
        }

        public IDefaultManpowerManHrsRateRepository DefaultManpowerManHrsRateRepository
        {
            get
            {
                if (this._defaultManpowerManHrsRateRepository == null)
                {
                    this._defaultManpowerManHrsRateRepository = new DefaultManpowerManHrsRateRepository(_context);
                }
                return _defaultManpowerManHrsRateRepository;
            }
        }

        public IDefaultEquipmentManPowerPercentageRepository DefaultEquipmentManPowerPercentageRepository
        {
            get
            {
                if (this._defaultEquipmentManPowerPercentageRepository == null)
                {
                    this._defaultEquipmentManPowerPercentageRepository = new DefaultEquipmentManPowerPercentageRepository(_context);
                }
                return _defaultEquipmentManPowerPercentageRepository;
            }
        }

        public IDefaultMarineSpreadAndOthersRepository DefaultMarineSpreadAndOthersRepository
        {
            get
            {
                if (this._defaultMarineSpreadAndOthersRepository == null)
                {
                    this._defaultMarineSpreadAndOthersRepository = new DefaultMarineSpreadAndOthersRepository(_context);
                }
                return _defaultMarineSpreadAndOthersRepository;
            }
        }

        public IDefaultOthersFuelAndPWRepository DefaultOthersFuelAndPWRepository
        {
            get
            {
                if (this._defaultOthersFuelAndPWRepository == null)
                {
                    this._defaultOthersFuelAndPWRepository = new DefaultFuelAndPWRepository(_context);
                }
                return _defaultOthersFuelAndPWRepository;
            }
        }

        public IDefaultThirdPartyServicesSectionOneRepository DefaultThirdPartyServicesSectionOneRepository
        {
            get
            {
                if (this._defaultThirdPartyServicesSectionOneRepository == null)
                {
                    this._defaultThirdPartyServicesSectionOneRepository = new DefaultThirdPartyServicesSectionOneRepository(_context);
                }
                return _defaultThirdPartyServicesSectionOneRepository;
            }
        }

        public IDefaultThirdPartyServicesSectionTwoRepository DefaultThirdPartyServicesSectionTwoRepository
        {
            get
            {
                if (this._defaultThirdPartyServicesSectionTwoRepository == null)
                {
                    this._defaultThirdPartyServicesSectionTwoRepository = new DefaultThirdPartyServicesSectionTwoRepository(_context);
                }
                return _defaultThirdPartyServicesSectionTwoRepository;
            }
        }

        public IDefaultThirdPartyServicesSectionThreeRepository DefaultThirdPartyServicesSectionThreeRepository
        {
            get
            {
                if (this._defaultThirdPartyServicesSectionThreeRepository == null)
                {
                    this._defaultThirdPartyServicesSectionThreeRepository = new DefaultThirdPartyServicesSectionThreeRepository(_context);
                }
                return _defaultThirdPartyServicesSectionThreeRepository;
            }
        }
        public ITypicalManpowerCostRepository TypicalManpowerCostRepository
        {
            get
            {
                if (this._typicalManpowerCostRepository == null)
                {
                    this._typicalManpowerCostRepository = new TypicalManpowerCostRepository(_context);
                }
                return _typicalManpowerCostRepository;
            }
        }

        public IHUCSummaryCostRepository HUCSummaryCostRepository
        {
            get
            {
                if (this._hUCSummaryCostRepository == null)
                {
                    this._hUCSummaryCostRepository = new HUCSummaryCostRepository(_context);
                }
                return _hUCSummaryCostRepository;
            }
        }

        public IEquipmentToolsConsCostRepository EquipmentToolsConsCostRepository
        {
            get
            {
                if (this._equipmentToolsConsCostRepository == null)
                {
                    this._equipmentToolsConsCostRepository = new EquipmentToolsConstCostRepository(_context);
                }
                return _equipmentToolsConsCostRepository;
            }
        }

        public IMaterialsCostRepository MaterialsCostRepository
        {
            get
            {
                if (this._materialsCostRepository == null)
                {
                    this._materialsCostRepository = new MaterialsCostRepository(_context);
                }
                return _materialsCostRepository;
            }
        }

        public IMarineSpreadCostRepository MarineSpreadCostRepository
        {
            get
            {
                if (this._marineSpreadCostRepository == null)
                {
                    this._marineSpreadCostRepository = new MarineSpreadCostRepository(_context);
                }
                return _marineSpreadCostRepository;
            }
        }

        public IFuelAndPWCostRepository fuelAndPWCostRepository
        {
            get
            {
                if (this._fuelAndPWCostRepository == null)
                {
                    this._fuelAndPWCostRepository = new FuelAndPWCostRepository(_context);
                }
                return _fuelAndPWCostRepository;
            }
        }

        public IThirdPartyServicesSectionTwoCostRepository ThirdPartyServicesSectionTwoCostRepository
        {
            get
            {
                if (this._thirdPartyServicesSectionTwoCostRepository == null)
                {
                    this._thirdPartyServicesSectionTwoCostRepository = new ThirdPartyServicesSectionTwoCostRepository(_context);
                }
                return _thirdPartyServicesSectionTwoCostRepository;
            }
        }

        public IThirdPartyServicesSectionThreeCostRepository ThirdPartyServicesSectionThreeCostRepository
        {
            get
            {
                if (this._thirdPartyServicesSectionThreeCostRepository == null)
                {
                    this._thirdPartyServicesSectionThreeCostRepository = new ThirdPartyServicesSectionThreeCostRepository(_context);
                }
                return _thirdPartyServicesSectionThreeCostRepository;
            }
        }

        public ITICostCalculationRepository TICostCalculationRepository
        {
            get
            {
                if (this._tiCostCalculationRepository == null)
                {
                    this._tiCostCalculationRepository = new TICostCalculationRepository(_context);
                }
                return _tiCostCalculationRepository;
            }
        }
        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void DetachEntity<T>(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
