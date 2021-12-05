using AutoMapper;
using CF.CostBrainService.Application.Common.Interfaces;
using CF.CostBrainService.Application.Entities;
using CF.CostBrainService.Application.Features.CostBrainSettings.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace CF.CostBrainService.Application.Features.CostBrainSettings.Queries
{
    public class GetCostCountryQuery : IRequest<List<CountryDto>>
    {
        public class GetCostCountryQueryHandler : IRequestHandler<GetCostCountryQuery, List<CountryDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;

            public GetCostCountryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<List<CountryDto>> Handle(GetCostCountryQuery request, CancellationToken cancellationToken)
            {
                var countryList = _unitOfWork.CountryRepository.Filter(a => !a.IsDeleted).OrderBy(a => a.Name).ToList();
                List<CountryDto> countries = new List<CountryDto>();
                countries = _mapper.Map<List<CountryDto>>(countryList);
                return countries.Select(a => new CountryDto { Name = a.Name.Replace("\r\n", string.Empty), Id = a.Id }).ToList();
            }
        }
    }
}
