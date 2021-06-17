using OnlineMarketPlace.Domain;
using OnlineMarketPlace.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketPlace.Infrastructure.Repositories
{
    public class AttributeTypeRepository : Repository<AttributeType>, IAttributeTypeRepository
    {
        public AttributeTypeRepository(MarketPlaceContext context) : base(context)
        {

        }
    }
}
