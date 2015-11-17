namespace Events.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enumerations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Event
    {
        private ICollection<User> users;

        public Event()
        {
            this.users = new HashSet<User>();
        }

        [Key]
        public int EventId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime StartTime { get; set; }

        public int Capacity { get; set; }

        public TypeOfEventFormat TypeOfEventFormat { get; set; }

        public TypeOfTeamAssemble TypeOfTeamAssemble { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [ForeignKey("UserTeam")]
        public int? UserTeamId { get; set; }

        public virtual UserTeam UserTeam { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
