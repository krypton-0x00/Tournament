using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament.Core.Entities;
using Tournament.Data;

namespace Tournament.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TournamentController : ControllerBase
{
    private readonly TournamentDbContext _context;

    public TournamentController(TournamentDbContext context){
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetTournaments(){
        var tournaments = await _context.Tournaments.ToListAsync<TournamentEntity>();
        return  Ok(tournaments);
    }
    
}
