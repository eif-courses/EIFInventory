using EIFInventory.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EIFInventory.Data;

public class InventoryDatabaseContext(DbContextOptions<InventoryDatabaseContext> options)
    : IdentityDbContext<IdentityUser, IdentityRole, string>(options)
{
    
    public DbSet<Item> Items { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        ConvertUlidsForEntities(builder);
        SeedData.Initialize(builder);
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=EIFInventory.db");
    }
    private void ConvertUlidsForEntities(ModelBuilder modelBuilder)
    {
        var ulidConverter = new UlidValueConverter();

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            var properties = entity.ClrType.GetProperties()
                .Where(p => p.PropertyType == typeof(Ulid));
            foreach (var property in properties)
            {
                modelBuilder.Entity(entity.ClrType)
                    .Property(property.Name)
                    .HasConversion(ulidConverter);
            }
        }
    }
    
}