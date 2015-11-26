namespace Events.Data.Repositories
{
    using System.Collections.Generic;
    using Events.Model;
    using System.Linq;
    using System;
    using Model.ViewModels;
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

        public IEnumerable<User> GetAllOrganizers()
        {
            return this.EventsDbContext.Users.Where(u => u.MyEvents != null).Select(u => u);
        }

        public User GetUser(string id)
        {
            return this.EventsDbContext.Users.Find(id);
        }

        public User GetUserByEmail(string email)
        {
            return this.EventsDbContext.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public UserViewModel GetUserInfo(string email)
        {
            var userInfo = this.EventsDbContext
                 .Users
                 .Where(u => u.Email == email)
                 .Select(u => new
                  {
                      Id = u.Id,
                      Email = u.Email,
                      FirstName = u.FirstName,
                      LastName = u.LastName,
                      Address = u.Address,
                      PhoneNumber = u.PhoneNumber,
                      MyEvents = u.MyEvents,
                      Followers = u.Followers,
                      Following = u.Following
                  })
                 .ToList()
                 .Select(u => new UserViewModel
                 {
                     Id = u.Id,
                     Email = u.Email,
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     Address = u.Address,
                     PhoneNumber = u.PhoneNumber,
                     MyEvents = u.MyEvents,
                     Followers = u.Followers,
                     Following = u.Following
                 })
                  .FirstOrDefault();

            return userInfo;
        }

        
    }
}
