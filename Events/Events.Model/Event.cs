﻿namespace Events.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enumerations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Statistics;

    public class Event
    {
        private ICollection<Team> teams;
        private ICollection<MatchStatistic> matchStatistics;

        public Event()
        {
            this.teams = new HashSet<Team>();
            this.matchStatistics = new HashSet<MatchStatistic>();
        }

        [Key]
        public int EventId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }

        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }

        public TypeOfEventFormat TypeOfEventFormat { get; set; }

        public TypeOfTeamAssemble TypeOfTeamAssemble { get; set; }

        [Required]
        [ForeignKey("Host")]
        public string HostId { get; set; }

        public virtual User Host { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Range(0,20)]
        public int TeamCapacity { get; set; }


        public virtual ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }

        public virtual ICollection<MatchStatistic> MatchStatistics
        {
            get { return this.matchStatistics; }
            set { this.matchStatistics = value; }
        }
    }
}
