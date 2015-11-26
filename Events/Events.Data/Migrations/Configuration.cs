namespace Events.Data.Migrations
{
    using Model.Statistics;
    using Model;
    using Model.Enumerations;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<EventsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EventsDbContext context)
        {
            context.Events.Add(new Event
            {
                Address = "Sofia",
                CreatedOn = DateTime.Now,
                Description = "some desc",
                HostId = "2044a4f7-1b6e-451b-9bbf-00a6e46b4594",
                NumberOfTeams = 4,
                StartTime = DateTime.Now.AddDays(2),
                TeamMembersCapacity = 2,
                Title = "Basketball",
                TypeOfEventFormat = TypeOfEventFormat.Team,
                TypeOfTeamAssemble = TypeOfTeamAssemble.HandPicked
            });


            context.Teams.Add(new Team()
            {
                Name = "rocket",
                TeamId = 1,
                Members = new HashSet<User>() {
                    context.Users.Find("8b01950c-1c35-454d-a5c5-203417388921"),
                 context.Users.Find("96edb6f1-11f4-4f8f-99bb-79f071ffc80c")},
                EventsParticipatedIn = new HashSet<Event>() {
                    context.Events.Find(1)
                },
                HomeMatchStatistics = null,
                GuestMatchStatistics = null
            });

            context.Teams.Add(new Team()
            {
                Name = "dve",
                TeamId = 2,
                Members = new HashSet<User>() {
                    context.Users.Find("a81fff77-f957-4443-8efe-31320a3a0cb6"),
                 context.Users.Find("22849136-4f48-4ed9-be8c-da96b147632ec")},
                EventsParticipatedIn = new HashSet<Event>() {
                    context.Events.Find(1)
                },
                HomeMatchStatistics = null,
                GuestMatchStatistics = null
            });

            context.MatchStatistics.Add(new MatchStatistic()
            {
                HomeTeamId = 1,
                GuestTeamId = 2,
                HomeTeamResult = 2,
                GuestTeamResult = 3,
                EventId = 8,
                TimeOfMatch = DateTime.Now.AddDays(-2),

            });
            context.SaveChanges();
        }
    }
}
