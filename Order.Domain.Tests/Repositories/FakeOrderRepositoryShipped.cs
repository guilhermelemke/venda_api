using Orders.Domain.Entities;
using Orders.Domain.Repositories;
using Orders.Domain.Tests.Helpers;

namespace Orders.Domain.Tests.Repositories
{
    internal class FakeOrderRepositoryShipped : IOrderRepository
    {
        public void Create(Order order)
        {
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(Guid id)
        {
            return CreateOrderHelper.ReturnOrderShipped();
        }

        public void Update(Order order)
        {

        }
    }
}
