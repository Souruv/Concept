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
    public class DeletePipelineRatingBoundarySettingCommand : IRequest<CustomResponse<bool>>
    {
        public Guid Id;
        public class DeletePipelineRatingBoundarySettingCommandHandler : IRequestHandler<DeletePipelineRatingBoundarySettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedInUserService _loggedInUserService;
            public DeletePipelineRatingBoundarySettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILoggedInUserService loggedInUserService)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _loggedInUserService = loggedInUserService;
            }

            public async Task<CustomResponse<bool>> Handle(DeletePipelineRatingBoundarySettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var pipelineRatingBoundary = new PipelineRatingBoundary();
                if (!string.IsNullOrEmpty(Convert.ToString(request.Id)) && request.Id != Guid.Empty)
                {
                    pipelineRatingBoundary = await _unitOfWork.PipelineRatingRepository.GetSingleAsync(x => x.Id == request.Id);
                    if (pipelineRatingBoundary == null) return default;
                    pipelineRatingBoundary.IsDeleted = true;
                    pipelineRatingBoundary.DeletedOn = DateTime.Now;
                    pipelineRatingBoundary.DeletedByUserId = _loggedInUserService.Id;

                    _unitOfWork.PipelineRatingRepository.Update(pipelineRatingBoundary);
                    await _unitOfWork.CommitAsync();
                    response.Data = true;
                    response.IsSucceed = true;
                }
                else
                {
                    response.Data = false;
                    response.IsSucceed = false;
                    response.Message = "Invalid ID";
                    return response;
                }
                return response;
            }
        }

    }
}
