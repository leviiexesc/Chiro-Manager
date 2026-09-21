namespace RobloxAccountManager.Models;

public sealed class ActivityEntry
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTimeOffset OccurredAt { get; init; } = DateTimeOffset.Now;
    public string Message { get; init; } = string.Empty;
    public string? AccountName { get; init; }
}
