using Orders.Domain.Entities;

namespace Orders.Domain.Repositories
{
    public interface IProductRepository
    {
        void Create(Product product);
        void Update(Product product);
        Product GetById(Guid id);
        IEnumerable<Product> GetAll();
        Product GetByName(string name);
    }
}
