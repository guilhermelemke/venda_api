using Orders.Domain.Commands;

namespace Orders.Domain.Tests.CommandTests
{
    [TestClass]
    [TestCategory("Commands")]
    public class CreateSellerCommandTests
    {
        private readonly CreateSellerCommand _invalidCommand = new CreateSellerCommand("", "Name One", "nameone@email.com", "+55(11)11234-5678");
        private readonly CreateSellerCommand _validCommand = new CreateSellerCommand("12345678909", "Name One", "nameone@email.com", "+55(11)11234-5678");

        public CreateSellerCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void Dado_um_comando_invalido()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
