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
    public class SaveBrainGasDisposalSettingCommand : IRequest<CustomResponse<bool>>
    {
        public BrainGasDisposalDto BrainGasDisposalDto;
        public class SaveBrainGasDisposalSettingCommandHandler : IRequestHandler<SaveBrainGasDisposalSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SaveBrainGasDisposalSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<CustomResponse<bool>> Handle(SaveBrainGasDisposalSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainGasDisposal = new BrainGasDisposal();
                if (request.BrainGasDisposalDto.Id.HasValue)
                {
                    //update
                    brainGasDisposal = await _unitOfWork.BrainGasDisposalRepository.GetSingleAsync(x => x.Id == request.BrainGasDisposalDto.Id);
                    if (brainGasDisposal != null)
                    {
                        brainGasDisposal.HydrocarbonType = request.BrainGasDisposalDto.HydrocarbonType;
                        brainGasDisposal.FlowrateGreaterThanGasInjectionPlusLift = request.BrainGasDisposalDto.FlowrateGreaterThanGasInjectionPlusLift;
                        brainGasDisposal.GasDisposalReinjection = request.BrainGasDisposalDto.GasDisposalReinjection;
                        brainGasDisposal.GasDisposal = request.BrainGasDisposalDto.GasDisposal;
                        brainGasDisposal.Process = request.BrainGasDisposalDto.Process;
                        brainGasDisposal.Pipeline = request.BrainGasDisposalDto.Pipeline;
                        _unitOfWork.BrainGasDisposalRepository.Update(brainGasDisposal);
                    }
                }
                else
                {
                    //insert
                    brainGasDisposal.Id = new Guid();
                    brainGasDisposal.HydrocarbonType = request.BrainGasDisposalDto.HydrocarbonType;
                    brainGasDisposal.FlowrateGreaterThanGasInjectionPlusLift = request.BrainGasDisposalDto.FlowrateGreaterThanGasInjectionPlusLift;
                    brainGasDisposal.GasDisposalReinjection = request.BrainGasDisposalDto.GasDisposalReinjection;
                    brainGasDisposal.GasDisposal = request.BrainGasDisposalDto.GasDisposal;
                    brainGasDisposal.Process = request.BrainGasDisposalDto.Process;
                    brainGasDisposal.Pipeline = request.BrainGasDisposalDto.Pipeline;

                    _unitOfWork.BrainGasDisposalRepository.Insert(brainGasDisposal);
                }
                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
