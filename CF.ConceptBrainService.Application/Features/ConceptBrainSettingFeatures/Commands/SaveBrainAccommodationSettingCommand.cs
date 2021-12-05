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
    public class SaveBrainAccommodationSettingCommand : IRequest<CustomResponse<bool>>
    {
        public BrainAccommodationDto BrainAccommodationDto;
        public class SaveBrainAccommodationSettingCommandHandler : IRequestHandler<SaveBrainAccommodationSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SaveBrainAccommodationSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<CustomResponse<bool>> Handle(SaveBrainAccommodationSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainAccommodation = new BrainAccommodation();
                if (request.BrainAccommodationDto.Id.HasValue)
                {
                    //update
                    brainAccommodation = await _unitOfWork.BrainAccommodationRepository.GetSingleAsync(x => x.Id == request.BrainAccommodationDto.Id);
                    if (brainAccommodation != null)
                    {
                        brainAccommodation.ProcessingScheme = request.BrainAccommodationDto.ProcessingScheme;
                        brainAccommodation.Location = request.BrainAccommodationDto.Location;
                        brainAccommodation.Accommodation = request.BrainAccommodationDto.Accommodation;

                        _unitOfWork.BrainAccommodationRepository.Update(brainAccommodation);
                    }
                }
                else
                {
                    //insert
                    brainAccommodation.Id = new Guid();
                    brainAccommodation.ProcessingScheme = request.BrainAccommodationDto.ProcessingScheme;
                    brainAccommodation.Location = request.BrainAccommodationDto.Location;
                    brainAccommodation.Accommodation = request.BrainAccommodationDto.Accommodation;

                    _unitOfWork.BrainAccommodationRepository.Insert(brainAccommodation);
                }
                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
