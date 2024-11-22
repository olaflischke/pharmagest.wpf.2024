using ChinookDal.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfCommunityToolkit.Infrastructure;
using WpfCommunityToolkit.ViewModels;
using WpfCommunityToolkit.Views;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WpfCommunityToolkit;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private Bootstrapper bootstrapper;

    public new static App Current => (App)Application.Current;
    public IServiceProvider Services { get => bootstrapper.Services; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Bootstrapper für die Dependency-Injection
        bootstrapper = new Bootstrapper();
        bootstrapper.Run();

        // Messages registrieren
        WeakReferenceMessenger.Default.Register<ShowArtistEditDialogMessage>(this,
            (recipient, message) =>
            {
                // Dialog anzeigen
                AddEditArtistWindow addEditArtistWindow = new AddEditArtistWindow(message.Artist, bootstrapper.Services.GetRequiredService<IMessenger>());
                addEditArtistWindow.ShowDialog();
            });
    }



}
