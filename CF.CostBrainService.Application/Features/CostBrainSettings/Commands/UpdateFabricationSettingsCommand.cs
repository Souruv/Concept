using AutoMapper;
using CF.CostBrainService.Application.Common.Interfaces;
using CF.CostBrainService.Application.Common.Response;
using CF.CostBrainService.Application.Entities;
using CF.CostBrainService.Application.Features.CostBrainSettings.Commands.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CF.CostBrainService.Application.Features.CostBrainSettings.Commands
{
    public class UpdateFabricationSettingsCommand : IRequest<ExceptionHelper<bool>>
    {
        public Guid CountryCode { get; set; }
        public List<FabricationSettingsDto> systemList { get; set; }
        public class UpdateFabricationSettingsHandler : IRequestHandler<UpdateFabricationSettingsCommand, ExceptionHelper<bool>>
        {
            private readonly ILogger<UpdateFabricationSettingsCommand> _logger;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedInUserService _loggedInUserService;

            public UpdateFabricationSettingsHandler(IUnitOfWork unitOfWork, ILogger<UpdateFabricationSettingsCommand> logger, ILoggedInUserService loggedInUserService, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _logger = logger;
                _loggedInUserService = loggedInUserService;
            }

            public async Task<ExceptionHelper<bool>> Handle(UpdateFabricationSettingsCommand request, CancellationToken cancellationToken)
            {
                ExceptionHelper<bool> reponse = new ExceptionHelper<bool>();
                var listDBWbsId = await _unitOfWork.EquipmentRepository.Filter(null).Select(x => x.WBSId).ToListAsync();
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
                                var id = _unitOfWork.FabricationRepository.Filter(x => x.EquipmentId == equipmentId && x.CountryCode == request.CountryCode && !x.IsDeleted).Select(y => y.Id).SingleOrDefault();

                                if (equipmentId != Guid.Empty && id != Guid.Empty)
                                {
                                    var equipment = await _unitOfWork.EquipmentRepository.GetSingleAsync(a => a.WBSId == system.WBS && a.Category == item.System.Trim());
                                    equipment.Unit = system.Unit.Trim();
                                    _unitOfWork.EquipmentRepository.Update(equipment);

                                    var fabricationRepository = await _unitOfWork.FabricationRepository.GetSingleAsync(a => a.Id == id && a.EquipmentId == equipmentId && a.CountryCode == request.CountryCode);
                                    fabricationRepository.Manhours = system.FabricationDetails.Manhours;
                                    fabricationRepository.ManhoursPerMT = system.FabricationDetails.ManhoursPerMT;
                                    _unitOfWork.FabricationRepository.Update(fabricationRepository);
                                }
                                else
                                {
                                    if (system.WBS != null && listDBWbsId.Contains((int)system.WBS))
                                    {
                                        var equipment = await _unitOfWork.EquipmentRepository.GetSingleAsync(a => a.WBSId == system.WBS && a.Category == item.System.Trim());
                                        equipment.Unit = system.Unit.Trim();
                                        _unitOfWork.EquipmentRepository.Update(equipment);

                                        var fabricationRepository = await _unitOfWork.FabricationRepository.GetSingleAsync(a => a.EquipmentId == equipment.Id && a.CountryCode == request.CountryCode);
                                        if (fabricationRepository != null)
                                        {
                                            fabricationRepository.Manhours = system.FabricationDetails.Manhours;
                                            fabricationRepository.ManhoursPerMT = system.FabricationDetails.ManhoursPerMT;
                                            fabricationRepository.IsDeleted = false;
                                            fabricationRepository.DeletedByUserId = null;
                                            fabricationRepository.DeletedOn = null;
                                            _unitOfWork.FabricationRepository.Update(fabricationRepository);
                                        }
                                        else
                                        {
                                            Fabrication fabrication = new Fabrication()
                                            {
                                                EquipmentId = equipment.Id,
                                                Id = Guid.NewGuid(),
                                                CountryCode = request.CountryCode,
                                                Manhours = system.FabricationDetails.Manhours,
                                                ManhoursPerMT = system.FabricationDetails.ManhoursPerMT,
                                            };
                                            _unitOfWork.FabricationRepository.Insert(fabrication);
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

                                        Fabrication fabrication = new Fabrication()
                                        {
                                            EquipmentId = NewEquipmentId,
                                            Id = Guid.NewGuid(),
                                            CountryCode = request.CountryCode,
                                            Manhours = system.FabricationDetails.Manhours,
                                            ManhoursPerMT = system.FabricationDetails.ManhoursPerMT
                                        };
                                        _unitOfWork.FabricationRepository.Insert(fabrication);
                                    }
                                }
                            }
                        }
                        List<int> wbsList = request.systemList.SelectMany(a => a.Equipments).Select(b => (int)b.WBS).ToList();

                        var fabricationList = _unitOfWork.EquipmentRepository.Filter(x => !x.IsDeleted).ToList()
                                                .Join(_unitOfWork.FabricationRepository.Filter(y => !y.IsDeleted)
                                                .ToList(), a => a.Id, b => b.EquipmentId, (a, b) => new { Equipment = a, Fabrication = b })
                                                .Where(z => !wbsList.Contains(z.Equipment.WBSId) && z.Fabrication.CountryCode == request.CountryCode).ToList();


                        if (fabricationList?.Count() > 0)
                        {
                            fabricationList.ForEach(a => { a.Fabrication.IsDeleted = true; a.Fabrication.DeletedOn = DateTime.Now; a.Fabrication.DeletedByUserId = _loggedInUserService.Id; });
                            _unitOfWork.FabricationRepository.UpdateRange(fabricationList.Select(a => a.Fabrication).ToList());
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
