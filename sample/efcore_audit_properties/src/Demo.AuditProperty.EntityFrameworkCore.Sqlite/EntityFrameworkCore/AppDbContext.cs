using Demo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Demo.EntityFrameworkCore
{
	public class AppDbContext : DbContext
	{
		private readonly ICurrentUser _currentUser;

		public AppDbContext(DbContextOptions options, ICurrentUser currentUser) : base(options)
		{
			_currentUser = currentUser;

			ChangeTracker.Tracked += ChangeTracker_Tracked;
			ChangeTracker.StateChanged += ChangeTracker_StateChanged;
		}

		private void ChangeTracker_StateChanged(object? sender, EntityStateChangedEventArgs e)
		{
			SetAuditProperties(e.Entry);
		}

		private void ChangeTracker_Tracked(object? sender, EntityTrackedEventArgs e)
		{
			SetAuditProperties(e.Entry);
		}

		private void SetAuditProperties(EntityEntry entry)
		{
			if (entry.Entity is IHasId entityWithId)
			{
				entityWithId.Id = Guid.NewGuid();
			}

			if (entry.State == EntityState.Added)
			{
				if (entry.Entity is IHasCreator entityWithCreator)
				{
					entityWithCreator.CreatorUserId = _currentUser.UserId;
				}
			}
		}

		public DbSet<Book> Books { get; set; }
	}
}
