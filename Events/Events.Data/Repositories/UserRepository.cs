namespace Events.Data.Repositories
{
    using System.Collections.Generic;
    using Events.Model;
    using System.Linq;

    public class UserRepository : Repository<User>, IUserRespository
    {
        public UserRepository(EventsDbContext eventsDbContext)
            : base(eventsDbContext)
        {
        }

        public EventsDbContext EventsDbContext
        {
            get { return Context as EventsDbContext; }
        }

        public IEnumerable<User> GetAllOrganizers()
        {
            return this.EventsDbContext.Users.Where(u => u.MyEvents != null).Select(u => u);
        }
    }
}
