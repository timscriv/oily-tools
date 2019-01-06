namespace Products.Core.UseCases.Products
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
