using System.Text.Json;
using RobloxAccountManager.Models;

namespace RobloxAccountManager.Services;

public sealed class LocalDataService
{
    private readonly string _dataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RobloxAccountManager");
    private readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web) { WriteIndented = true };

    public async Task<IReadOnlyList<RobloxAccount>> LoadAccountsAsync(CancellationToken cancellationToken = default)
    {
        var path = Path.Combine(_dataDirectory, "accounts.json");
        if (!File.Exists(path)) return [];
        await using var stream = File.OpenRead(path);
        return await JsonSerializer.DeserializeAsync<List<RobloxAccount>>(stream, _jsonOptions, cancellationToken) ?? [];
    }

    public async Task SaveAccountsAsync(IEnumerable<RobloxAccount> accounts, CancellationToken cancellationToken = default)
    {
        Directory.CreateDirectory(_dataDirectory);
        var path = Path.Combine(_dataDirectory, "accounts.json");
        await using var stream = File.Create(path);
        await JsonSerializer.SerializeAsync(stream, accounts, _jsonOptions, cancellationToken);
    }
}
