using Microsoft.AspNetCore.Mvc;
using Tournament.Core.Entities;
using Tournament.Core.Interfaces;

namespace Tournament.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamController : ControllerBase
{
    private readonly ITeamService _teamService;

    public TeamController(ITeamService teamService)
    {
        _teamService = teamService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTeams()
    {
        var teams = await _teamService.GetAllTeamsAsync();
        return Ok(teams);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeamById(Guid id)
    {
        var team = await _teamService.GetTeamByIdAsync(id);
        if (team != null)
        {
            return Ok(team);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeam([FromBody] TeamEntity team)
    {
        await _teamService.CreateTeamAsync(team);
        return CreatedAtAction(nameof(GetTeamById), new { id = team.Id }, team);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeam(Guid id, [FromBody] TeamEntity team)
    {
        if (id != team.Id)
        {
            return BadRequest("ID mismatch");
        }

        await _teamService.UpdateTeamAsync(team);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeam(Guid id)
    {
        await _teamService.DeleteTeamAsync(id);
        return NoContent();
    }

    [HttpPost("{teamId}/join-tournament/{tournamentId}")]
    public async Task<IActionResult> AssignTeamToTournament(Guid teamId, Guid tournamentId)
    {
        await _teamService.AssignTeamToTournamentAsync(teamId, tournamentId);
        return NoContent();
    }


}
