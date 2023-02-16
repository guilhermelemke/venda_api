using Flunt.Notifications;
using Flunt.Validations;
using Orders.Domain.Commands.Contracts;
using Orders.Domain.Entities;

namespace Orders.Domain.Commands
{
    public class UpdateOrderCommand : Notifiable, ICommand
    {
        public DateTime OrderDate { get; private set; }
        public string Status { get; private set; }
        public Seller Seller { get; private set; }
        public virtual ICollection<Product> Products { get; private set; }
        public Guid Id { get; set; }

        public UpdateOrderCommand() { }

        public UpdateOrderCommand(DateTime orderDate, string status, Seller seller, ICollection<Product> products)
        {
            OrderDate = orderDate;
            Status = status;
            Seller = seller;
            Products = products;
        }

        public void Validate()
        {
            new Contract()
                .Requires()
                .IsNotNull(Products, "Products", "A lista de produtos não pode ser vazia")
                .Requires()
                .IsNotNull(Seller, "Seller", "É necessário passar um vendedor");
        }
    }
}
