using Orders.Domain.Entities;
using System.Linq.Expressions;

namespace Orders.Domain.Queries
{
    public static class OrderQueries
    {
        public static Expression<Func<Order, bool>> GetAllOrdersByStatus(EnumOrderStatus status)
        {
            return x => x.Status == status;
        }

        public static Expression<Func<Order, bool>> GetByDate(DateTime date)
        {
            return x => x.OrderDate == date;
        }

        public static Expression<Func<Order, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
