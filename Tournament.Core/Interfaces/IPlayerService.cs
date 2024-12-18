using Tournament.Core.Entities;

namespace Tournament.Core.Interfaces;

public interface IPlayerService
{
    Task<IEnumerable<PlayersEntity>> GetAllPlayersAsync();
    Task<PlayersEntity?> GetPlayerByIdAsync(Guid id);
    Task CreatePlayerAsync(PlayersEntity player);
    Task UpdatePlayerAsync(PlayersEntity player);
    Task DeletePlayerAsync(Guid id);
    Task AssignPlayerToTeamAsync(Guid playerId, Guid teamId);
}
