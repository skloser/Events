﻿namespace Events.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enumerations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Event
    {
        private ICollection<Team> teams;
        private ICollection<Match> match;

        public Event()
        {
            this.teams = new HashSet<Team>();
            this.match = new HashSet<Match>();
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        public int EventId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        public PredifinedSports? PredefinedSport { get; set; }

        public int TeamMembersCapacity { get; set; }

        public int NumberOfTeams { get; set; }

        public string Address { get; set; }

        public TypeOfMatchAssemble TypeOfMatchAssemble { get; set; }

        [ForeignKey("Host")]
        public int? HostId{ get; set; }

        public virtual Player Host { get; set; }

        [MaxLength(200)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }

        public virtual ICollection<Match> MatchStatistics
        {
            get { return this.match; }
            set { this.match = value; }
        }
    }
}
