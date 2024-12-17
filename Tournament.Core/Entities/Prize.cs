using System.ComponentModel.DataAnnotations.Schema;

namespace Tournament.Core.Entities;

public class PrizeEntity
{
    public Guid Id { get; set; }
    public int PrizeAmount {get;set;}
    public int postion {get;set;}
     
    public Guid? TournamentId {get;set;} //FK
    [ForeignKey("TournamentId")]
    public TournamentEntity? Tournament {get;set;} //Navigation PRop
 
}
