using Microsoft.EntityFrameworkCore;
using QuiSNCF.Models;

namespace QuiSNCF.Database;

public class GameDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public GameDbContext(DbContextOptions<GameDbContext> options): base(options){}

    public DbSet<Player> Players { get; set; }
    public DbSet<Station> Stations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>()
            .HasKey(x =>  x.PlayerId);

        modelBuilder.Entity<Station>()
            .HasKey(x => x.StationId);
        
        base.OnModelCreating(modelBuilder);
    }
    
}