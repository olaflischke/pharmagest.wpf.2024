using Microsoft.EntityFrameworkCore;
using NorthwindDal.Model;
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

namespace NorthwindExplorer;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    NorthwindContext context; // = GetContext();

    private NorthwindContext GetContext()
    {
        DbContextOptionsBuilder<NorthwindContext> builder = new DbContextOptionsBuilder<NorthwindContext>()
                                                                    .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                                                                    .LogTo(log => Console.WriteLine(log), Microsoft.Extensions.Logging.LogLevel.Information);

        return new NorthwindContext(builder.Options);
    }


    public MainWindow()
    {
        InitializeComponent();

        context = GetContext();

        var qLaender = context.Customers.Select(cu => cu.Country).Distinct();

        foreach (string? land in qLaender)
        {
            TreeViewItem treeViewItem = new TreeViewItem() { Header = land };
            treeViewItem.Items.Add(new TreeViewItem());
            treeViewItem.Expanded += this.TreeViewItem_Expanded;

            trvCustomers.Items.Add(treeViewItem);
        }
    }

    private void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
    {
        if (sender is TreeViewItem tviLand)
        {
            tviLand.Items.Clear();

            string land = tviLand.Header.ToString();

            var qKundenDesLandes = context.Customers
                .Include(cu => cu.Orders).ThenInclude(od => od.OrderDetails).ThenInclude(dt => dt.Product)
                .Where(cu => cu.Country == land);

            foreach (Customer customer in qKundenDesLandes)
            {
                TreeViewItem tviKunde = new TreeViewItem() { Header = customer.CompanyName, Tag = customer };
                //tviKunde.Selected += this.TviKunde_Selected;

                tviLand.Items.Add(tviKunde);
            }
        }
    }

    //private void TviKunde_Selected(object sender, RoutedEventArgs e)
    //{
    //    if (sender is TreeViewItem tviKunde)
    //    {
    //        if (tviKunde.Tag is Customer kunde)
    //        {
    //            var qOrdersDesKunden = context.Orders
    //                                            .Include(od => od.OrderDetails).ThenInclude(od => od.Product)
    //                                            .Where(od => od.CustomerId == kunde.CustomerId);

    //            cbxOrders.ItemsSource = qOrdersDesKunden.ToList();
    //        }
    //    }
    //}

    //private void cbxOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    if (cbxOrders.SelectedItem is Order order)
    //    {
    //        int orderId = order.Id;
    //        var qOrderInfo = context.OrderDetails.Where(od => od.OrderId == orderId)
    //                                            .Select(od => new { od.Quantity, od.Product.ProductName, od.UnitPrice, od.Discount });

    //        dgOrderInfo.ItemsSource = qOrderInfo.ToList();
    //    }
    //}

}
