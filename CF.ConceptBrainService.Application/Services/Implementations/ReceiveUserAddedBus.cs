using CF.ConceptBrainService.Application.Entities;
using CF.ConceptBrainService.Application.Features.UserFeatures.Dto;
using CF.ConceptBrainService.Application.Features.UserFeatures.Queries;
using CF.ConceptBrainService.Application.Services.ServiceBus;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ConceptBrainService.Application.Services.Implementations
{
    public class ReceiveUserAddedBus 
    {
        public static ISubscriptionClient _subscriptionClient;
        private  readonly IConfiguration _config;
        private static string topicName = "UserAddedTopic";
        private static string subscriptionName = "userAddedSubscription";
        private static readonly IMediator mediator;

 

        public ReceiveUserAddedBus(IConfiguration config, ISubscriptionClient subscriptionClient)
        {
            _config = config;
            _subscriptionClient = subscriptionClient;

        }

        public static async  Task ReceiveMessageAsync()
        {
            string ServiceBusConnectionString = "Endpoint=sb://ptsg5cfsb01.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=NVNKU/wySL62Dp1GV0CpumoP579HERrxPXyITLqaNLE=";

            // _subscriptionClient = new SubscriptionClient(_config.GetConnectionString("AzureServiceBus"), topicName, subscriptionName,ReceiveMode.PeekLock,RetryPolicy.Default);
            _subscriptionClient = new SubscriptionClient(ServiceBusConnectionString, topicName, subscriptionName,ReceiveMode.PeekLock,RetryPolicy.Default);
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

      public static  async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            var messageBody = Encoding.UTF8.GetString(message.Body);
          

            var serviceMessageConceptBrain = JsonConvert.DeserializeObject<AppUserDto>(messageBody);

            var result = await mediator.Send(new GetUserByEmailQuery { Email = serviceMessageConceptBrain.Email });
            if (result == null)
            {
                await mediator.Send(serviceMessageConceptBrain);
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
