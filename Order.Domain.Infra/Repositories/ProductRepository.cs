using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;
using Orders.Domain.Infra.Contexts;
using Orders.Domain.Queries;
using Orders.Domain.Repositories;

namespace Orders.Domain.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products
                .AsNoTracking()
                .Where(ProductQueries.GetAll())
                .OrderBy(x => x.ProductName);
        }

        public Product GetById(Guid id)
        {
            return _context.Products
                .AsNoTracking()
                .FirstOrDefault(ProductQueries.GetById(id));
        }

        public Product GetByName(string productName)
        {
            return _context.Products
                .AsNoTracking()
                .FirstOrDefault(ProductQueries.GetByName(productName));
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
