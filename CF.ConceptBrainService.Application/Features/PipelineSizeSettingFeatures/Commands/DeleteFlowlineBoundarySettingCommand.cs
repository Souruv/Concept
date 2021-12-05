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
    public class DeleteFlowlineBoundarySettingCommand : IRequest<CustomResponse<bool>>
    {
        public Guid Id;
        public class DeleteFlowlineBoundarySettingCommandHandler : IRequestHandler<DeleteFlowlineBoundarySettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedInUserService _loggedInUserService;
            public DeleteFlowlineBoundarySettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILoggedInUserService loggedInUserService)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _loggedInUserService = loggedInUserService;
            }

            public async Task<CustomResponse<bool>> Handle(DeleteFlowlineBoundarySettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var flowlineBoundary = new FlowlineBoundary();
                if (!string.IsNullOrEmpty(Convert.ToString(request.Id)) && request.Id != Guid.Empty)
                {
                    flowlineBoundary = await _unitOfWork.FlowlineBoundaryRepository.GetSingleAsync(x => x.Id == request.Id);
                    if (flowlineBoundary == null) return default;
                    flowlineBoundary.IsDeleted = true;
                    flowlineBoundary.DeletedOn = DateTime.Now;
                    flowlineBoundary.DeletedByUserId = _loggedInUserService.Id;

                    _unitOfWork.FlowlineBoundaryRepository.Update(flowlineBoundary);
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
