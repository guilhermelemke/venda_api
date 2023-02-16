using Flunt.Notifications;
using Orders.Domain.Commands;
using Orders.Domain.Commands.Contracts;
using Orders.Domain.Entities;
using Orders.Domain.Handlers.Contracts;
using Orders.Domain.Repositories;

namespace Orders.Domain.Handlers
{
    public class OrderHandler :
        Notifiable,
        IHandler<CreateOrderCommand>,
        IHandler<UpdateOrderCommand>,
        IHandler<ChangeOrderStatusToPaymentApprovedCommand>,
        IHandler<ChangeOrderStatusToCancelledCommand>,
        IHandler<ChangeOrderStatusToSentToShipmentCommand>,
        IHandler<ChangeOrderStatusToDeliveredCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderHandler(IOrderRepository repository)
        {
            _orderRepository = repository;
        }

        public ICommandResult Handle(CreateOrderCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Parece que sua venda está incorreta!", command.Notifications);

            var order = new Order(command.OrderDate, command.Seller, command.Products);

            _orderRepository.Create(order);

            return new GenericCommandResult(true, "Pedido salvo", order);
        }

        public ICommandResult Handle(UpdateOrderCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Parece que sua venda está incorreta!", command.Notifications);

            // Altera os dados do pedido
            var order = new Order(command.OrderDate, command.Seller, command.Products);

            // Salva no banco
            _orderRepository.Update(order);

            // Retorna o resultado
            return new GenericCommandResult(true, "Pedido salvo", order);
        }

        public ICommandResult Handle(ChangeOrderStatusToPaymentApprovedCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, atualização inválida!", command.Notifications);

            // Recupera o TodoItem
            var order = _orderRepository.GetById(command.Id);

            if (order == null)
            {
                return new GenericCommandResult(false, "Pedido não pôde ser localizado!", command.Notifications);
            }

            if (order.Status == EnumOrderStatus.AguardandoPagamento)
            {
                // Altera o estado
                order.ChangeOrderStatusPayed();

                // Salva no banco
                _orderRepository.Update(order);

                // Retorna o resultado
                return new GenericCommandResult(true, $"Status do pedido alterado para {order.Status}", order);
            }
            else
            {
                return new GenericCommandResult(false, $"Pedido com status {order.Status} não pode ser alterado para o status {EnumOrderStatus.PagamentoAprovado}!", command.Notifications);
            }
        }

        public ICommandResult Handle(ChangeOrderStatusToCancelledCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, atualização inválida!", command.Notifications);

            // Recupera o Pedido
            var order = _orderRepository.GetById(command.Id);

            if (order == null)
            {
                return new GenericCommandResult(false, "Pedido não pôde ser localizado!", command.Notifications);
            }

            if (order.Status == EnumOrderStatus.AguardandoPagamento ||
                order.Status == EnumOrderStatus.PagamentoAprovado)
            {
                // Altera o estado
                order.ChangeOrderStatusCancelled();

                // Salva no banco
                _orderRepository.Update(order);

                // Retorna o resultado
                return new GenericCommandResult(true, $"Status do pedido alterado para {order.Status}", order);
            }
            else
            {
                return new GenericCommandResult(false, $"Pedido com status {order.Status} não pode ser alterado para o status {EnumOrderStatus.Cancelada}!", command.Notifications);
            }
        }

        public ICommandResult Handle(ChangeOrderStatusToSentToShipmentCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, atualização inválida!", command.Notifications);

            // Recupera o TodoItem
            var order = _orderRepository.GetById(command.Id);

            if (order == null)
            {
                return new GenericCommandResult(false, "Pedido não pôde ser localizado!", command.Notifications);
            }

            if (order.Status == EnumOrderStatus.PagamentoAprovado)
            {
                // Altera o estado
                order.ChangeOrderStatusSentToShipment();

                // Salva no banco
                _orderRepository.Update(order);

                // Retorna o resultado
                return new GenericCommandResult(true, $"Status do pedido alterado para {order.Status}", order);
            }
            else
            {
                return new GenericCommandResult(false, $"Pedido com status {order.Status} não pode ser alterado para o status {EnumOrderStatus.EnviadoParaTransportadora}!", command.Notifications);
            }
        }

        public ICommandResult Handle(ChangeOrderStatusToDeliveredCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, atualização inválida!", command.Notifications);

            // Recupera o TodoItem
            var order = _orderRepository.GetById(command.Id);

            if (order == null)
            {
                return new GenericCommandResult(false, "Pedido não pôde ser localizado!", command.Notifications);
            }

            if (order.Status == EnumOrderStatus.EnviadoParaTransportadora)
            {
                // Altera o estado
                order.ChangeOrderStatusDelivered();

                // Salva no banco
                _orderRepository.Update(order);

                // Retorna o resultado
                return new GenericCommandResult(true, $"Status do pedido alterado para {order.Status}", order);
            }
            else
            {
                return new GenericCommandResult(false, $"Pedido com status {order.Status} não pode ser alterado para o status {EnumOrderStatus.Entregue}!", command.Notifications);
            }
        }
    }
}
