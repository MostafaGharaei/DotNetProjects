using MediatR;
using Microsoft.Extensions.Logging;

namespace TaskManagement.Application.Common.Decorators
{
    // Logs every request before and after execution
    public class LoggingDecorator<TRequest, TResponse>
        : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> _inner;
        private readonly ILogger<LoggingDecorator<TRequest, TResponse>> _logger;

        public LoggingDecorator(
            IRequestHandler<TRequest, TResponse> inner,
            ILogger<LoggingDecorator<TRequest, TResponse>> logger)
        {
            _inner = inner;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken ct)
        {
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");

            var response = await _inner.Handle(request, ct);

            _logger.LogInformation($"Handled {typeof(TRequest).Name}");

            return response;
        }
    }
}
