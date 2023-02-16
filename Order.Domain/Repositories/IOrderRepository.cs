using Orders.Domain.Entities;

namespace Orders.Domain.Repositories
{
    public interface IOrderRepository
    {
        void Create(Order order);
        void Update(Order order);
        IEnumerable<Order> GetAll();
        Order GetById(Guid id);
    }
}
