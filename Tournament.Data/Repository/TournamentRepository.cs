using Microsoft.EntityFrameworkCore;
using Tournament.Core.Entities;
using Tournament.Core.Interfaces;
namespace Tournament.Data.Repository;


public class TournamentRepository: ITournamentRepository
{
    private readonly TournamentDbContext _context;

    public TournamentRepository(TournamentDbContext context){
        _context = context;
    }

    public async Task AddAsync(TournamentEntity tournament)
    {
        await _context.Tournaments.AddAsync(tournament);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var tournament = await GetByIdAsync(id);
        if(tournament != null){
            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync();
        }
        
    }

    public async Task<IEnumerable<TournamentEntity>> GetAllAsync()
    {
        return await _context.Tournaments.ToListAsync<TournamentEntity>();
    }

    public async Task<TournamentEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Tournaments.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task UpdataAsync(TournamentEntity tournament)
    {
        _context.Tournaments.Update(tournament);
        await _context.SaveChangesAsync();
    }
}
