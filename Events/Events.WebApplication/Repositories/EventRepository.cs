namespace Events.WebApplication.Repositories
{
    using System.Collections.Generic;
    using Events.Model;
    using System.Data.Entity;
    using System.Linq;
    using Data;

    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(EventsDbContext eventsDbContext)
            :base(eventsDbContext)
        {
        }
        
        public EventsDbContext EventsDbContext
        {
            get { return Context as EventsDbContext; }
        }

        public IEnumerable<Event> GetLatestEvents(int count = 20)
        {
            return this.EventsDbContext.Events.OrderByDescending(e => e.CreatedOn).Take(count).ToList();
        }
    }
}
