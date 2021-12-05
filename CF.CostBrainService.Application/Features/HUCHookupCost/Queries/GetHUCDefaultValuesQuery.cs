using AutoMapper;
using CF.CostBrainService.Application.Common.Interfaces;
using CF.CostBrainService.Application.Features.HUCHookupCost.Dto;
using CF.CostBrainService.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Queries
{
    public class GetHUCDefaultValuesQuery : IRequest<HUCDefaultValuesDto>
    {
        public string ProjectType { get; set; }
        public string Country { get; set; }
        public class GetHUCDefaultValuesQueryHandler : IRequestHandler<GetHUCDefaultValuesQuery, HUCDefaultValuesDto>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IHUCHookupService _hucHookupService;

            public GetHUCDefaultValuesQueryHandler(IUnitOfWork _unitOfWork, IMapper _mapper, IHUCHookupService _hucHookupService)
            {
                this._unitOfWork = _unitOfWork;
                this._mapper = _mapper;
                this._hucHookupService = _hucHookupService;
            }

            public async Task<HUCDefaultValuesDto> Handle(GetHUCDefaultValuesQuery query, CancellationToken cancellationToken)
            {
                var defaultValues = await _hucHookupService.GetHUCDefaultValues(query.ProjectType, query.Country);
                return defaultValues;
            }
        }
    }
}
