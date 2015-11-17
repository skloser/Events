namespace Events.Model.Statistics
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MatchStatistic
    {
        [Key]
        public int MatchStatisticId { get; set; }

        [ForeignKey("TeamRed")]
        public int TeamRedId { get; set; }

        public virtual UserTeam TeamRed { get; set; }

        [ForeignKey("TeamBlue")]
        public int TeamBlueId { get; set; }

        public virtual UserTeam TeamBlue { get; set; }

        public DateTime TimeOfEvent { get; set; }

        public int RedTeamResult { get; set; }

        public int BlueTeamResult { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        [ForeignKey("TeamStatistic")]
        public int? TeamStatisticId { get; set; }

        public virtual TeamStatistic TeamStatistic { get; set; }

        [ForeignKey("UserStatistic")]
        public int? UserStatisticId { get; set; }

        public virtual UserStatistic UserStatistic { get; set; }
    }
}
