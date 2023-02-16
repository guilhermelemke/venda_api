using Orders.Domain.Entities;
using Orders.Domain.Repositories;

namespace Orders.Domain.Tests.Repositories
{
    public class FakeSellerRepository : ISellerRepository
    {
        public void Create(Seller seller)
        {
        }

        public IEnumerable<Seller> GetAll()
        {
            throw new NotImplementedException();
        }

        public Seller GetByCpf(string cpf)
        {
            if (cpf == "12345678909")
            {
                return null;
            }
            return new Seller("90987654321", "Fake Name", "fake.name@email.com", "+55(11)00987-6765");
        }

        public Seller GetById(Guid id)
        {
            return new Seller("90987654321", "Fake Name", "fake.name@email.com", "+55(11)00987-6765");
        }

        public Seller GetByName(string name)
        {
            return new Seller("90987654321", "Fake Name", "fake.name@email.com", "+55(11)00987-6765");
        }

        public void Update(Seller seller)
        {
            throw new NotImplementedException();
        }
    }
}
