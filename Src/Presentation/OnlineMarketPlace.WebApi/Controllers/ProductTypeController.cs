using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMarketPlace.Application.Interfaces;
using OnlineMarketPlace.Domain;
using OnlineMarketPlace.WebApi.Helpers;
using OnlineMarketPlace.WebApi.Models;

namespace OnlineMarketPlace.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        [Authorize(new[] { Role.Admin, Role.Provider })]
        public IActionResult GetAll()
        {
            var productTypes = _productTypeService.GetAll().Select(productType => Mapper.Instance.ToProductTypeViewModel(productType));
            return Ok(productTypes);
        }

        [HttpPost]
        [Authorize(new[] { Role.Admin })]
        public IActionResult Insert(ProductTypeViewModel productType)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var savedProductType = _productTypeService.Insert(Mapper.Instance.ToProductType(productType));
            return Ok(Mapper.Instance.ToProductTypeViewModel(savedProductType));
        }

        [HttpDelete("{productTypeId}")]
        [Authorize(new[] { Role.Admin })]
        public IActionResult Delete(int productTypeId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _productTypeService.Delete(productTypeId);
            return Ok();
        }
    }
}
