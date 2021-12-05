using System.Threading.Tasks;

namespace CF.AuthService.Application.Services.ServiceBus
{
    public interface ISenderService
    {
        Task SendMessageAsync<T>(T serviceBusMessage, string topicName);
    }
}