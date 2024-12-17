using Tournament.Core.Enums;
namespace Tournament.Core.Entities{

    public class TournamentEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string BannerLink { get; set; } = "";
        public string OrganizationId { get; set; } = "";
        public DateOnly StartDate { get; set; }
        public DateTime RegistrationOpenDate { get; set; }
        public DateTime RegistrationCloseDate {get;set;}
        public int max_teams {get;set;}
        public int current_teams_count { get;set;}
        public TournamentStatus status { get; set; }
        public TournamentVisibility visibility {get;set;}
        public int TotalPrize {get;set;}
        public int RegistrationFee {get;set;} 
        
        public  ICollection<TeamEntity>? Teams {get;set;}

        public ICollection<PrizeEntity>? PrizePools {get;set;}
        

    }

}