using Orders.Domain.Entities;

namespace Orders.Domain.Tests.EntityTests
{
    [TestClass]
    [TestCategory("Entities")]
    public class OrderTests
    {
        private readonly Order _validOrder = new Order(DateTime.Now.Date,
                                                       new Seller("12345678909", "Seller Name", "seller.name@email.com", "+55(11)11234-5678"),
                                                       new List<Product> { new Product("Caneta"), new Product("Lápis") });

        [TestMethod]
        public void Dado_um_novo_pedido_o_mesmo_deve_ser_criado()
        {
            Assert.IsInstanceOfType(_validOrder.Id, typeof(Guid));
            Assert.AreEqual(EnumOrderStatus.AguardandoPagamento, _validOrder.Status);
            Assert.AreEqual("12345678909", _validOrder.Seller.Cpf);
            Assert.AreEqual("Seller Name", _validOrder.Seller.Name);
            Assert.AreEqual("seller.name@email.com", _validOrder.Seller.Email);
            Assert.AreEqual("+55(11)11234-5678", _validOrder.Seller.Phone);
            Assert.AreEqual("System.Guid", _validOrder.Id.GetType().ToString());
        }
    }
}
