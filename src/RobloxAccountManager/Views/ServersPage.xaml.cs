using Microsoft.UI.Xaml.Controls;
namespace RobloxAccountManager.Views;
public sealed partial class ServersPage : Page { public ServersPage() { InitializeComponent(); } protected override void OnNavigatedTo(Microsoft.UI.Xaml.Navigation.NavigationEventArgs e) { DataContext = e.Parameter; } }
