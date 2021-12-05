using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Queries
{
    public class GetProjectStagesQuery : IRequest<IEnumerable<ProjectStageDto>>
    {
        public class GetProjectStagesQueryHandler : IRequestHandler<GetProjectStagesQuery, IEnumerable<ProjectStageDto>>
        {
            
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public GetProjectStagesQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<IEnumerable<ProjectStageDto>> Handle(GetProjectStagesQuery request, CancellationToken cancellationToken)
            {
                var stages =await _unitOfWork.ProjectStageRepository.Filter(x => x.IsDeleted == false).OrderBy(x => x.Stage).ToListAsync();
                return _mapper.Map<IEnumerable<ProjectStageDto>>(stages);
            }
        }
    }
}
