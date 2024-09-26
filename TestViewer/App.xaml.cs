using Contracts;
using Domain.Services;
using IInfrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using TestViewer.Services;
using ViewModels.IServices;
using ViewModels.Services;

namespace TestViewer;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IHost? AppHost { get; private set; }

    public App()
    {
        AppHost = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MessageViewer>();
            services.AddTransient<IDateTimeManagerBuilder, DateTimeManagerBuilder>();
            services.AddTransient<IDateTimeMapper, DateTimeMapper>();
            services.AddTransient<IActionRouteService, ActionRouteServiceToUIThread>();
        }).Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        var dataContex = AppHost.Services.GetRequiredService<MessageViewer>();

        var startWindow = AppHost.Services.GetRequiredService<MainWindow>();
        startWindow.DataContext = dataContex;

        startWindow.Show();
        dataContex.Run();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
        base.OnExit(e);
    }
}
