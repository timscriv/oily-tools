using Microsoft.AspNetCore.Mvc;
using Products.Api.Dtos;
using Products.Core.Converters;
using Products.Core.Entities;
using Products.Core.Interfaces.UseCases.Products;
using Products.Infrastructure.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Products.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsContext _context;
        private readonly IGetProductsUseCase _getProductsUseCase;
        private readonly IGetProductUseCase _getProductUseCase;
        private readonly ICreateProductUseCase _createProductUseCase;
        private readonly IConverter<Product, ProductDto> _converter;

        public ProductsController(
            ProductsContext context,
            IGetProductsUseCase getProductsUseCase,
            IGetProductUseCase getProductUseCase,
            ICreateProductUseCase createProductUseCase,
            IConverter<Product, ProductDto> converter)
        {
            _context = context;
            _getProductsUseCase = getProductsUseCase;
            _getProductUseCase = getProductUseCase;
            _createProductUseCase = createProductUseCase;
            _converter = converter;
        }

        [HttpGet]
        public ActionResult<List<ProductDto>> Get()
        {
            var response = _getProductsUseCase.Execute();
            return _converter.Convert(response).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get(int id)
        {
            var response = _getProductUseCase.Execute(id);
            return _converter.Convert(response);
        }

        [HttpPost]
        public ActionResult<ProductDto> Post([FromBody] ProductDto productDto)
        {
            var product = _converter.Convert(productDto);

            var newProduct = _createProductUseCase.Execute(product);

            return _converter.Convert(newProduct);
        }

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] ProductDto productDto)
        //{
        //    var product = _context.Products.FirstOrDefault();

        //    if (product.CurrentPrice != productDto.Price)
        //        product.Events.Add(new ProductPriceChangedEvent(product.Id, productDto.Price));

        //    product.CurrentPrice = productDto.Price;
        //    product.Name = productDto.Name;

        //    _context.SaveChanges();
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
