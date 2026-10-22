using CPURepairSYS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPURepairSYS.Infrastructure.Persistence;

public sealed class RepairDbContext(DbContextOptions<RepairDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Part> Parts => Set<Part>();
    public DbSet<Repair> Repairs => Set<Repair>();
    public DbSet<RepairItem> RepairItems => Set<RepairItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepairDbContext).Assembly);
    }
}
