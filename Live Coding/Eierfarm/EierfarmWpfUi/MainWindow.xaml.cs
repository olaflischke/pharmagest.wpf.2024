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

        //private void btnGans_Click(object sender, RoutedEventArgs e)
        //{
        //    Gans gans = new Gans();

        //    cbxTier.Items.Add(gans as IEiLeger);
        //    cbxTier.SelectedItem = gans;
        //}

        //private void btnHuhn_Click(object sender, RoutedEventArgs e)
        //{
        //    Huhn huhn = new Huhn();

        //    cbxTier.Items.Add(huhn);
        //    cbxTier.SelectedItem = huhn;
        //}

        //private void btnSchnabeltier_Click(object sender, RoutedEventArgs e)
        //{
        //    Schnabeltier schnabeltier = new Schnabeltier();

        //    cbxTier.Items.Add(schnabeltier as IEiLeger);
        //    cbxTier.SelectedItem = schnabeltier;

        //}

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

        private void btnNeuesTier_Click(object sender, RoutedEventArgs e)
        {
            NeuesTierWindow dlgNeuesTier = new NeuesTierWindow() { Tiername = "Neues Tier" };
            if (dlgNeuesTier.ShowDialog() == true)
            {
                var tier = Activator.CreateInstance(dlgNeuesTier.Tiertyp);
                if (tier is Gefluegel gefluegel)
                {
                    gefluegel.Name = dlgNeuesTier.Tiername;
                }

                cbxTier.Items.Add(tier);
                cbxTier.SelectedItem = tier;
            }

        }
    }
}