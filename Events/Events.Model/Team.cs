namespace Events.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        private ICollection<Player> players;
        private ICollection<Match> homeMatches;
        private ICollection<Match> awayMatches;
        private ICollection<Event> eventsJoined;

        public Team()
        {
            this.players = new HashSet<Player>();
            this.homeMatches = new HashSet<Match>();
            this.awayMatches = new HashSet<Match>();
            this.eventsJoined = new HashSet<Event>();
        }

        [Key]
        public int TeamId { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Player> Players
        {
            get { return this.players; }
            set { this.players = value; }
        }

        public virtual ICollection<Match> HomeMatches
        {
            get { return this.homeMatches; }
            set { this.homeMatches = value; }
        }

        public virtual ICollection<Match> AwayMatches
        {
            get { return this.awayMatches; }
            set { this.awayMatches = value; }
        }

        public virtual ICollection<Event> EventsJoined
        {
            get { return this.eventsJoined; }
            set { this.eventsJoined = value; }
        }
    }
}

