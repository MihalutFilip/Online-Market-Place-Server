using Microsoft.EntityFrameworkCore;
using OnlineMarketPlace.Domain;
using OnlineMarketPlace.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineMarketPlace.Infrastructure.Repositories
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(MarketPlaceContext context) : base(context)
        {

        }

        public override IEnumerable<ProductType> GetAll()
        {
            return _context.ProductTypes.Include("AttributeTypes").ToList();
        }
    }
}
