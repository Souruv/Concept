using AutoMapper;
using CF.ConceptBrainService.Application.Common.Interfaces;
using CF.ConceptBrainService.Application.Entities;
using CF.ConceptBrainService.Application.Features.PipelineSizeSettingFeatures.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CF.ConceptBrainService.Application.Common;
namespace CF.ConceptBrainService.Application.Features.PipelineSizeSettingFeatures.Queries
{
    public class GetPipelineSizeSettingsQuery : IRequest<PipelineSizeSettingsDto>
    {
        public string PipelineType { get; set; }
        public string PressureType { get; set; }
        public class GetPipelineSizeSettingsQueryHandler : IRequestHandler<GetPipelineSizeSettingsQuery, PipelineSizeSettingsDto>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetPipelineSizeSettingsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<PipelineSizeSettingsDto> Handle(GetPipelineSizeSettingsQuery query, CancellationToken cancellationToken)
            {
                var pipelineSizeCalc = _unitOfWork.PipelineSizeCalcRepository.Filter(x => x.PressureType == query.PressureType && x.PipelineType == query.PipelineType && x.IsDeleted == false).ToList();
                var pipelineSizeSetting = new PipelineSizeSettingsDto();
                if (query.PipelineType.Equals(Common.Enums.PipelineType.Liquid.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    var liquidPipelineBoundary = _unitOfWork.LiquidPipelineSizeBoundaryRepository.Filter(x => x.PressureType == query.PressureType).ToList();
                    pipelineSizeSetting.LiquidPipelineSizeBoundaryDtos = _mapper.Map<List<LiquidPipelineSizeBoundary>, List<LiquidPipelineSizeBoundaryDto>>(liquidPipelineBoundary);
                }
                pipelineSizeSetting.PipelineSizeCalcDtos = _mapper.Map<List<PipelineSizeCalc>, List<PipelineSizeCalcDto>>(pipelineSizeCalc);

                return pipelineSizeSetting;
            }
        }
    }
}
