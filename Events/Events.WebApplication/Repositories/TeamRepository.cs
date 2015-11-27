//namespace Events.WebApplication.Repositories
//{
//    using System;
//    using System.Collections.Generic;
//    using Events.Model;
//    using System.Linq;
//    using Data;

//    public class TeamRepository : Repository<Team>, ITeamRepository
//    {
//        public TeamRepository(EventsDbContext eventsDbContext)
//            :base(eventsDbContext)
//        {
//        }

//        public EventsDbContext EventsDbContext
//        {
//            get { return this.Context as EventsDbContext; }
//        }


//        //public IEnumerable<User> GetTeamMembers(int id)
//        //{
//        //    return this.EventsDbContext.Teams.Where(t => t.TeamId == id).SelectMany(t => t.Members);
//        //}
//    }
//}
