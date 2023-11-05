using BackEnd_ApiTech.Shared.Extensions;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_ApiTech.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Analytic> Analytics { get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Analytic>().ToTable("Analytics");
        builder.Entity<Analytic>().HasKey(p => p.Id);
        builder.Entity<Analytic>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Analytic>().Property(p => p.Week).IsRequired();
        builder.Entity<Analytic>().Property(p => p.Month).IsRequired();
        builder.Entity<Analytic>().Property(p => p.Year).IsRequired();
        builder.Entity<Analytic>().ToTable(t => t.HasCheckConstraint("CK_Analytics_Week", "Week >= 1 AND Week <= 4"));
        builder.Entity<Analytic>().ToTable(t => t.HasCheckConstraint("CK_Analytics_Month", "Month >= 1 AND Month <= 12"));
        
        
        builder.UseSnakeCaseNamingConvention();
    }
}