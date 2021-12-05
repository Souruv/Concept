using Microsoft.Azure.ServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ConceptBrainService.Api.Services
{
    public interface IReceiveUserBus
    {
        Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs);
        Task ProcessMessagesAsync(Message message, CancellationToken token);
        Task ReceiveMessageAsync();
        void RegisterOnMessageHandlerAndReceiveMessages();
    }
}