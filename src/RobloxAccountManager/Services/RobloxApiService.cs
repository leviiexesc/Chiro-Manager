using System.Net.Http.Json;
using RobloxAccountManager.Models;

namespace RobloxAccountManager.Services;

public sealed class RobloxApiService
{
    private readonly HttpClient _httpClient = new() { BaseAddress = new Uri("https://users.roblox.com/") };

    public async Task<RobloxAccount?> FindAccountAsync(string username, CancellationToken cancellationToken = default)
    {
        using var response = await _httpClient.PostAsJsonAsync("v1/usernames/users", new { usernames = new[] { username }, excludeBannedUsers = false }, cancellationToken);
        if (!response.IsSuccessStatusCode) return null;
        var result = await response.Content.ReadFromJsonAsync<UserLookupResponse>(cancellationToken);
        var match = result?.Data?.FirstOrDefault();
        return match is null ? null : new RobloxAccount { UserId = match.Id, Username = match.Name, DisplayName = match.DisplayName };
    }

    private sealed record UserLookupResponse(List<UserLookup>? Data);
    private sealed record UserLookup(long Id, string Name, string DisplayName);
}
