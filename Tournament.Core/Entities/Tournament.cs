using Tournament.Core.Enums;
namespace Tournament.Core.Entities{

    public class TournamentEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string BannerLink { get; set; } = "";
        public string OrganizationId { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime RegistrationOpenDate { get; set; }
        public DateTime RegistrationCloseDate {get;set;}
        public int max_teams {get;set;} = 25;
        public int current_teams_count { get;set;} = 0;
        public TournamentStatus status { get; set; } = TournamentStatus.Upcoming;
        public TournamentVisibility visibility {get;set;} = TournamentVisibility.Private;
        public int TotalPrize {get;set;}
        public int RegistrationFee {get;set;} = 0;
        
        public  ICollection<TeamEntity>? Teams {get;set;}

        public ICollection<PrizeEntity>? PrizePools {get;set;}
        

    }

}