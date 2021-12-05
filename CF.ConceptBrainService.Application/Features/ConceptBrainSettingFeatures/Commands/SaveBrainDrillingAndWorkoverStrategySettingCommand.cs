using System;
using System.Collections.Generic;
using System.Text;
using CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto;
using CF.ConceptBrainService.Application.Common.Interfaces;
using AutoMapper;
using CF.ConceptBrainService.Application.Common.Response;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Commands
{
    public class SaveBrainDrillingAndWorkoverStrategySettingCommand : IRequest<CustomResponse<bool>>
    {
        public BrainDrillingAndWorkoverStrategyDto BrainDrillingAndWorkoverStrategyDto;
        public class SaveBrainDrillingAndWorkoverStrategySettingCommandHandler : IRequestHandler<SaveBrainDrillingAndWorkoverStrategySettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SaveBrainDrillingAndWorkoverStrategySettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<CustomResponse<bool>> Handle(SaveBrainDrillingAndWorkoverStrategySettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainDrillingAndWorkoverStrategy = new BrainDrillingAndWorkoverStrategy();
                if (request.BrainDrillingAndWorkoverStrategyDto.Id.HasValue)
                {
                    //update
                    brainDrillingAndWorkoverStrategy = await _unitOfWork.BrainDrillingAndWorkoverStrategyRepository.GetSingleAsync(x => x.Id == request.BrainDrillingAndWorkoverStrategyDto.Id);
                    if (brainDrillingAndWorkoverStrategy != null)
                    {
                        brainDrillingAndWorkoverStrategy.TreeType = request.BrainDrillingAndWorkoverStrategyDto.TreeType;
                        brainDrillingAndWorkoverStrategy.WaterDepthMin = request.BrainDrillingAndWorkoverStrategyDto.WaterDepthMin;
                        brainDrillingAndWorkoverStrategy.WaterDepthMax = request.BrainDrillingAndWorkoverStrategyDto.WaterDepthMax;
                        brainDrillingAndWorkoverStrategy.Strategy = request.BrainDrillingAndWorkoverStrategyDto.Strategy;

                        _unitOfWork.BrainDrillingAndWorkoverStrategyRepository.Update(brainDrillingAndWorkoverStrategy);
                    }
                }
                else
                {
                    //insert
                    brainDrillingAndWorkoverStrategy.Id = new Guid();
                    brainDrillingAndWorkoverStrategy.TreeType = request.BrainDrillingAndWorkoverStrategyDto.TreeType;
                    brainDrillingAndWorkoverStrategy.WaterDepthMin = request.BrainDrillingAndWorkoverStrategyDto.WaterDepthMin;
                    brainDrillingAndWorkoverStrategy.WaterDepthMax = request.BrainDrillingAndWorkoverStrategyDto.WaterDepthMax;
                    brainDrillingAndWorkoverStrategy.Strategy = request.BrainDrillingAndWorkoverStrategyDto.Strategy;

                    _unitOfWork.BrainDrillingAndWorkoverStrategyRepository.Insert(brainDrillingAndWorkoverStrategy);
                }
                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
