using Orders.Domain.Entities;
using Orders.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Tests.QueryTests
{
    [TestClass]
    [TestCategory("Queries")]
    public class ProductQueryTests
    {
        private List<Product> _products;

        public ProductQueryTests()
        {
            _products = new List<Product>();
            _products.Add(new Product("Caneta"));
            _products.Add(new Product("Lápis"));
            _products.Add(new Product("Penal"));
            _products.Add(new Product("Borracha"));
            _products.Add(new Product("Caderno"));
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_todos_os_produtos()
        {
            var results = _products.AsQueryable().Where(ProductQueries.GetAll());
            Assert.AreEqual(5, results.Count());
        }
    }
}
