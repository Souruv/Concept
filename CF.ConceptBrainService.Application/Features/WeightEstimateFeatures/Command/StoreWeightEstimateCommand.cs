using CF.ConceptBrainService.Application.Common.Interfaces;
using CF.ConceptBrainService.Application.Common.Response;
using CF.ConceptBrainService.Application.Entities;
using CF.ConceptBrainService.Application.Features.WeightEstimateFeatures.Dto;
using CF.ConceptBrainService.Application.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ConceptBrainService.Application.Features.WeightEstimateFeatures.Command
{
    public class StoreWeightEstimateCommand : IRequest<bool>
    {
        public LookupGenericWeightEstimateDto[] ListWeightEstimate { get; set; }
        public class StoreWeightEstimateCommandHandler : IRequestHandler<StoreWeightEstimateCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IWeightEstimateService _weightEstimateService;
            public StoreWeightEstimateCommandHandler(IUnitOfWork unitOfWork, IWeightEstimateService weightEstimateService)
            {
                _unitOfWork = unitOfWork;
                _weightEstimateService = weightEstimateService;
            }
            public async Task<bool> Handle(StoreWeightEstimateCommand request, CancellationToken cancellationToken)
            {


                foreach (var item in request.ListWeightEstimate)
                {
                    if (item.IsInsert == true)
                    {
                        var levelInformation = new LevelInformation();
                        var levelIsNull = true;
                        if (item.LevelInformation.SecMaxCriteriaValue != 0)
                        {
                            levelIsNull = false;
                            levelInformation = new LevelInformation()
                            {

                                Id = Guid.NewGuid(),
                                SecMinCriteriaValue = item.LevelInformation.SecMinCriteriaValue,
                                SecMaxCriteriaValue = item.LevelInformation.SecMaxCriteriaValue,
                            };
                        }
                        var equimentData = new Equipment()
                        {
                            Id = Guid.NewGuid(),
                            WBSId = item.Equipment.WBSId,
                            Manifolding = item.Equipment.Manifolding,
                            CostimatorCBS = item.Equipment.CostimatorCBS,
                            Unit = item.Equipment.Unit,
                            Category = item.Equipment.Category
                        };
                        var lookupGenericWeightEstimate = new LookupGenericWeightEstimate()
                        {
                            Id = Guid.NewGuid(),
                            EquipmentId = equimentData.Id,
                            MinCriteriaValue = item.MinCriteriaValue,
                            MaxCriteriaValue = item.MaxCriteriaValue,
                            Formula = item.Formula,
                            Remarks = item.Remarks,
                            Criteria = item.Criteria,
                            LevelInformationId = levelIsNull ? null : (Nullable<Guid>)levelInformation.Id
                        };
                        if (!levelIsNull)
                        {
                            _unitOfWork.LevelInformationRepository.Insert(levelInformation);
                        }

                        _unitOfWork.EquimentRepository.Insert(equimentData);
                        _unitOfWork.LookupGenericWeightEstimateRepository.Insert(lookupGenericWeightEstimate);
                    }
                    else if (item.IsDeleted == true)
                    {
                        var equimentObject = await _unitOfWork.EquimentRepository.Filter(x => x.WBSId == item.Equipment.WBSId).FirstOrDefaultAsync();
                        var lookupGenericWeightEstimateDeleteObject = await _unitOfWork.LookupGenericWeightEstimateRepository.Filter(x => x.EquipmentId == equimentObject.Id).FirstOrDefaultAsync();
                        var levelInformationDelete = await _unitOfWork.LevelInformationRepository.Filter(x => x.Id == lookupGenericWeightEstimateDeleteObject.LevelInformationId).FirstOrDefaultAsync();

                        if (levelInformationDelete != null)
                        {
                            _unitOfWork.LevelInformationRepository.Delete(levelInformationDelete);
                        } 
                        _unitOfWork.EquimentRepository.Delete(equimentObject);
                        _unitOfWork.LookupGenericWeightEstimateRepository.Delete(lookupGenericWeightEstimateDeleteObject);

                    }
                    else
                    {
                        var equimentObject = await _unitOfWork.EquimentRepository.Filter(x => x.WBSId == item.Equipment.WBSId).FirstOrDefaultAsync();
                        equimentObject.WBSId = item.Equipment.WBSId;
                        equimentObject.Manifolding = item.Equipment.Manifolding;
                        equimentObject.CostimatorCBS = item.Equipment.CostimatorCBS;
                        equimentObject.Unit = item.Equipment.Unit;
                        equimentObject.Category = item.Equipment.Category;
                        equimentObject.IsDeleted = item.IsDeleted;
                        _unitOfWork.EquimentRepository.Update(equimentObject);

                        var lookupGenericWeightEstimateUpdateObject = await _unitOfWork.LookupGenericWeightEstimateRepository.Filter(x => x.EquipmentId == equimentObject.Id).FirstOrDefaultAsync();
                        lookupGenericWeightEstimateUpdateObject.MinCriteriaValue = item.MinCriteriaValue;
                        lookupGenericWeightEstimateUpdateObject.MaxCriteriaValue = item.MaxCriteriaValue;
                        lookupGenericWeightEstimateUpdateObject.Formula = item.Formula;
                        lookupGenericWeightEstimateUpdateObject.Remarks = item.Remarks;
                        lookupGenericWeightEstimateUpdateObject.IsDeleted = item.IsDeleted;
                        lookupGenericWeightEstimateUpdateObject.Criteria = item.Criteria;
                        _unitOfWork.LookupGenericWeightEstimateRepository.Update(lookupGenericWeightEstimateUpdateObject);

                        var levelInformationUpdateObject = await _unitOfWork.LevelInformationRepository.Filter(x => x.Id == lookupGenericWeightEstimateUpdateObject.LevelInformationId).FirstOrDefaultAsync();
                        if(levelInformationUpdateObject != null || (item.LevelInformation.SecMaxCriteriaValue != 0 && item.LevelInformation.SecMinCriteriaValue != 0))
                        {
                            levelInformationUpdateObject.SecMinCriteriaValue = item.LevelInformation.SecMinCriteriaValue;
                            levelInformationUpdateObject.SecMaxCriteriaValue = item.LevelInformation.SecMaxCriteriaValue;
                            _unitOfWork.LevelInformationRepository.Update(levelInformationUpdateObject);
                        }
                        
                    }
                }
                await _unitOfWork.CommitAsync();

                return true;
            }
        }
    }
}
