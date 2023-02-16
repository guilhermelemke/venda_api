using Flunt.Notifications;
using Flunt.Validations;
using Orders.Domain.Commands.Contracts;

namespace Orders.Domain.Commands
{
    public class ChangeOrderStatusToDeliveredCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }

        public ChangeOrderStatusToDeliveredCommand()
        {

        }

        public ChangeOrderStatusToDeliveredCommand(Guid id)
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
