using Microsoft.EntityFrameworkCore;

namespace CIDM_3315_Final_Project.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {

    }

    public DbSet<Item> Items {get; set;}
    public DbSet<Type> Type {get; set;}
    public DbSet<Rarity> Rarity {get; set;}
}