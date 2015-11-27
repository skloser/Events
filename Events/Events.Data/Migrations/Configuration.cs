namespace Events.Data.Migrations
{
    using Model.Enumerations;
    using Model;
    using System;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<EventsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        //protected override void Seed(EventsDbContext context)
        //{
        //    context.Events.Add(new Event
        //    {
        //        Address = "Sofia",
        //        Capacity = 20,
        //        CreatedOn = DateTime.Now,
        //        Description= "some desc",
        //        HostId = "16c4fee8-8a74-4757-8bf4-da9880c07833",
        //        NumberOfTeams = 4,
        //        PredefinedSport = PredifinedSports.Basketball,
        //        StartTime = DateTime.Now.AddDays(2),
        //        TeamMembersCapacity = 2,
        //        Title = "Basketball",
        //        TypeOfEventFormat = TypeOfEventFormat.Team,
        //        TypeOfTeamAssemble = TypeOfTeamAssemble.HandPicked,
        //    });

        //    var user = context.Users.FirstOrDefault(u => u.Id == "16c4fee8-8a74-4757-8bf4-da9880c07833");
        //    var secondUser = context.Users.FirstOrDefault(u => u.Id == "938b757d-f9d1-45b4-8aeb-5e047df61c5d");


        //    context.Teams.Add(new Team
        //    {
        //        Name = "mitkoooo",
        //        Members = new List<User>
        //        {
        //            user,
        //            secondUser
        //        }
        //    });

        //    context.MatchStatistics.Add(new MatchStatistic
        //    {
        //        EventId = 1,
        //        GuestTeamId = 1,
        //        HomeTeamId = 2,
        //        GuestTeamResult = 4,
        //        HomeTeamResult = 3,
        //        TimeOfMatch = DateTime.Now
        //    });

        //    context.SaveChanges();

        //    base.Seed(context);
        //}
    }
}
