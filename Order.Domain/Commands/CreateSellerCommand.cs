using Flunt.Notifications;
using Flunt.Validations;
using Orders.Domain.Commands.Contracts;

namespace Orders.Domain.Commands
{
    public class CreateSellerCommand : Notifiable, ICommand
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public CreateSellerCommand() { }

        public CreateSellerCommand(string cpf, string name, string email, string phone)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Phone = phone;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrWhiteSpace(Name, "Name", "Nome não pode vazio")
                    .IsNotNullOrEmpty(Name, "Name", "Nome não pode ser nulo")
                    .HasLen(Cpf, 11, "Cpf", "Cpf precisa ter 11 caracteres")
                    .IsEmailOrEmpty(Email, "Email", "Favor preencher um email válido")
            );
        }
    }
}
