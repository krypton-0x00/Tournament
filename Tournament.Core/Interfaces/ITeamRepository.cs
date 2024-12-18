using Tournament.Core.Entities;

namespace Tournament.Core.Interfaces;

public interface ITeamRepository
{
    Task<IEnumerable<TeamEntity>> GetAllTeamsAsync();
    Task<TeamEntity?> GetTeamByIdAsync(Guid id);
    Task CreateTeamAsync(TeamEntity team);
    Task UpdateTeamAsync(TeamEntity team);
    Task DeleteTeamAsync(Guid id);
    Task AssignTeamToTournamentAsync(Guid teamId, Guid tournamentId);
}
