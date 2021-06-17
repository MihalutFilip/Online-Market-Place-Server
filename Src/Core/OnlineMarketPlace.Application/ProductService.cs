using OnlineMarketPlace.Application.Interfaces;
using OnlineMarketPlace.Domain;
using OnlineMarketPlace.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMarketPlace.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAllByUserId(int userId)
        {
            return _productRepository.GetAllByUserId(userId);
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product Insert(Product product)
        {
            var savedProduct = _productRepository.Insert(product);
            return _productRepository.GetById(savedProduct.Id);
        }

        public Product Update(Product product)
        {
            return _productRepository.Update(product);
        }
    }
}
