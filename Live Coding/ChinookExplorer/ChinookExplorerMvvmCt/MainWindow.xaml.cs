using ChinookDal.Model;
using ChinookExplorerMvvmCt.ViewModel;
using System.Windows;

namespace ChinookExplorerMvvmCt;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();


        this.DataContext = new MainWindowViewModel();
    }

    private void trvArtists_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        ((MainWindowViewModel)this.DataContext).SelectedArtist = trvArtists.SelectedItem as Artist;
    }
}