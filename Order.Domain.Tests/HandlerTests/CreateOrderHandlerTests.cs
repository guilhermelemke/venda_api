using Orders.Domain.Commands;
using Orders.Domain.Entities;
using Orders.Domain.Handlers;
using Orders.Domain.Tests.Repositories;

namespace Orders.Domain.Tests.HandlerTests
{
    [TestClass]
    [TestCategory("Handlers")]
    public class CreateOrderHandlerTests
    {
        private readonly CreateOrderCommand _invalidCommand = new CreateOrderCommand(DateTime.Now,
                                                                                     null,
                                                                                     new List<Product> { new Product("Caneta"), new Product("Lápis") });
        private readonly CreateOrderCommand _validCommand = new CreateOrderCommand(DateTime.Now,
                                                                             new Seller("12345678909", "Seller Name", "seller.name@email.com", "+55(11)11234-5678"),
                                                                             new List<Product> { new Product("Caneta"), new Product("Lápis") });
        private readonly OrderHandler _handler = new OrderHandler(new FakeOrderRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        public CreateOrderHandlerTests()
        {
        }

        [TestMethod]
        public void Dado_um_pedido_invalido_deve_interromper_a_execucao()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(false, _result.Success);
        }

        [TestMethod]
        public void Dado_um_pedido_valido_deve_criar_vendedor()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(true, _result.Success);
        }
    }
}
