namespace Events.Data
{
    using System.Data.Entity;
    using Events.Model;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class EventsDbContext : IdentityDbContext<User>
    {
        public EventsDbContext()
            : base("EventsDbConnection", throwIfV1Schema: false)
        {
        }
        
        public virtual IDbSet<Event> Events { get; set; }

        public virtual IDbSet<Team> Teams { get; set; }

        public virtual IDbSet<Match> Match { get; set; }

        public virtual IDbSet<Player> Players { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(m => m.Followers)
                .WithMany(p => p.Following)
                .Map(w => w.ToTable("Subscriptions")
                .MapLeftKey("OrganizerId")
                .MapRightKey("SubscriberId"));

            //modelBuilder.Entity<Match>()
            //     .HasRequired(m => m.HomeTeam)
            //     .WithMany(t => t.HomeMatchStatistics)
            //     .HasForeignKey(m => m.HomeTeamId)
            //     .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Match>()
            //       .HasRequired(m => m.GuestTeam)
            //       .WithMany(t => t.GuestMatchStatistics)
            //       .HasForeignKey(m => m.GuestTeamId)
            //       .WillCascadeOnDelete(false);


            modelBuilder.Entity<Match>()
                .HasRequired(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                .HasRequired(m => m.GuestTeam)
                .WithMany(t => t.AwayMatches)
                .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }

        public static EventsDbContext Create()
        {
            return new EventsDbContext();
        }
    }
}
