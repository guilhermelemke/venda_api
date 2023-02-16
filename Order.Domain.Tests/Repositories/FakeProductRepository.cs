using Orders.Domain.Entities;
using Orders.Domain.Repositories;

namespace Orders.Domain.Tests.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public void Create(Product product)
        {
        }

        public void Update(Product product)
        {
        }

        public Product GetById(Guid id)
        {
            return new Product("Caneta");
        }

        public Product GetByName(string productName)
        {
            return new Product("Caneta");
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
