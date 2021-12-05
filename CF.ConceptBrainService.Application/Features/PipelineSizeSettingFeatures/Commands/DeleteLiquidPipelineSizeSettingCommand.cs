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
    public class DeleteLiquidPipelineSizeSettingCommand : IRequest<CustomResponse<bool>>
    {
        public Guid Id;
        public class DeleteLiquidPipelineSizeSettingCommandHandler : IRequestHandler<DeleteLiquidPipelineSizeSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedInUserService _loggedInUserService;
            public DeleteLiquidPipelineSizeSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILoggedInUserService loggedInUserService)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _loggedInUserService = loggedInUserService;
            }

            public async Task<CustomResponse<bool>> Handle(DeleteLiquidPipelineSizeSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var liquidPipelineSizeBoundary = new LiquidPipelineSizeBoundary();
                if (!string.IsNullOrEmpty(Convert.ToString(request.Id)) && request.Id != Guid.Empty)
                {
                    liquidPipelineSizeBoundary = await _unitOfWork.LiquidPipelineSizeBoundaryRepository.GetSingleAsync(x => x.Id == request.Id);
                    if (liquidPipelineSizeBoundary == null) return default;
                    liquidPipelineSizeBoundary.IsDeleted = true;
                    liquidPipelineSizeBoundary.DeletedOn = DateTime.Now;
                    liquidPipelineSizeBoundary.DeletedByUserId = _loggedInUserService.Id;

                    _unitOfWork.LiquidPipelineSizeBoundaryRepository.Update(liquidPipelineSizeBoundary);
                    response.Data = true;
                    await _unitOfWork.CommitAsync();
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
