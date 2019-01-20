using Microsoft.AspNetCore.Mvc;
using OilyTools.Core.Converters;
using Products.Api.Products.Dtos;
using Products.Core.Common.Entities;
using Products.Core.Common.Interfaces.Products.CreateProduct;
using Products.Core.Common.Interfaces.Products.GetProduct;
using Products.Core.Common.Interfaces.Products.GetProducts;
using Products.Core.Products.GetProduct;
using System.Collections.Generic;
using System.Linq;

namespace Products.Api.Products
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGetProductsUseCase _getProductsUseCase;
        private readonly IGetProductUseCase _getProductUseCase;
        private readonly ICreateProductUseCase _createProductUseCase;
        private readonly IConverter<Product, ProductDto> _converter;

        public ProductsController(
            IGetProductsUseCase getProductsUseCase,
            IGetProductUseCase getProductUseCase,
            ICreateProductUseCase createProductUseCase,
            IConverter<Product, ProductDto> converter)
        {
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

        [HttpGet("{id:int}")]
        public ActionResult<ProductDto> GetById(int id)
        {
            var response = _getProductUseCase.Execute(GetProductUseCaseRequest.ById(id));

            return _converter.Convert(response);
        }

        [HttpGet("{name:alpha}")]
        public ActionResult<ProductDto> GetByName(string name)
        {
            var response = _getProductUseCase.Execute(GetProductUseCaseRequest.ByName(name));

            return _converter.Convert(response);
        }

        [HttpPost]
        public ActionResult<ProductDto> Post([FromBody] ProductDto productDto)
        {
            var product = _converter.Convert(productDto);

            var response = _createProductUseCase.Execute(product);

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, product);
        }
    }
}
