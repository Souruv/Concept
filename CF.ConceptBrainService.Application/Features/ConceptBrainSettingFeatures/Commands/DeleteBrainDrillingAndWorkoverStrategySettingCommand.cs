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
    public class DeleteBrainDrillingAndWorkoverStrategySettingCommand : IRequest<CustomResponse<bool>>
    {
        public Guid Id { get; set; }
        public class DeleteBrainDrillingAndWorkoverStrategySettingCommandHandler : IRequestHandler<DeleteBrainDrillingAndWorkoverStrategySettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedInUserService _loggedInUserService;
            public DeleteBrainDrillingAndWorkoverStrategySettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILoggedInUserService loggedInUserService)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _loggedInUserService = loggedInUserService;
            }
            public async Task<CustomResponse<bool>> Handle(DeleteBrainDrillingAndWorkoverStrategySettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainDrillingAndWorkoverStrategy = new BrainDrillingAndWorkoverStrategy();
                if (!string.IsNullOrEmpty(Convert.ToString(request.Id)) && request.Id != Guid.Empty)
                {
                    brainDrillingAndWorkoverStrategy = await _unitOfWork.BrainDrillingAndWorkoverStrategyRepository.GetSingleAsync(x => x.Id == request.Id);
                    if (brainDrillingAndWorkoverStrategy == null) return default;
                    brainDrillingAndWorkoverStrategy.IsDeleted = true;
                    brainDrillingAndWorkoverStrategy.DeletedOn = DateTime.Now;
                    brainDrillingAndWorkoverStrategy.DeletedByUserId = _loggedInUserService.Id;

                    _unitOfWork.BrainDrillingAndWorkoverStrategyRepository.Update(brainDrillingAndWorkoverStrategy);
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
