using Microsoft.EntityFrameworkCore;
using Tournament.Core.Entities;
using Tournament.Core.Interfaces;


namespace Tournament.Data.Repository;

public class TeamRepository : ITeamRepository
{
    private readonly TournamentDbContext _context;

    public TeamRepository(TournamentDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TeamEntity>> GetAllTeamsAsync()
    {
        return await _context.Teams
            .Include(t => t.Tournament) 
            .Include(t => t.Players)   
            .ToListAsync();
    }

    public async Task<TeamEntity?> GetTeamByIdAsync(Guid id)
    {
        return await _context.Teams
            .Include(t => t.Tournament)
            .Include(t => t.Players)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task CreateTeamAsync(TeamEntity team)
    {
        await _context.Teams.AddAsync(team);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTeamAsync(TeamEntity team)
    {
        _context.Teams.Update(team);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTeamAsync(Guid id)
    {
        var team = await _context.Teams.FindAsync(id);
        if (team != null)
        {
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
        }
    }

   public async Task AssignTeamToTournamentAsync(Guid teamId, Guid tournamentId)
    {
        var team = await _context.Teams.FindAsync(teamId);
        if (team != null)
        {
            team.TournamentId = tournamentId;  
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
        }
    }
}
