using Orders.Domain.Commands;
using Orders.Domain.Handlers;
using Orders.Domain.Tests.Repositories;

namespace Orders.Domain.Tests.HandlerTests
{
    [TestClass]
    [TestCategory("Handlers")]
    public class CreateSellerHandlerTests
    {
        private readonly CreateSellerCommand _invalidCommand = new CreateSellerCommand("098765432129", "Seller Name", "seller.name@email.com", "+55(11)11234-5678");
        private readonly CreateSellerCommand _validCommand = new CreateSellerCommand("12345678909", "Seller Name", "seller.name@email.com", "+55(11)11234-5678");
        private readonly SellerHandler _handler = new SellerHandler(new FakeSellerRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        public CreateSellerHandlerTests()
        {
        }

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(false, _result.Success);
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_vendedor()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(true, _result.Success);
        }

        [TestMethod]
        public void Dado_um_cpf_menor_onze_caracteres_deve_interromper_a_execucao()
        {
            CreateSellerCommand testSeller = new CreateSellerCommand("123", "Seller Name", "seller.name@email.com", "+55(11)11234-5678");
            _result = (GenericCommandResult)_handler.Handle(testSeller);
            Assert.AreEqual(false, _result.Success);
            Assert.AreEqual("Não foi possível criar o vendedor", _result.Message);
        }
    }
}
