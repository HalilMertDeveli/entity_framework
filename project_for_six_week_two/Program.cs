using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_for_six_week_two
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustmorEmail { get; set; }

    public ICollection<Order> Orders { get; set; }
}
public class Order
{
    [Key]
    public int OrderId { get; set; }
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public int ProductId { get; set; }


   
}

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double ProductPrice { get; set; }
    public Int16 UnitInStock { get; set; }
    public ICollection<Order> Orders { get; set; }
}
public class OrderDetail
{
    [Key]
    public int OrderDetailId { get; set; }

    [ForeignKey("Order")]
    public int OrderId { get; set; }
    public Order Order { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int QuantityPerUnit { get; set; }
    public DateTime OrderDate { get; set; }
}
public class CustomerContext : DbContext
{
    public DbSet<Customer> CustomerDb { get; set; }
    public DbSet<Order> OrderDb { get; set; }
    public DbSet<Product> ProductDb { get; set; }
    public DbSet<OrderDetail> OrderDetailDb { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer($"Data source=localhost;Database=CustomerDatabase;Trusted_Connection=True;TrustServerCertificate=True");

        base.OnConfiguring(optionsBuilder);
    }
}
