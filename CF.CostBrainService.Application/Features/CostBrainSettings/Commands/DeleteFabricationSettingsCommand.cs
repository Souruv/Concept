using CF.CostBrainService.Application.Common.Interfaces;
using CF.CostBrainService.Application.Common.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CF.CostBrainService.Application.Features.CostBrainSettings.Commands
{
    public class DeleteFabricationSettingsCommand : IRequest<ExceptionHelper<bool>>
    {
        public int WBS { get; set; }
        public Guid CountryCode { get; set; }

        public class DeleteFabricationSettingsHandler : IRequestHandler<DeleteFabricationSettingsCommand, ExceptionHelper<bool>>
        {
            private readonly ILoggedInUserService _loggedInUserService;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteFabricationSettingsHandler(IUnitOfWork unitOfWork, ILoggedInUserService loggedInUserService)
            {
                _unitOfWork = unitOfWork;
                _loggedInUserService = loggedInUserService;
            }

            public async Task<ExceptionHelper<bool>> Handle(DeleteFabricationSettingsCommand request, CancellationToken cancellationToken)
            {
                ExceptionHelper<bool> reponse = new ExceptionHelper<bool>();

                var countryListID = await _unitOfWork.CountryRepository.Filter(x => !x.IsDeleted).Select(y => y.Id).ToListAsync();
                var listDBWbsId = await _unitOfWork.EquipmentRepository.Filter(null).Select(x => x.WBSId).ToListAsync();

                if (request.CountryCode != Guid.Empty && countryListID.Contains(request.CountryCode) && request.WBS != 0 && listDBWbsId.Contains(request.WBS))
                {
                    var equipmentId = _unitOfWork.EquipmentRepository.Filter(x => x.WBSId == request.WBS).Select(y => y.Id).SingleOrDefault();
                    var fabricationRepository = _unitOfWork.FabricationRepository.Filter(x => x.EquipmentId == equipmentId && x.CountryCode == request.CountryCode).SingleOrDefault();

                    if (fabricationRepository != null)
                    {
                        fabricationRepository.IsDeleted = true;
                        fabricationRepository.DeletedByUserId = _loggedInUserService.Id;
                        fabricationRepository.DeletedOn = DateTime.Now;

                        _unitOfWork.FabricationRepository.Update(fabricationRepository);
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
