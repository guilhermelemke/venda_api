using Orders.Domain.Commands;
using Orders.Domain.Entities;

namespace Orders.Domain.Tests.CommandTests
{
    [TestClass]
    [TestCategory("Commands")]
    public class CreateOrderCommandTests
    {
        private Seller _seller;
        private List<Product> _products;
        private CreateOrderCommand _invalidCommand;
        private CreateOrderCommand _validCommand;

        [TestMethod]
        public void Dado_um_pedido_valido()
        {
            _seller = new Seller("12344567654", "Name One", "email@email.com", "+55(11)11234-5678");
            _products = new List<Product>
            {
                new Product("Caneta"),
                new Product("Lápis")
            };

            _validCommand = new CreateOrderCommand(DateTime.Now, _seller, _products);
            _validCommand.Validate();

            Assert.AreEqual(_validCommand.Valid, true);
        }

        [TestMethod]
        public void Dado_um_pedido_sem_produtos_invalido()
        {
            _seller = new Seller("12344567654", "Name One", "email@email.com", "+55(11)11234-5678");
            _products = new List<Product>();

            _invalidCommand = new CreateOrderCommand(DateTime.Now, _seller, _products);
            _invalidCommand.Validate();

            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Dado_um_pedido_sem_vendedor_invalido()
        {
            _seller = null;
            _products = new List<Product>
            {
                new Product("Caneta"),
                new Product("Lápis")
            };

            _invalidCommand = new CreateOrderCommand(DateTime.Now, _seller, _products);
            _invalidCommand.Validate();

            Assert.AreEqual(_invalidCommand.Valid, false);
        }
    }
}
