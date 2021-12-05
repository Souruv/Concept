using CF.ConceptBrainService.Application.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto;
using CF.ConceptBrainService.Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Queries
{
    public class GetAllGasExportQuery : IRequest<List<BrainGasExportDto>>
    {
        public class GetAllGasExportQueryHandler : IRequestHandler<GetAllGasExportQuery, List<BrainGasExportDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllGasExportQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<BrainGasExportDto>> Handle(GetAllGasExportQuery request, CancellationToken cancellationToken)
            {
                var gasExport = _unitOfWork.BrainGasExportRepository.Filter(x => x.IsDeleted == false).ToList();

                return _mapper.Map<List<BrainGasExport>, List<BrainGasExportDto>>(gasExport);
            }
        }
    }
}
