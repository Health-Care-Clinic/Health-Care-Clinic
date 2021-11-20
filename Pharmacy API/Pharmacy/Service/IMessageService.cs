using System;
using System.Collections.Generic;
using System.Text;
using Pharmacy.Model;

namespace Pharmacy.Service
{
    public interface IMessageService : IService<Message>
    {
        void SendMessage(string message, string receiver);
    }
}
