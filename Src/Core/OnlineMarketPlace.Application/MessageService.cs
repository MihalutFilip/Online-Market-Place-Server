using OnlineMarketPlace.Application.Interfaces;
using OnlineMarketPlace.Domain.DatabaseEntities;
using OnlineMarketPlace.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketPlace.Application
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public void Delete(int id)
        {
            _messageRepository.Delete(id);
        }

        public IEnumerable<Message> GetAll()
        {
            return _messageRepository.GetAll();
        }

        public IEnumerable<Message> GetAllByUser(int userId)
        {
            return _messageRepository.GetAllByUser(userId);
        }

        public Message GetById(int id)
        {
            return _messageRepository.GetById(id);
        }

        public Message Insert(Message message)
        {
            return _messageRepository.Insert(message);
        }

        public Message Update(Message message)
        {
            return _messageRepository.Update(message);
        }
    }
}
