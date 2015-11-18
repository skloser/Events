namespace Events.Model.Statistics
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MatchStatistic
    {
        [Key]
        public int MatchStatisticId { get; set; }

        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }

        public virtual Team HomeTeam { get; set; }

        [ForeignKey("GuestTeam")]
        public int GuestTeamId { get; set; }

        public virtual Team GuestTeam { get; set; }

        public DateTime TimeOfMatch { get; set; }

        public int? HomeTeamResult { get; set; }

        public int? GuestTeamResult { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
