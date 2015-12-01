namespace Events.Data.Repositories
{
    using System.Collections.Generic;
    using Events.Model;
    using System.Linq;
    using System;
    using System.Diagnostics;

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

        

        public User GetUser(string id)
        {
            return this.EventsDbContext.Users.Find(id);
        }

        public User GetUserByEmail(string email)
        {
            return this.EventsDbContext.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public User GetUserInfo(string userName)
        {
            var userInfo = this.EventsDbContext
                 .Users
                 .Where(u => u.UserName == userName)
                 .FirstOrDefault();
       

            return userInfo;
        }

     
    }
}
