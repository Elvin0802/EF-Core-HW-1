using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Task4.Models;

namespace Task4.AppDbContext;

public class CarDbContext : DbContext
{
	public DbSet<Car> Cars { get; set; }
	private string? connStr;

	public CarDbContext()
	{
		connStr = App.Configuration!.GetConnectionString("DefaultConnection");

		Database.EnsureCreated();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer(connStr);
}
