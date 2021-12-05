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
    public class GetAllGasDisposalQuery : IRequest<List<BrainGasDisposalDto>>
    {
        public class GetAllGasDisposalQueryHandler : IRequestHandler<GetAllGasDisposalQuery, List<BrainGasDisposalDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllGasDisposalQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<List<BrainGasDisposalDto>> Handle(GetAllGasDisposalQuery request, CancellationToken cancellationToken)
            {
                var gasDisposal = _unitOfWork.BrainGasDisposalRepository.Filter(x => x.IsDeleted == false).ToList();

                return _mapper.Map<List<BrainGasDisposal>, List<BrainGasDisposalDto>>(gasDisposal);
            }
        }
    }
}
