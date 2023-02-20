using Orders.Domain.Commands;

namespace Orders.Domain.Tests.CommandTests
{
    [TestClass]
    [TestCategory("Commands")]
    public class CreateProductCommandTests
    {
        private readonly CreateProductCommand _invalidCommand = new CreateProductCommand("");
        private readonly CreateProductCommand _validCommand = new CreateProductCommand("Caneta");

        public CreateProductCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void Dado_um_comando_invalido()
        {
            Assert.AreEqual(false, _invalidCommand.Valid);
        }

        [TestMethod]
        public void Dado_um_comando_valido()
        {
            Assert.AreEqual(true, _validCommand.Valid);
        }
    }
}
