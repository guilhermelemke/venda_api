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
    public class OrderQueryTests
    {
        private List<Order> _orders;
        private Seller _selller = new Seller("12345678911", "Seller One", "seller.one@email.com", "+55(11)11234-1111");
        private List<Product> _products = new List<Product>()
        {
            new Product("Penal"),
            new Product("Borracha"),
            new Product("Pincel"),
        };

        public OrderQueryTests()
        {
            _orders = new List<Order>
            {
                new Order(DateTime.Now.Date, _selller, _products),
                new Order(DateTime.Now.Date, _selller, _products),
                new Order(DateTime.Now.Date.AddDays(-20), _selller, _products),
                new Order(DateTime.Now.Date.AddDays(-30), _selller, _products),
                new Order(DateTime.Now.Date.AddDays(-40), _selller, _products),
                new Order(DateTime.Now.Date.AddDays(-1), _selller, _products)
            };
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_todos_os_pedidos_do_dia()
        {
            var results = _orders.AsQueryable().Where(OrderQueries.GetByDate(DateTime.Now.Date));
            Assert.AreEqual(2, results.Count());
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_todos_os_pedidos_por_status()
        {
            _orders[0].ChangeOrderStatusDelivered();
            _orders[1].ChangeOrderStatusCancelled();
            var results = _orders.AsQueryable().Where(OrderQueries.GetAllOrdersByStatus(EnumOrderStatus.AguardandoPagamento));
            Assert.AreEqual(4, results.Count());
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_pedido_por_id()
        {
            _orders[0].ChangeOrderStatusDelivered();
            _orders[1].ChangeOrderStatusCancelled();
            var results = _orders.AsQueryable().Where(OrderQueries.GetById(_orders[3].Id));
            Assert.AreEqual(1, results.Count());
        }
    }
}
