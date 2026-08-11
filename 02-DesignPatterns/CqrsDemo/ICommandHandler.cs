using System.Threading.Tasks;

namespace CqrsDemo;

public interface ICommandHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
{
    Task<TResponse> Handle(TCommand command);
}