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
            Assert.AreEqual(_validOrder.Status, EnumOrderStatus.AguardandoPagamento);
            Assert.AreEqual(_validOrder.Seller.Cpf, "12345678909");
            Assert.AreEqual(_validOrder.Seller.Name, "Seller Name");
            Assert.AreEqual(_validOrder.Seller.Email, "seller.name@email.com");
            Assert.AreEqual(_validOrder.Seller.Phone, "+55(11)11234-5678");
            Assert.AreEqual(_validOrder.Id.GetType().ToString(), "System.Guid");
        }
    }
}
