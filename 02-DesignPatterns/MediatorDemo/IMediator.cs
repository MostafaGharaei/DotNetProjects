using System.Threading.Tasks;

namespace MediatorDemo;

/// <summary>
/// Mediator interface for decoupling senders and handlers
/// </summary>
public interface IMediator
{
    Task<TResponse> Send<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>;
}