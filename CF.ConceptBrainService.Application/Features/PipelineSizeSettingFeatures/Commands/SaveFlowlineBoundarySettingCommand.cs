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
    public class SaveFlowlineBoundarySettingCommand : IRequest<CustomResponse<bool>>
    {
        public FlowlineBoundaryDto FlowlineDto;
        public class SaveFlowlineBoundarySettingCommandHandler : IRequestHandler<SaveFlowlineBoundarySettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SaveFlowlineBoundarySettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<CustomResponse<bool>> Handle(SaveFlowlineBoundarySettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var flowlineBoundary = new FlowlineBoundary();
                if (request.FlowlineDto.Id.HasValue)
                {
                    //update
                    flowlineBoundary = await _unitOfWork.FlowlineBoundaryRepository.GetSingleAsync(x => x.Id == request.FlowlineDto.Id);
                    if (flowlineBoundary != null)
                    {
                        flowlineBoundary.Formula = request.FlowlineDto.Formula;
                        flowlineBoundary.Min = request.FlowlineDto.Min;
                        flowlineBoundary.Max = request.FlowlineDto.Max;
                        _unitOfWork.FlowlineBoundaryRepository.Update(flowlineBoundary);
                    }
                }
                else
                {
                    //insert
                    flowlineBoundary.Formula = request.FlowlineDto.Formula;
                    flowlineBoundary.Min = request.FlowlineDto.Min;
                    flowlineBoundary.Max = request.FlowlineDto.Max;
                    flowlineBoundary.FlowlineType = request.FlowlineDto.FlowlineType;
                    _unitOfWork.FlowlineBoundaryRepository.Insert(flowlineBoundary);
                }
                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
