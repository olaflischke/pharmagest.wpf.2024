using ChinookDal.Model;
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
using WpfCommunityToolkit;
using WpfCommunityToolkit.ViewModels;

namespace WpfCommunityToolkit.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // ViewModel aus dem DI-Container 
        this.DataContext = App.Current.Services.GetService(typeof(MainWindowViewModel));
    }

    // TreeView hat leider kein SelectedItem - Abhilfe Event oder Behavior
    private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        MainWindowViewModel viewModel = (MainWindowViewModel)this.DataContext;
        if (viewModel != null && e.NewValue is Artist selected)
        {
            viewModel.SelectedArtist = selected;
        }
    }
}