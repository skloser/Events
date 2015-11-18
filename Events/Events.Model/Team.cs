namespace Events.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Statistics;

    public class Team
    {
        private ICollection<User> users;
        private ICollection<Event> events;

        public Team()
        {
            this.users = new HashSet<User>();
            this.events = new HashSet<Event>();
        }

        [Key]
        public int UserTeamId { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("TeamStatistic")]
        public int TeamStatisticId { get; set; }

        public virtual TeamStatistic TeamStatistic { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public virtual ICollection<Event> Events
        {
            get { return this.events; }
            set { this.events = value; }
        }
    }
}

