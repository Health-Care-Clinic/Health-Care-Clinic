using System;
using System.Collections.Generic;
using System.Text;
using Pharmacy.ApiKeys.Model;
using Pharmacy.Model;

namespace Pharmacy.Service
{
    public interface IMessageService : IService<Message>
    {
        void SendMessage(string message, string receiver);
        void ReceiveMessage(Message message);
    }
}
