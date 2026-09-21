using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RobloxAccountManager.Models;
using RobloxAccountManager.ViewModels;

namespace RobloxAccountManager.Views;

public sealed partial class DashboardPage : Page
{
    private MainViewModel ViewModel => (MainViewModel)DataContext;
    public DashboardPage() { InitializeComponent(); }
    protected override void OnNavigatedTo(Microsoft.UI.Xaml.Navigation.NavigationEventArgs e) { DataContext = e.Parameter; }
    private async void LaunchAccount_Click(object sender, RoutedEventArgs e) => await ViewModel.LaunchCommand.ExecuteAsync((sender as Button)?.Tag as RobloxAccount);
    private async void AddAccount_Click(object sender, RoutedEventArgs e) => await ViewModel.AddAccountCommand.ExecuteAsync("builderman");
    private void Launch_Click(object sender, RoutedEventArgs e) { }
    private void MultiLaunch_Click(object sender, RoutedEventArgs e) { }
}
