using AutoMapper;
using CF.CostBrainService.Application.Common.Interfaces;
using CF.CostBrainService.Application.Common.Response;
using CF.CostBrainService.Application.Features.TICostCalculation.Commands.Dto;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CF.CostBrainService.Application.Features.TICostCalculation.Commands
{
    public class UpdateTIOptimizationCostCommand : IRequest<ExceptionHelper<bool>>
    {
        public TICostCalculationDto TICostCalculation { get; set; }

        public class UpdateCostSettingsHandler : IRequestHandler<UpdateTIOptimizationCostCommand, ExceptionHelper<bool>>
        {
            private readonly ILogger<UpdateTIOptimizationCostCommand> logger;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedInUserService _loggedInUserService;
            private readonly IMapper _mapper;

            public UpdateCostSettingsHandler(IUnitOfWork unitOfWork, ILogger<UpdateTIOptimizationCostCommand> logger, ILoggedInUserService loggedInUserService, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                this.logger = logger;
                _loggedInUserService = loggedInUserService;
                _mapper = mapper;
            }

            public async Task<ExceptionHelper<bool>> Handle(UpdateTIOptimizationCostCommand request, CancellationToken cancellationToken)
            {
                ExceptionHelper<bool> response = new ExceptionHelper<bool>();
                if (request.TICostCalculation.ConceptId == Guid.Empty || request.TICostCalculation.ConceptDCDetailsId == Guid.Empty || request.TICostCalculation.DCName == null)
                {
                    response.Data = false;
                    response.IsSucceed = false;
                    response.Message = "Invalid or Empty ConceptId, ConceptDCDetailsId or DCName";
                    return response;
                }
                var tiCostCalculationRepository = await _unitOfWork.TICostCalculationRepository.GetSingleAsync(a => a.ConceptId == request.TICostCalculation.ConceptId && a.DCName.ToLower() == request.TICostCalculation.DCName.ToLower() && !a.IsDeleted);

                if (tiCostCalculationRepository != null)
                {
                    tiCostCalculationRepository.CostBasis = request.TICostCalculation.CostBasis;
                    tiCostCalculationRepository.Duration = request.TICostCalculation.Duration;
                    tiCostCalculationRepository.AssociatedCost = request.TICostCalculation.AssociatedCost;
                    tiCostCalculationRepository.AdditionalCost = request.TICostCalculation.AdditionalCost;
                    tiCostCalculationRepository.TotalOptimizationCost = request.TICostCalculation.TotalOptimizationCost;
                    tiCostCalculationRepository.GrandTotal = request.TICostCalculation.GrandTotal;
                    tiCostCalculationRepository.USDEquivalent = request.TICostCalculation.USDEquivalent;
                    _unitOfWork.TICostCalculationRepository.Update(_mapper.Map<Entities.TICostCalculation>(tiCostCalculationRepository));
                }
                else
                {
                    _unitOfWork.TICostCalculationRepository.Insert(_mapper.Map<Entities.TICostCalculation>(request.TICostCalculation));
                }

                await _unitOfWork.CommitAsync();

                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
