namespace Events.Data
{
    using System.Data.Entity;
    using Events.Model;
    using Events.Model.Statistics;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class EventsDbContext : IdentityDbContext<User>
    {
        public EventsDbContext()
            : base("EventsDbConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Address> Addresses { get; set; }

        public virtual IDbSet<UserStatistic> UserStatistics { get; set; }

        public virtual IDbSet<Event> Events { get; set; }

        public virtual IDbSet<UserTeam> UserTeams { get; set; }

        public virtual IDbSet<TeamStatistic> TeamStatistics { get; set; }

        public virtual IDbSet<MatchStatistic> MatchStatistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(m => m.Followers)
                .WithMany(p => p.Following)
                .Map(w => w.ToTable("Subscriptions")
                .MapLeftKey("OrganizerId")
                .MapRightKey("SubscriberId"));
            base.OnModelCreating(modelBuilder);
        }

        public static EventsDbContext Create()
        {
            return new EventsDbContext();
        }
    }
}
