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
    public class SaveLiquidPipelineSizeSettingCommand : IRequest<CustomResponse<bool>>
    {
        public LiquidPipelineSizeBoundaryDto LiquidPipelineSize;
        public class SaveLiquidPipelineSizeSettingCommandHandler : IRequestHandler<SaveLiquidPipelineSizeSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SaveLiquidPipelineSizeSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<CustomResponse<bool>> Handle(SaveLiquidPipelineSizeSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var liquidPipelineSizeBoundary = new LiquidPipelineSizeBoundary();
                if (request.LiquidPipelineSize.Id.HasValue)
                {
                    //update
                    liquidPipelineSizeBoundary = await _unitOfWork.LiquidPipelineSizeBoundaryRepository.GetSingleAsync(x => x.Id == request.LiquidPipelineSize.Id);
                    if (liquidPipelineSizeBoundary != null)
                    {
                        liquidPipelineSizeBoundary.LengthMin = request.LiquidPipelineSize.LengthMin;
                        liquidPipelineSizeBoundary.LengthMax = request.LiquidPipelineSize.LengthMax;
                        liquidPipelineSizeBoundary.FlowRateMin = request.LiquidPipelineSize.FlowRateMin;
                        liquidPipelineSizeBoundary.FlowRateMax = request.LiquidPipelineSize.FlowRateMax;
                        liquidPipelineSizeBoundary.Size = request.LiquidPipelineSize.Size;

                        _unitOfWork.LiquidPipelineSizeBoundaryRepository.Update(liquidPipelineSizeBoundary);
                    }
                }
                else
                {
                    //insert
                    liquidPipelineSizeBoundary.LengthMin = request.LiquidPipelineSize.LengthMin;
                    liquidPipelineSizeBoundary.LengthMax = request.LiquidPipelineSize.LengthMax;
                    liquidPipelineSizeBoundary.FlowRateMin = request.LiquidPipelineSize.FlowRateMin;
                    liquidPipelineSizeBoundary.FlowRateMax = request.LiquidPipelineSize.FlowRateMax;
                    liquidPipelineSizeBoundary.Size = request.LiquidPipelineSize.Size;
                    liquidPipelineSizeBoundary.PressureType = request.LiquidPipelineSize.PressureType;

                    _unitOfWork.LiquidPipelineSizeBoundaryRepository.Insert(liquidPipelineSizeBoundary);
                }
                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }

    }
}
