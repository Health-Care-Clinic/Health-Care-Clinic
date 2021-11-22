using System;
using System.Collections.Generic;
using System.Text;
using ClinicCore.Service;
using Integration.ApiKeys.Model;

namespace Integration.Interface.Service
{
    public interface IMessageService : IService<Message>
    {
        void SendMessage(string message, string receiver);
    }
}
