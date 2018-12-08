//using Products.Core.DomainEvents;
//using Products.Core.Interfaces.Repositories;
//using Products.Core.Interfaces.Services;
//using System.Collections.Generic;
//using System.Linq;

//namespace Products.Core.Services
//{
//    public class ProductService: IProductService
//    {
//        private readonly IProductRepository _productRepository;
//        private readonly ProductConverter _productConverter;

//        public ProductService(
//            IProductRepository productRepository,
//            ProductConverter productConverter)
//        {
//            _productRepository = productRepository;
//            _productConverter = productConverter;
//        }

//        public ProductDto AddProduct(ProductDto productDto)
//        {
//            var product = _productConverter.ConvertToEntity(productDto);
//            _productRepository.Add(product);

//            product.Events.Add(new ProductCreatedEvent(product));
//            _productRepository.Save();

//            return _productConverter.ConvertToDto(product);
//        }

//        public ProductDto GetProductById(int id)
//        {
//            var product = _productRepository.GetById(id);

//            return _productConverter.ConvertToDto(product);
//        }

//        public List<ProductDto> GetProducts()
//        {
//            var products = _productRepository.GetAll();

//            return _productConverter.ConvertToDtos(products).ToList();
//        }
//    }
//}
