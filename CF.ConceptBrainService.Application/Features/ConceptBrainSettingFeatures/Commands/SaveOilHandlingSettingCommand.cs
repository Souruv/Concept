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
    public class SaveOilHandlingSettingCommand : IRequest<CustomResponse<bool>>
    {
        public BrainOilHandlingDto BrainOilHandlingDto;
        public class SaveOilHandlingSettingCommandHandler : IRequestHandler<SaveOilHandlingSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SaveOilHandlingSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<CustomResponse<bool>> Handle(SaveOilHandlingSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainOilHandling = new BrainOilHandling();
                if (request.BrainOilHandlingDto.Id.HasValue)
                {
                    //update
                    brainOilHandling = await _unitOfWork.BrainOilHandlingRepository.GetSingleAsync(x => x.Id == request.BrainOilHandlingDto.Id);
                    if (brainOilHandling != null)
                    {
                        brainOilHandling.ProcessingScheme = request.BrainOilHandlingDto.ProcessingScheme;
                        brainOilHandling.EvacuationScheme = request.BrainOilHandlingDto.EvacuationScheme;
                        brainOilHandling.Desalting = request.BrainOilHandlingDto.Desalting;
                        brainOilHandling.H2SRemoval = request.BrainOilHandlingDto.H2SRemoval;
                        brainOilHandling.OilProcessing = request.BrainOilHandlingDto.OilProcessing;
                        brainOilHandling.ProcessText = request.BrainOilHandlingDto.ProcessText;
                        brainOilHandling.ProcessIds = request.BrainOilHandlingDto.ProcessIds;
                        brainOilHandling.Pipeline = request.BrainOilHandlingDto.Pipeline;

                        _unitOfWork.BrainOilHandlingRepository.Update(brainOilHandling);
                    }
                }
                else
                {
                    //insert
                    brainOilHandling.Id = new Guid();
                    brainOilHandling.ProcessingScheme = request.BrainOilHandlingDto.ProcessingScheme;
                    brainOilHandling.EvacuationScheme = request.BrainOilHandlingDto.EvacuationScheme;
                    brainOilHandling.Desalting = request.BrainOilHandlingDto.Desalting;
                    brainOilHandling.H2SRemoval = request.BrainOilHandlingDto.H2SRemoval;
                    brainOilHandling.OilProcessing = request.BrainOilHandlingDto.OilProcessing;
                    brainOilHandling.ProcessText = request.BrainOilHandlingDto.ProcessText;
                    brainOilHandling.ProcessIds = request.BrainOilHandlingDto.ProcessIds;
                    brainOilHandling.Pipeline = request.BrainOilHandlingDto.Pipeline;
                    _unitOfWork.BrainOilHandlingRepository.Insert(brainOilHandling);
                }
                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
