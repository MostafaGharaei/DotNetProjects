using MediatR;

namespace TaskManagement.Application.Common.Decorators
{
    // Decorator interface for logging or other cross-cutting concerns
    public interface IRequestHandlerDecorator<TRequest, TResponse>
        : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
    }
}
