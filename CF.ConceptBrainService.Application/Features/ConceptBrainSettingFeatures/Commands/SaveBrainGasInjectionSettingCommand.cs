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
    public class SaveBrainGasInjectionSettingCommand : IRequest<CustomResponse<bool>>
    {
        public BrainGasInjectionDto BrainGasInjectionDto;
        public class SaveBrainGasInjectionSettingCommandHandler : IRequestHandler<SaveBrainGasInjectionSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SaveBrainGasInjectionSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<CustomResponse<bool>> Handle(SaveBrainGasInjectionSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainGasInjection = new BrainGasInjection();
                if (request.BrainGasInjectionDto.Id.HasValue)
                {
                    //update
                    brainGasInjection = await _unitOfWork.BrainGasInjectionRepository.GetSingleAsync(x => x.Id == request.BrainGasInjectionDto.Id);
                    if (brainGasInjection != null)
                    {
                        brainGasInjection.HydrocarbonType = request.BrainGasInjectionDto.HydrocarbonType;
                        brainGasInjection.InjectionLiftGreaterThanZero = request.BrainGasInjectionDto.InjectionLiftGreaterThanZero;
                        brainGasInjection.FlowrateGreaterThanGasInjectionPlusLift = request.BrainGasInjectionDto.FlowrateGreaterThanGasInjectionPlusLift;
                        brainGasInjection.NAGReservoir = request.BrainGasInjectionDto.NAGReservoir;
                        brainGasInjection.NAGSeparateTrain = request.BrainGasInjectionDto.NAGSeparateTrain;
                        brainGasInjection.NAGPressureGreaterThanInjectionAndLiftPressure = request.BrainGasInjectionDto.NAGPressureGreaterThanInjectionAndLiftPressure;
                        brainGasInjection.NearByGasField = request.BrainGasInjectionDto.NearByGasField;
                        brainGasInjection.NearByGasFieldProcessed = request.BrainGasInjectionDto.NearByGasFieldProcessed;
                        brainGasInjection.NearByPressureGreaterThanInectionAndLiftPressure = request.BrainGasInjectionDto.NearByPressureGreaterThanInectionAndLiftPressure;
                        brainGasInjection.GasInjection = request.BrainGasInjectionDto.GasInjection;
                        brainGasInjection.ProcessText = request.BrainGasInjectionDto.ProcessText;
                        brainGasInjection.ProcessIds = request.BrainGasInjectionDto.ProcessIds;
                        brainGasInjection.Pipeline = request.BrainGasInjectionDto.Pipeline;

                        _unitOfWork.BrainGasInjectionRepository.Update(brainGasInjection);
                    }
                }
                else
                {
                    //insert
                    brainGasInjection.Id = new Guid();
                    brainGasInjection.HydrocarbonType = request.BrainGasInjectionDto.HydrocarbonType;
                    brainGasInjection.InjectionLiftGreaterThanZero = request.BrainGasInjectionDto.InjectionLiftGreaterThanZero;
                    brainGasInjection.FlowrateGreaterThanGasInjectionPlusLift = request.BrainGasInjectionDto.FlowrateGreaterThanGasInjectionPlusLift;
                    brainGasInjection.NAGReservoir = request.BrainGasInjectionDto.NAGReservoir;
                    brainGasInjection.NAGSeparateTrain = request.BrainGasInjectionDto.NAGSeparateTrain;
                    brainGasInjection.NAGPressureGreaterThanInjectionAndLiftPressure = request.BrainGasInjectionDto.NAGPressureGreaterThanInjectionAndLiftPressure;
                    brainGasInjection.NearByGasField = request.BrainGasInjectionDto.NearByGasField;
                    brainGasInjection.NearByGasFieldProcessed = request.BrainGasInjectionDto.NearByGasFieldProcessed;
                    brainGasInjection.NearByPressureGreaterThanInectionAndLiftPressure = request.BrainGasInjectionDto.NearByPressureGreaterThanInectionAndLiftPressure;
                    brainGasInjection.GasInjection = request.BrainGasInjectionDto.GasInjection;
                    brainGasInjection.ProcessText = request.BrainGasInjectionDto.ProcessText;
                    brainGasInjection.ProcessIds = request.BrainGasInjectionDto.ProcessIds;
                    brainGasInjection.Pipeline = request.BrainGasInjectionDto.Pipeline;
                    _unitOfWork.BrainGasInjectionRepository.Insert(brainGasInjection);
                }
                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
