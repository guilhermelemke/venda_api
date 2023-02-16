using Orders.Domain.Entities;
using Orders.Domain.Repositories;
using Orders.Domain.Tests.Helpers;

namespace Orders.Domain.Tests.Repositories
{
    internal class FakeOrderRepositoryCancelled : IOrderRepository
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
            return CreateOrderHelper.ReturnOrderCancelled();
        }

        public void Update(Order order)
        {

        }
    }
}
