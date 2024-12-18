using Microsoft.AspNetCore.Mvc;
using Tournament.Core.Entities;
using Tournament.Core.Services;

namespace Tournament.Api.Controllers
{
    [ApiController]  
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public PlayerController(PlayerService service)
        {
            _playerService = service;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _playerService.GetAllPlayersAsync();
            return Ok(players);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer(Guid id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id);
            if (player != null)
            {
                return Ok(player);
            }
            return NotFound();
        }

         
        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody] PlayersEntity player)
        {
            if (player == null)
            {
                return BadRequest();
            }

            await _playerService.CreatePlayerAsync(player);
            return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, player);
        }

         
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(Guid id, [FromBody] PlayersEntity player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            await _playerService.UpdatePlayerAsync(player);
            return NoContent();
        }

         
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(Guid id)
        {
            await _playerService.DeletePlayerAsync(id);
            return NoContent();
        }

         
        [HttpPost("{playerId}/join-team/{teamId}")]
        public async Task<IActionResult> AssignPlayerToTeam(Guid playerId, Guid teamId)
        {
            try
            {
                await _playerService.AssignPlayerToTeamAsync(playerId, teamId);
                return NoContent();
            }
            catch (Exception ex)
            {
                 
                return BadRequest($"Error assigning player to team: {ex.Message}");
            }
        }
    }
}
