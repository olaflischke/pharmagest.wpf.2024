using ChinookDal.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using WpfCommunityToolkit.Infrastructure;

namespace WpfCommunityToolkit.ViewModels;

public class AddEditArtistWindowViewModel : ObservableObject
{
    private Artist _artist;
    private readonly IMessenger _messenger;

    public AddEditArtistWindowViewModel(Artist artist, IMessenger messenger)
    {
        _messenger = messenger;
        this.Artist = artist;

        this.SaveCommand = new RelayCommand(SaveArtist);
    }

    private void SaveArtist()
    {
        _messenger.Send(new ArtistChangedMessage());
        CloseAction();
    }

    public Action CloseAction { get; set; }

    public Artist Artist
    {
        get { return _artist; }
        set { SetProperty(ref _artist, value); }
    }

    public ICommand SaveCommand { get; set; }



}
