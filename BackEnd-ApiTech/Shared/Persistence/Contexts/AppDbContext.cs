using BackEnd_ApiTech.Shared.Extensions;
using BackEnd_ApiTech.security.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_ApiTech.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Analytic> Analytics { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Technical> Technicals { get; set; }
    public DbSet<Client> Clients { get; set; }
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
        
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.FullName).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.Email).IsRequired();
        builder.Entity<User>().Property(p => p.Birthday).IsRequired();

        builder.Entity<Order>().ToTable("Orders");
        builder.Entity<Order>().HasKey(p => p.Id);
        builder.Entity<Order>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Order>().Property(p => p.TechnicalId).IsRequired();
        builder.Entity<Order>().Property(p => p.ClientName).IsRequired();
        builder.Entity<Order>().Property(p => p.PhoneName).IsRequired();
        builder.Entity<Order>().Property(p => p.Problem).IsRequired();
        builder.Entity<Order>().Property(p => p.ComponentsToUse).IsRequired();
        builder.Entity<Order>().Property(p => p.ValueProgress).HasDefaultValue(0);
        builder.Entity<Order>().Property(p => p.DeliveryDay).IsRequired().HasColumnType("date");
        builder.Entity<Order>().Property(p => p.Income).IsRequired();
        builder.Entity<Order>().Property(p => p.Finished).HasDefaultValue(0);
        builder.Entity<Order>().Property(p => p.Investment).IsRequired();
        builder.Entity<Order>().ToTable(t => t.HasCheckConstraint("CK_Order_ValueProgress", "value_progress >= 0 AND value_progress <= 100"));
        builder.Entity<Order>().ToTable(t => t.HasCheckConstraint("CK_Order_TechnicalId", "technical_id > 0"));

        builder.Entity<Request>().ToTable("Requests");
        builder.Entity<Request>().HasKey(p => p.Id);
        builder.Entity<Request>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Request>().Property(p => p.TechnicalId).IsRequired();
        builder.Entity<Request>().Property(p => p.Name).IsRequired();
        builder.Entity<Request>().Property(p => p.NumberPhone).IsRequired();
        builder.Entity<Request>().Property(p => p.Day).IsRequired();
        builder.Entity<Request>().Property(p => p.Hour).IsRequired();
        builder.Entity<Request>().Property(p => p.CellPhone).IsRequired();
        builder.Entity<Request>().Property(p => p.Problem).IsRequired();
        builder.Entity<Request>().Property(p => p.Specification).IsRequired();
        builder.Entity<Request>().ToTable(t => t.HasCheckConstraint("CK_Request_TechnicalId", "technical_id > 0"));
        
        builder.Entity<Technical>().ToTable("Technicals");
        builder.Entity<Technical>().HasKey(p => p.Id);
        builder.Entity<Technical>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Technical>().Property(p => p.FullName).IsRequired();
        builder.Entity<Technical>().Property(p => p.Password).IsRequired();
        builder.Entity<Technical>().Property(p => p.Birthday).IsRequired();
        builder.Entity<Technical>().Property(p => p.Email).IsRequired();
        builder.Entity<Technical>().Property(p => p.Experience);
        builder.Entity<Technical>().Property(p => p.Qualification);
        builder.Entity<Technical>().Property(p => p.Location);
        builder.Entity<Technical>().Property(p => p.AboutHim);
        builder.Entity<Technical>().Property(p => p.Image);
        builder.Entity<Technical>().Property(p => p.ConsultationPrice);
        builder.Entity<Technical>().Property(p => p.Number);

        builder.Entity<Client>().ToTable("Clients");
        builder.Entity<Client>().HasKey(p => p.Id);
        builder.Entity<Client>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Client>().Property(p => p.FullName).IsRequired();
        builder.Entity<Client>().Property(p => p.Email).IsRequired();
        builder.Entity<Client>().Property(p => p.Password).IsRequired();
        builder.Entity<Client>().Property(p => p.Birthday).IsRequired();
        builder.Entity<Client>().Property(p => p.Cellphone);
        builder.Entity<Client>().Property(p => p.Problem);
        builder.Entity<Client>().Property(p => p.Time);
        builder.Entity<Client>().Property(p => p.Number);
        
        builder.UseSnakeCaseNamingConvention();
    }
}