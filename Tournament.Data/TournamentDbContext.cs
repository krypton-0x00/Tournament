using Microsoft.EntityFrameworkCore;
using Tournament.Core.Entities;

namespace Tournament.Data;

public class TournamentDbContext : DbContext
{
    public TournamentDbContext(DbContextOptions<TournamentDbContext> options):base(options){}

    public DbSet<TournamentEntity> Tournaments {get;set;}
    public DbSet<PrizeEntity> Prizes {get;set;}
    public DbSet<TeamEntity> Teams {get;set;}
    public DbSet<PlayersEntity> Players {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         
            modelBuilder.Entity<TournamentEntity>()
                .HasMany(t => t.Teams)
                .WithOne(t => t.Tournament)
                .HasForeignKey(t => t.TournamentId);

            modelBuilder.Entity<TeamEntity>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId);

            
            modelBuilder.Entity<TournamentEntity>()
                .HasMany(t => t.PrizePools)
                .WithOne()
                .HasForeignKey("TournamentId");

            base.OnModelCreating(modelBuilder);
    }
}
