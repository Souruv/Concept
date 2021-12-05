using AutoMapper;
using AutoMapper.QueryableExtensions;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Queries
{
    public class GetListStage : IRequest<IEnumerable<ProjectStageDto>>
    {
        public Guid Id { get; set; }

        public string Stage { get; set; }

        public class GetListStageHandle : IRequestHandler<GetListStage,IEnumerable<ProjectStageDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;

            public GetListStageHandle(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<ProjectStageDto>> Handle(GetListStage request, CancellationToken cancellationToken)
            {
                var listStage =  _unitOfWork.ProjectStageRepository.Filter(x => !x.IsDeleted);
                if(listStage == null)
                {
                    return null;
                }
                IQueryable<ProjectStageDto> final = null;
                final = listStage.Select(x => new ProjectStageDto
                {
                    Id = x.Id,
                    Stage = x.Stage
                });
                final = final.OrderBy(x => x.Stage);

                //return await listStage.ProjectTo<ProjectStageDto>(_mapper.ConfigurationProvider).ToListAsync();
                return final;
            }
        }
    }
}
