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
    public class SaveBrainGasExportSettingCommand : IRequest<CustomResponse<bool>>
    {
        public BrainGasExportDto BrainGasExportDto;
        public class SaveBrainGasExportSettingCommandHandler : IRequestHandler<SaveBrainGasExportSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SaveBrainGasExportSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<CustomResponse<bool>> Handle(SaveBrainGasExportSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainGasExport = new BrainGasExport();
                if (request.BrainGasExportDto.Id.HasValue)
                {
                    //update
                    brainGasExport = await _unitOfWork.BrainGasExportRepository.GetSingleAsync(x => x.Id == request.BrainGasExportDto.Id);
                    if (brainGasExport != null)
                    {
                        brainGasExport.HydrocarbonType = request.BrainGasExportDto.HydrocarbonType;
                        brainGasExport.FlowrateGreaterThanGasInjectionPlusLift = request.BrainGasExportDto.FlowrateGreaterThanGasInjectionPlusLift;
                        brainGasExport.HCDewpoint = request.BrainGasExportDto.HCDewpoint;
                        brainGasExport.WaterContentDewpoint = request.BrainGasExportDto.WaterContentDewpoint;
                        brainGasExport.GasExport = request.BrainGasExportDto.GasExport;
                        brainGasExport.ProcessText = request.BrainGasExportDto.ProcessText;
                        brainGasExport.ProcessIds = request.BrainGasExportDto.ProcessIds;
                        brainGasExport.Pipeline = request.BrainGasExportDto.Pipeline;
                        _unitOfWork.BrainGasExportRepository.Update(brainGasExport);
                    }
                }
                else
                {
                    //insert
                    brainGasExport.Id = new Guid();
                    brainGasExport.HydrocarbonType = request.BrainGasExportDto.HydrocarbonType;
                    brainGasExport.FlowrateGreaterThanGasInjectionPlusLift = request.BrainGasExportDto.FlowrateGreaterThanGasInjectionPlusLift;
                    brainGasExport.HCDewpoint = request.BrainGasExportDto.HCDewpoint;
                    brainGasExport.WaterContentDewpoint = request.BrainGasExportDto.WaterContentDewpoint;
                    brainGasExport.GasExport = request.BrainGasExportDto.GasExport;
                    brainGasExport.ProcessText = request.BrainGasExportDto.ProcessText;
                    brainGasExport.ProcessIds = request.BrainGasExportDto.ProcessIds;
                    brainGasExport.Pipeline = request.BrainGasExportDto.Pipeline;
                    _unitOfWork.BrainGasExportRepository.Insert(brainGasExport);
                }
                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
