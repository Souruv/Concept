using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Common.Interfaces
{
    public interface ISignalrService
    {
        void KeepUserConnection(Guid userId, string connectionId);
        void RemoveUserConnection(string connectionId);
        Task SendMessageToUserAsync(Guid userId, Object data);
    }
}
