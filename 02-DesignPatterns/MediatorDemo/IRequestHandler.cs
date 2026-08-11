using System.Threading.Tasks;

namespace MediatorDemo;

/// <summary>
/// Handler interface for processing requests
/// </summary>
public interface IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request);
}