using Orders.Domain.Commands;
using Orders.Domain.Entities;
using Orders.Domain.Tests.Helpers;

namespace Orders.Domain.Tests.CommandTests
{
    [TestClass]
    [TestCategory("Commands")]
    public class ChangeOrderStatusToDeliveredCommandTests
    {
        [TestMethod]
        public void Dado_um_comando_valido()
        {
            var _validCommand = new ChangeOrderStatusToDeliveredCommand(CreateOrderHelper.ReturnOrderWaitingForPayment().Id);
            _validCommand.Validate();

            Assert.AreEqual(_validCommand.Valid, true);
        }

        [TestMethod]
        public void Dado_um_comando_valido_invalido()
        {
            var _invalidCommand = new ChangeOrderStatusToDeliveredCommand(Guid.Empty);
            _invalidCommand.Validate();

            Assert.AreEqual(_invalidCommand.Valid, false);
        }
    }
}
