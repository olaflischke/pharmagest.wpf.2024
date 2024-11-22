using ChinookDal.Model;
using ChinookExplorerUi.Presentation;
using ChinookExplorerUi.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChinookExplorerUi
{
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
}