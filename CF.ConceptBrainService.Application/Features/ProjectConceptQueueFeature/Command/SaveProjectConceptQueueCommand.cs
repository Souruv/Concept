using AutoMapper;
using CF.ConceptBrainService.Application.Common.Interfaces;
using CF.ConceptBrainService.Application.Common.Response;
using CF.ConceptBrainService.Application.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ConceptBrainService.Application.Features.ProjectConceptQueueFeature.Command
{
    public class SaveProjectConceptQueueCommand : IRequest<CustomResponse<bool>>
    {
        public Guid? Id { get; set; }
        public Guid ProjectRevisionId { get; set; }
        public string ProcessingStatus { get; set; }
        public class SaveProjectConceptQueueCommandHandler : IRequestHandler<SaveProjectConceptQueueCommand, CustomResponse<bool>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public SaveProjectConceptQueueCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<CustomResponse<bool>> Handle(SaveProjectConceptQueueCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                var projectConceptQueue = new ProjectConceptQueue();
                if (request.Id.HasValue)
                {
                    projectConceptQueue = await _unitOfWork.ProjectConceptQueueRepository.GetSingleAsync(x => x.Id == request.Id);
                    if(projectConceptQueue != null)
                    {
                        projectConceptQueue.ProjectRevisionId = request.ProjectRevisionId;
                        projectConceptQueue.ProcessingStatus = request.ProcessingStatus;
                        _unitOfWork.ProjectConceptQueueRepository.Update(projectConceptQueue);
                    }
                }
                else
                {
                    projectConceptQueue.Id = new Guid();
                    projectConceptQueue.ProjectRevisionId = request.ProjectRevisionId;
                    projectConceptQueue.ProcessingStatus = request.ProcessingStatus;
                    _unitOfWork.ProjectConceptQueueRepository.Insert(projectConceptQueue);
                }

                await _unitOfWork.CommitAsync();
                response.Data = true;
                response.IsSucceed = true;
                return response;


            }
        }
    }
}
