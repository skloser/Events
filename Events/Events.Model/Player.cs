using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Model
{
    public class Player
    {
        private ICollection<Team> teams;
        private ICollection<Event> myEvents;

        public Player()
        {
            this.teams = new HashSet<Team>();
            this.myEvents = new HashSet<Event>();
        }

        [Key]
        public int PlayerId { get; set; }

        public string Name { get; set; }

        [ForeignKey("User")]
        [Index(IsUnique = true)]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }

        public virtual ICollection<Event> Events
        {
            get { return this.myEvents; }
            set { this.myEvents = value; }
        }

    }
}
