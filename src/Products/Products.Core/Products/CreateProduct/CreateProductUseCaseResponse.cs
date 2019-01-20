namespace Products.Core.Products.CreateProduct
{
    public class CreateProductUseCaseResponse
    {
        public CreateProductUseCaseResponse(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
