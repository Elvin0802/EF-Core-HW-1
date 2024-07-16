using Microsoft.EntityFrameworkCore;
using Task4.Models;

namespace Task4.AppDbContext;

public class CarDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }

    public CarDbContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB;Integrated Security = SSPI; Database = EFCoreCars;");
}
