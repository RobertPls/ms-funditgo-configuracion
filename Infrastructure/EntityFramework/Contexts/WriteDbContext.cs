using Domain.Model;
using Infrastructure.EntityFramework.WriteConfig.Files;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Contexts;

internal class WriteDbContext : DbContext
{
    public virtual DbSet<ApplicationFile> ApplicationFiles { get; set; }

    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ApplicationFileConfig());
    }
}
