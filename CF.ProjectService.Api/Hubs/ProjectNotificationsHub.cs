using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Api.Hubs
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Authorize]
    public class ProjectNotificationsHub : Hub
    {
        private readonly ISignalrService _signalrConnectionManager;
        private readonly IProjectNotificationService _projectNotificationService;
        public ProjectNotificationsHub(ISignalrService signalRConnectionManager, IProjectNotificationService projectNotificationService)
        {
            _signalrConnectionManager = signalRConnectionManager;
            _projectNotificationService = projectNotificationService;
        }
        public string GetConnectionId()
        {
            var httpContext = this.Context.GetHttpContext();
            var userId = httpContext.Request.Query["userId"];
            _signalrConnectionManager.KeepUserConnection(new Guid(userId), Context.ConnectionId);

            return Context.ConnectionId;
        }

        public async Task<bool> ReadingNotification(Guid notificationId)
        {
            try
            {
                await _projectNotificationService.UpdateReadingNotificationAsync(notificationId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        //Called when a connection with the hub is terminated.
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            //get the connectionId
            var connectionId = Context.ConnectionId;
            _signalrConnectionManager.RemoveUserConnection(connectionId);
            var value = await Task.FromResult(0);
        }

        public struct WebSocketActions
        {
            public static readonly string SEND_TO_USER = "sendToUser";
        }
    }
}
