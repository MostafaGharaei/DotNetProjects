using System;
using System.Threading.Tasks;

namespace MediatorDemo;

public sealed class SendNotificationHandler : IRequestHandler<SendNotificationCommand, bool>
{
    public Task<bool> Handle(SendNotificationCommand request)
    {
        Console.WriteLine($"📨 [Mediator] Sending to {request.Recipient}: {request.Message}");
        return Task.FromResult(true);
    }
}