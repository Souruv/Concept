using CF.CostBrainService.Application.Features.UserFeatures.Dto;
using CF.CostBrainService.Application.Features.UserFeatures.Queries;
using MediatR;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.CostBrainService.Application.Services.Implementations
{
   public class ReceiveUserAddedBus
    {
        public static ISubscriptionClient _subscriptionClient;
        private readonly IConfiguration _config;
        private static string topicName = "UserAddedTopic";
        private static string subscriptionName = "completedWithSuccessCost";
        private static readonly IMediator mediator;

        public ReceiveUserAddedBus(IConfiguration config, ISubscriptionClient subscriptionClient)
        {
            _config = config;
            _subscriptionClient = subscriptionClient;

        }


        public static async Task ReceiveMessageAsync()
        {
            string ServiceBusConnectionString = "Endpoint=sb://ptsg5cfsb01.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=NVNKU/wySL62Dp1GV0CpumoP579HERrxPXyITLqaNLE=";

            // _subscriptionClient = new SubscriptionClient(_config.GetConnectionString("AzureServiceBus"), topicName, subscriptionName,ReceiveMode.PeekLock,RetryPolicy.Default);
            _subscriptionClient = new SubscriptionClient(ServiceBusConnectionString, topicName, subscriptionName, ReceiveMode.PeekLock, RetryPolicy.Default);
           
            RegisterOnMessageHandlerAndReceiveMessages();

            // Console.ReadKey();

            // await _subscriptionClient.CloseAsync();
        }


        public static void RegisterOnMessageHandlerAndReceiveMessages()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler);

            // Register the function that processes messages.
            _subscriptionClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        public static async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            var messageBody = Encoding.UTF8.GetString(message.Body);

            var serviceMessageCostBrain = JsonConvert.DeserializeObject<AppUserDto>(messageBody);

            var result = await mediator.Send(new GetUserByEmailQuery { Email = serviceMessageCostBrain.Email });
            if (result == null)
            {
                await mediator.Send(serviceMessageCostBrain);
            }
         

            await _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);

            //await _subscriptionClient.CloseAsync();
        }

        public static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            var exception = exceptionReceivedEventArgs.Exception;

            return Task.CompletedTask;
        }
    }
}
