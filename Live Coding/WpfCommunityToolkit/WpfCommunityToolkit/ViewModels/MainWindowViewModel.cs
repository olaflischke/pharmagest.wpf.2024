using ChinookDal.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Windows.Input;
using WpfCommunityToolkit.Infrastructure;

namespace WpfCommunityToolkit.ViewModels;

public partial class MainWindowViewModel : ObservableRecipient //ObservableObject, IRecipient<ArtistChangedMessage>
{
    //[ObservableProperty]
    //[NotifyCanExecuteChangedFor(nameof(EditArtistCommand))]
    //[NotifyCanExecuteChangedFor(nameof(RemoveArtistCommand))]
    //private Artist? selectedArtist;

    private List<Presentation.Genre> _genres;
    private Album? _selectedAlbum;
    private readonly ChinookContext context;
    private readonly IMessenger messenger;
    private readonly ILogger<MainWindowViewModel> logger;

    public MainWindowViewModel(ChinookContext context, IMessenger messenger, ILogger<MainWindowViewModel> logger)
    {
        this.context = context;
        this.messenger = messenger;
        this.logger = logger;
        // Message registrieren für ArtistChanged
        messenger.Register<MainWindowViewModel, ArtistChangedMessage>(this, (r, m) => r.Receive(m));

        AddArtistCommand = new RelayCommand(AddArtist);
        //EditArtistCommand = new RelayCommand(EditArtist, CanEditArtist);
        //RemoveArtistCommand = new RelayCommand(RemoveArtist, CanRemoveArtist);

        this.Genres = GetArtistsWithGenres();

        logger.LogInformation("MeinWindowViewModel initialized.");
    }

    private List<Presentation.Genre> GetArtistsWithGenres()
    {
        var genres = context.Genres.Select(g => new Presentation.Genre(g, context.Tracks.Where(t => t.GenreId == g.GenreId).Select(t => t.Album.Artist).Distinct().ToList()));
        return genres.ToList();
    }


    [RelayCommand(CanExecute = nameof(CanRemoveArtist))]
    private void RemoveArtist()
    {

    }

    private bool CanRemoveArtist()
    {
        return this.SelectedArtist != null;
    }

    [RelayCommand(CanExecute = nameof(CanEditArtist))]
    private void EditArtist()
    {
        messenger.Send(new ShowArtistEditDialogMessage(this.SelectedArtist));
    }

    private bool CanEditArtist()
    {
        return this.SelectedArtist != null;
    }

    private void AddArtist()
    {

    }

    public void Receive(ArtistChangedMessage message)
    {
        context.Artists.Update(this.selectedArtist);
        context.SaveChanges();
    }

    private Artist? selectedArtist;

    public Artist? SelectedArtist
    {
        get { return selectedArtist; }
        set
        {
            if (selectedArtist != value)
            {
                value.Albums = context.Albums.Where(al => al.ArtistId == value.ArtistId).ToList();
                SetProperty(ref selectedArtist, value);
                EditArtistCommand.NotifyCanExecuteChanged();
                this.SelectedAlbum = this.SelectedArtist?.Albums.FirstOrDefault();
            }
        }
    }

    public Album? SelectedAlbum
    {
        get => _selectedAlbum;
        set
        {
            if (_selectedAlbum != value && value != null)
            {
                value.Tracks = context.Tracks.Where(tr => tr.AlbumId == value.AlbumId).ToList();
            }
            SetProperty(ref _selectedAlbum, value);
        }
    }

    public List<Presentation.Genre> Genres
    {
        get => _genres;
        set => SetProperty(ref _genres, value);
    }

    public ICommand AddArtistCommand { get; set; }

    // Ersetzt duch Attribut-Schreibweise
    //public ICommand EditArtistCommand { get; set; }
    //public ICommand RemoveArtistCommand { get; set; }


}
