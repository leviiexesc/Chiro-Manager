using Microsoft.UI.Xaml.Controls;
namespace RobloxAccountManager.Views;
public sealed partial class FavoritesPage : Page { public FavoritesPage() { InitializeComponent(); } protected override void OnNavigatedTo(Microsoft.UI.Xaml.Navigation.NavigationEventArgs e) { DataContext = e.Parameter; } }
