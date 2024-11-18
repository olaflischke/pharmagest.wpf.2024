using System.ServiceModel.Syndication;
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
using System.Xml;

namespace RssReaderUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string url = "https://www.spiegel.de/schlagzeilen/index.rss";

            XmlReader xmlReader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

            // Basis aller Binding-Ausdrücke
            this.DataContext = feed;
        }
    }
}