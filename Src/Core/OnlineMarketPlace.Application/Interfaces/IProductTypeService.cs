using OnlineMarketPlace.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketPlace.Application.Interfaces
{
    public interface IProductTypeService
    {
        IEnumerable<ProductType> GetAll();
        ProductType GetById(int id);
        ProductType Insert(ProductType productType);
        ProductType Update(ProductType productType);
        void Delete(int id);
    }
}
