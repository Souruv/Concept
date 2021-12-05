using AutoMapper;
using CF.CostBrainService.Application.Common.Constants;
using CF.CostBrainService.Application.Common.Interfaces;
using CF.CostBrainService.Application.Features.TICostCalculation.Dto;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CF.CostBrainService.Application.Features.TICostCalculation.Queries
{
    public class GetTIOptimizationCostQuery : IRequest<TransportationInstallationDto>
    {
        public Guid ConceptId { get; set; }
        public string DCName { get; set; }
        public class GetTIOptimizationCostQueryHandler : IRequestHandler<GetTIOptimizationCostQuery, TransportationInstallationDto>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IConfiguration _configuration;
            private readonly IMapper _mapper;
            public GetTIOptimizationCostQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
            {
                _unitOfWork = unitOfWork;
                _configuration = configuration;
                _mapper = mapper;
            }

            public async Task<TransportationInstallationDto> Handle(GetTIOptimizationCostQuery request, CancellationToken cancellationToken)
            {
                TransportationInstallationDto transportationInstallation = new TransportationInstallationDto();
                TIOptimizationCostDto optimizationCostDto = new TIOptimizationCostDto();
                MWBReference mwb = new MWBReference();
                TIBreakdownDto breakdownDto = new TIBreakdownDto();

                decimal? totalDuration = 0;

                var tiCostCalculationRepository = _unitOfWork.TICostCalculationRepository.Filter(a => a.ConceptId == request.ConceptId && a.DCName.ToLower() == request.DCName.ToLower() && !a.IsDeleted).FirstOrDefault();

                if (tiCostCalculationRepository != null)
                {
                    optimizationCostDto = _mapper.Map<TIOptimizationCostDto>(tiCostCalculationRepository);
                    mwb = _mapper.Map<MWBReference>(tiCostCalculationRepository);
                    breakdownDto = _mapper.Map<TIBreakdownDto>(tiCostCalculationRepository);
                    transportationInstallation.ConceptDCDetailsId = tiCostCalculationRepository.ConceptDCDetailsId;
                    transportationInstallation.DCName = tiCostCalculationRepository.DCName;
                }
                else
                {
                    optimizationCostDto.CostBasis = CostBasisCosnt.Manual;
                    optimizationCostDto.Duration = Convert.ToDecimal(_configuration.GetSection("TIDefaultDuration").Value);
                    optimizationCostDto.Scope = CostSummaryStructureConst.Sharing;

                    var costSummaryList = _unitOfWork.CostSummaryStructureRepository.Filter(a => a.ConceptId == request.ConceptId && a.DCName.ToLower() == request.DCName.ToLower() && a.Category.ToUpper() == CostSummaryStructureConst.InstallationCampaign && !a.IsDeleted).ToList();
                    if (costSummaryList?.Count > 0)
                    {
                        transportationInstallation.ConceptDCDetailsId = costSummaryList.FirstOrDefault().ConceptDCDetailsId;
                        transportationInstallation.DCName = costSummaryList.FirstOrDefault().DCName;

                        var installation = costSummaryList.Where(a => a.Activity.ToUpper() == CostSummaryStructureConst.Installation).FirstOrDefault();

                        mwb.Installation = installation?.TotalDuration_Days;
                        mwb.MOB = costSummaryList.Where(a => a.Activity.ToUpper() == CostSummaryStructureConst.MOB).FirstOrDefault()?.Total_RM;
                        mwb.DMOB = costSummaryList.Where(a => a.Activity.ToUpper() == CostSummaryStructureConst.DEMOB).FirstOrDefault()?.Total_RM;

                        totalDuration = installation?.TotalDuration_Days / optimizationCostDto.Duration;

                        var totalRM = costSummaryList.Where(a => a.Activity.ToUpper() == CostSummaryStructureConst.MOB || a.Activity.ToUpper() == CostSummaryStructureConst.DEMOB).ToList()?.Sum(a => a.Total_RM);
                        var costSummarySubTotalList = _unitOfWork.CostSummarySubTotalRepository.Filter(a => a.ConceptId == request.ConceptId && !a.IsDeleted).ToList();

                        if (totalDuration != null && totalRM != null)
                        {
                            optimizationCostDto.AssociatedCost = Math.Round((decimal)(totalDuration * totalRM), 2);
                            optimizationCostDto.AdditionalCost = Math.Round((decimal)(optimizationCostDto.AssociatedCost - totalRM), 2);
                            optimizationCostDto.TotalOptimizationCost = optimizationCostDto.AdditionalCost;

                            var costSummarySubTotal = costSummarySubTotalList?.Sum(a => a.SubTotal);

                            optimizationCostDto.GrandTotal = Math.Round((decimal)(optimizationCostDto.TotalOptimizationCost + costSummarySubTotal), 2);
                            optimizationCostDto.USDEquivalent = Math.Round((decimal)(optimizationCostDto.GrandTotal / Convert.ToDecimal(_configuration.GetSection("ForexRate").Value)), 2);
                        }

                        if (costSummarySubTotalList != null)
                        {
                            breakdownDto.ContratorPMT = (decimal)(costSummarySubTotalList.Where(a => a.CostSummaryCategory.ToUpper() == CostSummaryStructureConst.PMTInstallation).FirstOrDefault()?.SubTotal);
                            breakdownDto.InstallationEngineering = (decimal)(costSummarySubTotalList.Where(a => a.CostSummaryCategory.ToUpper() == CostSummaryStructureConst.Engineering).FirstOrDefault()?.SubTotal);
                            breakdownDto.TransportationSpread = (decimal)(costSummarySubTotalList.Where(a => a.CostSummaryCategory.ToUpper() == CostSummaryStructureConst.Transportation).FirstOrDefault()?.SubTotal);
                            breakdownDto.Others = (decimal)(costSummarySubTotalList.Where(a => a.CostSummaryCategory.ToUpper() == CostSummaryStructureConst.Others).FirstOrDefault()?.SubTotal);
                            breakdownDto.MWB = (decimal)(costSummarySubTotalList.Where(a => a.CostSummaryCategory.ToUpper() == CostSummaryStructureConst.InstallationCampaign).FirstOrDefault()?.SubTotal);
                            breakdownDto.BreakdownGrandTotal = costSummarySubTotalList?.Sum(a => a.SubTotal);
                            breakdownDto.BreakdownUSDEquivalent = Math.Round((decimal)(breakdownDto.BreakdownGrandTotal / Convert.ToDecimal(_configuration.GetSection("ForexRate").Value)), 2);
                        }
                    }
                }
                transportationInstallation.TIOptimizationCost = optimizationCostDto;
                optimizationCostDto.MWBReference = mwb;
                transportationInstallation.Breakdown = breakdownDto;

                return transportationInstallation;
            }
        }
    }
}
