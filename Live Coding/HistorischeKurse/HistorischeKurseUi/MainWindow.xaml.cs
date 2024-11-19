using HistorischeKurseDal;
using System;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
namespace HistorischeKurseUi;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        try
        {
            string url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml";

            //throw new Exception("Mist, hier klemmt was..");

            ReferenzkursArchiv archiv = new ReferenzkursArchiv(url);

            this.DataContext = archiv;

        }
        catch (HistorischeKurseDalException ex)
        {
            MessageBox.Show("Fehler beim Datenlesen\n\rBitte prüfe die URL", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Fehler beim Programmstart:\n\r{ex.Message}\n\r{ex.InnerException?.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        finally
        {
            // wird immer ausgeführt
        }
    }
}