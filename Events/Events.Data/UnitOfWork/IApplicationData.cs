using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories;
using Events.Model;
using Events.Model.Statistics;

namespace Data.UnitOfWork
{
   public interface IApplicationData
    {
        IRepository<User> Users { get; }

        IRepository<Event> Events { get; }

        IRepository<Team> UserTeams { get; }

        IRepository<MatchStatistic> MatchStatistics { get; }

        void SaveChanges();
    }
}
