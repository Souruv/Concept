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
    public class SaveBrainPressureProtectionSettingCommand : IRequest<CustomResponse<bool>>
    {
        public BrainPressureProtectionDto BrainPressureProtectionDto;
        public class SaveBrainPressureProtectionSettingCommandHandler : IRequestHandler<SaveBrainPressureProtectionSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SaveBrainPressureProtectionSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<CustomResponse<bool>> Handle(SaveBrainPressureProtectionSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainPressureProtection = new BrainPressureProtection();
                if (request.BrainPressureProtectionDto.Id.HasValue)
                {
                    //update
                    brainPressureProtection = await _unitOfWork.BrainPressureProtectionRepository.GetSingleAsync(x => x.Id == request.BrainPressureProtectionDto.Id);
                    if (brainPressureProtection != null)
                    {
                        brainPressureProtection.CithpMin = request.BrainPressureProtectionDto.CithpMin;
                        brainPressureProtection.Pressureprotection = request.BrainPressureProtectionDto.Pressureprotection;

                        _unitOfWork.BrainPressureProtectionRepository.Update(brainPressureProtection);
                    }
                }
                else
                {
                    //insert
                    brainPressureProtection.Id = new Guid();
                    brainPressureProtection.CithpMin = request.BrainPressureProtectionDto.CithpMin;
                    brainPressureProtection.Pressureprotection = request.BrainPressureProtectionDto.Pressureprotection;

                    _unitOfWork.BrainPressureProtectionRepository.Insert(brainPressureProtection);
                }
                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
