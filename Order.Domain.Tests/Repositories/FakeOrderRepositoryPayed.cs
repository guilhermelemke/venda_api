using Orders.Domain.Entities;
using Orders.Domain.Repositories;
using Orders.Domain.Tests.Helpers;

namespace Orders.Domain.Tests.Repositories
{
    internal class FakeOrderRepositoryPayed : IOrderRepository
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
            return CreateOrderHelper.ReturnOrderPaymentApproved();
        }

        public void Update(Order order)
        {

        }
    }
}
