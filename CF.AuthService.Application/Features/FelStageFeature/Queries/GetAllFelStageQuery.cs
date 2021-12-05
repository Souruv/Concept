
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
    public class GetAllFelStageQuery : IRequest<IEnumerable<FelStageDto>>
    {

        public class GetAllFelStageQueryHandler : IRequestHandler<GetAllFelStageQuery, IEnumerable<FelStageDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetAllFelStageQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<IEnumerable<FelStageDto>> Handle(GetAllFelStageQuery query, CancellationToken cancellationToken)
            {
                var felStageList =  _unitOfWork.FelStageRepository.Filter(x=>!x.IsDeleted).OrderBy(x => x.SortOrder); 
                if (felStageList == null)
                {
                    return null;
                }
                var list = await felStageList.ToListAsync();
                return await felStageList.ProjectTo<FelStageDto>(_mapper.ConfigurationProvider).ToListAsync();
            }
        }
    }
}
