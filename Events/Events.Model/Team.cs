namespace Events.Model
{
    using Statistics;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        private ICollection<User> members;
        private ICollection<Event> eventsParticipatedIn;
        private ICollection<MatchStatistic> homeMatchStatistics;
        private ICollection<MatchStatistic> guestMatchStatistics;

        public Team()
        {
            this.members = new HashSet<User>();
            this.eventsParticipatedIn = new HashSet<Event>();
            this.homeMatchStatistics = new HashSet<MatchStatistic>();
            this.guestMatchStatistics = new HashSet<MatchStatistic>();
        }

        [Key]
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }

        public virtual ICollection<Event> EventsParticipatedIn
        {
            get { return this.eventsParticipatedIn; }
            set { this.eventsParticipatedIn = value; }
        }

        public virtual ICollection<MatchStatistic> HomeMatchStatistics
        {
            get { return this.homeMatchStatistics; }
            set { this.homeMatchStatistics = value; }
        }

        public virtual ICollection<MatchStatistic> GuestMatchStatistics
        {
            get { return this.guestMatchStatistics; }
            set { this.guestMatchStatistics = value; }
        }
    }
}

