using Tournament.Core.Entities;
using Tournament.Core.Interfaces;

namespace Tournament.Core.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;

    public PlayerService(IPlayerRepository repository)
    {
        _playerRepository = repository;
    }

    public async Task<IEnumerable<PlayersEntity>> GetAllPlayersAsync()
    {
        return await _playerRepository.GetAllPlayersAsync();
    }

    public async Task<PlayersEntity?> GetPlayerByIdAsync(Guid id)
    {
        return await _playerRepository.GetPlayerById(id);
    }

    public async Task CreatePlayerAsync(PlayersEntity player)
    {
        await _playerRepository.CreatePlayerAsync(player);
    }

    public async Task UpdatePlayerAsync(PlayersEntity player)
    {
        await _playerRepository.UpdatePlayerAsync(player);
    }

    public async Task DeletePlayerAsync(Guid id)
    {
        await _playerRepository.DeletePlayerAsync(id);
    }

    public async Task AssignPlayerToTeamAsync(Guid playerId, Guid teamId)
    {
        await _playerRepository.AssignPlayerToTeamAsync(playerId, teamId);
    }
}
