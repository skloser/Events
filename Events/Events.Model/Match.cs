namespace Events.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Match
    {
        [Key]
        public int MatchId { get; set; }

        public DateTime StartTime { get; set; }

        public int? HomeTeamResult { get; set; }

        public int? AwayTeamResult { get; set; }

        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }

        [ForeignKey("GuestTeam")]
        public int GuestTeamId { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }

        public virtual Team HomeTeam { get; set; }

        public virtual Team GuestTeam { get; set; }

        public virtual Event Event { get; set; }
    }
}
