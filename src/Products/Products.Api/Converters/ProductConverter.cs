using OilyTools.Core.Converters;
using Products.Api.Dtos;
using Products.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Products.Core.Converters
{
    public class ProductConverter : BaseConverter<Product, ProductDto>
    {
        public override ProductDto Convert(Product entity)
        {
            if (entity == null) return null;

            return new ProductDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.CurrentPrice
            };
        }

        public override Product Convert(ProductDto dto)
        {
            if (dto == null) return null;

            return new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                CurrentPrice = dto.Price
            };
        }
    }
}
