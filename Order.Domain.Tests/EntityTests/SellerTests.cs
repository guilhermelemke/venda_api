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
            Assert.AreEqual("12345678909", _validSeller.Cpf);
            Assert.AreEqual("Seller Name", _validSeller.Name);
            Assert.AreEqual("seller.name@email.com", _validSeller.Email);
            Assert.AreEqual("+55(11)11234-5678", _validSeller.Phone);
        }
    }
}
