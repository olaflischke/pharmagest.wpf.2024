using EierfarmBl;
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

namespace EierfarmWpfUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGans_Click(object sender, RoutedEventArgs e)
        {
            Gans gans = new Gans();

            cbxTier.Items.Add(gans);
            cbxTier.SelectedItem = gans;
        }

        private void btnHuhn_Click(object sender, RoutedEventArgs e)
        {
            Huhn huhn = new Huhn();

            cbxTier.Items.Add(huhn);
            cbxTier.SelectedItem = huhn;
        }

        private void btnSchnabeltier_Click(object sender, RoutedEventArgs e)
        {
            Schnabeltier schnabeltier = new Schnabeltier();

            cbxTier.Items.Add(schnabeltier);
            cbxTier.SelectedItem = schnabeltier;

        }

        private void btnEiLegen_Click(object sender, RoutedEventArgs e)
        {
            if (cbxTier.SelectedItem is IEiLeger tier)
            {
                tier.EiLegen();
            }
        }

        private void btnFuettern_Click(object sender, RoutedEventArgs e)
        {
            if (cbxTier.SelectedItem is IEiLeger tier)
            {
                tier.Fressen();
            }
        }
    }
}