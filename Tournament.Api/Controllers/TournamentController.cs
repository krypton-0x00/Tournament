using Microsoft.AspNetCore.Mvc;
using Tournament.Core.Entities;
using Tournament.Core.Interfaces;

namespace Tournament.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TournamentController : ControllerBase
{
    private readonly ITournamentService _tournamentService;

    public TournamentController(ITournamentService service){
        _tournamentService = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetTournaments(){
        var tournaments = await _tournamentService.GetAllTournamentsAsync();
        return Ok(tournaments);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTournament(Guid id)
    {
        var tournament = await _tournamentService.GetTournamentByIdAsync(id);
        if (tournament == null)
        {
            return NotFound(new { message = $"Tournament with id {id} not found" });
        }
        return Ok(tournament);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTournament(TournamentEntity tournament)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (tournament.StartDate <= DateTime.UtcNow)
        {
            return BadRequest(new { message = "StartDate must be a future date." });
        }
        if (tournament.RegistrationOpenDate >= tournament.RegistrationCloseDate)
        {
            return BadRequest(new { message = "RegistrationOpenDate must be earlier than RegistrationCloseDate." });
        }
        await _tournamentService.CreateTournamentAsync(tournament);
        return CreatedAtAction(nameof(GetTournament), new { id = tournament.Id }, tournament);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTournament(Guid id)
    {
        var existingTournament = await _tournamentService.GetTournamentByIdAsync(id);
        if (existingTournament == null)
        {
            return NotFound(new { message = $"Tournament with id {id} not found" });
        }

        await _tournamentService.DeleteTournamentAsync(id);
        return NoContent();
    }


    [HttpPut("{id}")]
    
    public async Task<IActionResult> UpdateTournament(Guid id, TournamentEntity tournament)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != tournament.Id)
        {
            return BadRequest(new { message = "URL id does not match tournament id in the body." });
        }

        var existingTournament = await _tournamentService.GetTournamentByIdAsync(id);
        if (existingTournament == null)
        {
            return NotFound(new { message = $"Tournament with id {id} not found" });
        }

        if (tournament.StartDate <= DateTime.UtcNow)
        {
            return BadRequest(new { message = "StartDate must be a future date." });
        }

        await _tournamentService.UpdataTournamentAsync(tournament);
        return NoContent();
    }

 
}
