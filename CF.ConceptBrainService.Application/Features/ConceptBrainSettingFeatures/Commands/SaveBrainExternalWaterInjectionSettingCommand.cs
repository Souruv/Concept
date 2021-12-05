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
    public class SaveBrainExternalWaterInjectionSettingCommand : IRequest<CustomResponse<bool>>
    {
        public BrainExternalWaterInjectionDto BrainExternalWaterInjectionDto;
        public class SaveBrainExternalWaterInjectionSettingCommandHandler : IRequestHandler<SaveBrainExternalWaterInjectionSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SaveBrainExternalWaterInjectionSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<CustomResponse<bool>> Handle(SaveBrainExternalWaterInjectionSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainExternalWaterInjection = new BrainExternalWaterInjection();
                if (request.BrainExternalWaterInjectionDto.Id.HasValue)
                {
                    //update
                    brainExternalWaterInjection = await _unitOfWork.BrainExternalWaterInjectionRepository.GetSingleAsync(x => x.Id == request.BrainExternalWaterInjectionDto.Id);
                    if (brainExternalWaterInjection != null)
                    {
                        brainExternalWaterInjection.Location = request.BrainExternalWaterInjectionDto.Location;
                        brainExternalWaterInjection.PwtLessThanInjection = request.BrainExternalWaterInjectionDto.PwtLessThanInjection;
                        brainExternalWaterInjection.ExternalWaterInjection = request.BrainExternalWaterInjectionDto.ExternalWaterInjection;
                        brainExternalWaterInjection.ProcessText = request.BrainExternalWaterInjectionDto.ProcessText;
                        brainExternalWaterInjection.ProcessIds = request.BrainExternalWaterInjectionDto.ProcessIds;
                        brainExternalWaterInjection.Pipeline = request.BrainExternalWaterInjectionDto.Pipeline;

                        _unitOfWork.BrainExternalWaterInjectionRepository.Update(brainExternalWaterInjection);
                    }
                }
                else
                {
                    //insert
                    brainExternalWaterInjection.Id = new Guid();
                    brainExternalWaterInjection.Location = request.BrainExternalWaterInjectionDto.Location;
                    brainExternalWaterInjection.PwtLessThanInjection = request.BrainExternalWaterInjectionDto.PwtLessThanInjection;
                    brainExternalWaterInjection.ExternalWaterInjection = request.BrainExternalWaterInjectionDto.ExternalWaterInjection;
                    brainExternalWaterInjection.ProcessText = request.BrainExternalWaterInjectionDto.ProcessText;
                    brainExternalWaterInjection.ProcessIds = request.BrainExternalWaterInjectionDto.ProcessIds;
                    brainExternalWaterInjection.Pipeline = request.BrainExternalWaterInjectionDto.Pipeline;

                    _unitOfWork.BrainExternalWaterInjectionRepository.Insert(brainExternalWaterInjection);
                }
                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
