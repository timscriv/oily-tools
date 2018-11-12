using Microsoft.AspNetCore.Mvc;
using OilyTools.Core.Converters;
using OilyTools.Core.Dtos;
using OilyTools.Core.Entities;
using OilyTools.Core.DomainEvents;
using OilyTools.Core.Exceptions;
using OilyTools.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OilyTools.Core.Services;

namespace OilyTools.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly OilyToolsDbContext _context;
        private readonly IProductService _productService;

        public ProductsController(OilyToolsDbContext context, IProductService productService)
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
