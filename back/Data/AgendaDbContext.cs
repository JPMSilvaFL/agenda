using AgendaApi.Data.Mappings.Profiles;
using AgendaApi.Data.Mappings.Schedule;
using AgendaApi.Data.Mappings.Utilities;
using AgendaApi.Models.Log;
using AgendaApi.Models.Profiles;
using AgendaApi.Models.Schedule;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Data;

public class AgendaDbContext : DbContext{
	public AgendaDbContext(DbContextOptions<AgendaDbContext> options)
		: base(options)
	{ }
	public DbSet<Person> Persons { get; set; }
	public DbSet<Customer> Customers { get; set; }
	public DbSet<Role> Roles { get; set; }
	public DbSet<Employee> Employees { get; set; }
	public DbSet<Access> Accesses { get; set; }
	public DbSet<Secretary> Secretaries { get; set; }
	public DbSet<User> Users { get; set; }

	public DbSet<Available> Availables { get; set; }
	public DbSet<Purpose> Purposes { get; set; }
	public DbSet<Scheduled> Scheduleds { get; set; }
	public DbSet<LogActivity> Logs { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		modelBuilder.ApplyConfiguration(new PersonMap());
		modelBuilder.ApplyConfiguration(new CustomerMap());
		modelBuilder.ApplyConfiguration(new RoleMap());
		modelBuilder.ApplyConfiguration(new EmployeeMap());
		modelBuilder.ApplyConfiguration(new AccessMap());
		modelBuilder.ApplyConfiguration(new UserMap());
		modelBuilder.ApplyConfiguration(new AvailableMap());
		modelBuilder.ApplyConfiguration(new SecretaryMap());
		modelBuilder.ApplyConfiguration(new PurposeMap());
		modelBuilder.ApplyConfiguration(new ScheduledMap());
		modelBuilder.ApplyConfiguration(new LogActivityMap());

		modelBuilder.Ignore<LogSuccess>();

		modelBuilder.Entity<LogActivity>()
			.Property(e => e.Type)
			.HasConversion<string>();
		modelBuilder.Entity<LogActivity>()
			.Property(e => e.Action)
			.HasConversion<string>();
		modelBuilder.Entity<LogActivity>()
			.Property(e => e.Code)
			.HasConversion<string>();
	}
}