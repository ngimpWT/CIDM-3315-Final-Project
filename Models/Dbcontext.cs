using Microsoft.EntityFrameworkCore;

namespace CIDM_3315_Final_Project.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {

    }

    public DbSet<Item> Items {get; set;}
    public DbSet<Type> Types {get; set;}
    public DbSet<Rarity> Rarities {get; set;}
}