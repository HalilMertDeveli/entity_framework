using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
static void UpdateMethod(ManagerContext managerContext)
{
    var managerInstance = managerContext.ManagerDbSet.FirstOrDefault(managerInstance => managerInstance.ManagerName == "HMDManager" && managerInstance.ManagerID == 2);
    if (managerInstance != null)
    {
        managerInstance.ManagerName = "HMDSS";
        managerContext.Entry(managerInstance).State = EntityState.Modified;
        managerContext.SaveChanges();
    }
    Console.WriteLine("Element has changed ");
}
static void AddManager(ManagerContext managerContext, Manager manager)
{
    //await managerContext.ManagerDbSet.AddAsync(manager);
    //await managerContext.SaveChangesAsync();
    managerContext.ManagerDbSet.Add(manager);
    managerContext.SaveChanges();
}
//AddManager(managerContext, manager);
//UpdateMethod(managerContext);

Manager manager = new Manager { ManagerName = "hmdss with and normal wtihout savechanges" };

ManagerContext managerContext = new();

var customers = managerContext.ManagerDbSet.ToList();
foreach (var item in customers)
{
    Console.WriteLine(item.ManagerName);
    Console.WriteLine(item.ManagerID);
    Console.WriteLine("-------------");

}


namespace DbFirstFiveWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");
        }
    }
}
public class Manager
{
    public int ManagerID { get; set; }
    public string ManagerName { get; set; }
}
public class Costumer
{
    public int CostumerId { get; set; }
    public string CustomerName { get; set; }

}
public class Employee
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }

}
public class ManagerContext : DbContext
{
    public DbSet<Manager> ManagerDbSet { get; set; }
    public DbSet<Costumer> CostumerDbSet { get; set; }
    public DbSet<Employee> EnployeDbSet { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer($"Server=localhost;Database=ManagerDb;Trusted_Connection=True;TrustServerCertificate=true");
        base.OnConfiguring(optionsBuilder);
    }
}
public class DatabaseOperation
{
    public class Entities
    {
        public Employee EmployeeEntity { get; } = new Employee { EmployeeId = 1, EmployeeName = "HMDEmp" };
        public Costumer CostumerEntity { get; } = new Costumer { CostumerId = 3, CustomerName = "HMDcos" };
        public Manager ManagerEntity { get; } = new Manager { ManagerID = 1, ManagerName = "HMDMan" };
    }
    ManagerContext managerContext = new ManagerContext();
    Entities entities = new Entities();
    public void AddManager()
    {

        managerContext.ManagerDbSet.Add(entities.ManagerEntity);

    }
    public void AddCostumer()
    {
        managerContext.CostumerDbSet.Add(entities.CostumerEntity);
    }
    public void AddEmploye()
    {
        managerContext.EnployeDbSet.Add(entities.EmployeeEntity);
    }
}