using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace CF.ConceptBrainService.Application.Services.ServiceBus
{
    public interface IReceiveBusService
    {
        Task ReceiveMessageAsync();
    }
}