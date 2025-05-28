using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AgendaApi.Data;

public class AgendaDbContextFactory : IDesignTimeDbContextFactory<AgendaDbContext>
{
	public AgendaDbContext CreateDbContext(string[] args)
	{
		var config = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		var connectionString = config.GetConnectionString("DefaultConnection");

		var optionsBuilder = new DbContextOptionsBuilder<AgendaDbContext>();
		optionsBuilder.UseSqlServer(connectionString);

		return new AgendaDbContext(optionsBuilder.Options);
	}
}