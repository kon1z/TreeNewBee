using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TreeNewBee.Autofac.DependencyInjection;
using TreeNewBee.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(containerBuilder =>
{
	var dataAccess = Assembly.GetExecutingAssembly();

	containerBuilder.RegisterAssemblyTypes(dataAccess)
		.Where(x => x.Name.EndsWith("Repository"))
		.AsImplementedInterfaces();

	containerBuilder.RegisterAssemblyTypes(dataAccess)
		.Where(x => x.IsAssignableFrom(typeof(IScopedDependency)) && x != typeof(IScopedDependency))
		.AsImplementedInterfaces()
		.InstancePerLifetimeScope()
		.PropertiesAutowired();

	containerBuilder.RegisterAssemblyTypes(dataAccess)
		.Where(x => x.IsAssignableFrom(typeof(ISingletonDependency)) && x != typeof(ISingletonDependency))
		.AsImplementedInterfaces()
		.SingleInstance()
		.PropertiesAutowired();

	containerBuilder.RegisterAssemblyTypes(dataAccess)
		.Where(x => x.IsAssignableFrom(typeof(ITransientDependency)) && x != typeof(ITransientDependency))
		.AsImplementedInterfaces()
		.PropertiesAutowired();
}));

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(configuration.GetConnectionString("Default"));
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

await app.RunAsync();