using System.ComponentModel.DataAnnotations.Schema;

namespace Tournament.Core.Entities;

public class TeamEntity
{
    public Guid Id { get; set; }

    public Guid? TournamentId {get;set;}
    [ForeignKey("TournamentId")]
    public TournamentEntity? Tournament {get;set;} = null!;
    
    public ICollection<PlayersEntity>? Players {get;set;}
      
}
