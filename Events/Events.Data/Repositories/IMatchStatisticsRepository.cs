namespace Events.Data.Repositories
{
    using Events.Model.Statistics;
    using System.Collections.Generic;

    public interface IMatchStatisticRepository : IRepository<MatchStatistic>
    {
        IEnumerable<MatchStatistic> GetHighestScores(int count, int page);
    }
}
