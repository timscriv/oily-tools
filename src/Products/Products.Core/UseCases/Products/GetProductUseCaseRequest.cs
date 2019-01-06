using OilyTools.Core.ValueObjects;
using System.Collections.Generic;

namespace Products.Core.UseCases.Products
{
    public class GetProductUseCaseRequest: BaseValueObject
    {
        public int? Id { get; private set; }

        public string Name { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
            yield return Name;
        }

        public static GetProductUseCaseRequest ByName(string name) => new GetProductUseCaseRequest() { Name = name };

        public static GetProductUseCaseRequest ById(int id) => new GetProductUseCaseRequest() { Id = id };
    }
}
