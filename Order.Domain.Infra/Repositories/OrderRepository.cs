using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;
using Orders.Domain.Infra.Contexts;
using Orders.Domain.Queries;
using Orders.Domain.Repositories;

namespace Orders.Domain.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders
                .AsNoTracking()
                .Include(x => x.Seller)
                .Include(x => x.Products)
                .OrderBy(x => x.OrderDate);
        }

        public Order GetById(Guid id)
        {
            return _context.Orders
                .AsNoTracking()
                .Include(x => x.Seller)
                .Include(x => x.Products)
                .FirstOrDefault(OrderQueries.GetById(id));
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}
