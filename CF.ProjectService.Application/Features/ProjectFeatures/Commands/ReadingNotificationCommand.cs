using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Common.Response;
using CF.ProjectService.Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Commands
{
    public class ReadingNotificationCommand : IRequest<CustomResponse<bool>>
    {
        public Guid NotificationId { get; set; }

        public class ReadingNotificationCommandHandler : IRequestHandler<ReadingNotificationCommand, CustomResponse<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IProjectNotificationService _projectNotificationService;
            public ReadingNotificationCommandHandler(IUnitOfWork unitOfWork, IProjectNotificationService projectNotificationService)
            {
                _projectNotificationService = projectNotificationService;
                _unitOfWork = unitOfWork;
            }
            public async Task<CustomResponse<bool>> Handle(ReadingNotificationCommand request, CancellationToken cancellationToken)
            {
                await _projectNotificationService.UpdateReadingNotificationAsync(request.NotificationId);
                //await _unitOfWork.CommitAsync();

                CustomResponse<bool> response = new CustomResponse<bool>()
                {
                    Data = true,
                    IsSucceed = true
                };

                return response;
            }
        }
    }
}
