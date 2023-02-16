using Orders.Domain.Commands.Contracts;

namespace Orders.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
