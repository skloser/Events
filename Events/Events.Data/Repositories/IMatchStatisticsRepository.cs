namespace Events.Data.Repositories
{
    using Events.Model.Statistics;
    using System.Collections.Generic;
    using System.Linq;
    public interface IMatchStatisticRepository : IRepository<MatchStatistic>
    {
        IEnumerable<MatchStatistic> GetHighestScores(int count, int page);

        MatchStatistic GetEventStats(int eventId);
        IEnumerable<MatchStatistic> GetAllStats();
    }
}
