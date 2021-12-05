using AutoMapper;
using CF.ConceptBrainService.Application.Common.Interfaces;
using CF.ConceptBrainService.Application.Common.Response;
using CF.ConceptBrainService.Application.Features.PipelineSizeSettingFeatures.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Commands
{
    public class DeleteBrainGasContaminantMgmtSettingCommand : IRequest<CustomResponse<bool>>
    {
        public Guid Id { get; set; }
        public class DeleteBrainGasContaminantMgmtSettingCommandHandler : IRequestHandler<DeleteBrainGasContaminantMgmtSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedInUserService _loggedInUserService;
            public DeleteBrainGasContaminantMgmtSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILoggedInUserService loggedInUserService)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _loggedInUserService = loggedInUserService;
            }

            public async Task<CustomResponse<bool>> Handle(DeleteBrainGasContaminantMgmtSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainGasContaminantMgmt = new BrainGasContaminantMgmt();
                if (!string.IsNullOrEmpty(Convert.ToString(request.Id)) && request.Id != Guid.Empty)
                {
                    brainGasContaminantMgmt = await _unitOfWork.BrainGasContaminantMgmtRepository.GetSingleAsync(x => x.Id == request.Id);
                    if (brainGasContaminantMgmt == null) return default;
                    brainGasContaminantMgmt.IsDeleted = true;
                    brainGasContaminantMgmt.DeletedOn = DateTime.Now;
                    brainGasContaminantMgmt.DeletedByUserId = _loggedInUserService.Id;

                    _unitOfWork.BrainGasContaminantMgmtRepository.Update(brainGasContaminantMgmt);
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
