namespace Orders.Domain.Entities
{
    public class Seller : Entity
    {
        public string Cpf { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        public Seller(string cpf, string name, string email, string phone)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Phone = phone;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public void UpdatePhone(string phone)
        {
            Phone = phone;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateCpf(string cpf)
        {
            Cpf = cpf;
        }
    }
}
