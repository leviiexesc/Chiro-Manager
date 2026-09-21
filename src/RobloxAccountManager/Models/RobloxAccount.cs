namespace RobloxAccountManager.Models;

public sealed class RobloxAccount
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public long UserId { get; init; }
    public string Username { get; init; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
    public bool IsFavorite { get; set; }
    public DateTimeOffset? LastLaunchedAt { get; set; }
    public string DisplayLabel => string.IsNullOrWhiteSpace(DisplayName) ? Username : DisplayName;
}
