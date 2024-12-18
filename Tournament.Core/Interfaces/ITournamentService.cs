using Tournament.Core.Entities;
namespace Tournament.Core.Interfaces;

public interface ITournamentService
{
    Task<IEnumerable<TournamentEntity>> GetAllTournamentsAsync();
    Task<TournamentEntity?> GetTournamentByIdAsync(Guid id);
    Task CreateTournamentAsync(TournamentEntity tournament);
    Task AddTeamToTournamentAsync(Guid tournamentId, TeamEntity player);

    Task RemoveTeamFromTournamentAsync(Guid teamId,Guid tournamentId);
    Task DeleteTournamentAsync(Guid id);
    Task UpdataTournamentAsync(TournamentEntity tournament);
}
