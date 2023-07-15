using Infrastructure.EntityFramework.ReadModel.Files;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Contexts;

internal class ReadDbContext : DbContext
{
    public DbSet<ApplicationFileReadModel> ApplicationFile { get; set; }

    public ReadDbContext(
        DbContextOptions<ReadDbContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }
}
