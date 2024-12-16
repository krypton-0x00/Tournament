using Tournament.Core.Entities;

namespace Tournament.Core.Interfaces;

public interface ITournamentRepository
{
    Task<TournamentEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<TournamentEntity>> GetAllAsync();
    Task AddAsync(TournamentEntity tournament);
    Task UpdataAsync(TournamentEntity tournament);
    Task DeleteAsync(Guid id);

}
