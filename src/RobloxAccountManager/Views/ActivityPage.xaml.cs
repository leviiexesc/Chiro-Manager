using Microsoft.UI.Xaml.Controls;
namespace RobloxAccountManager.Views;
public sealed partial class ActivityPage : Page { public ActivityPage() { InitializeComponent(); } protected override void OnNavigatedTo(Microsoft.UI.Xaml.Navigation.NavigationEventArgs e) { DataContext = e.Parameter; } }
