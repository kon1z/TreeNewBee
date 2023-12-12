using Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.EntityFrameworkCore
{
	public class AppDbContext : DbContext
	{
		public DbSet<User> Users { get; set; } = null!;
		public DbSet<Order> Orders { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>(b =>
			{
				b.ToTable("User");
				b.HasKey(x => x.Id);
				b.Property(x => x.Name).IsRequired().HasMaxLength(64);
			});

			modelBuilder.Entity<Order>(b =>
			{
				b.ToTable("Order");
				b.HasKey(x => x.Id);
				b.Property(x => x.Name).IsRequired().HasMaxLength(64);
			});
		}
	}
}
