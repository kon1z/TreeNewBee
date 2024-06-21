using Demo.Entities;
using Demo.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Demo.AuditProperty.EntityFrameworkCore.Sqlite.Tests
{
	public class AppDbContextTests
	{
		private readonly IServiceProvider _rootServiceProvider;

		public AppDbContextTests()
		{
			var services = new ServiceCollection();

			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlite(new SqliteConnection("Data Source=:memory:"));
			});
			services.AddTransient<ICurrentUser, FakeCurrentUser>();

			_rootServiceProvider = services.BuildServiceProvider();
		}

		[Fact]
		public async Task Test1()
		{
			await using ( var scope = _rootServiceProvider.CreateAsyncScope())
			{
				var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
				await dbContext.Database.OpenConnectionAsync();
				await dbContext.Database.EnsureCreatedAsync();
				await dbContext.SaveChangesAsync();
				var book = new Book("asd");
				
				await dbContext.AddAsync(book);
				await dbContext.SaveChangesAsync();

				book.Id.ShouldNotBe(Guid.Empty);
				book.CreatorUserId.ShouldBe(Guid.Parse("96CD671D-14AB-4186-9B58-BB787802A7A7"));
			};
		}
	}
}