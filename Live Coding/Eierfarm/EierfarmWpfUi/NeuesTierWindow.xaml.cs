using EierfarmBl;
using System.Windows;

namespace EierfarmWpfUi;

/// <summary>
/// Interaction logic for NeuesTierWindow.xaml
/// </summary>
public partial class NeuesTierWindow : Window
{
    public NeuesTierWindow()
    {
        InitializeComponent();

        this.Tiertyp = this.Tiertypen.First();

        this.DataContext = this;
    }

    public string? Tiername { get; set; }
    public Type Tiertyp { get; set; }

    public List<Type> Tiertypen { get; set; } = new List<Type>() { typeof(Huhn), typeof(Gans), typeof(Schnabeltier) };

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        this.DialogResult = true;
        this.Close();
    }
}
