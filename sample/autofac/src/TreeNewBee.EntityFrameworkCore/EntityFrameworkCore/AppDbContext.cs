﻿using Microsoft.EntityFrameworkCore;
using TreeNewBee.Domain.Entities;

namespace TreeNewBee.EntityFrameworkCore;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<User> Users { get; set; }
}