using Microsoft.AspNetCore.Mvc;
using Orders.Domain.Commands;
using Orders.Domain.Entities;
using Orders.Domain.Handlers;
using Orders.Domain.Repositories;

namespace Orders.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/sellers")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SellerController
    {
        /// GET v1/sellers
        /// <summary>
        /// Retorna todos os vendedores cadastrados
        /// </summary>
        /// <param name="repository"></param>
        /// <returns>Vendedores retornados</returns>
        /// <response code="200">Success</response>
        [Route("")]
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IEnumerable<Seller> GetAll(
            [FromServices] ISellerRepository repository)
        {
            return repository.GetAll();
        }

        /// GET v1/sellers/{sellerId}
        /// <summary>
        /// Retorna o vendedor cadastrado através do Id
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="sellerId">sellerId</param>
        /// <returns>Vendedor através do Id</returns>
        /// <response code="200">Success</response>
        [HttpGet("{sellerId}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public Seller GetSellerById(
            [FromServices] ISellerRepository repository,
            Guid sellerId)
        {
            return repository.GetById(sellerId);
        }

        /// POST v1/sellers
        /// <summary>
        /// Cadastra um vendedor
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /sellers
        ///     {
        ///         "cpf": "string",
        ///         "name": "string",
        ///         "email": "string",
        ///         "phone": "string"
        ///     }
        ///
        /// </remarks>
        /// <returns>Um novo vendedor cadastrado</returns>
        /// <response code="201">Success</response>
        [Route("")]
        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public GenericCommandResult Create(
                [FromBody] CreateSellerCommand command,
                [FromServices] SellerHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        /// PUT v1/sellers
        /// <summary>
        /// Altera um produto cadastrado
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     {
        ///       "cpf": "string",
        ///       "name": "string",
        ///       "email": "string",
        ///       "phone": "string",
        ///       "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///     }
        ///
        /// </remarks>
        /// <returns>Cadastrado do vendedor alterado</returns>
        /// <response code="200">Success</response>
        [Route("")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        public GenericCommandResult Update(
                [FromBody] UpdateSellerCommand command,
                [FromServices] SellerHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
