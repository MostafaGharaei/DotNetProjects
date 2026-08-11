using System;
using System.Threading.Tasks;

namespace MediatorDemo;

/// <summary>
/// Simple in-memory mediator implementation
/// </summary>
public sealed class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResponse> Send<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
    {
        var handlerType = typeof(IRequestHandler<TRequest, TResponse>);
        var handler = _serviceProvider.GetService(handlerType) as IRequestHandler<TRequest, TResponse>
            ?? throw new InvalidOperationException($"Handler for {typeof(TRequest).Name} not found.");

        return await handler.Handle(request);
    }
}