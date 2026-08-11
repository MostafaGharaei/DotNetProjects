namespace MediatorDemo;

public sealed record SendNotificationCommand(string Recipient, string Message) : IRequest<bool>;