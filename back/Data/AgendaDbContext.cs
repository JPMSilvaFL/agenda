using AgendaApi.Data.Mappings;
using AgendaApi.Models.Profiles;
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
	public DbSet<User> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		modelBuilder.ApplyConfiguration(new PersonMap());
		modelBuilder.ApplyConfiguration(new CustomerMap());
		modelBuilder.ApplyConfiguration(new RoleMap());
		modelBuilder.ApplyConfiguration(new EmployeeMap());
		modelBuilder.ApplyConfiguration(new AccessMap());
		modelBuilder.ApplyConfiguration(new UserMap());
	}
}