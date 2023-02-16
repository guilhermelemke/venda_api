using Flunt.Notifications;
using Orders.Domain.Commands;
using Orders.Domain.Commands.Contracts;
using Orders.Domain.Entities;
using Orders.Domain.Handlers.Contracts;
using Orders.Domain.Repositories;

namespace Orders.Domain.Handlers
{
    public class ProductHandler :
        Notifiable,
        IHandler<CreateProductCommand>,
        IHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repository;

        public ProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateProductCommand command)
        {
            // Fail Validation First
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Parece que o cadastro de produto está incorreto!", command.Notifications);

            // Verifica se o produto já está cadastrado
            var productExist = _repository.GetByName(command.ProductName);

            if (productExist != null && productExist.ProductName == command.ProductName)
            {
                return new GenericCommandResult(false, $"Este produto já está cadastrado com ProductID {productExist.Id}!", command.Notifications);
            }

            // Cria o objeto do produto
            var product = new Product(command.ProductName);

            // Salva no banco
            _repository.Create(product);

            // Retorna o resultado
            return new GenericCommandResult(true, "Produto salvo", product);
        }

        public ICommandResult Handle(UpdateProductCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Não é possível atualizar o produto", command.Notifications);

            // Recupera o produto
            var product = _repository.GetById(command.Id);

            if (product == null)
            {
                return new GenericCommandResult(false, "Não é possível localizar nenhum produto com esse ProductId", command.Notifications);
            }

            // Altera o nome do produto
            product.UpdateProductName(command.ProductName);

            // Salva no banco
            _repository.Update(product);

            // Retorna o resultado
            return new GenericCommandResult(true, "Nome do produto atualizado", product);
        }
    }
}
