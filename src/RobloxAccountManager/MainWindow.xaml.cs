using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Extensions.DependencyInjection;
using RobloxAccountManager.ViewModels;
using RobloxAccountManager.Views;

namespace RobloxAccountManager;

public sealed partial class MainWindow : Window
{
    private readonly MainViewModel _viewModel;

    public MainWindow()
    {
        InitializeComponent();
        _viewModel = App.Services.GetRequiredService<MainViewModel>();
        Navigation.SelectedItem = Navigation.MenuItems[0];
        _ = InitializeAsync();
    }

    private async Task InitializeAsync()
    {
        await _viewModel.LoadAsync();
        ContentFrame.Navigate(_viewModel.Accounts.Count == 0 ? typeof(WelcomePage) : typeof(DashboardPage), _viewModel);
    }

    private void Navigation_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.SelectedItem is not NavigationViewItem item || item.Tag is not string tag) return;
        var pageType = tag switch
        {
            "Dashboard" => typeof(DashboardPage), "Accounts" => typeof(AccountsPage), "MultiLaunch" => typeof(MultiLaunchPage),
            "Games" => typeof(GamesPage), "Servers" => typeof(ServersPage), "Activity" => typeof(ActivityPage),
            "Favorites" => typeof(FavoritesPage), "Settings" => typeof(SettingsPage), "About" => typeof(AboutPage), _ => typeof(DashboardPage)
        };
        ContentFrame.Navigate(pageType, _viewModel);
    }
}
