using Orders.Domain.Entities;

namespace Orders.Domain.Tests.EntityTests
{
    [TestClass]
    [TestCategory("Entities")]
    public class SellerTests
    {
        private readonly Seller _validSeller = new Seller("12345678909", "Seller Name", "seller.name@email.com", "+55(11)11234-5678");

        [TestMethod]
        public void Dado_um_novo_vendedor_o_mesmo_deve_ser_criado()
        {
            Assert.AreEqual(_validSeller.Cpf, "12345678909");
            Assert.AreEqual(_validSeller.Name, "Seller Name");
            Assert.AreEqual(_validSeller.Email, "seller.name@email.com");
            Assert.AreEqual(_validSeller.Phone, "+55(11)11234-5678");
        }
    }
}
