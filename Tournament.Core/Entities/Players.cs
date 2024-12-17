using System.ComponentModel.DataAnnotations.Schema;

namespace Tournament.Core.Entities;

public class PlayersEntity
{
    public Guid Id { get; set; }
    public string Name {get;set;} = "";
    public Guid UserId {get;set;}
    public string GameId {get;set;} = "";
    public DateOnly CreatedAt {get;set;}

    
    public Guid? TeamId {get;set;}
    [ForeignKey("TeamId")]
    public TeamEntity? Team  {get;set;}
}
