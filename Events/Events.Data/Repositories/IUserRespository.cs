namespace Events.Data.Repositories
{
    using Events.Model;
    using Model.ViewModels;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Linq;

    public interface IUserRespository : IRepository<User>
    {
        IEnumerable<User> GetAllOrganizers();
        UserViewModel GetUserInfo(string email);

         User GetUser(string id);

        User GetUserByEmail(string email);
    }
}
