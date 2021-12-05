using CF.ConceptBrainService.Api.Controllers;
using CF.ConceptBrainService.Application.Features.UserFeatures.Dto;
using CF.ConceptBrainService.Application.Features.UserFeatures.Queries;
using MediatR;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CF.ConceptBrainService.Api.Services
{
    public class ReceiveUserBus :IReceiveUserBus
    {
        public static ISubscriptionClient _subscriptionClient;
        private readonly IConfiguration _config;
        private static string topicName = "UserAddedTopic";
        private static string subscriptionName = "userAddedSubscription";
          private  IMediator mediator ;
        HttpContext httpContext;
        protected  IMediator Mediator => mediator ??= httpContext.RequestServices.GetService<IMediator>();

        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReceiveUserBus(IHttpContextAccessor httpContextAccessor, IMediator mediator)
        {
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
            //ReceiveMessageAsync().GetAwaiter().GetResult();
        }


        public  async Task ReceiveMessageAsync()
        {


            string ServiceBusConnectionString = "Endpoint=sb://ptsg5cfsb01.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=NVNKU/wySL62Dp1GV0CpumoP579HERrxPXyITLqaNLE=";

            // _subscriptionClient = new SubscriptionClient(_config.GetConnectionString("AzureServiceBus"), topicName, subscriptionName,ReceiveMode.PeekLock,RetryPolicy.Default);
            _subscriptionClient = new SubscriptionClient(ServiceBusConnectionString, topicName, subscriptionName, ReceiveMode.PeekLock, RetryPolicy.Default);
            RegisterOnMessageHandlerAndReceiveMessages();

            // Console.ReadKey();

            // await _subscriptionClient.CloseAsync();
        }


        public  void RegisterOnMessageHandlerAndReceiveMessages()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler);

            // Register the function that processes messages.
            _subscriptionClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        public  async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            var messageBody = Encoding.UTF8.GetString(message.Body);

          
            var serviceMessageConceptBrain = JsonConvert.DeserializeObject<AppUserDto>(messageBody);

          

           //var mediator = (IMediator)_httpContextAccessor.HttpContext.RequestServices.GetService(typeof(IMediator));

            GetUserByEmailQuery cmd = new GetUserByEmailQuery { Email = serviceMessageConceptBrain.Email };
            await _mediator.Send(cmd);

            //var result = await mediator.Send(new GetUserByEmailQuery { Email = serviceMessageConceptBrain.Email });
            //if (result == null)
            //{
            //    await Mediator.Send(serviceMessageConceptBrain);
            //}

            //await _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);

            //await _subscriptionClient.CloseAsync();
        }

        public Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            var exception = exceptionReceivedEventArgs.Exception;

            return Task.CompletedTask;
        }
    }
}
