using Orders.Domain.Entities;
using System.Linq.Expressions;

namespace Orders.Domain.Queries
{
    public static class SellerQueries
    {
        public static Expression<Func<Seller, bool>> GetAll()
        {
            return x => x.Name.Any();
        }

        public static Expression<Func<Seller, bool>> GetByName(string name)
        {
            return x => x.Name == name;
        }

        public static Expression<Func<Seller, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Seller, bool>> GetByCpf(string cpf)
        {
            return x => x.Cpf == cpf;
        }
    }
}
