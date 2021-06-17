using Microsoft.EntityFrameworkCore;
using OnlineMarketPlace.Domain;
using OnlineMarketPlace.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineMarketPlace.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MarketPlaceContext context) : base(context)
        {
        }

        public override IEnumerable<Product> GetAll()
        {
            return _context.Products.Include("AttributeValues").Include("AttributeValues.AttributeType").Include("User").ToList(); 
        }

        public override Product GetById(int id)
        {
            return _context.Products.Include("AttributeValues").Include("AttributeValues.AttributeType").Include("User").FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAllByUserId(int userId)
        {
            return _context.Products.Where(x => x.UserId == userId).Include("AttributeValues").Include("AttributeValues.AttributeType").Include("User");
        }
    }
}
