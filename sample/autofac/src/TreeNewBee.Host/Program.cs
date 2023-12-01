using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TreeNewBee.Autofac.DependencyInjection;
using TreeNewBee.Domain.Repositories;
using TreeNewBee.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
	var dataAccess = AppDomain.CurrentDomain.GetAssemblies()
		.Where(x => x.FullName != null && x.FullName.StartsWith("TreeNewBee"))
		.ToArray();

	containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();

	containerBuilder.RegisterAssemblyTypes(dataAccess)
		.Where(x => x.Name.EndsWith("Repository"))
		.AsImplementedInterfaces();

	containerBuilder.RegisterAssemblyTypes(dataAccess)
		.Where(t => typeof(ITransientDependency).IsAssignableFrom(t))
		.AsImplementedInterfaces()
		.InstancePerDependency();
});

builder.Services.AddControllers().AddControllersAsServices();
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