using CF.CostBrainService.Application.Common.Interfaces;
using CF.CostBrainService.Application.Common.Response;
using CF.CostBrainService.Application.Features.GeneralSettings.Commands.Dto;
using CF.CostBrainService.Application.Common.Constants;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CF.CostBrainService.Application.Features.GeneralSettings.Commands
{
    public class UpdateGeneralSettingsCommand : IRequest<ExceptionHelper<bool>>
    {
        public GeneralSettingsSaveDto GeneralData { get; set; }

        public class UpdateGeneralSettingsHandler : IRequestHandler<UpdateGeneralSettingsCommand, ExceptionHelper<bool>>
        {
            private readonly ILogger<UpdateGeneralSettingsCommand> _logger;
            private readonly IUnitOfWork _unitOfWork;

            public UpdateGeneralSettingsHandler(ILogger<UpdateGeneralSettingsCommand> logger, IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
                _logger = logger;
            }

            public async Task<ExceptionHelper<bool>> Handle(UpdateGeneralSettingsCommand request, CancellationToken cancellationToken)
            {
                ExceptionHelper<bool> reponse = new ExceptionHelper<bool>();
                var generalData = _unitOfWork.GeneralSettingsDetailsRepository.Filter(a => !a.IsDeleted).ToList();
                try
                {
                    if (generalData != null) 
                    {
                        if (request.GeneralData.Rate != null)
                        {
                            var ratefilteredData = generalData?.Where(x => x.Id == request.GeneralData.Rate.GenralSettingId && x.Type.ToUpper() == GeneralSettingsConst.Rate.ToUpper()).SingleOrDefault();
                            ratefilteredData.Value = request.GeneralData.Rate.Value;
                            _unitOfWork.GeneralSettingsDetailsRepository.Update(ratefilteredData);
                        }
                        else if (request.GeneralData.PreDevFeed != null)
                        {
                            var preDevFeedfilteredData = generalData?.Where(x => x.Id == request.GeneralData.PreDevFeed.GenralSettingId && x.Type.ToUpper() == GeneralSettingsConst.PreDevFeed.ToUpper()).SingleOrDefault();
                            preDevFeedfilteredData.Value = request.GeneralData.PreDevFeed.Value;
                            _unitOfWork.GeneralSettingsDetailsRepository.Update(preDevFeedfilteredData);
                        }
                        else if (request.GeneralData.OwnerCost != null)
                        {
                            var ownerCostfilteredData = generalData?.Where(x => x.Id == request.GeneralData.OwnerCost.GenralSettingId && x.Type.ToUpper() == GeneralSettingsConst.OwnerCost.ToUpper()).SingleOrDefault();
                            ownerCostfilteredData.Value = request.GeneralData.OwnerCost.Value;
                            _unitOfWork.GeneralSettingsDetailsRepository.Update(ownerCostfilteredData);
                        }
                        else if (request.GeneralData.PhasingYears != null)
                        {
                            var phasingYearsfilteredData = generalData?.Where(x => x.Id == request.GeneralData.PhasingYears.GenralSettingId && x.Type.ToUpper() == GeneralSettingsConst.PhasingYears.ToUpper()).SingleOrDefault();
                            phasingYearsfilteredData.Value = request.GeneralData.PhasingYears.Value;
                            _unitOfWork.GeneralSettingsDetailsRepository.Update(phasingYearsfilteredData);
                        }
                        else if (request.GeneralData.DefaultCurrency != null)
                        {
                            var filteredgeneralData = generalData?.Where(x => x.Id == request.GeneralData.DefaultCurrency.GenralSettingId && x.Type.ToUpper() == GeneralSettingsConst.DefaultCurrency.ToUpper()).SingleOrDefault();
                            var defaultCurrencyfilteredData = _unitOfWork.GeneralSettingsValuesRepository.Filter(a => !a.IsDeleted).ToList().Where(x => x.GeneralSettingsDetailsId == filteredgeneralData.Id);

                            foreach (var item in defaultCurrencyfilteredData)
                            {
                                if (item.Value.ToUpper() == request.GeneralData.DefaultCurrency.Value.ToUpper())
                                {
                                    item.IsActive = true;
                                    _unitOfWork.GeneralSettingsValuesRepository.Update(item);
                                }
                                else
                                {
                                    item.IsActive = false;
                                    _unitOfWork.GeneralSettingsValuesRepository.Update(item);
                                }
                            }
                        }
                        else
                        {
                            reponse.Data = false;
                            reponse.IsSucceed = false;
                            reponse.Message = "Data Should not be Empty";
                            return reponse;
                        }
                    }
                    else
                    {
                        reponse.Data = false;
                        reponse.IsSucceed = false;
                        reponse.Message = "Database Data is Blank or in Deleted Stage";
                        return reponse;
                    }
                    await _unitOfWork.CommitAsync();
                    reponse.Data = true;
                    reponse.IsSucceed = true;
                    return reponse;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex, "Exception Occured in GetGeneralSettingsQueryHandler", ex.Message);
                    reponse.Data = false;
                    reponse.IsSucceed = false;
                    return reponse;
                }
            }
        }
    }
}
