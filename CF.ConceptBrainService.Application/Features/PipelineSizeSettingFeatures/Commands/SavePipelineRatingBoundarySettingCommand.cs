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
    public class SavePipelineRatingBoundarySettingCommand : IRequest<CustomResponse<bool>>
    {
        public PipelineRatingBoundaryDto PipelineRatingBoundaryDto;
        public class SavePipelineRatingBoundarySettingCommandHandler : IRequestHandler<SavePipelineRatingBoundarySettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SavePipelineRatingBoundarySettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<CustomResponse<bool>> Handle(SavePipelineRatingBoundarySettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var pipelineRatingBoundary = new PipelineRatingBoundary();
                if (request.PipelineRatingBoundaryDto.Id.HasValue)
                {
                    //update
                    pipelineRatingBoundary = await _unitOfWork.PipelineRatingRepository.GetSingleAsync(x => x.Id == request.PipelineRatingBoundaryDto.Id);
                    if (pipelineRatingBoundary != null)
                    {
                        pipelineRatingBoundary.PressureMin = request.PipelineRatingBoundaryDto.PressureMin;
                        pipelineRatingBoundary.PressureMax = request.PipelineRatingBoundaryDto.PressureMax;
                        pipelineRatingBoundary.Rating = request.PipelineRatingBoundaryDto.Rating;
                        _unitOfWork.PipelineRatingRepository.Update(pipelineRatingBoundary);
                    }
                }
                else
                {
                    //insert
                    pipelineRatingBoundary.PressureMin = request.PipelineRatingBoundaryDto.PressureMin;
                    pipelineRatingBoundary.PressureMax = request.PipelineRatingBoundaryDto.PressureMax;
                    pipelineRatingBoundary.Rating = request.PipelineRatingBoundaryDto.Rating;
                    _unitOfWork.PipelineRatingRepository.Insert(pipelineRatingBoundary);
                }
                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
