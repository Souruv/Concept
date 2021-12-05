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
    public class SaveBrainTreeTypeSettingCommand : IRequest<CustomResponse<bool>>
    {
        public BrainTreeTypeDto BrainTreeTypeDto;
        public class SaveBrainTreeTypeSettingCommandHandler : IRequestHandler<SaveBrainTreeTypeSettingCommand, CustomResponse<bool>>
        {

            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SaveBrainTreeTypeSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<CustomResponse<bool>> Handle(SaveBrainTreeTypeSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainTreeType = new BrainTreeType();
                if (request.BrainTreeTypeDto.Id.HasValue)
                {
                    //update
                    brainTreeType = await _unitOfWork.BrainTreeTypeRepository.GetSingleAsync(x => x.Id == request.BrainTreeTypeDto.Id);
                    if (brainTreeType != null)
                    {
                        brainTreeType.Location = request.BrainTreeTypeDto.Location;
                        brainTreeType.NumberOfWell = request.BrainTreeTypeDto.NumberOfWell;
                        brainTreeType.WaterDepthMin = request.BrainTreeTypeDto.WaterDepthMin;
                        brainTreeType.WaterDepthMax = request.BrainTreeTypeDto.WaterDepthMax;
                        brainTreeType.TreeType = request.BrainTreeTypeDto.TreeType;
                        _unitOfWork.BrainTreeTypeRepository.Update(brainTreeType);
                    }
                }
                else
                {
                    //insert
                    brainTreeType.Id = new Guid();
                    brainTreeType.Location = request.BrainTreeTypeDto.Location;
                    brainTreeType.NumberOfWell = request.BrainTreeTypeDto.NumberOfWell;
                    brainTreeType.WaterDepthMin = request.BrainTreeTypeDto.WaterDepthMin;
                    brainTreeType.WaterDepthMax = request.BrainTreeTypeDto.WaterDepthMax;
                    brainTreeType.TreeType = request.BrainTreeTypeDto.TreeType;
                    _unitOfWork.BrainTreeTypeRepository.Insert(brainTreeType);
                }
                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
