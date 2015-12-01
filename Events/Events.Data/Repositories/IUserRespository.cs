namespace Events.Data.Repositories
{
    using Events.Model;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Linq;

    public interface IUserRespository : IRepository<User>
    {
        User GetUserInfo(string userName);

         User GetUser(string id);

        User GetUserByEmail(string email);
    }
}
