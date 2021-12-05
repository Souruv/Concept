namespace CF.ProjectService.Application.Features.ProjectFeatures.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using CF.ProjectService.Application.Common.Interfaces;
    using CF.ProjectService.Application.Entities;
    using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
    using MediatR;

    public class SaveProjectDeterMinisticValues : IRequest<bool>
    {
        public Guid RevisionId { get; set; }
        public List<ProjectDeterMinisticValuesPostDto> ProjectDeterMinisticValues { get; set; }

        public class SaveProjectDeterMinisticValuesCommandHandler : IRequestHandler<SaveProjectDeterMinisticValues, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly ILoggedInUserService loggedInUserService;

            public SaveProjectDeterMinisticValuesCommandHandler(IUnitOfWork unitOfWork, ILoggedInUserService loggedInUserService)
            {
                this.unitOfWork = unitOfWork;
                this.loggedInUserService = loggedInUserService;
            }

            public async Task<bool> Handle(SaveProjectDeterMinisticValues request, CancellationToken cancellationToken)
            {
                if (request.ProjectDeterMinisticValues.Any())
                {
                    // Check if project revision id exist
                    var projDeterministicValues = this.unitOfWork.ProjectDeterministicValueRepository.Filter(x => x.ProjectRevisionId == request.RevisionId && x.IsDeleted == false);

                    foreach (var projectDetValues in request.ProjectDeterMinisticValues)
                    {
                        if (!projDeterministicValues.Any())
                        {
                            // Get the deterministic revision id
                            var deterministicValues = this.unitOfWork.DeterministicValueRepository.Filter(x => x.Score == projectDetValues.Score && x.Section == projectDetValues.DeterministicValueDto.Section && x.SubSection == projectDetValues.DeterministicValueDto.SubSection && x.IsDeleted == false).FirstOrDefault();

                            var projectDeterMinisticValues = new ProjectDeterministicValue
                            {
                                Id = Guid.NewGuid(),
                                Comments = projectDetValues.Comments,
                                Score = projectDetValues.Score,
                                DeterministicValueId = deterministicValues.Id,
                                ProjectRevisionId = request.RevisionId,
                            };

                            this.unitOfWork.ProjectDeterministicValueRepository.Insert(projectDeterMinisticValues);
                        }
                        else
                        {
                            var projectDeterMinisticValues = projDeterministicValues.FirstOrDefault(x => x.DeterministicValue.Section == projectDetValues.DeterministicValueDto.Section && x.DeterministicValue.SubSection == projectDetValues.DeterministicValueDto.SubSection);
                            projectDeterMinisticValues.Comments = projectDetValues.Comments;
                            projectDeterMinisticValues.Score = projectDetValues.Score;

                            this.unitOfWork.ProjectDeterministicValueRepository.Update(projectDeterMinisticValues);
                        }
                    }

                    await this.unitOfWork.CommitAsync();

                    return true;
                }

                return false;
            }
        }
    }
}
