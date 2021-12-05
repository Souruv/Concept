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
    public class DeleteBrainPwtInjectionSettingCommand : IRequest<CustomResponse<bool>>
    {
        public Guid Id { get; set; }
        public class DeleteBrainPwtInjectionSettingCommandHandler : IRequestHandler<DeleteBrainPwtInjectionSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedInUserService _loggedInUserService;
            public DeleteBrainPwtInjectionSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILoggedInUserService loggedInUserService)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _loggedInUserService = loggedInUserService;
            }

            public async Task<CustomResponse<bool>> Handle(DeleteBrainPwtInjectionSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainPwtInjection = new BrainPWTInjection();
                if (!string.IsNullOrEmpty(Convert.ToString(request.Id)) && request.Id != Guid.Empty)
                {
                    brainPwtInjection = await _unitOfWork.BrainPWTInjectionRepository.GetSingleAsync(x => x.Id == request.Id);
                    if (brainPwtInjection == null) return default;
                    brainPwtInjection.IsDeleted = true;
                    brainPwtInjection.DeletedOn = DateTime.Now;
                    brainPwtInjection.DeletedByUserId = _loggedInUserService.Id;

                    _unitOfWork.BrainPWTInjectionRepository.Update(brainPwtInjection);
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
