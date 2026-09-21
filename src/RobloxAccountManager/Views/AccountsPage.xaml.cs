using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RobloxAccountManager.Models;
using RobloxAccountManager.ViewModels;
namespace RobloxAccountManager.Views;
public sealed partial class AccountsPage : Page
{
    private MainViewModel ViewModel => (MainViewModel)DataContext;
    public AccountsPage() { InitializeComponent(); }
    protected override void OnNavigatedTo(Microsoft.UI.Xaml.Navigation.NavigationEventArgs e) { DataContext = e.Parameter; }
    private async void Launch_Click(object sender, RoutedEventArgs e) => await ViewModel.LaunchCommand.ExecuteAsync((sender as Button)?.Tag as RobloxAccount);
}
