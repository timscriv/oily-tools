using OilyTools.Core.Converters;
using Products.Api.Products.Dtos;
using Products.Core.Common.Entities;

namespace Products.Core.Products.Converters
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
