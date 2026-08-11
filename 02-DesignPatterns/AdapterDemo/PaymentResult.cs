namespace AdapterDemo;

public sealed record PaymentResult(string TransactionId, bool IsSuccess, string Message);