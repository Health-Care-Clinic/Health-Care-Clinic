using System;
using System.Collections.Generic;
using Pharmacy.ApiKeys.Model;
using Pharmacy.Repository;
using Pharmacy.Service;

namespace Pharmacy.ApiKeys.Service
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public void Add(Message entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Message entity)
        {
            throw new NotImplementedException();
        }

        public Message GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetAll()
        {
            throw new NotImplementedException();
        }
        public void SendMessage(string message, string receiver)
        {
            _messageRepository.Add(new Message("Hospital", message, receiver));
            _messageRepository.Save();
        }

        public void ReceiveMessage(Message message)
        {
            _messageRepository.Add(message);
            _messageRepository.Save();
        }
    }
}
