using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Services.Interfaces;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Commands
{
    public class DeleteFileByRevisionIdCommand : IRequest<bool>
    {
        public Guid RevisionId { get; set; }
        public class DeleteFileByRevisionIdCommandHandler : IRequestHandler<DeleteFileByRevisionIdCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ICosmosDbService _db;
            private readonly ICosmosWellService _well;
            public DeleteFileByRevisionIdCommandHandler(IUnitOfWork unitOfWork, ICosmosDbService db, ICosmosWellService well)
            {
                _unitOfWork = unitOfWork;
                _db = db;
                _well = well;
            }
            public async Task<bool> Handle(DeleteFileByRevisionIdCommand command,CancellationToken cancellationToken)
            {

                var projectInvision = await _unitOfWork.RevisionRepository.GetSingleAsync(x => x.Id == command.RevisionId,
                   source => source.Include(x => x.Enviromental).Include(x => x.Project).Include(x => x.InfrastructureData).ThenInclude(x => x.EvacuationOptions));


                var project = await _unitOfWork.ProjectRepository.GetSingleAsync(a => a.Id == projectInvision.ProjectId);
                if (project == null) return default;
                project.FileName = null;

                _unitOfWork.ProjectRepository.Update(project);


                await _db.DeleteAsync(command.RevisionId.ToString(), command.RevisionId.ToString());
                await  _well.DeleteAsync(command.RevisionId.ToString(), command.RevisionId.ToString());

                await _unitOfWork.CommitAsync();
                return true;
            }
        }
    }
}
