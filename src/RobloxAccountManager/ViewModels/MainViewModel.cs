using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using RobloxAccountManager.Models;
using RobloxAccountManager.Services;

namespace RobloxAccountManager.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly LocalDataService _localData;
    private readonly RobloxApiService _api;
    private readonly LaunchService _launcher;

    public ObservableCollection<RobloxAccount> Accounts { get; } = [];
    public ObservableCollection<ActivityEntry> Activity { get; } = [];

    [ObservableProperty] private bool isLoading;
    [ObservableProperty] private string? errorMessage;
    [ObservableProperty] private string searchText = string.Empty;
    [ObservableProperty] private string selectedPage = "Dashboard";

    public int FavoriteCount => Accounts.Count(account => account.IsFavorite);
    public int ActiveCount => Accounts.Count(account => account.LastLaunchedAt is not null && account.LastLaunchedAt > DateTimeOffset.Now.AddMinutes(-30));

    public MainViewModel(LocalDataService localData, RobloxApiService api, LaunchService launcher)
    {
        _localData = localData;
        _api = api;
        _launcher = launcher;
    }

    [RelayCommand]
    public async Task LoadAsync(CancellationToken cancellationToken = default)
    {
        IsLoading = true;
        ErrorMessage = null;
        try
        {
            Accounts.Clear();
            foreach (var account in await _localData.LoadAccountsAsync(cancellationToken)) Accounts.Add(account);
            OnPropertyChanged(nameof(FavoriteCount));
            OnPropertyChanged(nameof(ActiveCount));
        }
        catch (Exception)
        {
            ErrorMessage = "Unable to load local account data.";
        }
        finally { IsLoading = false; }
    }

    [RelayCommand]
    public async Task AddAccountAsync(string username)
    {
        if (string.IsNullOrWhiteSpace(username)) return;
        IsLoading = true;
        ErrorMessage = null;
        try
        {
            var account = await _api.FindAccountAsync(username.Trim());
            if (account is null) { ErrorMessage = "That username could not be found."; return; }
            Accounts.Add(account);
            Activity.Insert(0, new ActivityEntry { Message = $"Added {account.DisplayLabel}", AccountName = account.Username });
            await _localData.SaveAccountsAsync(Accounts);
            OnPropertyChanged(nameof(FavoriteCount));
        }
        catch (HttpRequestException) { ErrorMessage = "Roblox could not be reached. Check your connection and retry."; }
        finally { IsLoading = false; }
    }

    [RelayCommand]
    public async Task LaunchAsync(RobloxAccount? account)
    {
        if (account is null) return;
        try
        {
            await _launcher.LaunchAsync(account);
            account.LastLaunchedAt = DateTimeOffset.Now;
            Activity.Insert(0, new ActivityEntry { Message = $"{account.DisplayLabel} opened Roblox", AccountName = account.Username });
            await _localData.SaveAccountsAsync(Accounts);
            OnPropertyChanged(nameof(ActiveCount));
        }
        catch (Exception) { ErrorMessage = "Roblox could not be opened."; }
    }

    [RelayCommand]
    public void ToggleFavorite(RobloxAccount? account)
    {
        if (account is null) return;
        account.IsFavorite = !account.IsFavorite;
        OnPropertyChanged(nameof(FavoriteCount));
        _ = _localData.SaveAccountsAsync(Accounts);
    }
}
