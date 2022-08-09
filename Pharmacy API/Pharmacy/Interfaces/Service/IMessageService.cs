using Pharmacy.ApiKeys.Model;

namespace Pharmacy.Interfaces.Service
{
    public interface IMessageService : IService<Message>
    {
        void SendMessage(string message, string receiver);
        void ReceiveMessage(Message message);
    }
}
