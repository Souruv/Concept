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
    public class DeletePipelineSizeCalcSettingCommand : IRequest<CustomResponse<bool>>
    {
        public Guid Id;
        public class DeletePipelineSizeCalcSettingCommandHandler : IRequestHandler<DeletePipelineSizeCalcSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedInUserService _loggedInUserService;
            public DeletePipelineSizeCalcSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILoggedInUserService loggedInUserService)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _loggedInUserService = loggedInUserService;
            }

            public async Task<CustomResponse<bool>> Handle(DeletePipelineSizeCalcSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var pipelineSizeCalc = new PipelineSizeCalc();
                if (!string.IsNullOrEmpty(Convert.ToString(request.Id)) && request.Id != Guid.Empty)
                {
                    pipelineSizeCalc = await _unitOfWork.PipelineSizeCalcRepository.GetSingleAsync(x => x.Id == request.Id);
                    if (pipelineSizeCalc == null) return default;
                    pipelineSizeCalc.IsDeleted = true;
                    pipelineSizeCalc.DeletedOn = DateTime.Now;
                    pipelineSizeCalc.DeletedByUserId = _loggedInUserService.Id;

                    _unitOfWork.PipelineSizeCalcRepository.Update(pipelineSizeCalc);
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
