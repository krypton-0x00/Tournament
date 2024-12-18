using Tournament.Core.Entities;
using Tournament.Data;
using Microsoft.EntityFrameworkCore;


public class PlayerRepository : IPlayerRepository
{
   private readonly TournamentDbContext _context;

    public PlayerRepository(TournamentDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PlayersEntity>> GetAllPlayersAsync()
    {
        return await _context.Players.Include(p => p.Team).ToListAsync();
    }

    public async Task<PlayersEntity?> GetPlayerById(Guid id)
    {
        return await _context.Players.Include(p => p.Team).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task CreatePlayerAsync(PlayersEntity player)
    {
        await _context.Players.AddAsync(player);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePlayerAsync(PlayersEntity player)
    {
        _context.Players.Update(player);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePlayerAsync(Guid id)
    {
        var player = await _context.Players.FindAsync(id);
        if (player != null)
        {
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }
    }
    

    public async Task AssignPlayerToTeamAsync(Guid playerId, Guid teamId)
    {
        var player = await _context.Players.FindAsync(playerId);
        if (player != null)
        {
            player.TeamId = teamId;   
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
        }
    }
}
