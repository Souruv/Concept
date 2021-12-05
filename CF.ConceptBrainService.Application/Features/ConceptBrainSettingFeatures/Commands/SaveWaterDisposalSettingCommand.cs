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
    public class SaveWaterDisposalSettingCommand : IRequest<CustomResponse<bool>>
    {
        public BrainWaterDisposalDto BrainWaterDisposalDto;
        public class SaveWaterDisposalSettingCommandHandler : IRequestHandler<SaveWaterDisposalSettingCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SaveWaterDisposalSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<CustomResponse<bool>> Handle(SaveWaterDisposalSettingCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var brainWaterDispolsal = new BrainWaterDisposal();
                if (request.BrainWaterDisposalDto.Id.HasValue)
                {
                    //update
                    brainWaterDispolsal = await _unitOfWork.BrainWaterDisposalRepository.GetSingleAsync(x => x.Id == request.BrainWaterDisposalDto.Id);
                    if (brainWaterDispolsal != null)
                    {
                        brainWaterDispolsal.AvailabilityOfDisposalReservoir = request.BrainWaterDisposalDto.AvailabilityOfDisposalReservoir;
                        brainWaterDispolsal.Location = request.BrainWaterDisposalDto.Location;
                        brainWaterDispolsal.PwtGreaterThanWif = request.BrainWaterDisposalDto.PwtGreaterThanWif;
                        brainWaterDispolsal.WaterDisposal = request.BrainWaterDisposalDto.WaterDisposal;
                        brainWaterDispolsal.ProcessText = request.BrainWaterDisposalDto.ProcessText;
                        brainWaterDispolsal.ProcessIds = request.BrainWaterDisposalDto.ProcessIds;
                        brainWaterDispolsal.Pipeline = request.BrainWaterDisposalDto.Pipeline;
                        _unitOfWork.BrainWaterDisposalRepository.Update(brainWaterDispolsal);
                    }
                }
                else
                {
                    //insert
                    brainWaterDispolsal.Id = new Guid();
                    brainWaterDispolsal.AvailabilityOfDisposalReservoir = request.BrainWaterDisposalDto.AvailabilityOfDisposalReservoir;
                    brainWaterDispolsal.Location = request.BrainWaterDisposalDto.Location;
                    brainWaterDispolsal.PwtGreaterThanWif = request.BrainWaterDisposalDto.PwtGreaterThanWif;
                    brainWaterDispolsal.WaterDisposal = request.BrainWaterDisposalDto.WaterDisposal;
                    brainWaterDispolsal.ProcessText = request.BrainWaterDisposalDto.ProcessText;
                    brainWaterDispolsal.ProcessIds = request.BrainWaterDisposalDto.ProcessIds;
                    brainWaterDispolsal.Pipeline = request.BrainWaterDisposalDto.Pipeline;
                    _unitOfWork.BrainWaterDisposalRepository.Insert(brainWaterDispolsal);
                }
                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
