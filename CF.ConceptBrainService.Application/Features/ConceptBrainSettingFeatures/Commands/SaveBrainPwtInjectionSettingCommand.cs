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
    public class SaveBrainPwtInjectionSettingCommand : IRequest<CustomResponse<bool>>
    {
        public BrainPWTInjectionDto BrainPWTInjectionDto;
        public class SaveBrainPwtInjectionSettingCommandHandler : IRequestHandler<SaveBrainPwtInjectionSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SaveBrainPwtInjectionSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<CustomResponse<bool>> Handle(SaveBrainPwtInjectionSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainPwtInjection = new BrainPWTInjection();
                if (request.BrainPWTInjectionDto.Id.HasValue)
                {
                    //update
                    brainPwtInjection = await _unitOfWork.BrainPWTInjectionRepository.GetSingleAsync(x => x.Id == request.BrainPWTInjectionDto.Id);
                    if (brainPwtInjection != null)
                    {
                        brainPwtInjection.PWTGreaterThanZero = request.BrainPWTInjectionDto.PWTGreaterThanZero;
                        brainPwtInjection.InjectionRequiredGreaterThanZero = request.BrainPWTInjectionDto.InjectionRequiredGreaterThanZero;
                        brainPwtInjection.PwtInjection = request.BrainPWTInjectionDto.PwtInjection;
                        brainPwtInjection.ProcessText = request.BrainPWTInjectionDto.ProcessText;
                        brainPwtInjection.ProcessIds = request.BrainPWTInjectionDto.ProcessIds;
                        brainPwtInjection.Pipeline = request.BrainPWTInjectionDto.Pipeline;
                        _unitOfWork.BrainPWTInjectionRepository.Update(brainPwtInjection);
                    }
                }
                else
                {
                    //insert
                    brainPwtInjection.Id = new Guid();
                    brainPwtInjection.PWTGreaterThanZero = request.BrainPWTInjectionDto.PWTGreaterThanZero;
                    brainPwtInjection.InjectionRequiredGreaterThanZero = request.BrainPWTInjectionDto.InjectionRequiredGreaterThanZero;
                    brainPwtInjection.PwtInjection = request.BrainPWTInjectionDto.PwtInjection;
                    brainPwtInjection.ProcessText = request.BrainPWTInjectionDto.ProcessText;
                    brainPwtInjection.ProcessIds = request.BrainPWTInjectionDto.ProcessIds;
                    brainPwtInjection.Pipeline = request.BrainPWTInjectionDto.Pipeline;
                    _unitOfWork.BrainPWTInjectionRepository.Insert(brainPwtInjection);
                }
                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
