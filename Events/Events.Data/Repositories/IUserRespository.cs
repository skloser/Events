namespace Events.Data.Repositories
{
    using Events.Model;
    using System.Collections.Generic;

    public interface IUserRespository : IRepository<User>
    {
        IEnumerable<User> GetAllOrganizers();
    }
}
