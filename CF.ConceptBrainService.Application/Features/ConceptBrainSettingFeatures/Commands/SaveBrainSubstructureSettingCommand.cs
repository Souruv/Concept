using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto;
using CF.ConceptBrainService.Application.Common.Interfaces;
using AutoMapper;
using CF.ConceptBrainService.Application.Common.Response;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Commands
{
    public class SaveBrainSubstructureSettingCommand : IRequest<CustomResponse<bool>>
    {
        public BrainSubstructureDto BrainSubstructureDto;
        public class SaveBrainSubstructureSettingCommandHandler : IRequestHandler<SaveBrainSubstructureSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SaveBrainSubstructureSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<CustomResponse<bool>> Handle(SaveBrainSubstructureSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainSubstructure = new BrainSubstructure();
                if (request.BrainSubstructureDto.Id.HasValue)
                {
                    //update
                    brainSubstructure = await _unitOfWork.BrainSubstructureRepository.GetSingleAsync(x => x.Id == request.BrainSubstructureDto.Id);
                    if (brainSubstructure != null)
                    {
                        brainSubstructure.Location = request.BrainSubstructureDto.Location;
                        brainSubstructure.TreeType = request.BrainSubstructureDto.TreeType;
                        brainSubstructure.NoOfConductorsMax = request.BrainSubstructureDto.NoOfConductorsMax;
                        brainSubstructure.NoOfConductorsMin = request.BrainSubstructureDto.NoOfConductorsMin;
                        brainSubstructure.WaterDepthMax = request.BrainSubstructureDto.WaterDepthMax;
                        brainSubstructure.WaterDepthMin = request.BrainSubstructureDto.WaterDepthMin;
                        brainSubstructure.TopsideWeightMax = request.BrainSubstructureDto.TopsideWeightMax;
                        brainSubstructure.TopsideWeightMin = request.BrainSubstructureDto.TopsideWeightMin;
                        brainSubstructure.ProcessingScheme = request.BrainSubstructureDto.ProcessingScheme;
                        brainSubstructure.SubStructureType = request.BrainSubstructureDto.SubStructureType;

                        _unitOfWork.BrainSubstructureRepository.Update(brainSubstructure);
                    }
                }
                else
                {
                    //insert
                    brainSubstructure.Id = new Guid();
                    brainSubstructure.Location = request.BrainSubstructureDto.Location;
                    brainSubstructure.TreeType = request.BrainSubstructureDto.TreeType;
                    brainSubstructure.NoOfConductorsMax = request.BrainSubstructureDto.NoOfConductorsMax;
                    brainSubstructure.NoOfConductorsMin = request.BrainSubstructureDto.NoOfConductorsMin;
                    brainSubstructure.WaterDepthMax = request.BrainSubstructureDto.WaterDepthMax;
                    brainSubstructure.WaterDepthMin = request.BrainSubstructureDto.WaterDepthMin;
                    brainSubstructure.TopsideWeightMax = request.BrainSubstructureDto.TopsideWeightMax;
                    brainSubstructure.TopsideWeightMin = request.BrainSubstructureDto.TopsideWeightMin;
                    brainSubstructure.ProcessingScheme = request.BrainSubstructureDto.ProcessingScheme;
                    brainSubstructure.SubStructureType = request.BrainSubstructureDto.SubStructureType;

                    _unitOfWork.BrainSubstructureRepository.Insert(brainSubstructure);
                }
                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
