using OilyTools.Core.Dtos;
using OilyTools.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OilyTools.Core.Converters
{
    public class ProductConverter : IConverter<Product, ProductDto>
    {
        public ProductDto ConvertToDto(Product entity)
        {
            if (entity == null) return null;

            return new ProductDto
            {
                Name = entity.Name,
                Price = entity.CurrentPrice
            };
        }

        public IEnumerable<ProductDto> ConvertToDtos(IEnumerable<Product> entities)
        {
            return entities?.Select(e => ConvertToDto(e));
        }

        public IEnumerable<Product> ConvertToEntities(IEnumerable<ProductDto> dtos)
        {
            return dtos?.Select(d => ConvertToEntity(d));
        }

        public Product ConvertToEntity(ProductDto dto)
        {
            if (dto == null) return null;

            return new Product
            {
                Name = dto.Name,
                CurrentPrice = dto.Price
            };
        }
    }
}
