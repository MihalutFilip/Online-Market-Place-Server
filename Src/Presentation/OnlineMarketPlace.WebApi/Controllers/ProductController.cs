using Microsoft.AspNetCore.Mvc;
using OnlineMarketPlace.Application.Interfaces;
using OnlineMarketPlace.Domain;
using OnlineMarketPlace.WebApi.Helpers;
using OnlineMarketPlace.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketPlace.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productsService;

        public ProductController(IProductService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [Authorize(new[] { Role.Client })]
        public IActionResult GetAll()
        {
            var products = _productsService.GetAll().Select(product => Mapper.Instance.ToProductViewModel(product));
            return Ok(products);
        }

        [HttpGet("{userId}")]
        [Authorize(new[] { Role.Provider })]
        public IActionResult GetAllById(int userId)
        {
            var products = _productsService.GetAllByUserId(userId).Select(product => Mapper.Instance.ToProductViewModel(product));
            return Ok(products);
        }

        [HttpPost]
        [Authorize(new[] { Role.Provider })]
        public IActionResult Insert(ProductViewModel product)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var savedProduct = _productsService.Insert(Mapper.Instance.ToProduct(product));
            return Ok(Mapper.Instance.ToProductViewModel(savedProduct));
        }

        [HttpDelete("{productId}")]
        [Authorize(new[] { Role.Provider })]
        public IActionResult Delete(int productId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _productsService.Delete(productId);
            return Ok();
        }
    }
}
