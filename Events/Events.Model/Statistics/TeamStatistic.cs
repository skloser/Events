namespace Events.Model.Statistics
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TeamStatistic
    {
        private ICollection<Event> eventsParticipatedIn;
        private ICollection<TeamMatchStatistic> teamMatchStatistics;

        public TeamStatistic()
        {
            this.eventsParticipatedIn = new HashSet<Event>();
            this.teamMatchStatistics = new HashSet<TeamMatchStatistic>();
        }
        [Key]
        public int TeamStatisticId { get; set; }

        public int Points { get; set; }

        public int CountOfWins { get; set; }

        public virtual ICollection<Event> EventsParticipatedIn
        {
            get { return this.eventsParticipatedIn; }
            set { this.eventsParticipatedIn = value; }
        }

        public virtual ICollection<TeamMatchStatistic> TeamMatchStatistics
        {
            get { return this.teamMatchStatistics; }
            set { this.teamMatchStatistics = value; }
        }

    }
}