using Orders.Domain.Entities;

namespace Orders.Domain.Repositories
{
    public interface ISellerRepository
    {
        void Create(Seller seller);
        void Update(Seller seller);
        Seller GetById(Guid id);
        Seller GetByCpf(string cpf);
        Seller GetByName(string name);
        IEnumerable<Seller> GetAll();
    }
}
