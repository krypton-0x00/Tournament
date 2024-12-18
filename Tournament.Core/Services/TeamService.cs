using Tournament.Core.Entities;
using Tournament.Core.Interfaces;

namespace Tournament.Service;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;

    public TeamService(ITeamRepository repository)
    {
        _teamRepository = repository;
    }

    public async Task<IEnumerable<TeamEntity>> GetAllTeamsAsync()
    {
        return await _teamRepository.GetAllTeamsAsync();
    }

    public async Task<TeamEntity?> GetTeamByIdAsync(Guid id)
    {
        return await _teamRepository.GetTeamByIdAsync(id);
    }

    public async Task CreateTeamAsync(TeamEntity team)
    {
        await _teamRepository.CreateTeamAsync(team);
    }

    public async Task UpdateTeamAsync(TeamEntity team)
    {
        await _teamRepository.UpdateTeamAsync(team);
    }

    public async Task DeleteTeamAsync(Guid id)
    {
        await _teamRepository.DeleteTeamAsync(id);
    }
    public async Task AssignTeamToTournamentAsync(Guid teamId, Guid tournamentId)
    {
        await _teamRepository.AssignTeamToTournamentAsync(teamId, tournamentId);
    }
}
