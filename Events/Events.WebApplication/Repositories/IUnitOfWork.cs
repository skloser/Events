namespace Events.WebApplication.Repositories
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get; }
        
        ITeamRepository Teams { get; }

        IMatchStatisticRepository MatchStatistics { get; }

        int SaveChanges();
    }
}
