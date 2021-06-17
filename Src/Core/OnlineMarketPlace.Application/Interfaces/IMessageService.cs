using OnlineMarketPlace.Domain.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketPlace.Application.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<Message> GetAll();
        IEnumerable<Message> GetAllByUser(int userId);
        Message GetById(int id);
        Message Insert(Message message);
        Message Update(Message message);
        void Delete(int id);
    }
}
