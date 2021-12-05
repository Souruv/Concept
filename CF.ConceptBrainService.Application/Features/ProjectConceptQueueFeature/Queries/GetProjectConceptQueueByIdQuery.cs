using CF.ConceptBrainService.Application.Entities;
using MediatR;
using System.Collections.Generic;
using CF.ConceptBrainService.Application.Features.ProjectConceptQueueFeature.Dto;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using CF.ConceptBrainService.Application.Common.Interfaces;
using System;
using System.Linq;

namespace CF.ConceptBrainService.Application.Features.ProjectConceptQueueFeature.Queries
{
    public class GetProjectConceptQueueByIdQuery : IRequest<ProjectConceptQueueDto>
    {
        public Guid Id { get; set; }
        public class GetProjectConceptQueueByIdQueryHandler : IRequestHandler<GetProjectConceptQueueByIdQuery, ProjectConceptQueueDto>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public GetProjectConceptQueueByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<ProjectConceptQueueDto> Handle(GetProjectConceptQueueByIdQuery request, CancellationToken cancellationToken)
            {
                var projectConceptQueue = _unitOfWork.ProjectConceptQueueRepository.Filter(x => x.IsDeleted == false && x.ProjectRevisionId == request.Id).OrderBy(x=>x.CreatedOn).FirstOrDefault();
                return _mapper.Map<ProjectConceptQueue, ProjectConceptQueueDto>(projectConceptQueue);
            }
        }
    }
}
