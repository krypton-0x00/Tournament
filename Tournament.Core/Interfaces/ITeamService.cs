using Tournament.Core.Entities;

namespace Tournament.Core.Interfaces;

public interface ITeamService
{
    Task<IEnumerable<TeamEntity>> GetAllTeams();
    Task<TeamEntity?> GetTeamByIdAsync(Guid id);
    Task CreateTeamAsync(TeamEntity team);
    Task DeleteTeamAsync(Guid id);
    Task UpdataTeamAsync(TeamEntity team);
}
