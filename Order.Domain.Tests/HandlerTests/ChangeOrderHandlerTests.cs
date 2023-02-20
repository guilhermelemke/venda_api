using Orders.Domain.Commands;
using Orders.Domain.Handlers;
using Orders.Domain.Tests.Helpers;
using Orders.Domain.Tests.Repositories;

namespace Orders.Domain.Tests.HandlerTests
{
    [TestClass]
    [TestCategory("Handlers")]
    public class ChangeOrderHandlerTests
    {
        private ChangeOrderStatusToCancelledCommand _commandCancel;
        private ChangeOrderStatusToDeliveredCommand _commandDelivered;
        private ChangeOrderStatusToPaymentApprovedCommand _commandPayed;
        private ChangeOrderStatusToSentToShipmentCommand _commandShipped;
        private readonly OrderHandler _handlerCancelled = new OrderHandler(new FakeOrderRepositoryCancelled());
        private readonly OrderHandler _handlerDelivered = new OrderHandler(new FakeOrderRepositoryDelivered());
        private readonly OrderHandler _handlerPayed = new OrderHandler(new FakeOrderRepositoryPayed());
        private readonly OrderHandler _handlerShipped = new OrderHandler(new FakeOrderRepositoryShipped());
        private readonly OrderHandler _handlerWaitingPayment = new OrderHandler(new FakeOrderRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        #region Cancelar
        [TestMethod]
        public void Dado_um_pedido_aguardando_pagamento_deve_cancelar()
        {
            _commandCancel = new ChangeOrderStatusToCancelledCommand(CreateOrderHelper.ReturnOrderWaitingForPayment().Id);
            _result = (GenericCommandResult)_handlerWaitingPayment.Handle(_commandCancel);

            Assert.AreEqual(true, _result.Success);
        }

        [TestMethod]
        public void Dado_um_pedido_pagamento_aprovado_deve_cancelar()
        {
            _commandCancel = new ChangeOrderStatusToCancelledCommand(CreateOrderHelper.ReturnOrderPaymentApproved().Id);
            _result = (GenericCommandResult)_handlerPayed.Handle(_commandCancel);

            Assert.AreEqual(true, _result.Success);
        }

        [TestMethod]
        public void Dado_um_pedido_cancelado_nao_deve_cancelar()
        {
            _commandCancel = new ChangeOrderStatusToCancelledCommand(CreateOrderHelper.ReturnOrderCancelled().Id);
            _result = (GenericCommandResult)_handlerCancelled.Handle(_commandCancel);

            Assert.AreEqual(false, _result.Success);
        }

        [TestMethod]
        public void Dado_um_pedido_enviado_nao_deve_cancelar()
        {
            _commandCancel = new ChangeOrderStatusToCancelledCommand(CreateOrderHelper.ReturnOrderShipped().Id);
            _result = (GenericCommandResult)_handlerShipped.Handle(_commandCancel);

            Assert.AreEqual(false, _result.Success);
        }

        [TestMethod]
        public void Dado_um_pedido_entregue_nao_deve_cancelar()
        {
            _commandCancel = new ChangeOrderStatusToCancelledCommand(CreateOrderHelper.ReturnOrderCancelled().Id);
            _result = (GenericCommandResult)_handlerDelivered.Handle(_commandCancel);

            Assert.AreEqual(false, _result.Success);
        }
        #endregion

        #region Aprovar Pagamento
        [TestMethod]
        public void Dado_um_pedido_aguardando_pagamento_deve_aprovar_pagamento()
        {
            _commandPayed = new ChangeOrderStatusToPaymentApprovedCommand(CreateOrderHelper.ReturnOrderWaitingForPayment().Id);
            _result = (GenericCommandResult)_handlerWaitingPayment.Handle(_commandPayed);

            Assert.AreEqual(true, _result.Success);
        }

        [TestMethod]
        public void Dado_um_pedido_pagamento_aprovado_nao_deve_aprovar_pagamento()
        {
            _commandPayed = new ChangeOrderStatusToPaymentApprovedCommand(CreateOrderHelper.ReturnOrderPaymentApproved().Id);
            _result = (GenericCommandResult)_handlerPayed.Handle(_commandPayed);

            Assert.AreEqual(false, _result.Success);
        }

        [TestMethod]
        public void Dado_um_pedido_cancelado_nao_deve_aprovar_pagamento()
        {
            _commandPayed = new ChangeOrderStatusToPaymentApprovedCommand(CreateOrderHelper.ReturnOrderCancelled().Id);
            _result = (GenericCommandResult)_handlerCancelled.Handle(_commandPayed);

            Assert.AreEqual(false, _result.Success);
        }

        [TestMethod]
        public void Dado_um_pedido_enviado_nao_deve_aprovar_pagamento()
        {
            _commandPayed = new ChangeOrderStatusToPaymentApprovedCommand(CreateOrderHelper.ReturnOrderShipped().Id);
            _result = (GenericCommandResult)_handlerShipped.Handle(_commandPayed);

            Assert.AreEqual(false, _result.Success);
        }

        [TestMethod]
        public void Dado_um_pedido_entregue_nao_deve_aprovar_pagamento()
        {
            _commandPayed = new ChangeOrderStatusToPaymentApprovedCommand(CreateOrderHelper.ReturnOrderCancelled().Id);
            _result = (GenericCommandResult)_handlerDelivered.Handle(_commandPayed);

            Assert.AreEqual(false, _result.Success);
        }
        #endregion

        #region Enviado para Transportador
        [TestMethod]
        public void Dado_um_pedido_aguardando_pagamento_deve_enviar_para_transportador()
        {
            _commandShipped = new ChangeOrderStatusToSentToShipmentCommand(CreateOrderHelper.ReturnOrderWaitingForPayment().Id);
            _result = (GenericCommandResult)_handlerWaitingPayment.Handle(_commandShipped);

            Assert.AreEqual(false, _result.Success);
        }

        [TestMethod]
        public void Dado_um_pedido_pagamento_aprovado_deve_enviar_para_transportador()
        {
            _commandShipped = new ChangeOrderStatusToSentToShipmentCommand(CreateOrderHelper.ReturnOrderPaymentApproved().Id);
            _result = (GenericCommandResult)_handlerPayed.Handle(_commandShipped);

            Assert.AreEqual(true, _result.Success);
        }

        [TestMethod]
        public void Dado_um_pedido_cancelado_nao_deve_enviar_para_transportador()
        {
            _commandShipped = new ChangeOrderStatusToSentToShipmentCommand(CreateOrderHelper.ReturnOrderCancelled().Id);
            _result = (GenericCommandResult)_handlerCancelled.Handle(_commandShipped);

            Assert.AreEqual(false, _result.Success);
        }

        [TestMethod]
        public void Dado_um_pedido_enviado_nao_deve_enviar_para_transportador()
        {
            _commandShipped = new ChangeOrderStatusToSentToShipmentCommand(CreateOrderHelper.ReturnOrderShipped().Id);
            _result = (GenericCommandResult)_handlerShipped.Handle(_commandShipped);

            Assert.AreEqual(false, _result.Success);
        }

        [TestMethod]
        public void Dado_um_pedido_entregue_nao_deve_enviar_para_transportador()
        {
            _commandShipped = new ChangeOrderStatusToSentToShipmentCommand(CreateOrderHelper.ReturnOrderCancelled().Id);
            _result = (GenericCommandResult)_handlerDelivered.Handle(_commandShipped);

            Assert.AreEqual(false, _result.Success);
        }
        #endregion

        #region Entregue
        [TestMethod]
        public void Dado_um_pedido_aguardando_pagamento_deve_alterar_para_entregue()
        {
            _commandDelivered = new ChangeOrderStatusToDeliveredCommand(CreateOrderHelper.ReturnOrderWaitingForPayment().Id);
            _result = (GenericCommandResult)_handlerWaitingPayment.Handle(_commandDelivered);

            Assert.AreEqual(false, _result.Success);
        }

        [TestMethod]
        public void Dado_um_pedido_pagamento_aprovado_nao_deve_alterar_para_entregue()
        {
            _commandDelivered = new ChangeOrderStatusToDeliveredCommand(CreateOrderHelper.ReturnOrderPaymentApproved().Id);
            _result = (GenericCommandResult)_handlerPayed.Handle(_commandDelivered);

            Assert.AreEqual(false, _result.Success);
        }

        [TestMethod]
        public void Dado_um_pedido_cancelado_nao_deve_alterar_para_entregue()
        {
            _commandDelivered = new ChangeOrderStatusToDeliveredCommand(CreateOrderHelper.ReturnOrderCancelled().Id);
            _result = (GenericCommandResult)_handlerCancelled.Handle(_commandDelivered);

            Assert.AreEqual(false, _result.Success);
        }

        [TestMethod]
        public void Dado_um_pedido_enviado_deve_alterar_para_entregue()
        {
            _commandDelivered = new ChangeOrderStatusToDeliveredCommand(CreateOrderHelper.ReturnOrderShipped().Id);
            _result = (GenericCommandResult)_handlerShipped.Handle(_commandDelivered);

            Assert.AreEqual(true, _result.Success);
        }

        [TestMethod]
        public void Dado_um_pedido_entregue_nao_deve_alterar_para_entregue()
        {
            _commandDelivered = new ChangeOrderStatusToDeliveredCommand(CreateOrderHelper.ReturnOrderCancelled().Id);
            _result = (GenericCommandResult)_handlerDelivered.Handle(_commandDelivered);

            Assert.AreEqual(false, _result.Success);
        }
        #endregion
    }
}
