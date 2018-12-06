using Microsoft.AspNetCore.Mvc;
using Products.Core.Converters;
using Products.Core.Dtos;
using Products.Core.Entities;
using Products.Core.DomainEvents;
using Products.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Products.Core.Services;
using Products.Infrastructure.Contexts;

namespace Products.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsContext _context;
        private readonly IProductService _productService;

        public ProductsController(ProductsContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            return _productService.GetProducts();
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            throw new NotFoundException("value", id);
        }

        [HttpPost]
        public ActionResult<ProductDto> Post([FromBody] ProductDto productDto)
        {
            return _productService.AddProduct(productDto);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductDto productDto)
        {
            var product = _context.Products.FirstOrDefault();

            if (product.CurrentPrice != productDto.Price)
                product.Events.Add(new ProductPriceChangedEvent(product.Id, productDto.Price));

            product.CurrentPrice = productDto.Price;
            product.Name = productDto.Name;

            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
