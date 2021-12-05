using CF.CostBrainService.Application.Common.Interfaces;
using CF.CostBrainService.Application.Features.GeneralSettings.Dto;
using CF.CostBrainService.Application.Common.Constants;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.CostBrainService.Application.Features.GeneralSettings.Queries
{
    public class GetGeneralSettingsQuery : IRequest<GeneralSettingDto>
    {
        public class GetGeneralSettingsQueryHandler : IRequestHandler<GetGeneralSettingsQuery, GeneralSettingDto>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILogger<GetGeneralSettingsQuery> logger;

            public GetGeneralSettingsQueryHandler(IUnitOfWork unitOfWork, ILogger<GetGeneralSettingsQuery> logger)
            {
                _unitOfWork = unitOfWork;
                this.logger = logger;
            }

            public async Task<GeneralSettingDto> Handle(GetGeneralSettingsQuery request, CancellationToken cancellationToken)
            {
                GeneralSettingDto generalSettingDto = generalSettingDto = new GeneralSettingDto();
                try
                {
                    var generalDataList = _unitOfWork.GeneralSettingsDetailsRepository.Filter(a => !a.IsDeleted).ToList()
                                               .Join(_unitOfWork.MasterGeneralSettingsRepository.Filter(b => !b.IsDeleted)
                                               .ToList(), a => a.MasterGeneralSettingsId, b => b.Id, (a, b) => new { GeneralSettingsDetails = a, MasterGeneralSetting = b }).ToList();

                    foreach (var item in generalDataList)
                    {  
                        if (item.GeneralSettingsDetails.Type.ToUpper() == GeneralSettingsConst.Rate.ToUpper())
                        {
                            generalSettingDto.Rate = new Rate()
                            {
                                GenralSettingId = item.GeneralSettingsDetails.Id,
                                label = item.MasterGeneralSetting.LabelName,
                                IsCurrency = item.GeneralSettingsDetails.IsCurrency,
                                CurrencyLabel = item.GeneralSettingsDetails.CurrencyLabel,
                                Value = item.GeneralSettingsDetails.Value,
                                Unit = item.GeneralSettingsDetails.Unit
                            };
                        }
                        else if (item.GeneralSettingsDetails.Type.ToUpper() == GeneralSettingsConst.PreDevFeed.ToUpper())
                        {
                            generalSettingDto.PreDevFeed = new PreDevFeed()
                            {
                                GenralSettingId = item.GeneralSettingsDetails.Id,
                                label = item.MasterGeneralSetting.LabelName,
                                IsCurrency = item.GeneralSettingsDetails.IsCurrency,
                                CurrencyLabel = item.GeneralSettingsDetails.CurrencyLabel,
                                Value = item.GeneralSettingsDetails.Value,
                                Unit = item.GeneralSettingsDetails.Unit
                            };
                        }
                        else if (item.GeneralSettingsDetails.Type.ToUpper() == GeneralSettingsConst.OwnerCost.ToUpper())
                        {
                            generalSettingDto.OwnerCost = new OwnerCost()
                            {
                                GenralSettingId = item.GeneralSettingsDetails.Id,
                                label = item.MasterGeneralSetting.LabelName,
                                IsCurrency = item.GeneralSettingsDetails.IsCurrency,
                                CurrencyLabel = item.GeneralSettingsDetails.CurrencyLabel,
                                Value = item.GeneralSettingsDetails.Value,
                                Unit = item.GeneralSettingsDetails.Unit
                            };
                        }
                        else if (item.GeneralSettingsDetails.Type.ToUpper() == GeneralSettingsConst.PhasingYears.ToUpper())
                        {
                            generalSettingDto.PhasingYears = new PhasingYears()
                            {
                                GenralSettingId = item.GeneralSettingsDetails.Id,
                                label = item.MasterGeneralSetting.LabelName,
                                IsCurrency = item.GeneralSettingsDetails.IsCurrency,
                                CurrencyLabel = item.GeneralSettingsDetails.CurrencyLabel,
                                Value = item.GeneralSettingsDetails.Value,
                                Unit = item.GeneralSettingsDetails.Unit
                            };
                        }
                        else if (item.GeneralSettingsDetails.Type.ToUpper() == GeneralSettingsConst.DefaultCurrency.ToUpper())
                        {
                            List<DefaultCurrencyValue> listDefaultCurrencies = new List<DefaultCurrencyValue>();
                            generalSettingDto.DefaultCurrency = new DefaultCurrency()
                            {
                                GenralSettingId = item.GeneralSettingsDetails.Id,
                                label = item.MasterGeneralSetting.LabelName,
                                IsCurrency = item.GeneralSettingsDetails.IsCurrency,
                                CurrencyLabel = item.GeneralSettingsDetails.CurrencyLabel,
                                Unit = item.GeneralSettingsDetails.Unit
                            };
                            if (item.GeneralSettingsDetails.IsMultipleValue)
                            {                               
                                var defaultCurrencyData = _unitOfWork.GeneralSettingsValuesRepository.Filter(a => !a.IsDeleted)
                                                         .Where(x => x.GeneralSettingsDetailsId == item.GeneralSettingsDetails.Id).ToList();
                                foreach (var defaultcurrencyObj in defaultCurrencyData)
                                {
                                    DefaultCurrencyValue defaultCurrency = new DefaultCurrencyValue()
                                    {
                                        Label = defaultcurrencyObj.Label,
                                        Value = defaultcurrencyObj.Value,
                                        IsActive = defaultcurrencyObj.IsActive,
                                    };
                                    listDefaultCurrencies.Add(defaultCurrency);
                                }                              
                            }
                            generalSettingDto.DefaultCurrency.Value = listDefaultCurrencies;
                        }
                    }
                    return generalSettingDto;
                }
                catch (Exception ex)
                {
                    logger.LogInformation(ex, "Exception Occured in GetGeneralSettingsQueryHandler", ex.Message);
                    return generalSettingDto;
                }
            }
        }
    }
}
