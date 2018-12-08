namespace Products.Core.UseCases.Products
{
    public class GetProductUseCaseRequest
    {
        public int? Id { get; private set; }

        public string Name { get; private set; }

        public static GetProductUseCaseRequest ByName(string name) => new GetProductUseCaseRequest() { Name = name };

        public static GetProductUseCaseRequest ById(int id) => new GetProductUseCaseRequest() { Id = id };
    }
}
