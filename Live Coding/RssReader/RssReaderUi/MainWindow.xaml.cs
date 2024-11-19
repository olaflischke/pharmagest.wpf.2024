using System.ServiceModel.Syndication;
using System.Windows;
using System.Windows.Markup;
using System.Xml;

namespace RssReaderUi;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // Sprache/Zahlenformate des Fensters an die Sprache/Zahlenformate der Umgebung anpassen
        //this.Language = XmlLanguage.GetLanguage(Thread.CurrentThread.CurrentCulture.Name);

        string url = "https://www.spiegel.de/schlagzeilen/index.rss";

        XmlReader xmlReader = XmlReader.Create(url);
        SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

        // Basis aller Binding-Ausdrücke
        this.DataContext = feed;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        this.Language = XmlLanguage.GetLanguage("de-DE");
    }
}