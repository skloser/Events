namespace Events.Model
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        private ICollection<User> followers;
        private ICollection<User> following;
        private ICollection<Event> myEvents;
        private ICollection<Team> myTeams;

        public User()
        {
            this.followers = new HashSet<User>();
            this.following = new HashSet<User>();
            this.myEvents = new HashSet<Event>();
            this.myTeams = new HashSet<Team>();
        }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [MaxLength(120)]
        public string Address { get; set; }

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
        

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
