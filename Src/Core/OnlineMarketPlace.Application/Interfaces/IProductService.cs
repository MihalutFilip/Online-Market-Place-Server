using OnlineMarketPlace.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketPlace.Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Product Insert(Product product);
        Product Update(Product product);
        void Delete(int id);
        IEnumerable<Product> GetAllByUserId(int userId);
    }
}
