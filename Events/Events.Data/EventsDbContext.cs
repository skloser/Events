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


        public virtual IDbSet<Event> Events { get; set; }

        public virtual IDbSet<Team> Teams { get; set; }

        public virtual IDbSet<MatchStatistic> MatchStatistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(m => m.Followers)
                .WithMany(p => p.Following)
                .Map(w => w.ToTable("Subscriptions")
                .MapLeftKey("OrganizerId")
                .MapRightKey("SubscriberId"));

            modelBuilder.Entity<MatchStatistic>()
                 .HasRequired(m => m.HomeTeam)
                 .WithMany(t => t.HomeMatchStatistics)
                 .HasForeignKey(m => m.HomeTeamId)
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<MatchStatistic>()
                   .HasRequired(m => m.GuestTeam)
                   .WithMany(t => t.GuestMatchStatistics)
                   .HasForeignKey(m => m.GuestTeamId)
                   .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public static EventsDbContext Create()
        {
            return new EventsDbContext();
        }
    }
}
