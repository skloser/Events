using System.Collections.Generic;
using Events.Model;

namespace Events.Data.Repositories
{
    internal class UserViewModel
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public ICollection<User> Followers { get; set; }
        public ICollection<User> Following { get; set; }
        public string Id { get; set; }
        public string LastName { get; set; }
        public object MyEvents { get; set; }
        public string PhoneNumber { get; set; }
    }
}