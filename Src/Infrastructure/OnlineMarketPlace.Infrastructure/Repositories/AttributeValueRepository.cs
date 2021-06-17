using OnlineMarketPlace.Domain;
using OnlineMarketPlace.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketPlace.Infrastructure.Repositories
{
    public class AttributeValueRepository : Repository<AttributeValue>, IAttributeValueRepository
    {
        public AttributeValueRepository(MarketPlaceContext context) : base(context)
        {
        }
    }
}
