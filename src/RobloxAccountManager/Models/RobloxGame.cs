namespace RobloxAccountManager.Models;

public sealed class RobloxGame
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public long PlaceId { get; init; }
    public string Name { get; set; } = string.Empty;
    public string? ThumbnailUrl { get; set; }
    public bool IsFavorite { get; set; }
    public DateTimeOffset? LastPlayedAt { get; set; }
}
