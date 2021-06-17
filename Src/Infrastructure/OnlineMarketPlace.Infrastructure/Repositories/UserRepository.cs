using OnlineMarketPlace.Domain;
using OnlineMarketPlace.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineMarketPlace.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MarketPlaceContext context) : base(context)
        {
        }

        public User GetByEmail(string email)
        {
            return _table.SingleOrDefault(user => user.Email == email);
        }
    }
}
