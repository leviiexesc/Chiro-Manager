using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RobloxAccountManager.ViewModels;
namespace RobloxAccountManager.Views;
public sealed partial class WelcomePage : Page
{
    public WelcomePage() { InitializeComponent(); }
    protected override void OnNavigatedTo(Microsoft.UI.Xaml.Navigation.NavigationEventArgs e) { DataContext = e.Parameter; }
    private void GetStarted_Click(object sender, RoutedEventArgs e) => Frame?.Navigate(typeof(DashboardPage), DataContext);
}
