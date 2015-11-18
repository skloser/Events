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

        public virtual Team TeamRed { get; set; }

        [ForeignKey("TeamBlue")]
        public int TeamBlueId { get; set; }

        public virtual Team TeamBlue { get; set; }

        public DateTime TimeOfMatch { get; set; }

        public int RedTeamResult { get; set; }

        public int BlueTeamResult { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        [ForeignKey("TeamRedStatistic")]
        public int? TeamRedStatisticId { get; set; }

        public virtual TeamStatistic TeamRedStatistic { get; set; }

        [ForeignKey("TeamBlueStatistic")]
        public int? TeamBlueStatisticId { get; set; }

        public virtual TeamStatistic TeamBlueStatistic { get; set; }
    }
}
