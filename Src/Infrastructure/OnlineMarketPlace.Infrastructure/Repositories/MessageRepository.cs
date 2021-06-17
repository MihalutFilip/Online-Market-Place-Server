using OnlineMarketPlace.Domain.DatabaseEntities;
using OnlineMarketPlace.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineMarketPlace.Infrastructure.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(MarketPlaceContext context) : base(context)
        {
        }

        public IEnumerable<Message> GetAllByUser(int userId)
        {
            return _table.AsQueryable().Where(m => m.ReceiverId == userId || m.SenderId == userId);
        }
    }
}
