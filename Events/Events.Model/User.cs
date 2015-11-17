namespace Events.Model
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Statistics;

    public class User : IdentityUser
    {
        private ICollection<User> followers;
        private ICollection<User> following;
        private ICollection<Event> events;

        public User()
        {
            this.followers = new HashSet<User>();
            this.following = new HashSet<User>();
            this.events = new HashSet<Event>();
        }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

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

        public virtual ICollection<Event> Events
        {
            get { return this.events; }
            set { this.events = value; }
        }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }

        [ForeignKey("UserStatistic")]
        public int UserStatisticsId { get; set; }

        public virtual UserStatistic UserStatistic { get; set; }

        [ForeignKey("UserTeam")]
        public int UserTeamId { get; set; }

        public virtual UserTeam UserTeam { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
