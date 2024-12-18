using Tournament.Core.Entities;

public interface IPlayerRepository
{
    Task<IEnumerable<PlayersEntity>> GetAllPlayersAsync();
    Task CreatePlayerAsync(PlayersEntity player);
    Task DeletePlayerAsync(Guid id);
    Task UpdatePlayerAsync(PlayersEntity player);
    Task<PlayersEntity?> GetPlayerById(Guid id);

    Task AssignPlayerToTeamAsync(Guid playerId, Guid teamId);
}
