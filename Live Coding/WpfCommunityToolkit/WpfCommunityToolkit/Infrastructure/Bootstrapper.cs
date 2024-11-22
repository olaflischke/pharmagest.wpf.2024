using ChinookDal.Model;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WpfCommunityToolkit.ExtensionMethods;
using WpfCommunityToolkit.ViewModels;
using WpfCommunityToolkit.Views;

namespace WpfCommunityToolkit.Infrastructure;

public class Bootstrapper
{
    public IServiceProvider Services { get; }
    private readonly string? connectionString;

    public Bootstrapper()
    {
        connectionString = Properties.Settings.Default.ChinookConnection;

        ServiceCollection services = new ServiceCollection();

        // Logger 
        services.AddLogging(builder =>
        {
            builder.AddFileLogger(Properties.Settings.Default.LogPath); // eigene ExtensionMethod
            builder.SetMinimumLevel(LogLevel.Information);
        });

        // Messaging
        services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);

        // Windows und ViewModels
        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<AddEditArtistWindow>();
        services.AddSingleton<AddEditArtistWindowViewModel>();

        // DBContext
        services.AddDbContextFactory<ChinookContext>(op => GetContext());

        this.Services = services.BuildServiceProvider();
    }

    public void Run()
    {
        MainWindow mainWindow = this.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    private ChinookContext GetContext(QueryTrackingBehavior trackingBehavior = QueryTrackingBehavior.TrackAll,
                                        Action<string> logAction = null)
    {
        DbContextOptionsBuilder<ChinookContext> builder = new DbContextOptionsBuilder<ChinookContext>()
                                                                .UseSqlServer(connectionString)
                                                                .UseQueryTrackingBehavior(trackingBehavior);

        if (logAction != null)
        {
            builder.LogTo(logAction, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        return new ChinookContext(builder.Options);
    }
}
