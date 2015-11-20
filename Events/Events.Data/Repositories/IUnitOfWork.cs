namespace Events.Data.Repositories
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get; }

        IUserRespository Users { get; }

        ITeamRepository Teams { get; }

        IMatchStatisticRepository MatchStatistics { get; }

        int SaveChanges();
    }
}
