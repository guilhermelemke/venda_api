using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;
using Orders.Domain.Infra.Contexts;
using Orders.Domain.Queries;
using Orders.Domain.Repositories;

namespace Orders.Domain.Infra.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly DataContext _context;

        public SellerRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Seller seller)
        {
            _context.Sellers.Add(seller);
            _context.SaveChanges();
        }

        public void Update(Seller seller)
        {
            _context.Entry(seller).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Seller> GetAll()
        {
            return _context.Sellers
                .AsNoTracking()
                .Where(SellerQueries.GetAll())
                .OrderBy(x => x.Name);
        }

        public Seller GetById(Guid id)
        {
            return _context.Sellers
                .AsNoTracking()
                .FirstOrDefault(SellerQueries.GetById(id));
        }

        public Seller GetByName(string name)
        {
            return _context.Sellers
                .AsNoTracking()
                .FirstOrDefault(SellerQueries.GetByName(name));
        }

        public Seller GetByCpf(string cpf)
        {
            return _context.Sellers
                .AsNoTracking()
                .FirstOrDefault(SellerQueries.GetByCpf(cpf));
        }
    }
}
