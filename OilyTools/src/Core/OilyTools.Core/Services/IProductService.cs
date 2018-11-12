using OilyTools.Core.Dtos;
using System.Collections.Generic;

namespace OilyTools.Core.Services
{
    public interface IProductService
    {
        List<ProductDto> GetProducts();
        ProductDto GetProductById(int id);
        ProductDto AddProduct(ProductDto productDto);
    }
}