using Flunt.Notifications;
using Flunt.Validations;
using Orders.Domain.Commands.Contracts;

namespace Orders.Domain.Commands
{
    public class CreateProductCommand : Notifiable, ICommand
    {
        public string ProductName { get; set; }

        public CreateProductCommand() { }

        public CreateProductCommand(string productName)
        {
            ProductName = productName;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrWhiteSpace(ProductName, "ProductName", "Nome do produto não pode vazio")
                    .IsNotNullOrEmpty(ProductName, "ProductName", "Nome do produto não pode ser nulo")
            );
        }
    }
}
