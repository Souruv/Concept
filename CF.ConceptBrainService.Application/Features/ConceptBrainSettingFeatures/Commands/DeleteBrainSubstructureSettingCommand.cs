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
    public class DeleteBrainSubstructureSettingCommand : IRequest<CustomResponse<bool>>
    {
        public Guid Id { get; set; }
        public class DeleteBrainSubstructureSettingCommandHandler : IRequestHandler<DeleteBrainSubstructureSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedInUserService _loggedInUserService;
            public DeleteBrainSubstructureSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILoggedInUserService loggedInUserService)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _loggedInUserService = loggedInUserService;
            }
            public async Task<CustomResponse<bool>> Handle(DeleteBrainSubstructureSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainSubstructure = new BrainSubstructure();
                if (!string.IsNullOrEmpty(Convert.ToString(request.Id)) && request.Id != Guid.Empty)
                {
                    brainSubstructure = await _unitOfWork.BrainSubstructureRepository.GetSingleAsync(x => x.Id == request.Id);
                    if (brainSubstructure == null) return default;
                    brainSubstructure.IsDeleted = true;
                    brainSubstructure.DeletedOn = DateTime.Now;
                    brainSubstructure.DeletedByUserId = _loggedInUserService.Id;

                    _unitOfWork.BrainSubstructureRepository.Update(brainSubstructure);
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
