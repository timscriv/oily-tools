using OilyTools.Core.Converters;
using OilyTools.Core.DomainEvents;
using OilyTools.Core.Dtos;
using OilyTools.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OilyTools.Core.Services
{
    public class ProductService: IProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly ProductConverter _productConverter;

        public ProductService(
            ProductRepository productRepository,
            ProductConverter productConverter)
        {
            _productRepository = productRepository;
            _productConverter = productConverter;
        }

        public ProductDto AddProduct(ProductDto productDto)
        {
            var product = _productConverter.ConvertToEntity(productDto);
            _productRepository.Add(product);

            product.Events.Add(new ProductCreatedEvent(product));
            _productRepository.Save();

            return _productConverter.ConvertToDto(product);
        }

        public ProductDto GetProductById(int id)
        {
            var product = _productRepository.GetById(id);

            return _productConverter.ConvertToDto(product);
        }

        public List<ProductDto> GetProducts()
        {
            var products = _productRepository.GetAll();

            return _productConverter.ConvertToDtos(products).ToList();
        }
    }
}
