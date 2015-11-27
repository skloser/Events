namespace Events.WebApplication.Repositories
{
    using Events.Model;
    using System.Collections.Generic;

    public interface ITeamRepository : IRepository<Team>
    {
        IEnumerable<User> GetTeamMembers(int id);
    }
}
