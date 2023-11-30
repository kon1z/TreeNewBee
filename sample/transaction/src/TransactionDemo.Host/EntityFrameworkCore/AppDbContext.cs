using Microsoft.EntityFrameworkCore;
using TransactionDemo.Host.Entities;

namespace TransactionDemo.Host.EntityFrameworkCore;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<User> Users { get; set; }
}