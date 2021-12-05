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
    public class SaveBrainGasContaminantMgmtSettingCommand : IRequest<CustomResponse<bool>>
    {
        public BrainGasContaminantMgmtDto BrainGasContaminantMgmtDto;
        public class SaveBrainGasContaminantMgmtSettingCommandHandler : IRequestHandler<SaveBrainGasContaminantMgmtSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SaveBrainGasContaminantMgmtSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<CustomResponse<bool>> Handle(SaveBrainGasContaminantMgmtSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainGasContaminantMgmt = new BrainGasContaminantMgmt();
                if (request.BrainGasContaminantMgmtDto.Id.HasValue)
                {
                    //update
                    brainGasContaminantMgmt = await _unitOfWork.BrainGasContaminantMgmtRepository.GetSingleAsync(x => x.Id == request.BrainGasContaminantMgmtDto.Id);
                    if (brainGasContaminantMgmt != null)
                    {
                        brainGasContaminantMgmt.Location = request.BrainGasContaminantMgmtDto.Location;
                        brainGasContaminantMgmt.FeedCo2Max = request.BrainGasContaminantMgmtDto.FeedCo2Max;
                        brainGasContaminantMgmt.FeedCo2Min = request.BrainGasContaminantMgmtDto.FeedCo2Min;
                        brainGasContaminantMgmt.ExportCo2Max = request.BrainGasContaminantMgmtDto.ExportCo2Max;
                        brainGasContaminantMgmt.ExportCo2Min = request.BrainGasContaminantMgmtDto.ExportCo2Min;
                        brainGasContaminantMgmt.CondensateProcessing = request.BrainGasContaminantMgmtDto.CondensateProcessing;
                        brainGasContaminantMgmt.Process = request.BrainGasContaminantMgmtDto.Process;
                        brainGasContaminantMgmt.PipeLine = request.BrainGasContaminantMgmtDto.PipeLine;

                        _unitOfWork.BrainGasContaminantMgmtRepository.Update(brainGasContaminantMgmt);
                    }
                }
                else
                {
                    //insert
                    brainGasContaminantMgmt.Id = new Guid();
                    brainGasContaminantMgmt.Location = request.BrainGasContaminantMgmtDto.Location;
                    brainGasContaminantMgmt.FeedCo2Max = request.BrainGasContaminantMgmtDto.FeedCo2Max;
                    brainGasContaminantMgmt.FeedCo2Min = request.BrainGasContaminantMgmtDto.FeedCo2Min;
                    brainGasContaminantMgmt.ExportCo2Max = request.BrainGasContaminantMgmtDto.ExportCo2Max;
                    brainGasContaminantMgmt.ExportCo2Min = request.BrainGasContaminantMgmtDto.ExportCo2Min;
                    brainGasContaminantMgmt.CondensateProcessing = request.BrainGasContaminantMgmtDto.CondensateProcessing;
                    brainGasContaminantMgmt.Process = request.BrainGasContaminantMgmtDto.Process;
                    brainGasContaminantMgmt.PipeLine = request.BrainGasContaminantMgmtDto.PipeLine;

                    _unitOfWork.BrainGasContaminantMgmtRepository.Insert(brainGasContaminantMgmt);
                }
                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
