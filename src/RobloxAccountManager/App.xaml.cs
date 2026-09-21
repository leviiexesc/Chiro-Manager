using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using RobloxAccountManager.Services;

namespace RobloxAccountManager;

public partial class App : Application
{
    public static IServiceProvider Services { get; private set; } = null!;
    private Window? _window;

    public App()
    {
        InitializeComponent();
        Services = ServiceRegistration.Create();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        _window = new MainWindow();
        _window.Activate();
    }
}
