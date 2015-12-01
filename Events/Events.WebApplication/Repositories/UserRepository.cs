namespace Events.WebApplication.Repositories
{
    using System.Collections.Generic;
    using Events.Model;
    using System.Linq;
    using Data;

    public class UserRepository : Repository<User>
    {
        public UserRepository(EventsDbContext eventsDbContext)
            : base(eventsDbContext)
        {
        }

        public EventsDbContext EventsDbContext
        {
            get { return Context as EventsDbContext; }
        }
    }
}
