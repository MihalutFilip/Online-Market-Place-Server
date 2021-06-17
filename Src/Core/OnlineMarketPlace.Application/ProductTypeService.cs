using OnlineMarketPlace.Application.Interfaces;
using OnlineMarketPlace.Domain;
using OnlineMarketPlace.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketPlace.Application
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeService(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public void Delete(int id)
        {
            _productTypeRepository.Delete(id);
        }

        public IEnumerable<ProductType> GetAll()
        {
            return _productTypeRepository.GetAll();
        }

        public ProductType GetById(int id)
        {
            return _productTypeRepository.GetById(id);
        }

        public ProductType Insert(ProductType productType)
        {
            return _productTypeRepository.Insert(productType);
        }

        public ProductType Update(ProductType productType)
        {
            return _productTypeRepository.Update(productType);
        }
    }
}
