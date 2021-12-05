using CF.ConceptBrainService.Application.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CF.ConceptBrainService.Application.Common.Interfaces;
using AutoMapper;
using CF.ConceptBrainService.Application.Features.UserFeatures.Dto;

namespace CF.ConceptBrainService.Application.Features.UserFeatures.Queries
{
    public class GetUserByEmailQuery : IRequest<AppUserDto>
    {
        public string Email { get; set; }
        public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, AppUserDto>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetUserByEmailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<AppUserDto> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
            {
                var user = await _unitOfWork.UserRepository.GetSingleAsync(a => !a.IsDeleted && a.Email == query.Email);
                if (user == null) return null;

                return _mapper.Map<AppUser, AppUserDto>(user);
            }
        }
    }
}
