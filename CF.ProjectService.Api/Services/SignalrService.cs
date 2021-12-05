using AutoMapper;
using CF.ProjectService.Api.Hubs;
using CF.ProjectService.Application.Common.Constants;
using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Api.Services
{
    public class SignalrService : ISignalrService
    {
        private static Dictionary<Guid, List<string>> userConnectionMap = new Dictionary<Guid, List<string>>();
        private static string userConnectionMapLocker = string.Empty;
        private readonly IHubContext<ProjectNotificationsHub> _notificationUserHubContext;

        public SignalrService(IHubContext<ProjectNotificationsHub> notificationUserHubContext)
        {
            _notificationUserHubContext = notificationUserHubContext;
        }

        public void KeepUserConnection(Guid userId, string connectionId)
        {
            lock (userConnectionMapLocker)
            {
                if (!userConnectionMap.ContainsKey(userId))
                {
                    userConnectionMap[userId] = new List<string>();
                }

                userConnectionMap[userId].Add(connectionId);
            }
        }

        public void RemoveUserConnection(string connectionId)
        {
            //This method will remove the connectionId of user
            lock (userConnectionMapLocker)
            {
                foreach (var userId in userConnectionMap.Keys)
                {
                    if (userConnectionMap.ContainsKey(userId))
                    {
                        if (userConnectionMap[userId].Contains(connectionId))
                        {
                            userConnectionMap[userId].Remove(connectionId);
                            break;
                        }
                    }
                }
            }
        }

        private List<string> GetUserConnections(Guid userId)
        {
            var conn = new List<string>();
            lock (userConnectionMapLocker)
            {
                if (userConnectionMap.ContainsKey(userId))
                {
                    conn = userConnectionMap[userId];
                }
            }

            return conn;
        }

        public async Task SendMessageToUserAsync(Guid userId, Object data)
        {
            var connections = GetUserConnections(userId);
            if (connections != null && connections.Count > 0)
            {
                foreach (var connectionId in connections)
                {
                    await _notificationUserHubContext.Clients.Client(connectionId).SendAsync(ProjectNotificationsHub.WebSocketActions.SEND_TO_USER, data);
                }
            }
        }
    }
}
