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
    public class SaveBrainCondensateHandlingSettingCommand : IRequest<CustomResponse<bool>>
    {
        public BrainCondensateHandlingDto BrainCondensateHandlingDto;
        public class SaveBrainCondensateHandlingSettingCommandHandler : IRequestHandler<SaveBrainCondensateHandlingSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SaveBrainCondensateHandlingSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<CustomResponse<bool>> Handle(SaveBrainCondensateHandlingSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainCondensateHandling = new BrainCondensateHandling();
                if (request.BrainCondensateHandlingDto.Id.HasValue)
                {
                    //update
                    brainCondensateHandling = await _unitOfWork.BrainCondensateHandlingRepository.GetSingleAsync(x => x.Id == request.BrainCondensateHandlingDto.Id);
                    if (brainCondensateHandling != null)
                    {
                        brainCondensateHandling.ProcessingScheme = request.BrainCondensateHandlingDto.ProcessingScheme;
                        brainCondensateHandling.EvacuationScheme = request.BrainCondensateHandlingDto.EvacuationScheme;
                        brainCondensateHandling.CondensateExport = request.BrainCondensateHandlingDto.CondensateExport;
                        brainCondensateHandling.HcDewpoint = request.BrainCondensateHandlingDto.HcDewpoint;
                        brainCondensateHandling.CondensateProcessing = request.BrainCondensateHandlingDto.CondensateProcessing;
                        brainCondensateHandling.ProcessText = request.BrainCondensateHandlingDto.ProcessText;
                        brainCondensateHandling.ProcessIds = request.BrainCondensateHandlingDto.ProcessIds;
                        brainCondensateHandling.PipeLine = request.BrainCondensateHandlingDto.PipeLine;

                        _unitOfWork.BrainCondensateHandlingRepository.Update(brainCondensateHandling);
                    }
                }
                else
                {
                    //insert
                    brainCondensateHandling.Id = new Guid();
                    brainCondensateHandling.ProcessingScheme = request.BrainCondensateHandlingDto.ProcessingScheme;
                    brainCondensateHandling.EvacuationScheme = request.BrainCondensateHandlingDto.EvacuationScheme;
                    brainCondensateHandling.CondensateExport = request.BrainCondensateHandlingDto.CondensateExport;
                    brainCondensateHandling.HcDewpoint = request.BrainCondensateHandlingDto.HcDewpoint;
                    brainCondensateHandling.CondensateProcessing = request.BrainCondensateHandlingDto.CondensateProcessing;
                    brainCondensateHandling.ProcessText = request.BrainCondensateHandlingDto.ProcessText;
                    brainCondensateHandling.ProcessIds = request.BrainCondensateHandlingDto.ProcessIds;
                    brainCondensateHandling.PipeLine = request.BrainCondensateHandlingDto.PipeLine;

                    _unitOfWork.BrainCondensateHandlingRepository.Insert(brainCondensateHandling);
                }
                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
