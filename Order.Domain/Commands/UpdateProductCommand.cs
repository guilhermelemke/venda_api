using Flunt.Notifications;
using Flunt.Validations;
using Orders.Domain.Commands.Contracts;

namespace Orders.Domain.Commands
{
    public class UpdateProductCommand : Notifiable, ICommand
    {
        public string ProductName { get; set; }
        public Guid Id { get; set; }

        public UpdateProductCommand() { }

        public UpdateProductCommand(Guid id, string productName)
        {
            Id = id;
            ProductName = productName;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrWhiteSpace(ProductName, "ProductName", "Nome do produto não pode vazio")
                    .IsNotNullOrEmpty(ProductName, "ProductName", "Nome do produto não pode ser nulo")
                    .IsNotNullOrWhiteSpace(ProductName, "ProductName", "ProductId não pode ser vazio")
                    .IsNotNullOrEmpty(ProductName, "ProductName", "ProductId não pode ser nulo")
            );
        }
    }
}
