
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;

using CF.AuthService.Application.Features.UserFeatures.Dto;
using CF.AuthService.Application.Common.Interfaces;

namespace CF.AuthService.Application.Features.UserFeatures.Queries
{
    public class GetAllDepartmentsQuery : IRequest<IEnumerable<string>>
    {

        public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<string>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllDepartmentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<IEnumerable<string>> Handle(GetAllDepartmentsQuery query, CancellationToken cancellationToken)
            {
                var depList = _unitOfWork.UserRepository.Filter(x => !x.IsDeleted 
                        && x.Id!=new Guid("EAA6081C-16F1-41BE-9153-5662BC03E9FC")
                ).Select(x=>x.DepartmentName).Distinct();
                
                if (depList == null)
                {
                    return null;
                }
                return await depList.ToListAsync();
            }
        }
    }
}
