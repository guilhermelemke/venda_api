using Orders.Domain.Entities;

namespace Orders.Domain.Tests.EntityTests
{
    [TestClass]
    [TestCategory("Entities")]
    public class ProductTests
    {
        private readonly Product _validProduct = new Product("Caneta");

        [TestMethod]
        public void Dado_um_novo_produto_o_mesmo_deve_ser_criado()
        {
            Assert.AreEqual("Caneta", _validProduct.ProductName);
        }
    }
}
