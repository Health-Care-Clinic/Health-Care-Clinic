using System;
using System.Collections.Generic;
using Integration.ApiKeys.Model;
using Integration.Interface.Repository;
using Integration.Interface.Service;

namespace Integration.ApiKeys.Service
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
    }
}
