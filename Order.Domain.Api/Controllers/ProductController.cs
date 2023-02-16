using Microsoft.AspNetCore.Mvc;
using Orders.Domain.Commands;
using Orders.Domain.Entities;
using Orders.Domain.Handlers;
using Orders.Domain.Repositories;

namespace Orders.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/products")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProductController : ControllerBase
    {
        /// GET v1/products
        /// <summary>
        /// Retorna todos os produtos cadastrados
        /// </summary>
        /// <param name="repository">Nome do Produto</param>
        /// <returns>Produtos retornados</returns>
        /// <response code="200">Success</response>
        [Route("")]
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IEnumerable<Product> GetAll(
            [FromServices] IProductRepository repository)
        {
            return repository.GetAll();
        }

        /// GET v1/products/{productId}
        /// <summary>
        /// Retorna o produto cadastrado através do Id
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="productId">productId</param>
        /// <returns>Produto através do Id</returns>
        /// <response code="200">Success</response>
        [HttpGet("{productId}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public Product GetProductById(
            [FromServices] IProductRepository repository,
            Guid productId)
        {
            return repository.GetById(productId);
        }

        /// POST v1/products
        /// <summary>
        /// Cadastra um produto
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /products
        ///     {
        ///        "productName": "Caneta"
        ///     }
        ///
        /// </remarks>
        /// <returns>Um novo produto cadastrado</returns>
        /// <response code="201">Success</response>
        [Route("")]
        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public GenericCommandResult Create(
            [FromBody] CreateProductCommand command,
            [FromServices] ProductHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        /// PUT v1/products
        /// <summary>
        /// Altera um produto cadastrado
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     PUT /products
        ///     {
        ///        "productName": "Caneta",
        ///        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///     }
        ///
        /// </remarks>
        /// <returns>Produto alterado</returns>
        /// <response code="200">Success</response>
        [Route("")]
        [HttpPut]
        [ApiExplorerSettings(IgnoreApi = true)]
        public GenericCommandResult Update(
                [FromBody] UpdateProductCommand command,
                [FromServices] ProductHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
