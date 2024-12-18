
using Tournament.Core.Entities;
using Tournament.Core.Interfaces;

namespace Tournament.Core.Services;

public class TournamentService : ITournamentService
{
    private readonly ITournamentRepository _tournamentRepository;
    public TournamentService(ITournamentRepository repo){
        _tournamentRepository = repo;
    }
    public Task AddTeamToTournamentAsync(Guid tournamentId, TeamEntity player)
    {
        throw new NotImplementedException();
    }

    public async Task CreateTournamentAsync(TournamentEntity tournament)
    {
        await _tournamentRepository.AddAsync(tournament);
    }

    public async Task DeleteTournamentAsync(Guid id)
    {
        await _tournamentRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<TournamentEntity>> GetAllTournamentsAsync()
    {
        return await _tournamentRepository.GetAllAsync();
    }

    public async Task<TournamentEntity?> GetTournamentByIdAsync(Guid id)
    {
        return await _tournamentRepository.GetByIdAsync(id);
    }

    public Task RemoveTeamFromTournamentAsync(Guid teamId, Guid tournamentId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdataTournamentAsync(TournamentEntity tournament)
    {
        await _tournamentRepository.UpdataAsync(tournament);
    }

   
}
