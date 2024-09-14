
using backend.payments.Domain.Model.Aggregates;

using backend.IAM;
using backend.Profiles;

using backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using backend.tracking;
using backend.Promos.Domain.Model.Aggregates;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace backend.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        // Profile Context
        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).HasColumnName("FirstName");
                n.Property(p => p.LastName).HasColumnName("LastName");
            });
        builder.Entity<Profile>().OwnsOne(p => p.Email,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.Address).HasColumnName("EmailAddress");
            });
        builder.Entity<Profile>().OwnsOne(p => p.Address,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.Street).HasColumnName("AddressStreet");
                n.Property(p => p.Number).HasColumnName("AddressNumber");
                n.Property(p => p.city).HasColumnName("AddressCity");
                n.Property(p => p.PostalCode).HasColumnName("AddressPostalCode");
                n.Property(p => p.country).HasColumnName("AddressCountry");
            });

        //IAM Context
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        
       // BusRoute Context
        builder.Entity<BusRoute>().HasKey(b => b.Id);
        builder.Entity<BusRoute>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
        
        // Payments Context
        builder.Entity<Payment>().HasKey(p => p.Id);
        builder.Entity<Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Payment>().Property(p => p.BusName).IsRequired();
        builder.Entity<Payment>().Property(p => p.OriginName).IsRequired();
        builder.Entity<Payment>().Property(p => p.DestinationName).IsRequired();
        builder.Entity<Payment>().Property(p => p.TicketPrice).IsRequired();
        
        
        // builder.Entity<BusRoute>().OwnsOne(b => b., n =>
        // {
        //     n.WithOwner().HasForeignKey("Id");
        //     n.Property(b => b.).HasColumnName("Distance");
        // })
      
        //Promo Context
        
        builder.Entity<Promo>().HasKey(t => t.Id);
        builder.Entity<Promo>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Promo>().Property(t => t.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Promo>().Property(t => t.Description).HasMaxLength(240);
        
        
        base.OnModelCreating(builder);
       

        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}