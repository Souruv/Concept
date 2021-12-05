using CF.CostBrainService.Application.Common.Interfaces;
using CF.CostBrainService.Application.Entities;
using CF.CostBrainService.Application.Features.CostBrainSettings.Commands.Dto;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CF.CostBrainService.Application.Common.Response;
using Microsoft.EntityFrameworkCore;

namespace CF.CostBrainService.Application.Features.CostBrainSettings.Commands
{
    public class DeleteCostSettingsCommand : IRequest<ExceptionHelper<bool>>
    {
        public int WBS { get; set; }
        public Guid CountryCode { get; set; }

        public class DeleteCostSettingsHandler : IRequestHandler<DeleteCostSettingsCommand, ExceptionHelper<bool>>
        {
            private readonly ILogger<UpdateCostSettingsCommand> logger;
            private readonly ILoggedInUserService _loggedInUserService;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteCostSettingsHandler(IUnitOfWork unitOfWork, ILoggedInUserService loggedInUserService, ILogger<UpdateCostSettingsCommand> logger)
            {
                _unitOfWork = unitOfWork;
                this.logger = logger;
                _loggedInUserService = loggedInUserService;
            }

            public async Task<ExceptionHelper<bool>> Handle(DeleteCostSettingsCommand request, CancellationToken cancellationToken)
            {
                ExceptionHelper<bool> reponse = new ExceptionHelper<bool>();

                var countryListID = await _unitOfWork.CountryRepository.Filter(x => !x.IsDeleted).Select(y => y.Id).ToListAsync();
                var listDBWbsId = await _unitOfWork.EquipmentRepository.Filter(null).Select(x => x.WBSId).ToListAsync();

                if (request.CountryCode != Guid.Empty && countryListID.Contains(request.CountryCode) && request.WBS != 0 && listDBWbsId.Contains(request.WBS))
                {
                    var equipmentId = _unitOfWork.EquipmentRepository.Filter(x => x.WBSId == request.WBS).Select(y => y.Id).SingleOrDefault();
                    var equipmentCostId = _unitOfWork.EquipmentCostRepository.Filter(x => x.EquipmentId == equipmentId && x.CountryCode == request.CountryCode).Select(y => y.Id).SingleOrDefault();

                    var equipmentCost = await _unitOfWork.EquipmentCostRepository.GetSingleAsync(a => a.Id == equipmentCostId && a.EquipmentId == equipmentId && a.CountryCode == request.CountryCode);
                    if (equipmentCost != null) {
                        equipmentCost.IsDeleted = true;
                        equipmentCost.DeletedByUserId = _loggedInUserService.Id;
                        equipmentCost.DeletedOn = DateTime.Now;

                        _unitOfWork.EquipmentCostRepository.Update(equipmentCost);
                    }
                    else
                    {
                        reponse.Data = false;
                        reponse.IsSucceed = false;
                        reponse.Message = "Invalid CountryCode / WBS or Empty";
                        return reponse;
                    }
                    await _unitOfWork.CommitAsync();
                }
                else
                {
                    reponse.Data = false;
                    reponse.IsSucceed = false;
                    reponse.Message = "Invalid CountryCode / WBS or Empty";
                    return reponse;
                }
                reponse.Data = true;
                reponse.IsSucceed = true;
                return reponse;
            }
        }
    }
}
