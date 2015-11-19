namespace Events.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using Events.Model.Statistics;

    public class MatchStatisticRepository : Repository<MatchStatistic>, IMatchStatisticRepository
    {
        public MatchStatisticRepository(EventsDbContext eventsDbContext)
            :base(eventsDbContext)
        {
        }

        public IEnumerable<MatchStatistic> GetHighestScores(int count, int page)
        {
            throw new NotImplementedException();
        }
    }
}
