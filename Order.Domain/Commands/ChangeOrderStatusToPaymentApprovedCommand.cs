using Flunt.Notifications;
using Flunt.Validations;
using Orders.Domain.Commands.Contracts;

namespace Orders.Domain.Commands
{
    public class ChangeOrderStatusToPaymentApprovedCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }

        public ChangeOrderStatusToPaymentApprovedCommand()
        {
        }

        public ChangeOrderStatusToPaymentApprovedCommand(Guid id)
        {
            Id = id;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id, "Id", "Id é campo obrigatório"));
        }
    }
}
