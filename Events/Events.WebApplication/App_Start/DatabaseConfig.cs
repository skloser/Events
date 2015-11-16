using Events.Data;
using Events.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Events.WebApplication.App_Start
{
    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EventsDbContext, Configuration>());
            EventsDbContext.Create().Database.Initialize(true);
        }
    }
}