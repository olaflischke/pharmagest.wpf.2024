using ChinookDal.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookExplorerMvvmCt.ViewModel;

public partial class MainWindowViewModel : ObservableObject
{
    //[ObservableProperty]
    //private Artist? selectedArtist;

    private ChinookContext context;

    public MainWindowViewModel()
    {
        context = new ChinookContext();

        genres = GetGenresWithArtists();
    }

    private List<Presentation.Genre> GetGenresWithArtists()
    {
        var genres = context.Genres.Select(g => new Presentation.Genre(g, context.Tracks.Where(t => t.GenreId == g.GenreId).Select(t => t.Album.Artist).Distinct().ToList()));
        return genres.ToList();

    }

    //[ObservableProperty]
    //[NotifyCanExecuteChangedFor(nameof(EditArtistCommand))]
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

    private List<Presentation.Genre> genres;
    public List<Presentation.Genre> Genres
    {
        get => genres;
        set => SetProperty(ref genres, value);
    }

    private Album? selectedAlbum;

    public Album? SelectedAlbum
    {
        get { return selectedAlbum; }
        set
        {

            if (selectedAlbum != value && value != null)
            {
                value.Tracks = context.Tracks.Where(tr => tr.AlbumId == value.AlbumId).ToList();
                SetProperty(ref selectedAlbum, value);

            }
        }
    }

    [RelayCommand(CanExecute = nameof(CanEditArtist))]
    private void EditArtist()
    {
        // TODO: Artist bearbeiten
    }

    private bool CanEditArtist()
    {
        return this.SelectedArtist != null;
    }

    [RelayCommand(CanExecute = nameof(CanAddArtist))]
    private void AddArtist()
    {
        // TODO: Artist hinzufügen
    }

    private bool CanAddArtist()
    {
        return true;
    }
}
