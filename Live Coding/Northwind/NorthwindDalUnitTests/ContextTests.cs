using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NorthwindDal.Model;

namespace NorthwindDalUnitTests
{
    [TestClass]
    public sealed class ContextTests
    {
        [TestMethod]
        public void CanGetAllCustomers()
        {
            NorthwindContext context = GetContext();

            var customers = context.Customers; //.ToList();

            Assert.AreEqual(92, customers.Count());

        }

        [TestMethod]
        public void CanGetCustomer()
        {
            NorthwindContext context = GetContext();

            //   Customer? customer = context.Customers.Find("ALFKI");
            Customer? customer = context.Customers.Where(cu => cu.CustomerId == "ALFKI").FirstOrDefault();

            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void CanGetCustomerOrders()
        {
            NorthwindContext context = GetContext();

            string id = "ALFKI";
            Customer? customer = context.Customers
                //.Where(cu => cu.Orders.Any(od => od.OrderDate.Value.Year > 1990))
                //.FirstOrDefault(cu => cu.CustomerId == "ALFKI");
                .Include(c => c.Orders)
                .ThenInclude(od => od.OrderDetails)
                .ThenInclude(pd => pd.Product)
                .FirstOrDefault(cu => cu.CustomerId == id);

            //var orders = context.Orders.ToList();

            Assert.AreEqual(6, customer.Orders.Count());
        }

        private NorthwindContext GetContext()
        {
            DbContextOptionsBuilder<NorthwindContext> builder = new DbContextOptionsBuilder<NorthwindContext>()
                                                                        .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                                                                        .LogTo(log => Console.WriteLine(log), Microsoft.Extensions.Logging.LogLevel.Information);

            return new NorthwindContext(builder.Options);
        }
    }
}
