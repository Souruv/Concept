using AutoMapper;
using CF.CostBrainService.Application.Common.Interfaces;
using CF.CostBrainService.Application.Features.HUCHookupCost.Dto;
using CF.CostBrainService.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Command
{
    public class CalculateHUCHookupCostCommand : IRequest<HUCCostSummaryDto>
    {
        public HUCInputValuesDto HUCInputValuesDto { get; set; }
      
        public class SaveHUCValuesCommandHandler : IRequestHandler<CalculateHUCHookupCostCommand, HUCCostSummaryDto>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IHUCHookupService _hucHookupService;
            private readonly IHostingEnvironment _env;

            public SaveHUCValuesCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper, IHUCHookupService _hucHookupService,IHostingEnvironment env)
            {
                this._unitOfWork = _unitOfWork;
                this._mapper = _mapper;
                this._hucHookupService = _hucHookupService;
                this._env = env;
            }
        
            public async Task<HUCCostSummaryDto> Handle(CalculateHUCHookupCostCommand query, CancellationToken cancellationToken)
            {
                Spire.License.LicenseProvider.SetLicenseFileName(_env.WebRootPath + "\\license.elic.xml");

                string filePath = _env.WebRootPath + "\\Templates\\HUCOutput.xlsx";
                var hucCostCostSummary = await _hucHookupService.CalculateHUCCost(query.HUCInputValuesDto,filePath);
                return hucCostCostSummary;
            }
        }
    }
}
