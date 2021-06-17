using OnlineMarketPlace.Domain.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketPlace.Infrastructure.Interfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
        IEnumerable<Message> GetAllByUser(int userId);
    }
}
