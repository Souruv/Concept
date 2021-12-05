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
    public class GetCostSettingsQuery : IRequest<List<CostSettingsDto>>
    {
        public Guid CountryCode { get; set; }
        public class GetCostSettingsQueryHandle : IRequestHandler<GetCostSettingsQuery, List<CostSettingsDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetCostSettingsQueryHandle(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<CostSettingsDto>> Handle(GetCostSettingsQuery query, CancellationToken cancellationToken)
            {
                List<CostSettingsDto> equipments = new List<CostSettingsDto>();
                CostSettingsDto equipmentDto = new CostSettingsDto();
                List<EquipmentCostDto> equipmentsList = new List<EquipmentCostDto>();

                bool isFirstRecord = false;
                List<string> category = new List<string>();
                if (query.CountryCode != Guid.Empty)
                {
                    var equipmentCostList = _unitOfWork.EquipmentRepository.Filter(x => !x.IsDeleted).ToList()
                                            .Join(_unitOfWork.EquipmentCostRepository.Filter(y => !y.IsDeleted)
                                            .ToList(), a => a.Id, b => b.EquipmentId, (a, b) => new { Equipment = a, EquipmentCost = b })
                                            .Where(z => z.EquipmentCost.CountryCode.ToString().ToLower() == query.CountryCode.ToString().ToLower())
                                            .OrderBy(w => w.Equipment.WBSId).ToList();

                    if (equipmentCostList == null) return null;

                    /* Mapping */
                    foreach (var item in equipmentCostList)
                    {
                        if (category.Contains(item.Equipment.Category))
                        {
                            continue;
                        }
                        var categoryList = equipmentCostList.Where(x => x.Equipment.Category == item.Equipment.Category).ToList();

                        isFirstRecord = true;
                        foreach (var categoryItem in categoryList)
                        {
                            if (isFirstRecord)
                            {
                                equipmentDto = new CostSettingsDto();
                                equipmentDto.System = item.Equipment.Category;
                                equipmentsList = new List<EquipmentCostDto>();
                                isFirstRecord = false;
                                category.Add(item.Equipment.Category);
                            }

                            EquipmentCostDto equipmentCostDto = new EquipmentCostDto();
                            equipmentCostDto.Name = categoryItem.Equipment.Manifolding.Replace("\r\n", string.Empty);
                            equipmentCostDto.WBS = categoryItem.Equipment.WBSId;
                            equipmentCostDto.Unit = categoryItem.Equipment.Unit?.Replace("\r\n", string.Empty);
                            equipmentCostDto.Prices = _mapper.Map<EquipmentPriceDto>(categoryItem.EquipmentCost);
                            equipmentsList.Add(equipmentCostDto);
                        }
                        equipmentDto.Equipments = equipmentsList;
                        equipments.Add(equipmentDto);
                    }
                }
                return equipments;
            }
        }
    }
}
