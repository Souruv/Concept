using CF.ConceptBrainService.Application.Features.PipelineSizeSettingFeatures.Dto;
using MediatR;
using CF.ConceptBrainService.Application.Common.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CF.ConceptBrainService.Application.Common.Interfaces;
using System.Threading;
using AutoMapper;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.PipelineSizeSettingFeatures.Commands
{
    public class SavePipelineSizeCalcSettingCommand : IRequest<CustomResponse<bool>>
    {
        public PipelineSizeCalcDto PipelineSizeDto;
        public class SavePipelineSizeCalcSettingCommandHandler : IRequestHandler<SavePipelineSizeCalcSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SavePipelineSizeCalcSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<CustomResponse<bool>> Handle(SavePipelineSizeCalcSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var pipelineSizeCalc = new PipelineSizeCalc();
                if (request.PipelineSizeDto.Id.HasValue)
                {
                    //update
                    pipelineSizeCalc = await _unitOfWork.PipelineSizeCalcRepository.GetSingleAsync(x => x.Id == request.PipelineSizeDto.Id);
                    if (pipelineSizeCalc != null)
                    {
                        pipelineSizeCalc.Formula = request.PipelineSizeDto.Formula;
                        pipelineSizeCalc.Size = request.PipelineSizeDto.Size;

                        _unitOfWork.PipelineSizeCalcRepository.Update(pipelineSizeCalc);
                    }
                }
                else
                {
                    //insert
                    pipelineSizeCalc.Formula = request.PipelineSizeDto.Formula;
                    pipelineSizeCalc.Size = request.PipelineSizeDto.Size;
                    pipelineSizeCalc.PipelineType = request.PipelineSizeDto.PipelineType;
                    pipelineSizeCalc.PressureType = request.PipelineSizeDto.PressureType;
                    _unitOfWork.PipelineSizeCalcRepository.Insert(pipelineSizeCalc);
                }
                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }

    }
}
