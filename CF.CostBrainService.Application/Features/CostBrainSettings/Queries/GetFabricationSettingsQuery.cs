using AutoMapper;
using CF.CostBrainService.Application.Common.Interfaces;
using CF.CostBrainService.Application.Features.CostBrainSettings.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace CF.CostBrainService.Application.Features.CostBrainSettings.Queries
{
    public class GetFabricationSettingsQuery : IRequest<List<FabricationSettingsDto>>
    {
        public Guid CountryCode { get; set; }
        public class GetFabricationCostSettingsQueryHandle : IRequestHandler<GetFabricationSettingsQuery, List<FabricationSettingsDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public const string Category = "FABRICATION";
            public GetFabricationCostSettingsQueryHandle(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<FabricationSettingsDto>> Handle(GetFabricationSettingsQuery query, CancellationToken cancellationToken)
            {
                List<FabricationSettingsDto> equipments = new List<FabricationSettingsDto>();
                FabricationSettingsDto fabricationSettingsDto = new FabricationSettingsDto();
                List<FabricationEquipment> equipmentsList = new List<FabricationEquipment>();

                bool isFirstRecord = false;
                List<string> category = new List<string>();
                if (query.CountryCode != Guid.Empty)
                {
                    var equipmentList = _unitOfWork.EquipmentRepository.Filter(x => !x.IsDeleted && x.Category.ToUpper() == Category).ToList()
                                            .Join(_unitOfWork.FabricationRepository.Filter(y => !y.IsDeleted)
                                            .ToList(), a => a.Id, b => b.EquipmentId, (a, b) => new { Equipment = a, Fabrication = b })
                                            .Where(z => z.Fabrication.CountryCode.ToString().ToLower() == query.CountryCode.ToString().ToLower())
                                            .OrderBy(w => w.Equipment.WBSId).ToList();

                    if (equipmentList == null) return null;

                    /* Mapping */
                    foreach (var item in equipmentList)
                    {
                        if (category.Contains(item.Equipment.Category))
                        {
                            continue;
                        }
                        var categoryList = equipmentList.Where(x => x.Equipment.Category == item.Equipment.Category).ToList();

                        isFirstRecord = true;
                        foreach (var categoryItem in categoryList)
                        {
                            if (isFirstRecord)
                            {
                                fabricationSettingsDto = new FabricationSettingsDto();
                                fabricationSettingsDto.System = item.Equipment.Category;
                                equipmentsList = new List<FabricationEquipment>();
                                isFirstRecord = false;
                                category.Add(item.Equipment.Category);
                            }

                            FabricationEquipment fabricationEquipment = new FabricationEquipment();
                            fabricationEquipment.Name = categoryItem.Equipment.Manifolding.Replace("\r\n", string.Empty);
                            fabricationEquipment.WBS = categoryItem.Equipment.WBSId;
                            fabricationEquipment.Unit = categoryItem.Equipment.Unit?.Replace("\r\n", string.Empty);
                            fabricationEquipment.FabricationDetails = _mapper.Map<FabricationDetails>(categoryItem.Fabrication);
                            equipmentsList.Add(fabricationEquipment);
                        }
                        fabricationSettingsDto.Equipments = equipmentsList;
                        equipments.Add(fabricationSettingsDto);
                    }
                }
                return equipments;
            }
        }
    }
}
