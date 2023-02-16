using Flunt.Notifications;
using Orders.Domain.Commands;
using Orders.Domain.Commands.Contracts;
using Orders.Domain.Entities;
using Orders.Domain.Handlers.Contracts;
using Orders.Domain.Repositories;

namespace Orders.Domain.Handlers
{
    public class SellerHandler :
        Notifiable,
        IHandler<CreateSellerCommand>,
        IHandler<UpdateSellerCommand>
    {
        private readonly ISellerRepository _repository;

        public SellerHandler(ISellerRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateSellerCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Não foi possível criar o vendedor", command.Notifications);

            var sellerExists = _repository.GetByCpf(command.Cpf);

            if (sellerExists != null)
            {
                return new GenericCommandResult(false, $"Já existe um vendedor com este CPF cadastrado com o SellerId {sellerExists.Id}", command.Notifications);
            }

            // Cria objeto vendedor
            var seller = new Seller(command.Cpf, command.Name, command.Email, command.Phone);

            // Cria o vendedor
            _repository.Create(seller);

            // Retorna o resultado
            return new GenericCommandResult(true, "Vendedor salvo", seller);
        }

        public ICommandResult Handle(UpdateSellerCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Não é possível atualizar o vendedor", command.Notifications);

            // Recupera o produto
            var seller = _repository.GetById(command.Id);

            // Altera os dados do vendedor
            seller.UpdatePhone(command.Phone);
            seller.UpdateEmail(command.Email);
            seller.UpdateCpf(command.Cpf);
            seller.UpdateName(command.Name);

            // Salva no banco
            _repository.Update(seller);

            // Retorna o resultado
            return new GenericCommandResult(true, "Dados do vendedor atualizados", seller);
        }
    }
}
