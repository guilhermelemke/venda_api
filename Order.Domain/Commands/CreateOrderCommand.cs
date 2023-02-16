using Flunt.Notifications;
using Flunt.Validations;
using Orders.Domain.Commands.Contracts;
using Orders.Domain.Entities;

namespace Orders.Domain.Commands
{
    public class CreateOrderCommand : Notifiable, ICommand
    {
        public DateTime OrderDate { get; private set; }
        public Seller Seller { get; private set; }
        public virtual ICollection<Product> Products { get; private set; }

        public CreateOrderCommand(DateTime orderDate, Seller seller, ICollection<Product> products)
        {
            OrderDate = orderDate;
            Seller = seller;
            Products = products;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(Products.Count, 0, "Products", "At least one product is required")
                    .IsNotNull(Seller, "Seller", "Vendedor não pode ser nulo")
            );
        }
    }
}
