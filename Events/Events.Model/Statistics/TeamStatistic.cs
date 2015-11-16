namespace Events.Model.Statistics
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TeamStatistic
    {
        private ICollection<MatchStatistic> matchStatistics;

        public TeamStatistic()
        {
            this.matchStatistics = new HashSet<MatchStatistic>();
        }
        [Key]
        public int TeamStatisticId { get; set; }

        public int CountOfEvents { get; set; }

        public int Points { get; set; }

        public int CountOfWins { get; set; }

        public virtual ICollection<MatchStatistic> MatchStatistics
        {
            get { return this.matchStatistics; }
            set { this.matchStatistics = value; }
        }
    }
}