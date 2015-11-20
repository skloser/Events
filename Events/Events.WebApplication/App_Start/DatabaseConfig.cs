namespace Events.WebApplication.App_Start
{
    using Events.Data;
    using Events.Data.Migrations;
    using System.Data.Entity;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EventsDbContext, Configuration>());
            EventsDbContext.Create().Database.Initialize(true);
        }
    }
}