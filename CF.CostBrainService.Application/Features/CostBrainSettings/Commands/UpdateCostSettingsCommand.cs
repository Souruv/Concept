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
    public class UpdateCostSettingsCommand : IRequest<ExceptionHelper<bool>>
    {
        public Guid CountryCode { get; set; }
        public List<CostSettingsDto> systemList { get; set; }

        public class UpdateCostSettingsHandler : IRequestHandler<UpdateCostSettingsCommand, ExceptionHelper<bool>>
        {
            private readonly ILogger<UpdateCostSettingsCommand> logger;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedInUserService _loggedInUserService;

            public UpdateCostSettingsHandler(IUnitOfWork unitOfWork, ILogger<UpdateCostSettingsCommand> logger, ILoggedInUserService loggedInUserService)
            {
                _unitOfWork = unitOfWork;
                this.logger = logger;
                _loggedInUserService = loggedInUserService;
            }

            public async Task<ExceptionHelper<bool>> Handle(UpdateCostSettingsCommand request, CancellationToken cancellationToken)
            {
                ExceptionHelper<bool> reponse = new ExceptionHelper<bool>();
                var listDBWbsId = await _unitOfWork.EquipmentRepository.Filter(null).Select(x => x.WBSId).ToListAsync();
                List<EquipmentCost> equipmentCostsList = new List<EquipmentCost>();
                var countryListID = await _unitOfWork.CountryRepository.Filter(x => !x.IsDeleted).Select(y => y.Id).ToListAsync();
                if (request.CountryCode != Guid.Empty)
                {
                    if (countryListID.Contains(request.CountryCode))
                    {
                        foreach (var item in request.systemList)
                        {
                            foreach (var system in item.Equipments)
                            {
                                var equipmentId = _unitOfWork.EquipmentRepository.Filter(x => x.WBSId == system.WBS && !x.IsDeleted && x.Category == item.System.Trim()).Select(y => y.Id).SingleOrDefault();
                                var id = _unitOfWork.EquipmentCostRepository.Filter(x => x.EquipmentId == equipmentId && x.CountryCode == request.CountryCode && !x.IsDeleted).Select(y => y.Id).SingleOrDefault();

                                if (equipmentId != Guid.Empty && id != Guid.Empty)
                                {
                                    var equipment = await _unitOfWork.EquipmentRepository.GetSingleAsync(a => a.WBSId == system.WBS && a.Category == item.System.Trim());
                                    equipment.Unit = system.Unit.Trim();
                                    _unitOfWork.EquipmentRepository.Update(equipment);

                                    var equipmentCost = await _unitOfWork.EquipmentCostRepository.GetSingleAsync(a => a.Id == id && a.EquipmentId == equipmentId && a.CountryCode == request.CountryCode);
                                    equipmentCost.Standard = system.Prices.Standard;
                                    equipmentCost.Acid = system.Prices.Acid;
                                    equipmentCost.PrimarySteel = system.Prices.PrimarySteel;
                                    equipmentCost.SecondarySteel = system.Prices.SecondarySteel;
                                    equipmentCost.Piping = system.Prices.Piping;
                                    equipmentCost.Electrical = system.Prices.Electrical;
                                    equipmentCost.Instrument = system.Prices.Instrument;
                                    equipmentCost.Others = system.Prices.Others;

                                    _unitOfWork.EquipmentCostRepository.Update(equipmentCost);
                                }
                                else
                                {
                                    if (system.WBS != null && listDBWbsId.Contains((int)system.WBS))
                                    {
                                        var equipment = await _unitOfWork.EquipmentRepository.GetSingleAsync(a => a.WBSId == system.WBS && a.Category == item.System.Trim());
                                        equipment.Unit = system.Unit.Trim();
                                        _unitOfWork.EquipmentRepository.Update(equipment);

                                        var equipmentCost = await _unitOfWork.EquipmentCostRepository.GetSingleAsync(a => a.EquipmentId == equipment.Id && a.CountryCode == request.CountryCode);
                                        if (equipmentCost != null)
                                        {
                                            equipmentCost.IsDeleted = false;
                                            equipmentCost.DeletedByUserId = null;
                                            equipmentCost.DeletedOn = null;
                                            equipmentCost.Standard = system.Prices.Standard;
                                            equipmentCost.Acid = system.Prices.Acid;
                                            equipmentCost.PrimarySteel = system.Prices.PrimarySteel;
                                            equipmentCost.SecondarySteel = system.Prices.SecondarySteel;
                                            equipmentCost.Piping = system.Prices.Piping;
                                            equipmentCost.Electrical = system.Prices.Electrical;
                                            equipmentCost.Instrument = system.Prices.Instrument;
                                            equipmentCost.Others = system.Prices.Others;
                                            _unitOfWork.EquipmentCostRepository.Update(equipmentCost);
                                        }
                                        else
                                        {
                                            EquipmentCost newequipmentCost = new EquipmentCost()
                                            {
                                                EquipmentId = equipment.Id,
                                                Id = Guid.NewGuid(),
                                                CountryCode = request.CountryCode,
                                                Standard = system.Prices.Standard,
                                                Acid = system.Prices.Acid,
                                                PrimarySteel = system.Prices.PrimarySteel,
                                                SecondarySteel = system.Prices.SecondarySteel,
                                                Piping = system.Prices.Piping,
                                                Electrical = system.Prices.Electrical,
                                                Instrument = system.Prices.Instrument,
                                                Others = system.Prices.Others,
                                            };
                                            _unitOfWork.EquipmentCostRepository.Insert(newequipmentCost);
                                        }
                                    }
                                    else
                                    {
                                        Guid NewEquipmentId = Guid.NewGuid();
                                        var equipmentDetail = await _unitOfWork.EquipmentRepository.GetSingleAsync(a => a.Manifolding == system.Name.Trim() && a.Category == item.System.Trim());
                                        if (equipmentDetail != null)
                                        {
                                            NewEquipmentId = equipmentDetail.Id;
                                            system.WBS = equipmentDetail.WBSId;
                                        }
                                        else
                                        {                                           
                                            Equipment equipment = new Equipment()
                                            {
                                                Id = NewEquipmentId,
                                                WBSId = (int)((system.WBS == 0 || system.WBS == null) ? listDBWbsId.Max() + 1 : system.WBS),
                                                Manifolding = system.Name.Trim(),
                                                CostimatorCBS = "",
                                                Unit = system.Unit.Trim(),
                                                Category = item.System.Trim()
                                            };
                                            system.WBS = equipment.WBSId;
                                            _unitOfWork.EquipmentRepository.Insert(equipment);
                                            listDBWbsId.Add(equipment.WBSId);
                                        }

                                        EquipmentCost newequipmentCost = new EquipmentCost()
                                        {
                                            EquipmentId = NewEquipmentId,
                                            Id = Guid.NewGuid(),
                                            CountryCode = request.CountryCode,
                                            Standard = system.Prices.Standard,
                                            Acid = system.Prices.Acid,
                                            PrimarySteel = system.Prices.PrimarySteel,
                                            SecondarySteel = system.Prices.SecondarySteel,
                                            Piping = system.Prices.Piping,
                                            Electrical = system.Prices.Electrical,
                                            Instrument = system.Prices.Instrument,
                                            Others = system.Prices.Others,
                                        };
                                        _unitOfWork.EquipmentCostRepository.Insert(newequipmentCost);                                       
                                    }
                                }
                            }
                        }
                        List<int> wbsList = request.systemList.SelectMany(a => a.Equipments).Select(b => (int)b.WBS).ToList();

                        var equipmentCostList = _unitOfWork.EquipmentRepository.Filter(x => !x.IsDeleted).ToList()
                                                .Join(_unitOfWork.EquipmentCostRepository.Filter(y => !y.IsDeleted)
                                                .ToList(), a => a.Id, b => b.EquipmentId, (a, b) => new { Equipment = a, EquipmentCost = b })
                                                .Where(z => !wbsList.Contains(z.Equipment.WBSId) && z.EquipmentCost.CountryCode == request.CountryCode).ToList();


                        if (equipmentCostList?.Count() > 0)
                        {
                            equipmentCostList.ForEach(a => { a.EquipmentCost.IsDeleted = true; a.EquipmentCost.DeletedOn = DateTime.Now; a.EquipmentCost.DeletedByUserId = _loggedInUserService.Id; });
                            _unitOfWork.EquipmentCostRepository.UpdateRange(equipmentCostList.Select(a => a.EquipmentCost).ToList());
                        }
                        await _unitOfWork.CommitAsync();
                    }
                    else
                    {
                        reponse.Data = false;
                        reponse.IsSucceed = false;
                        reponse.Message = "Invalid CountryCode";
                        return reponse;
                    }
                }
                else
                {
                    reponse.Data = false;
                    reponse.IsSucceed = false;
                    reponse.Message = "Invalid or Empty CountryCode";
                    return reponse;
                }
                reponse.Data = true;
                reponse.IsSucceed = true;
                return reponse;
            }
        }
    }
}
