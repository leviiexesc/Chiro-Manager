using Microsoft.Extensions.DependencyInjection;
using RobloxAccountManager.ViewModels;

namespace RobloxAccountManager.Services;

public static class ServiceRegistration
{
    public static IServiceProvider Create()
    {
        var services = new ServiceCollection();
        services.AddSingleton<SecureStorageService>();
        services.AddSingleton<LocalDataService>();
        services.AddSingleton<RobloxApiService>();
        services.AddSingleton<LaunchService>();
        services.AddTransient<MainViewModel>();
        return services.BuildServiceProvider();
    }
}
