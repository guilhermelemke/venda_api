using Microsoft.AspNetCore.Mvc;
using Orders.Domain.Commands;
using Orders.Domain.Entities;
using Orders.Domain.Handlers;
using Orders.Domain.Repositories;

namespace Orders.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/orders")]
    public class OrderController : ControllerBase
    {
        /// GET v1/orders
        /// <summary>
        /// Retorna todos os pedidos cadastrados
        /// </summary>
        /// <param name="repository">Pedido</param>
        /// <returns>Pedidos retornados</returns>
        /// <response code="200">Success</response>
        [Route("")]
        [HttpGet]
        public IEnumerable<Order> GetAll(
            [FromServices] IOrderRepository repository)
        {
            return repository.GetAll();
        }

        /// GET v1/orders/{orderId}
        /// <summary>
        /// Retorna o pedido cadastrado através do Id
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="orderId">orderId</param>
        /// <returns>Pedido através do Id</returns>
        /// <response code="200">Success</response>
        [HttpGet("{orderId}")]
        public Order GetOrderById(
            [FromServices] IOrderRepository repository,
            Guid orderId)
        {
            return repository.GetById(orderId);
        }

        /// POST v1/products
        /// <summary>
        /// Cadastra um pedido
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     {
        ///       "orderDate": "2023-01-28T15:38:00.818Z",
        ///       "seller": {
        ///         "cpf": "12345678909",
        ///         "name": "Test Name",
        ///         "email": "testname@email.com",
        ///         "phone": "+55(11)11111-2222"
        ///       },
        ///       "products": [
        ///         {
        ///           "productName": "Apontador"
        ///         },
        ///         {
        ///           "productName": "Pincel"
        ///         },
        ///         {
        ///           "productName": "Caderno"
        ///         }
        ///       ]
        ///     }
        ///
        /// </remarks>
        /// <returns>Um novo pedido cadastrado</returns>
        /// <response code="201">Success</response>
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
                    [FromBody] CreateOrderCommand command,
                    [FromServices] OrderHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        /// PUT v1/orders
        /// <summary>
        /// Altera um pedido
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     {
        ///       "orderDate": "2023-01-28T15:38:00.818Z",
        ///       "seller": {
        ///         "cpf": "12345678909",
        ///         "name": "Test Name",
        ///         "email": "testname@email.com",
        ///         "phone": "+55(11)11111-2222"
        ///       },
        ///       "products": [
        ///         {
        ///           "productName": "Apontador"
        ///         },
        ///         {
        ///           "productName": "Pincel"
        ///         },
        ///         {
        ///           "productName": "Caderno"
        ///         }
        ///       ]
        ///     }
        ///
        /// </remarks>
        /// <returns>Um pedido alterado</returns>
        /// <response code="200">Success</response>
        [Route("")]
        [HttpPut]
        [ApiExplorerSettings(IgnoreApi = true)]
        public GenericCommandResult Update(
            [FromBody] UpdateOrderCommand command,
            [FromServices] OrderHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        /// PUT v1/orders
        /// <summary>
        /// Altera o status do pedido para Pagamento Efetuado
        /// </summary>
        /// <remarks>
        /// Apenas para pedidos com status: "Aguardando pagamento"
        /// Exemplo:
        ///
        ///     {
        ///       "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///     }
        ///
        /// </remarks>
        /// <returns>Status do pedido alterado para pagamento efetuado</returns>
        /// <response code="200">Success</response>
        [Route("payment-approved")]
        [HttpPut]
        public GenericCommandResult MarkAsPayed(
                [FromBody] ChangeOrderStatusToPaymentApprovedCommand command,
                [FromServices] OrderHandler handler
            )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        /// PUT v1/orders
        /// <summary>
        /// Altera o status do pedido para Pedido Cancelado
        /// </summary>
        /// <remarks>
        /// Apenas para pedidos com status: "Aguardando pagamento" ou "Pagamento aprovado"
        /// Exemplo:
        ///
        ///     {
        ///       "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///     }
        ///
        /// </remarks>
        /// <returns>Status do pedido alterado para cancelado</returns>
        /// <response code="200">Success</response>
        [Route("canceled")]
        [HttpPut]
        public GenericCommandResult MarkAsCancelled(
            [FromBody] ChangeOrderStatusToCancelledCommand command,
            [FromServices] OrderHandler handler
)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        /// PUT v1/orders
        /// <summary>
        /// Altera o status do pedido para Pedido Despachado
        /// </summary>
        /// <remarks>
        /// Apenas para pedidos com status: "Pagamento aprovado"
        /// Exemplo:
        ///
        ///     {
        ///       "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///     }
        ///
        /// </remarks>
        /// <returns>Status do pedido alterado para pedido despachado</returns>
        /// <response code="200">Success</response>
        [Route("shipped")]
        [HttpPut]
        public GenericCommandResult MarkAsShipped(
            [FromBody] ChangeOrderStatusToSentToShipmentCommand command,
            [FromServices] OrderHandler handler
)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        /// PUT v1/orders
        /// <summary>
        /// Altera o status do pedido para Pedido Entregue
        /// </summary>
        /// <remarks>
        /// Apenas para pedidos com status: "Enviado para Transportador"
        /// Exemplo:
        ///
        ///     {
        ///       "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///     }
        ///
        /// </remarks>
        /// <returns>Status do pedido alterado para pedido entregue</returns>
        /// <response code="200">Success</response>
        [Route("delivered")]
        [HttpPut]
        public GenericCommandResult MarkAsDelivered(
            [FromBody] ChangeOrderStatusToDeliveredCommand command,
            [FromServices] OrderHandler handler
)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
