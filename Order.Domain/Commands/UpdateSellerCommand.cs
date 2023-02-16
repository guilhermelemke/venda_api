using Flunt.Notifications;
using Flunt.Validations;
using Orders.Domain.Commands.Contracts;

namespace Orders.Domain.Commands
{
    public class UpdateSellerCommand : Notifiable, ICommand
    {
        public string Cpf { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public Guid Id { get; set; }

        public UpdateSellerCommand(string cpf, string name, string email, string phone)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Phone = phone;
        }

        public void Validate()
        {
            new Contract()
                .Requires()
                .HasLen(Cpf, 11, "Cpf", "Cpf precisa ter 11 caracteres")
                .Requires()
                .IsEmail(Email, "Email", "Email informado não é válido");
        }
    }
}
