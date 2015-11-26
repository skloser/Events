﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Model.ViewModels
{
    public class UserViewModel
    {
        private ICollection<User> followers;
        private ICollection<User> following;
        private ICollection<Event> myEvents;
        private ICollection<Team> myTeams;

        public UserViewModel()
        {
            this.followers = new HashSet<User>();
            this.following = new HashSet<User>();
            this.myEvents = new HashSet<Event>();
            this.myTeams = new HashSet<Team>();
        }

        [Key]
        public string Id { get; set; }

        public string Email { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [MaxLength(120)]
        public string Address { get; set; }

        public string  PhoneNumber { get; set; }
        public virtual ICollection<User> Followers
        {
            get { return this.followers; }
            set { this.followers = value; }
        }

        public virtual ICollection<User> Following
        {
            get { return this.following; }
            set { this.following = value; }
        }

        public virtual ICollection<Event> MyEvents
        {
            get { return this.myEvents; }
            set { this.myEvents = value; }
        }

        public virtual ICollection<Team> MyTeams
        {
            get { return this.myTeams; }
            set { this.myTeams = value; }
        }

    }
}
