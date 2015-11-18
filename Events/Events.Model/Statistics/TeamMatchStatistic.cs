namespace Events.Model.Statistics
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TeamMatchStatistic
    {
        [Key]
        public int TeamMatchStatisticId { get; set; }

        [ForeignKey("MatchStatistic")]
        public int MatchStatisticId { get; set; }

        public MatchStatistic MatchStatistic { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
