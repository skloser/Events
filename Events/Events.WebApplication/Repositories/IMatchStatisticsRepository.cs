namespace Events.WebApplication.Repositories
{
    using Events.Model;
    using WebApplication.Models;
    using System.Collections.Generic;

    public interface IMatchStatisticRepository : IRepository<Match>
    {
        IEnumerable<MatchStatisticsViewModel> GetAllMatchStatistics();

        IEnumerable<MyMatchStatisticsViewModel> GetMyMatchStatistics(string id);
    }
}
