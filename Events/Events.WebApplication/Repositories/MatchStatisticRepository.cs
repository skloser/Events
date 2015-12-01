//namespace Events.WebApplication.Repositories
//{
//    using System.Linq;
//    using System.Collections.Generic;
//    using Events.Model;
//    using System;
//    using WebApplication.Models;
//    using Data;

//    public class MatchStatisticRepository : Repository<Match>, IMatchStatisticRepository
//    {
//        public MatchStatisticRepository(EventsDbContext eventsDbContext)
//            : base(eventsDbContext)
//        {
//        }

//        public EventsDbContext EventsDbContext
//        {
//            get { return Context as EventsDbContext; }
//        }

//        public IEnumerable<MatchStatisticsViewModel> GetAllMatchStatistics()
//        {
//            var allMatchStatistics = this.EventsDbContext
//                                        .MatchStatistics
//                                        .Select(m => new MatchStatisticsViewModel
//                                        {
//                                            HomeTeamName = m.HomeTeam.Name,
//                                            GuestTeamName = m.GuestTeam.Name,
//                                            HomeTeamResult = m.HomeTeamResult,
//                                            GuestTeamResult = m.GuestTeamResult,
//                                            TimeOfMatch = m.TimeOfMatch
//                                        })
//                                        .OrderByDescending(m => m.TimeOfMatch);

//            return allMatchStatistics;
//        }

//        public IEnumerable<MyMatchStatisticsViewModel> GetMyMatchStatistics(string id)
//        {
//            var ctx = this.EventsDbContext;

//            var result = (from ms in ctx.MatchStatistics
//                          join e in ctx.Events on ms.EventId equals e.EventId
//                          from t in e.Teams
//                          from u in t.Members
//                          where u.Id == id
//                          select new MyMatchStatisticsViewModel
//                          {
//                              MyResult = ms.HomeTeamId == t.TeamId ? ms.HomeTeamResult : ms.GuestTeamResult,
//                              OpponentResult = ms.HomeTeamId == t.TeamId ? ms.GuestTeamResult : ms.HomeTeamResult,
//                              MyTeamName = t.Name,
//                              Opponents = e.Teams.Where(p => !p.Members.Select(m => m.Id).Contains(id)).Select(p => p.Name),
//                              TimePlayed = e.StartTime

//                          }).ToList();

//            return result;
//        }
//    }
//}
