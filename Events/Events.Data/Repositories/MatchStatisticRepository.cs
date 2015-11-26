namespace Events.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Events.Model.Statistics;

    public class MatchStatisticRepository : Repository<MatchStatistic>, IMatchStatisticRepository
    {
        public MatchStatisticRepository(EventsDbContext eventsDbContext)
            :base(eventsDbContext)
        {
        }

        public EventsDbContext EventsDbContext
        {
            get { return Context as EventsDbContext; }
        }
        public MatchStatistic GetEventStats(int eventId)
        {
            return this.EventsDbContext.MatchStatistics
                .Where(e => e.EventId == eventId).FirstOrDefault();
        }

        public IEnumerable<MatchStatistic> GetAllStats()
        {
            return this.EventsDbContext.MatchStatistics
                .ToList();
        }

        public IEnumerable<MatchStatistic> GetHighestScores(int count, int page)
        {
            throw new NotImplementedException();
        }
    }
}
