using EmployeeBenefitsPackage.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBenefitsPackage.Repositories;

public class ApplicationDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Dependent> Dependents { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Dependents)
            .WithOne()
            .HasForeignKey(d => d.EmployeeId);

        base.OnModelCreating(modelBuilder);
    }
}
