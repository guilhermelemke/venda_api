using Orders.Domain.Commands;
using Orders.Domain.Handlers;
using Orders.Domain.Tests.Repositories;

namespace Orders.Domain.Tests.HandlerTests
{
    [TestClass]
    [TestCategory("Handlers")]
    public class CreateProductHandlerTests
    {
        private readonly CreateProductCommand _invalidCommand = new CreateProductCommand("");
        private readonly CreateProductCommand _validCommand = new CreateProductCommand("Apontador");
        private readonly ProductHandler _handler = new ProductHandler(new FakeProductRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        public CreateProductHandlerTests()
        {
        }

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_produto()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}
