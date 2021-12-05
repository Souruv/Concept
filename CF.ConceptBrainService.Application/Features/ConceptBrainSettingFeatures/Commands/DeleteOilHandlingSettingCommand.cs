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
    public class DeleteOilHandlingSettingCommand : IRequest<CustomResponse<bool>>
    {
        public Guid Id { get; set; }
        public class DeleteOilHandlingSettingCommandHandler : IRequestHandler<DeleteOilHandlingSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedInUserService _loggedInUserService;
            public DeleteOilHandlingSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILoggedInUserService loggedInUserService)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _loggedInUserService = loggedInUserService;
            }
            public async Task<CustomResponse<bool>> Handle(DeleteOilHandlingSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainOilHandling = new BrainOilHandling();
                if (!string.IsNullOrEmpty(Convert.ToString(request.Id)) && request.Id != Guid.Empty)
                {
                    brainOilHandling = await _unitOfWork.BrainOilHandlingRepository.GetSingleAsync(x => x.Id == request.Id);
                    if (brainOilHandling == null) return default;
                    brainOilHandling.IsDeleted = true;
                    brainOilHandling.DeletedOn = DateTime.Now;
                    brainOilHandling.DeletedByUserId = _loggedInUserService.Id;

                    _unitOfWork.BrainOilHandlingRepository.Update(brainOilHandling);
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
