using System.Diagnostics;
using RobloxAccountManager.Models;

namespace RobloxAccountManager.Services;

public sealed class LaunchService
{
    public Task<bool> LaunchAsync(RobloxAccount account, RobloxGame? game = null, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var url = game is null ? "https://www.roblox.com/home" : $"https://www.roblox.com/games/{game.PlaceId}";
        Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
        return Task.FromResult(true);
    }
}
