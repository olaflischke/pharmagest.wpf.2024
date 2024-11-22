using ChinookDal.Model;
using ChinookExplorerUi.View;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChinookExplorerUi.ViewModel;

public class MainWindowViewModel : INotifyPropertyChanged
{
    ChinookContext context;

    public MainWindowViewModel()
    {
        context = GetContext();

        this.Genres = GetGenresWithArtists();

        this.NeuerArtistCommand = new RelayCommand(p => CanNeuerArtist(), a => NeuerArtist());
        this.ArtistBearbeitenCommand = new RelayCommand(p => CanArtistBearbeiten(), a => ArtistBearbeiten());

    }

    private bool CanArtistBearbeiten()
    {
        return selectedArtist != null;
    }

    private void ArtistBearbeiten()
    {
        AddEditArtist dlgArtistBearbeiten = new AddEditArtist(this.selectedArtist);
        if (dlgArtistBearbeiten.ShowDialog() == true)
        {
            context.SaveChanges();
        }
        else
        {
            context.Entry(selectedArtist).Reload();
        }
    }

    private bool CanNeuerArtist()
    {
        return true;
    }

    private void NeuerArtist()
    {
        throw new NotImplementedException();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string property = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }

    private List<Presentation.Genre?> GetGenresWithArtists()
    {
        var genres = context.Genres.Select(g => new Presentation.Genre(g,
                                                            context.Tracks
                                                            .Where(t => t.GenreId == g.GenreId).Select(t => t.Album.Artist).Distinct().ToList()));
        return genres.ToList();
    }

    public List<Presentation.Genre> Genres { get; set; }

    private Artist selectedArtist;
    public Artist SelectedArtist
    {
        get
        {
            return selectedArtist;
        }
        set
        {
            if (selectedArtist != value)
            {
                value.Albums = context.Albums.Where(al => al.ArtistId == value.ArtistId).ToList();
                selectedArtist = value;
                this.SelectedAlbum = selectedArtist.Albums.FirstOrDefault();
                OnPropertyChanged();
            }
        }
    }

    private Album? selectedAlbum;

    public Album? SelectedAlbum
    {
        get { return selectedAlbum; }
        set
        {
            if (selectedAlbum != value)
            {
                value.Tracks = context.Tracks.Where(al => al.AlbumId == value.AlbumId).ToList();
                selectedAlbum = value;
                OnPropertyChanged();
            }
        }
    }

    public RelayCommand NeuerArtistCommand { get; set; }
    public RelayCommand ArtistBearbeitenCommand { get; set; }


    private ChinookContext? GetContext()
    {
        DbContextOptionsBuilder<ChinookContext> builder = new DbContextOptionsBuilder<ChinookContext>().UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Chinook;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        return new ChinookContext(builder.Options);
    }

}
