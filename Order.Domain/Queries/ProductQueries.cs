using Orders.Domain.Entities;
using System.Linq.Expressions;

namespace Orders.Domain.Queries
{
    public static class ProductQueries
    {
        public static Expression<Func<Product, bool>> GetAll()
        {
            return x => x.ProductName.Any();
        }

        public static Expression<Func<Product, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Product, bool>> GetByName(string productName)
        {
            return x => x.ProductName == productName;
        }
    }
}
