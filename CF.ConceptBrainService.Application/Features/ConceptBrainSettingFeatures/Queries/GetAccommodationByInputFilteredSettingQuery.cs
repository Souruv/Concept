using CF.ConceptBrainService.Application.Entities;
using MediatR;
using System.Collections.Generic;
using AutoMapper;
using CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto;
using CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Dto.InputDto;
using CF.ConceptBrainService.Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using CF.ConceptBrainService.Application.Services.Interfaces;
using CF.ConceptBrainService.Application.Common.Constants;

namespace CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Queries
{
    public class GetAccommodationByInputFilteredSettingQuery : IRequest<List<BrainAccommodationDto>>
    {
        public string? ProcessingScheme { get; set; }
        public string? Location { get; set; }
        public class GetAccommodationByInputFilteredSettingQueryHandler : IRequestHandler<GetAccommodationByInputFilteredSettingQuery, List<BrainAccommodationDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRuleEngine<BrainAccommodationDto, AccommodationInputParamDto> _ruleEngine;
            public GetAccommodationByInputFilteredSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IRuleEngine<BrainAccommodationDto, AccommodationInputParamDto> ruleEngine)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _ruleEngine = ruleEngine;
            }
            public async Task<List<BrainAccommodationDto>> Handle(GetAccommodationByInputFilteredSettingQuery request, CancellationToken cancellationToken)
            {
                AccommodationInputParamDto accommodationInputParamDto = new AccommodationInputParamDto();
                accommodationInputParamDto.ProcessingScheme = request.ProcessingScheme;
                accommodationInputParamDto.Location = request.Location;


                var accommodation = _unitOfWork.BrainAccommodationRepository.Filter(x => x.IsDeleted == false).ToList();
                var accommodationDto = _mapper.Map<List<BrainAccommodation>, List<BrainAccommodationDto>>(accommodation);
                return _ruleEngine.EvaluateAndGetResult(accommodationInputParamDto, accommodationDto, FormulaFieldName.ACCOMODATION);
            }
        }
    }
}
