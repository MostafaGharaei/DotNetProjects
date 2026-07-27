using System;

namespace RepositoryDemo;

/// <summary>
/// Customer entity
/// </summary>
public record Customer
{
    public int Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public string? Phone { get; init; }
    public DateTime CreatedDate { get; init; } = DateTime.UtcNow;
    public bool IsActive { get; init; } = true;

    public string FullName => $"{FirstName} {LastName}";

    public override string ToString()
        => $"[{Id}] {FullName} - {Email} ({(IsActive ? "🟢 Active" : "🔴 Inactive")})";
}