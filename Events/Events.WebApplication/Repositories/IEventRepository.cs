namespace Events.WebApplication.Repositories
{
    using Events.Model;
    using System.Collections.Generic;

    public interface IEventRepository : IRepository<Event>
    {
        IEnumerable<Event> GetLatestEvents(int count = 20);
    }
}
